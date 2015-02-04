using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal class MovementModule : Module
    {
        
        private Gps gps;
        private bool _gpsMoveEnabled;
        private bool regenBetweenGpsMoves = true;
        private bool forceGpsMove = false;
        private GpsPoint targetToGpsPoint;
        public bool disableMounting;
        public bool gpsMoveEnabled 
        {
            get 
            {
                return _gpsMoveEnabled;
            }
            set 
            {
                _gpsMoveEnabled = value;
                if (value)
                    host.mainForm.SetMovementModuleText("GpsMove");
                else
                    host.mainForm.SetMovementModuleText("");
            }
        }

        public override void Start(Host host)
        {
            base.Start(host);
            gps = new Gps(host);
            host.Log("Loading gps from " + Host.AssemblyDirectory + "\\path.db3");
            gps.LoadDataBase(Properties.Resources.path);
            gps.onGpsPreMove += gpsPreMove;
        }

#if DEBUG
        public override void Run(CancellationToken ct)
#elif !DEBUG
        public override void Run()
#endif
        {
#if !DEBUG
            try
            {
#endif
                while (!host.cancelRequested)
                {
#if DEBUG
                    base.Run(ct);
#elif !DEBUG
                    base.Run();
#endif
                    Thread.Sleep(10);
                }
                Console.WriteLine("Thread abort. Movement module.");
#if !DEBUG
            }
            catch (Exception error)
            {
                Console.WriteLine("Thread abort. Movement module.");
            }
#endif
        }

        public void EnableForceGpsMove()
        {
            gps.onGpsPreMove -= gpsPreMove;
            host.movementModule.regenBetweenGpsMoves = false;
            forceGpsMove = true;
            host.farmModule.farmState = FarmState.Disabled;
        }

        public void DisableForceGpsMove()
        {
            host.movementModule.regenBetweenGpsMoves = true;
            gps.onGpsPreMove += gpsPreMove;
            forceGpsMove = false;
        }

        public void SuspendGpsMove()
        {
            if (!gpsMoveEnabled)
                return;
            if (gps.gpsMoveSuspended)
                return;
            Console.WriteLine("SuspendGpsMove");
            gps.SuspendGpsMove();
        }

        public void ResumeGpsMove()
        {
            if (!gpsMoveEnabled)
                return;
            if (!gps.gpsMoveSuspended)
                return;
            Console.WriteLine("ResumeGpsMove");
            gps.ResumeGpsMove();
        }

        public bool gpsMoveSuspended
        {
            get
            {
                return gps.gpsMoveSuspended;
            }
        }

        private void CheckBadBosses()
        {
            foreach (var m in host.getCreatures())
            {
                if (m.creatureId >= 6443 && m.creatureId <= 6447 && host.dist(m) < 60 && host.isAlive(m))
                {
                    host.Log("ALARM. FOUND RAID BOSS " + m.name + "[" + m.creatureId + "]");
                    host.Log("CANT CONTINUE GPSMOVE WHILE RAID BOSS ALIVE. WAITING.");
                    while (host.isExists(m) && host.me.isAlive())
                        Thread.Sleep(1000);
                }
            }
        }

        private void gpsPreMove(GpsPoint point)
        {
            try
            {
                CheckBadBosses();
                while (host.farmModule.aggroMobsCount() > 0 && host.me.isAlive())
                    Thread.Sleep(300);
                while (regenBetweenGpsMoves && host.farmModule.aggroMobsCount() == 0 && host.me.isAlive() && (host.me.hpp < 65 || host.me.mpp < 60))
                    Thread.Sleep(100);
                host.farmModule.PickUpNearMe();

                int intersectCount = 0;
                var lc = host.getCreatures();
                for (int i = 0; i < lc.Count; i++)
                {
                    if (host.isInPeaceZone(lc[i]) || host.isInPeaceZone(host.me))
                        continue;
                    //мобы стоящие в местах типа башен
                    if (host.farmModule.mobsToIgnore.Contains(lc[i].creatureId))
                        continue;
                    var zRange = host.me.Z - lc[i].Z;
                    var zBetweenGround = lc[i].Z - host.getZFromHeightMap(lc[i].X, lc[i].Y);
                    //if (host.isAlive(lc[i]) && host.isEnemy(lc[i]) && lc[i].db.aggression && host.CircleIntersects(lc[i].X, lc[i].Y, 8, host.me.X, host.me.Y, point.x, point.y) && (zRange > -5 && zRange < 13) && (lc[i].Z - host.getZFromHeightMap(lc[i].X, lc[i].Y)) < 3)
                    if (host.isAlive(lc[i]) && host.isEnemy(lc[i]) && host.isAttackable(lc[i]) && lc[i].db.aggression && host.CircleIntersects(lc[i].X, lc[i].Y, 8, host.me.X, host.me.Y, point.x, point.y) && zBetweenGround < 4
                        && (lc[i].type != BotTypes.Player || (lc[i].type == BotTypes.Player && !host.farmModule.CheckGuardsNear(lc[i]))))
                    {
                        host.SetVar(lc[i], "Intersect", true);
                        intersectCount++;
                    }
                }
                double distTargetToGpsPoint = 0;
                if (targetToGpsPoint != null && point != null)
                    distTargetToGpsPoint = targetToGpsPoint.dist(point);
                var mount = host.getMount();
                if (mount != null)
                {
                    if (!disableMounting && host.characterSettings.rideOnMount && !host.farmModule.IsSwim() && distTargetToGpsPoint > 50 && intersectCount == 0 && !host.me.isGlobalCooldown && !host.me.isCasting && Math.Abs(host.me.Z - mount.Z) < 1 && host.dist(mount) < 3)
                    {
                        host.ComeTo(mount, 1.5);
                        host.SitToMount();
                    }
                    if (host.farmModule.IsSwim())
                        host.StandFromMount();
                }
            }
            catch { }
        }

        private int moveFailCount = 0;
        public bool GpsMove(string name)
        {
            try
            {
                Console.WriteLine("Gps move to " + name);
                if (!host.farmModule.readyToActions)
                    return false;
                var oldState = host.farmModule.farmState;
                if (!forceGpsMove)
                    host.farmModule.SetFarmAggros();
                gpsMoveEnabled = true;
                var p = gps.GetPoint(name);
                targetToGpsPoint = p;
                if (host.dist(p.x, p.y, p.z) < 5) //?
                    return true;
                bool result = gps.GpsMove(name);
                if (host.cancelRequested)
                    return false;
                gpsMoveEnabled = false;
                if (!forceGpsMove)
                    host.farmModule.farmState = oldState;
                if (!result)
                    moveFailCount++;
                else
                    moveFailCount = 0;
                if (moveFailCount > 3 && host.skillCooldown(20297) == 0)
                {
                    try
                    {
                        host.SwimUp(true);
                        host.farmModule.UseSkillAndWait(20297);
                        while (host.buffTime(4840) > 0)
                            Thread.Sleep(100);
                    }
                    finally
                    {
                        host.SwimUp(false);
                    }
                    Thread.Sleep(30000);
                }
                return result;
            }
            catch { }
            return false;
        }
    }
}
