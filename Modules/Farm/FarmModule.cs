using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal enum FarmState
    {
        Enabled = 0,
        AttackOnlyAgro = 1,
        Disabled = 2,
        Doodads = 3,
        MobsFromDoodads = 4,
        DoodadsFromMobs = 5
    }

    internal class FarmModule : Module
    {
        private uint[] specialItems;
        private uint[] specialSkills;
        private FarmState _farmState;
#if DEBUG
        Task mountTask;
#elif !DEBUG
        Thread mountThread;
#endif

        internal FarmState farmState
        {
            get
            {
                return _farmState;
            }
            set
            {
                _farmState = value;
                host.mainForm.SetFarmModuleText(_farmState.ToString());
            }
        }
        public List<uint> questsForRadiusRaidInvite = new List<uint>() { 857, 1156, 1098, 1099, 3309, 2903, 879, 899, 877, 3313, 258, 3720, 2292 };
        public List<uint> mobsToIgnore = new List<uint>() { 5213, 455, 2714, 7705, 7706, 3488, 1478, 8030, 8012, 8036, 8009, 8023, 8019, 8043, 1458, 9998, 790, 10120, 2635, 10655, 1696, 10199, 10198, 2926, 2921, 2924, 2938, 1676, 2331, 2332, 4994, 4993, 7895, 3417, 10132, 10536, 10332, 10333, 10334, 7518 };
        private List<uint> farmMobsIds = new List<uint>();
        private List<uint> farmDoodadsIds = new List<uint>();
        private Zone farmZone = new RoundZone(0, 0, 0);
        private Creature _bestMob = null;
        private DoodadObject _bestDoodad = null;
        private Creature bestMob
        {
            get
            {
                return _bestMob;
            }
            set
            {
                try
                {
                    if (_bestMob != value)
                    {
                        if (value != null && host.isExists(value))
                            host.mainForm.SetBestMobText(value.name + "[" + value.creatureId + "]" + "[" + host.dist(value).ToString("F2") + "]");
                        else
                            host.mainForm.SetBestMobText("null");
                    }
                }
                catch { }
                _bestMob = value;
            }
        }

        public bool IsSwim()
        {
            var m = host.getMount();
            return (host.me.isSwim || (m != null && m.isSwim));
        }

        public void CheckRadiusInvite()
        {
            if (host.characterSettings.autoRaidRadiusInvite && questsForRadiusRaidInvite.Contains(host.questModule.currentQuestId))
            {
                host.commonModule.invitePosX = host.me.X;
                host.commonModule.invitePosY = host.me.Y;
                host.commonModule.invitePosZ = host.me.Z;
                host.InviteAreaToRaid();
            }
        }

        private DoodadObject bestDoodad
        {
            get
            {
                return _bestDoodad;
            }
            set
            {
                try
                {
                    if (_bestDoodad != value)
                    {
                        if (value != null && host.isExists(value))
                            host.mainForm.SetBestDoodadText(value.name + "[" + value.phaseId + "]" + "[" + host.dist(value).ToString("F2") + "]");
                        else
                            host.mainForm.SetBestDoodadText("null");
                    }
                }
                catch { }
                _bestDoodad = value;
            }
        }
        private double doodadCastDist = 1;
        public bool readyToActions = true;

        public override void Start(Host host)
        {
            base.Start(host);
            farmState = FarmState.Disabled;
        }

        public override void Stop()
        {
#if !DEBUG
            try
            {
                if (mountThread != null)
                {
                    mountThread.Abort();
                    mountThread.Join(10000);
                    Console.WriteLine("Aborted mountThread!");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
#endif
            base.Stop();
        }

        public uint mobsCountInZone(uint mobId, Zone zone)
        {
            uint result = 0;
            foreach (var m in host.getCreatures())
            {
                if (m.isAlive() && zone.ObjInZone(m) && m.creatureId == mobId)
                    result++;
            }
            return result;
        }

        public uint enemyTargetersMobsCountOnMyMount()
        {
            /*uint result = 0;
            var myMount = host.getMount();
            if (myMount == null)
                return 0;
            var mobs = host.getCreatures();
            for (int i = 0; i < mobs.Count; i++)
            {
                if (mobs[i].type == BotTypes.Npc && mobs[i].target == myMount)
                    result++;
            }
            return result + host.getAggroMobsCount(myMount);*/
            return 0;
        }

        public uint aggroMobsCount()
        {
            return host.getAggroMobsCount() + host.getAggroMobsCount(host.getMount());
        }

        internal bool Climb(DoodadObject doodad)
        {
            try
            {
                readyToActions = false;
                if (host.isMounted())
                {
                    host.StandFromMount();
                    while (host.me.isMoving)
                        Thread.Sleep(100);
                    host.DespawnMount();
                    Thread.Sleep(1500);
                }
                bool result = host.Climb(doodad);
                Thread.Sleep(1000);
                return result;
            }
            finally
            {
                readyToActions = true;
            }
            
        }

        internal bool UseDoodadSkill(uint skillId, DoodadObject doodad, bool autoCome = false, double addDist = 0)
        {
            if (host.isMounted())
            {
                host.StandFromMount();
                while (host.me.isMoving)
                    Thread.Sleep(100);
                Thread.Sleep(550);
            }
            bool result = host.UseDoodadSkill(skillId, doodad, autoCome, addDist);
            if (!result)
                Console.WriteLine(host.GetLastError());
            return result;
        }

        internal bool UseSkillAndWait(uint skillId, bool selfTarget = false, bool suspendMovements = false, int mp = -1)
        {
            if (!selfTarget && host.me.target != null && !host.me.target.isAlive())
                return true;
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            bool result = false;
            try
            {
                if (suspendMovements)
                    host.SuspendMoveToBeforeUseSkill(true);
                if (host.isMounted())
                {
                    host.StandFromMount();
                    Thread.Sleep(250);
                }

                result = host.UseSkill(skillId, mp, true, selfTarget);
                if (!result)
                {
                    var le = host.GetLastError();
                    if (host.me.target != null && (le == LastError.NoLineOfSight || le == LastError.TargetTooFarAway))
                    {
                        if (host.dist(host.me.target) <= 5)
                            host.ComeTo(host.me.target, 2);
                        else if (host.dist(host.me.target) <= 10)
                            host.ComeTo(host.me.target, 3);
                        else if (host.dist(host.me.target) < 20)
                            host.ComeTo(host.me.target, 8);
                        else
                            host.ComeTo(host.me.target, 8);
                    }
                }
                while (host.me.isCasting || host.me.isGlobalCooldown)
                    Thread.Sleep(50);
            }
            finally
            {
                if (suspendMovements)
                    host.SuspendMoveToBeforeUseSkill(false);
            }
            return result;
        }

        internal void UseItemAndWait(uint itemId, bool suspendMovements = false, int mpCost = -1)
        {
            while (host.me.isCasting || host.me.isGlobalCooldown)
                Thread.Sleep(50);
            try
            {
                if (suspendMovements)
                    host.SuspendMoveToBeforeUseSkill(true);
                if (host.isMounted())
                {
                    host.StandFromMount();
                    while (host.me.isMoving)
                        Thread.Sleep(100);
                    Thread.Sleep(250);
                }

                if (!host.UseItem(itemId, mpCost, true))
                {
                    var le = host.GetLastError();
                    if (host.me.target != null && (le == LastError.NoLineOfSight || le == LastError.TargetTooFarAway))
                    {
                        Console.WriteLine(le);
                        if (host.dist(host.me.target) <= 5)
                            host.ComeTo(host.me.target, 2);
                        else if (host.dist(host.me.target) <= 10)
                            host.ComeTo(host.me.target, 3);
                        else if (host.dist(host.me.target) < 20)
                            host.ComeTo(host.me.target, 8);
                        else
                            host.ComeTo(host.me.target, 8);
                    }
                }
                while (host.me.isCasting || host.me.isGlobalCooldown)
                    Thread.Sleep(50);
            }
            finally
            {
                if (suspendMovements)
                    host.SuspendMoveToBeforeUseSkill(false);
            }
        }

        private void CheckUnderWaterBreath()
        {
            if (host.me.isUnderWaterBreath && host.me.underWaterBreathTime < 20000)
            {
                try
                {
                    host.SwimUp(true);
                    while (host.farmModule.readyToActions && host.me.isAlive() && host.me.isUnderWaterBreath)
                        Thread.Sleep(10);
                }
                finally
                {
                    host.SwimUp(false);
                }
            }
        }

        private void UseRegenItems()
        {
            if (!host.me.isAlive())
                return;
            if (host.me.inFight)
            {
                //Банки, моментально юзаются
                if (host.me.hpp < 60)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 18791 || i.id == 34006 || i.id == 34007));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, false, 0);
                }
                if (host.me.mpp < 70)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 18792 || i.id == 34008 || i.id == 34009));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, false, 0);
                }
            }
            else
            {
                //Печенье и т.п., юзается за 1-2 сек
                if (host.me.hpp < 60)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 34003 || i.id == 34001 || i.id == 34000));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, true, 0);
                }
                if (host.me.mpp < 70)
                {
                    var itemsToUse = host.me.getItems().FindAll(i => i.place == ItemPlace.Bag && (i.id == 34002 || i.id == 34005 || i.id == 34004));
                    foreach (var i in itemsToUse)
                        UseItemAndWait(i.id, true, 0);
                }
            }
        }

        private void ControlMount()
        {
            try
            {
                while (!host.cancelRequested)
                {
                    Thread.Sleep(250);
                    try
                    {
                        if (!host.characterSettings.autoUseMount)
                            continue;
                        if (!host.isAlive() || !readyToActions)
                            continue;
                        var mount = host.getMount();
                        if (mount != null)
                        {
                            //if (mount.hpp < 80 && mount.hp != 1 && (aggroMobsCount() > 0 || enemyTargetersMobsCountOnMyMount() > 0))
                            if (mount.hpp < 80 && mount.hp != 1 && mount.inFight)
                                host.DespawnMount();
                            else if (mount.hp == 1)
                            {
                                if ((host.itemCount(18649) > 0 || host.itemCount(27387) > 0))
                                {
                                    try
                                    {
                                        host.SuspendMoveToBeforeUseSkill(true);
                                        host.movementModule.SuspendGpsMove();
                                        host.SetTarget(host.getMount());
                                        host.ComeTo(host.getMount(), 2);
                                        Thread.Sleep(750);
                                        UseItemAndWait(18649);
                                        UseItemAndWait(27387);
                                    }
                                    finally
                                    {
                                        host.movementModule.ResumeGpsMove();
                                        host.SuspendMoveToBeforeUseSkill(false);
                                    }
                                }
                                else
                                    host.DespawnMount();
                            }
                        }
                        else
                        {
                            var mountItem = host.getInvItem(4941);
                            if (mountItem == null) mountItem = host.getInvItem(19517);
                            if (mountItem == null) mountItem = host.getInvItem(8161);
                            
                            if (!host.me.isClimb && aggroMobsCount() == 0 && host.mobsInRange(5, false) == 0 && mountItem != null && mountItem.mountAlive)
                            {
                                mountItem.UseItem();
                                Thread.Sleep(500);
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Thread stopped");
            }
        }

        

        private bool isZDistGoodForMeleeAttack()
        {
            if (host.me.target == null)
                return false;
            return (Math.Abs(host.me.Z - host.me.target.Z) < 2);
        }

        private void AttackWithSkill(uint skillId)
        {
            var d = host.getNearestDoodad(9859);
            if (d != null && host.dist(d) < 2)
            {
                try
                {
                    host.MoveForward(true);
                    host.MoveRight(true);
                    while (host.isExists(d) && host.dist(d) < 2)
                        Thread.Sleep(25);
                }
                finally
                {
                    host.MoveForward(false);
                    host.MoveRight(false);
                }
            }

            UseSpecialSkills();
            if (!UseSkillAndWait(skillId))
            {
                Console.WriteLine("[" + skillId + "]" + host.GetLastError());
            }
        }

       

        private void UseSecondarySkills()
        {
            #region SelfBuffsAndHeal
            if (host.isAbilityTaken(Ability.Vitalism) && host.buffTime(3455) == 0 && host.buffTime(220) == 0 && host.skillCooldown(10547) == 0 && host.hpp() < 80)
                UseSkillAndWait(10547, true, true); //Resurgence
            if (host.isAbilityTaken(Ability.Auramancy) && host.getAggroMobsCount() > 0)
                AttackWithSkill(11869); //Conversion Shield
            if (host.isAbilityTaken(Ability.Archery) && host.buffTime(2170) == 0 && host.buffTime(2172) == 0 && host.buffTime(2173) == 0 && host.buffTime(2175) == 0 && host.skillCooldown(15073) == 0 && host.dist(bestMob) < 20)
                AttackWithSkill(15073); //Deadeye
            #endregion
            #region RangeAndMage
            if (host.isAbilityTaken(Ability.Vitalism) && host.isExists(bestMob) && host.isAlive(bestMob) && host.isAttackable(bestMob))
                AttackWithSkill(11379); //Mirror Light
            if (host.isAbilityTaken(Ability.Shadowplay) && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(12139); //Stalker's Mark
            if (host.isAbilityTaken(Ability.Songcraft) && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(11934); //Startling Strain
            if (host.isAbilityTaken(Ability.Witchcraft) && host.characterSettings.weaponPriority == 0 && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(10159);//Enervate
            if (host.isAbilityTaken(Ability.Witchcraft) && host.characterSettings.weaponPriority == 0 && host.isExists(bestMob) && host.isAlive(bestMob) && host.buffTime(bestMob, 101) > 1500)
                AttackWithSkill(14376);//Earthen Grip
            if (host.isAbilityTaken(Ability.Archery) && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(16210);//Charged Bolt
            if (host.isAbilityTaken(Ability.Archery) && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(13564);//Piercing Shot
            if (host.isAbilityTaken(Ability.Occultism) && host.characterSettings.weaponPriority == 0 && host.isExists(bestMob) && host.isAlive(bestMob) && host.dist(bestMob) < 5 && bestMob.creatureId != 8026 && bestMob.creatureId != 8023)
                AttackWithSkill(12759);//Mana Force
            if (host.isAbilityTaken(Ability.Sorcery) && host.characterSettings.weaponPriority == 0 && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(10667);//Freezing Arrow
            if (host.isAbilityTaken(Ability.Songcraft) && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(11973); //Critical Discord
            #endregion
            #region Melee
            if (host.isAbilityTaken(Ability.Defense) && host.isExists(bestMob) && host.isAlive(bestMob) && isZDistGoodForMeleeAttack())
                AttackWithSkill(10399);//Shield Slam
            if (host.isAbilityTaken(Ability.Defense) && host.isExists(bestMob) && host.isAlive(bestMob) && isZDistGoodForMeleeAttack())
                AttackWithSkill(10501);//Bull Rush
            if (host.isAbilityTaken(Ability.Defense) && isZDistGoodForMeleeAttack() && host.isExists(bestMob) && host.isAlive(bestMob))
            {
                var b = host.getBuff(864);
                if (b != null && b.charge > 2000)
                    AttackWithSkill(12048); //Boastful Roar
            }
            if (host.isAbilityTaken(Ability.Battlerage) && host.characterSettings.weaponPriority == 2 || (host.characterSettings.weaponPriority == 1 && host.me.level < 10) && isZDistGoodForMeleeAttack() && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(11918);//Charge
            if (host.isAbilityTaken(Ability.Shadowplay) && host.characterSettings.weaponPriority == 2 || (host.characterSettings.weaponPriority == 1 && host.me.level < 10) && isZDistGoodForMeleeAttack() && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(10648);//Overwhelm
            if (host.isAbilityTaken(Ability.Shadowplay) && host.characterSettings.weaponPriority == 2 && isZDistGoodForMeleeAttack() && host.isExists(bestMob) && host.isAlive(bestMob))
                AttackWithSkill(12029);//Wallop
            #endregion
            #region AOE
            if (host.isAbilityTaken(Ability.Auramancy) && host.isExists(bestMob) && host.isAlive(bestMob) && host.me.dist(bestMob) < 6 && !host.isSpellImmune(bestMob) && (aggroMobsCount() == host.mobsInRange(7, false)) && isZDistGoodForMeleeAttack())
            {
                if (host.me.level < 30 && host.enemysInRange(15, false) == 0)
                    AttackWithSkill(16486); //Thwart
                else if (host.me.level >= 30)
                    AttackWithSkill(16486); //Thwart
            }
            if (host.isAbilityTaken(Ability.Occultism) && host.characterSettings.weaponPriority == 0 && host.isExists(bestMob) && host.isAlive(bestMob) && host.me.dist(bestMob) < 4 && !host.isSpellImmune(bestMob) && (aggroMobsCount() == host.mobsInRange(7, false)) && isZDistGoodForMeleeAttack())
            {
                if (host.me.level < 30 && host.enemysInRange(15, false) == 0)
                    AttackWithSkill(10135); //Hell Spear
                else if (host.me.level >= 30)
                    AttackWithSkill(10135); //Hell Spear
            }
            if (host.isAbilityTaken(Ability.Battlerage) && host.characterSettings.weaponPriority == 2 && host.isExists(bestMob) && host.isAlive(bestMob) && host.me.dist(bestMob) < 3 && !host.isMeleeImmune(bestMob) && (aggroMobsCount() == host.mobsInRange(7, false)) && isZDistGoodForMeleeAttack())
            {
                if (host.me.level < 30 && host.enemysInRange(15, false) == 0)
                    AttackWithSkill(13282); //Whirlwind Slash
                else if (host.me.level >= 30)
                    AttackWithSkill(13282); //Whirlwind Slash
            }
            if (host.isAbilityTaken(Ability.Battlerage) && host.characterSettings.weaponPriority == 2 && host.isExists(bestMob) && host.isAlive(bestMob) && host.me.dist(bestMob) < 3 && !host.isMeleeImmune(bestMob) && (aggroMobsCount() == host.mobsInRange(7, false)) && isZDistGoodForMeleeAttack())
            {
                if (host.me.level < 30 && host.enemysInRange(15, false) == 0)
                    AttackWithSkill(10644); //Sunder Earth
                else if (host.me.level >= 30)
                    AttackWithSkill(10644); //Sunder Earth
            }
            #endregion
        }

        private void UseSpecialSkills()
        {
            if (specialItems != null)
            {
                for (int i = 0; i < specialItems.Length; i++)
                {
                    if (specialItems[i] == 23433)
                    {
                        if (host.me.target != null && host.me.target.isAlive() && host.me.target.creatureId == 10690)
                        {
                            UseItemAndWait(specialItems[i]);
                            Thread.Sleep(2500);
                        }
                    }
                    if (specialItems[i] == 3999 && host.me.target != null && host.me.target.isAlive() && host.me.target.creatureId == 2038)
                        UseItemAndWait(specialItems[i]);
                    else if (specialItems[i] == 4000 && host.me.target != null && host.me.target.isAlive() && (host.me.target.creatureId == 2036 || host.me.target.creatureId == 2037))
                        UseItemAndWait(specialItems[i]);
                    else if (specialItems[i] == 24833 && host.me.target != null && host.me.target.isAlive() && host.me.target.creatureId == 8007 && host.buffTime(4651) == 0)
                        UseItemAndWait(specialItems[i]);
                    else if (specialItems[i] == 16420 && host.me.target != null && host.me.target.isAlive())
                    {
                        if (host.me.target.creatureId == 7955)
                            UseItemAndWait(specialItems[i]);
                    }
                    else if (specialItems[i] == 16428 && host.me.target != null && host.me.target.isAlive())
                    {
                        if (host.me.target.creatureId == 7795)
                            UseItemAndWait(specialItems[i]);
                    }
                    else if (specialItems[i] == 23416 && host.me.target != null && host.me.target.isAlive() && host.me.target.creatureId == 10598)
                    {
                        host.ComeTo(host.me.target, 4);
                        UseItemAndWait(specialItems[i]);
                    }
                    else
                        UseItemAndWait(specialItems[i]);
                    Thread.Sleep(100);
                }
            }
            if (specialSkills != null)
            {
                for (int i = 0; i < specialSkills.Length; i++)
                {
                    UseSkillAndWait(specialSkills[i]);
                    Thread.Sleep(100);
                }
            }
        }

        private void UsePrimarySkills()
        {
            if (host.angle(bestMob, host.me) > 45 && host.angle(bestMob, host.me) < 315) //если нужно - поворачиваемся к нему лицом
                host.TurnDirectly(bestMob);

            //Mage - Magic staff
            if (host.characterSettings.weaponPriority == 0)
            {
                if (host.isAbilityTaken(Ability.Sorcery) && host.isSkillLearned(10752))
                {
                    for (int i = 0; i < 2; i++)
                        UseSkillAndWait(10752); //Flamebolt
                }
                else if (host.isAbilityTaken(Ability.Occultism) && host.isSkillLearned(14810))
                {
                    for (int i = 0; i < 2; i++)
                        UseSkillAndWait(14810); //Mana Start
                }
            }
            //Range - Bow
            if (host.characterSettings.weaponPriority == 1)
            {
                if (host.isAbilityTaken(Ability.Archery) && host.isSkillLearned(14835))
                {
                    for (int i = 0; i < 2; i++)
                        UseSkillAndWait(14835); //Endless Arrows
                }
                else
                {
                    if (host.isAbilityTaken(Ability.Shadowplay) && host.isSkillLearned(18125) && isZDistGoodForMeleeAttack())
                    {
                        for (int i = 0; i < 2; i++)
                            UseSkillAndWait(18125); //Rapid Strike
                    }
                    else if (host.isAbilityTaken(Ability.Battlerage) && host.isSkillLearned(18132) && isZDistGoodForMeleeAttack())
                    {
                        for (int i = 0; i < 2; i++)
                            UseSkillAndWait(18132); //Triple slash
                    }
                    else
                        UseSkillAndWait(16064); //Shoot Arrow
                }
            }
            //Melee - Swords\Blunts
            if (host.characterSettings.weaponPriority == 2)
            {
                if (host.isAbilityTaken(Ability.Shadowplay) && host.isSkillLearned(18125) && isZDistGoodForMeleeAttack())
                {
                    for (int i = 0; i < 2; i++)
                        UseSkillAndWait(18125); //Rapid Strike
                }
                else if (host.isAbilityTaken(Ability.Battlerage) && host.isSkillLearned(18132) && isZDistGoodForMeleeAttack())
                {
                    for (int i = 0; i < 2; i++)
                        UseSkillAndWait(18132); //Triple slash
                }
                else
                    UseSkillAndWait(16064); //Shoot Arrow
            }
            if (host.mpp() < 10)
                UseSkillAndWait(16064, false, false, 0); //Shoot Arrow
        }

        private void FarmRoute()
        {
            try
            {
                CheckUnderWaterBreath();
                UseRegenItems();
                if (bestMob == null)
                    return;
                if (host.me.target != bestMob && host.isAlive(bestMob))
                    host.SetTarget(bestMob);
                if (host.angle(bestMob, host.me) > 45 && host.angle(bestMob, host.me) < 315) //если нужно - поворачиваемся к нему лицом
                    host.TurnDirectly(bestMob);
                if (host.me.target == bestMob && host.isAlive(bestMob))
                {
                    if (bestMob.creatureId == 2069)
                        host.ComeTo(bestMob, 3);
                    UseSecondarySkills();
                    UsePrimarySkills();
                    if (bestMob.Z - host.me.Z > 5)
                        UseSkillAndWait(16064);
                }
                if (!host.isAlive(bestMob) && isDropAvailable(bestMob))
                {
                    Console.WriteLine("Come to pickup drop");
                    host.ComeTo(bestMob);
                    if (!host.PickupAllDrop(bestMob))
                        host.SetVar(bestMob, "pickFailed", true);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        public bool isDropAvailable(Creature obj)
        {
            if (obj == null)
                return false;
            return (bestMob.dropAvailable && host.GetVar(bestMob, "pickFailed") == null);
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
                uint tick = 0;
#if DEBUG
                mountTask = new Task(ControlMount);
                mountTask.Start();
#elif !DEBUG
                mountThread = new Thread(ControlMount);
                mountThread.Start();
#endif
                while (!host.cancelRequested)
                {
#if DEBUG
                    base.Run(ct);
#elif !DEBUG
                    base.Run();
#endif

                    Thread.Sleep(100);
                    try
                    {
                        tick++;
                        if (!host.isAlive())
                        {
                            readyToActions = false;
                            farmState = FarmState.Disabled;
                            while (host.me.resurrectionWaitingTime > 0)
                                Thread.Sleep(100);
                            Thread.Sleep(3000);
                            host.movementModule.ResumeGpsMove();
                            host.CancelMoveTo();
                            host.ResToRespoint();
                            Thread.Sleep(10000);
                            host.MoveTo(host.me.X, host.me.Y, host.me.Z);
                            while (host.me.isMoving)
                                Thread.Sleep(100);
                            if (host.characterSettings.autoRestoreExp)
                                host.RestoreExp();
                            Thread.Sleep(30000);

                            readyToActions = true;
                        }

                        if (tick % 5 == 0 && host.isAlive() && !host.isMounted())
                        {
                            if (host.isAbilityTaken(Ability.Sorcery) && host.buffTime(95) == 0 && host.buffTime(426) == 0 && host.buffTime(427) == 0 && host.buffTime(428) == 0 && host.buffTime(429) == 0 && host.skillCooldown(10153) == 0)
                                UseSkillAndWait(10153, true, true); //Insulating Lens
                            if (host.isAbilityTaken(Ability.Defense) && host.buffTime(53) == 0 && host.buffTime(331) == 0 && host.buffTime(332) == 0 && host.buffTime(333) == 0 && host.buffTime(334) == 0 && host.buffTime(794) == 0 && host.buffTime(795) == 0 && host.buffTime(796) == 0 && host.buffTime(7655) == 0 && host.skillCooldown(10645) == 0)
                                UseSkillAndWait(10645, true, true); //Refreshment
                            if (host.isAbilityTaken(Ability.Defense) && host.buffTime(445) == 0 && host.buffTime(446) == 0 && host.buffTime(447) == 0 && host.buffTime(448) == 0 && host.skillCooldown(11365) == 0)
                                UseSkillAndWait(11365, true, true); //Toughen
                            if (host.isAbilityTaken(Ability.Archery) && host.buffTime(451) == 0 && host.buffTime(452) == 0 && host.buffTime(453) == 0 && host.buffTime(454) == 0 && host.buffTime(7658) == 0 && host.skillCooldown(11368) == 0)
                                UseSkillAndWait(11368, true, true); //Double Recurve
                            if (host.isAbilityTaken(Ability.Witchcraft) && host.buffTime(11) == 0 && host.buffTime(6956) == 0 && host.skillCooldown(11368) == 0)
                                UseSkillAndWait(10712, true, true); //Purge
                            if (host.isAbilityTaken(Ability.Vitalism) && host.buffTime(3455) == 0 && host.buffTime(220) == 0 && host.skillCooldown(10547) == 0 && host.hpp() < 80)
                                UseSkillAndWait(10547, true, true); //Resurgence
                            if (host.isAbilityTaken(Ability.Songcraft) && host.buffTime(462) == 0 && host.buffTime(463) == 0 && host.buffTime(464) == 0 && host.buffTime(465) == 0 && host.buffTime(466) == 0 && host.skillCooldown(11377) == 0)
                                UseSkillAndWait(11377, true, true); //Hummingbird Ditty

                            //Лут дропа рядом
                            host.farmModule.PickUpNearMe();
                        }


                        if (bestMob != null && host.isExists(bestMob) && host.isMounted())
                            host.StandFromMount();
                        if (host.isMounted() && host.getMount() != null && IsSwim()) 
                            host.StandFromMount();

                        if (farmState == FarmState.Enabled)
                        {
                            CheckRadiusInvite();
                            if (!host.isExists(bestMob))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && host.isAlive(bestMob) && (bestMob.firstHitter != null && bestMob.firstHitter != host.me && bestMob.aggroTarget != host.me))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && !host.isAlive(bestMob) && !isDropAvailable(bestMob))
                                bestMob = null;
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !isDropAvailable(bestMob))) && ((host.mpp() > 40 && host.hpp() > 75) || (aggroMobsCount() + enemyTargetersMobsCountOnMyMount() > 0)))
                                bestMob = GetBestMob();
                            FarmRoute();
                        }
                        else if (farmState == FarmState.AttackOnlyAgro)
                        {
                            
                            if (!host.isExists(bestMob))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && !host.isAlive(bestMob) && !isDropAvailable(bestMob))
                                bestMob = null;
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !isDropAvailable(bestMob))) && host.mpp() > 10)
                                bestMob = GetBestAgroMob();
                            if (bestMob != null && host.isExists(bestMob) && host.isAlive(bestMob))
                                host.movementModule.SuspendGpsMove();
                            if (host.getAggroMobsCount() == 0 && GetBestAgroMob() == null)
                                host.movementModule.ResumeGpsMove();
                            FarmRoute();
                        }
                        else if (farmState == FarmState.Doodads)
                        {
                            CheckRadiusInvite();
                            if (!host.isExists(bestMob))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && !host.isAlive(bestMob) && !isDropAvailable(bestMob))
                                bestMob = null;
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !isDropAvailable(bestMob))) && host.mpp() > 10)
                                bestMob = GetBestAgroMob();
                            if (bestMob == null)
                            {
                                CheckUnderWaterBreath();
                                for (int i = 0; i < farmDoodadsIds.Count; i++)
                                {
                                    bestDoodad = getNearestDoodadInZone(farmDoodadsIds[i]);
                                    if (bestDoodad == null)
                                        continue;
                                    //Проверяем путь к этому доодаду
                                    var mobPreventDoodadFarm = CheckBestAgroMob(bestDoodad);
                                    if (mobPreventDoodadFarm != null)
                                    {
                                        bestMob = mobPreventDoodadFarm;
                                        break;
                                    }
                                    var skills = bestDoodad.getUseSkills();
                                    if (skills.Count > 0)
                                    {
                                        if (doodadCastDist == 0)
                                            host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        else
                                        {
                                            host.ComeTo(bestDoodad, doodadCastDist, doodadCastDist);
                                            if (host.me.dist(bestDoodad) <= doodadCastDist)
                                                host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        }
                                    }
                                    if (specialItems != null)
                                    {
                                        for (int j = 0; j < specialItems.Length; j++)
                                        {
                                            if (doodadCastDist == 0)
                                            {
                                                host.CancelTarget();
                                                host.farmModule.UseItemAndWait(specialItems[j]);
                                            }
                                            else
                                            {
                                                host.ComeTo(bestDoodad, doodadCastDist, doodadCastDist);
                                                if (host.me.dist(bestDoodad) <= doodadCastDist)
                                                {
                                                    host.CancelTarget();
                                                    host.farmModule.UseItemAndWait(specialItems[j]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            FarmRoute();
                        }
                        else if (farmState == FarmState.MobsFromDoodads)
                        {
                            CheckRadiusInvite();
                            if (!host.isExists(bestMob))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && !host.isAlive(bestMob) && !isDropAvailable(bestMob))
                                bestMob = null;
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !isDropAvailable(bestMob))) && ((host.mpp() > 40 && host.hpp() > 75) || (aggroMobsCount() + enemyTargetersMobsCountOnMyMount() > 0)))
                                bestMob = GetBestMob();
                            if (bestMob == null)
                            {
                                CheckUnderWaterBreath();
                                for (int i = 0; i < farmDoodadsIds.Count; i++)
                                {
                                    bestDoodad = getNearestDoodadInZone(farmDoodadsIds[i]);
                                    if (bestDoodad == null)
                                        continue;
                                    //Проверяем путь к этому доодаду
                                    var mobPreventDoodadFarm = CheckBestAgroMob(bestDoodad);
                                    if (mobPreventDoodadFarm != null)
                                    {
                                        bestMob = mobPreventDoodadFarm;
                                        break;
                                    }
                                    var skills = bestDoodad.getUseSkills();
                                    if (skills.Count > 0)
                                    {
                                        if (doodadCastDist == 0)
                                            host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        else
                                        {
                                            host.ComeTo(bestDoodad, doodadCastDist, doodadCastDist);
                                            if (host.me.dist(bestDoodad) <= doodadCastDist)
                                                host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        }
                                    }
                                }
                            }
                            FarmRoute();
                        }
                        else if (farmState == FarmState.DoodadsFromMobs)
                        {
                            CheckRadiusInvite();
                            if (!host.isExists(bestMob))
                                bestMob = null;
                            if (bestMob != null && host.isExists(bestMob) && !host.isAlive(bestMob) && !isDropAvailable(bestMob))
                                bestMob = null;
                            if ((bestMob == null || !host.isExists(bestMob) || (!host.isAlive(bestMob) && !isDropAvailable(bestMob))) && ((host.mpp() > 40 && host.hpp() > 75) || (aggroMobsCount() + enemyTargetersMobsCountOnMyMount() > 0)))
                            {
                                CheckUnderWaterBreath();
                                bool doodadExists = false;
                                for (int i = 0; i < farmDoodadsIds.Count; i++)
                                {
                                    bestDoodad = getNearestDoodadInZone(farmDoodadsIds[i]);
                                    if (bestDoodad == null)
                                        continue;
                                    //Проверяем путь к этому доодаду
                                    var mobPreventDoodadFarm = CheckBestAgroMob(bestDoodad);
                                    if (mobPreventDoodadFarm != null)
                                    {
                                        bestMob = mobPreventDoodadFarm;
                                        break;
                                    }

                                    doodadExists = true;
                                    var skills = bestDoodad.getUseSkills();
                                    if (skills.Count > 0)
                                    {
                                        if (doodadCastDist == 0)
                                            host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        else
                                        {
                                            host.ComeTo(bestDoodad, doodadCastDist, doodadCastDist);
                                            if (host.me.dist(bestDoodad) <= doodadCastDist)
                                                host.farmModule.UseDoodadSkill(skills[0].id, bestDoodad, true);
                                        }
                                    }
                                    if (farmDoodadsIds[i] == 8648)
                                    {
                                        host.ComeTo(bestDoodad, 1, 1);
                                        if (host.me.dist(bestDoodad) <= 1)
                                            host.PickupAllDrop(bestDoodad);
                                    }
                                }
                                if (!doodadExists)
                                    bestMob = GetBestMob();
                            }
                            FarmRoute();
                        }
                    }
                    catch (Exception error)
                    {
                        host.Log(error.ToString());
                        Console.WriteLine(error.ToString());
                    }
                }
#if !DEBUG
            }
            catch (Exception error)
            {
                Console.WriteLine("Thread abort. Farm module.");
            }
#endif
        }

        public void SetFarmMobsFromDoodads(Zone zone, uint[] mobsIDs, uint[] doodadsIDs, double castDist = 0)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(doodadsIDs);
            lock (farmMobsIds)
                farmMobsIds = new List<uint>(mobsIDs);
            lock (farmZone)
                farmZone = zone;
            farmState = FarmState.MobsFromDoodads;
            doodadCastDist = castDist;
        }

        public void SetFarmDoodadsFromMobs(Zone zone, uint[] mobsIDs, uint[] doodadsIDs, uint[] UseSpecialItem, double castDist = 0, uint[] UseSpecialSkills = null)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(doodadsIDs);
            lock (farmMobsIds)
                farmMobsIds = new List<uint>(mobsIDs);
            lock (farmZone)
                farmZone = zone;
            if (UseSpecialItem != null && UseSpecialItem.Length > 0)
                specialItems = UseSpecialItem;
            if (UseSpecialSkills != null && UseSpecialSkills.Length > 0)
                specialSkills = UseSpecialSkills;
            farmState = FarmState.DoodadsFromMobs;
            doodadCastDist = castDist;
        }

        public void SetFarmDoodads(Zone zone, uint[] ids, double castDist = 0)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            farmState = FarmState.Doodads;
            doodadCastDist = castDist;
        }

        public void SetFarmDoodads(Zone zone, uint[] ids, uint[] UseSpecialItem, double castDist = 0)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            bestMob = null;
            lock (farmDoodadsIds)
                farmDoodadsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            if (UseSpecialItem != null && UseSpecialItem.Length > 0)
                specialItems = UseSpecialItem;
            farmState = FarmState.Doodads;
            doodadCastDist = castDist;
        }

        public void SetFarmMobs(Zone zone, uint[] ids, uint[] UseSpecialItem)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            //bestMob = null;
            lock (farmMobsIds)
                farmMobsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            specialItems = UseSpecialItem;
            farmState = FarmState.Enabled;
        }

        public void SetFarmMobs(Zone zone, uint[] ids, uint UseSpecialItem = 0)
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            //bestMob = null;
            lock(farmMobsIds)
                farmMobsIds = new List<uint>(ids);
            lock (farmZone)
                farmZone = zone;
            if (UseSpecialItem > 0)
                specialItems = new uint[] { UseSpecialItem };
            else
                specialItems = null;
            farmState = FarmState.Enabled;
        }

        public void SetFarmAggros()
        {
            if (!host.me.isAlive())
                return;
            specialSkills = null;
            specialItems = null;
            bestMob = null;
            farmState = FarmState.AttackOnlyAgro;
        }

        public void PickUpNearMe()
        {
            if (host.me.isAlive())
            {
                foreach (var m in host.getCreatures())
                {
                    if (m.dropAvailable && host.dist(m) < 5)
                    {
                        host.PickupAllDrop(m);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public void StopFarm()
        {
            bestMob = null;
            specialSkills = null;
            specialItems = null;
            farmState = Modules.FarmState.Disabled;
        }

        public int getDoodadsCountInZone(Zone zone, uint phaseId)
        {
            int result = 0;
            foreach (var doodad in host.getDoodads())
            {
                if (doodad.phaseId == phaseId && zone.ObjInZone(doodad))
                    result++;
            }
            return result;
        }

        public int getCreatureCountInZone(Zone zone, uint creatureId)
        {
            int result = 0;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == creatureId && zone.ObjInZone(creature) && creature.isAlive())
                    result++;
            }
            return result;
        }

        private DoodadObject getNearestDoodadInZone( uint phaseId)
        {
            double minDist = 999999;
            DoodadObject bDoodad = null;
            foreach (var doodad in host.getDoodads())
            {
                if (doodad.phaseId == phaseId && farmZone.ObjInZone(doodad))
                {
                    if (minDist > host.me.dist(doodad))
                    {
                        minDist = host.me.dist(doodad);
                        bDoodad = doodad;
                    }
                }

            }
            return bDoodad;
        }

        internal Creature GetNearestCreaturesInZoneById(Zone zone, List<uint> creatureId)
        {
            try
            {
                Creature creature = null;
                var tempCreatures = host.getCreatures();
                double minDist = 999999;
                for (int i = 0; i < tempCreatures.Count; i++)
                {
                    if (creatureId.Exists(c => c == tempCreatures[i].creatureId) && host.dist(tempCreatures[i]) < minDist && zone.ObjInZone(tempCreatures[i]))
                    {
                        minDist = host.dist(tempCreatures[i]);
                        creature = tempCreatures[i];
                    }
                }
                return creature;
            }
            catch (Exception error)
            {

            }
            return null;
        }

        internal Creature GetNearestCreatureById(uint creatureId)
        {
            try
            {
                Creature creature = null;
                var tempCreatures = host.getCreatures();
                double minDist = 999999;
                for (int i = 0; i < tempCreatures.Count; i++)
                {
                    if (tempCreatures[i].creatureId == creatureId && host.dist(tempCreatures[i]) < minDist)
                    {
                        minDist = host.dist(tempCreatures[i]);
                        creature = tempCreatures[i];
                    }
                }
                return creature;
            }
            catch (Exception error)
            {
                
            }
            return null;
        }


        private Creature getNearestMobInZone(uint mobId)
        {
            double minDist = 999999;
            Creature bestCreature = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.creatureId == mobId && host.isAlive(creature))
                {
                    if (minDist > host.me.dist(creature))
                    {
                        minDist = host.me.dist(creature);
                        bestCreature = creature;
                    }
                }

            }
            return bestCreature;
        }

        private bool isIntersect(Creature obj)
        {
            if (host.GetVar(obj, "Intersect") != null)
                return ((bool)(host.GetVar(obj, "Intersect")));
            return false;
        }

        public bool CheckGuardsNear(Creature obj)
        {
            foreach (var c in host.getCreatures())
            {
                if ((c.creatureId == 8242 || c.creatureId == 8243) && (host.dist(host.me) < 50 || host.dist(obj) < 50))
                    return true;
            }
            return false;
        }

        private Creature CheckBestMob(Creature bestMob)
        {
            if (bestMob == null)
                return null;
            List<Creature> finalResult = new List<Creature>();
            finalResult.Add(bestMob);

            foreach (var obj in host.getCreatures())
            {
                if (host.isInPeaceZone(obj) || host.isInPeaceZone(host.me))
                    continue;
                if (mobsToIgnore.Contains(obj.creatureId))
                    continue;
                var zRange = host.me.Z - obj.Z;
                if (host.isAlive(obj) && !host.isStealth(obj) && (IsSwim() || (!IsSwim() && host.me.Z - obj.Z < 15))
                        && (obj.firstHitter == null || obj.firstHitter == host.me || host.isPartyMember(obj.firstHitter))
                        && (obj.type != BotTypes.Player || (obj.type == BotTypes.Player && !CheckGuardsNear(obj) && host.isAttackable(obj)))
                        && (
                        (obj.aggroTarget != null && obj.aggroTarget == host.me) ||
                    //&& (zRange > -5 && zRange < 13)
                        (host.isEnemy(obj) && obj.db.aggression && obj.aggroTarget == null && host.CircleIntersects(obj.X, obj.Y, 8, host.me.X, host.me.Y, bestMob.X, bestMob.Y) && obj.Z - host.getZFromHeightMap(obj.X, obj.Y) < 3)
                        )
                    )
                {
                    finalResult.Add(obj);
                }
            }

            double finalDist = 999999;
            Creature finalMob = null;
            foreach (var obj in finalResult)
            {
                if (finalDist > host.me.dist(obj))
                {
                    finalDist = host.me.dist(obj);
                    finalMob = obj;
                }
            }
            return finalMob;
        }

        private Creature GetBestMob()
        {
            double bestDist = 999999;
            Creature bestMob = null;
            var myMount = host.getMount();
            foreach (var obj in host.getCreatures())
            {
                if (host.isAlive(obj) && !host.isStealth(obj) && bestDist > host.me.dist(obj) && (IsSwim() || (!IsSwim() && host.me.Z - obj.Z < 15))
                        && (obj.firstHitter == null || obj.firstHitter == host.me || host.isPartyMember(obj.firstHitter))
                        && (obj.type != BotTypes.Player || (obj.type == BotTypes.Player && !CheckGuardsNear(obj) && host.isAttackable(obj))) 
                        && (
                        (obj.aggroTarget != null && obj.aggroTarget == host.me) ||
                        (isIntersect(obj) && obj.aggroTarget == null) ||
                        (farmZone.ObjInZone(obj) && obj.aggroTarget == null && farmMobsIds.Contains(obj.creatureId))
                        )
                    )
                {
                    bestDist = host.me.dist(obj);
                    bestMob = obj;
                }
            }

            //Если bestMob != null - это наш лучший моб. Но нужно еще проверить путь к нему теперь.
            var finalMob = CheckBestMob(bestMob);
            while (finalMob != bestMob)
            {
                bestMob = finalMob;
                finalMob = CheckBestMob(bestMob);
            }
            return finalMob;
        }


        private Creature CheckBestAgroMob(SpawnObject bestObject)
        {
            if (bestObject == null)
                return null;
            List<Creature> finalResult = new List<Creature>();
            if (bestObject.type != BotTypes.DoodadObject)
                finalResult.Add((Creature)bestObject);

            foreach (var obj in host.getCreatures())
            {
                if (mobsToIgnore.Contains(obj.creatureId))
                    continue;
                if (host.isInPeaceZone(obj) || host.isInPeaceZone(host.me))
                    continue;
                var zRange = host.me.Z - obj.Z;
                if (host.isAlive(obj) && !host.isStealth(obj) && (IsSwim() || (!IsSwim() && host.me.Z - obj.Z < 15))
                        && (obj.aggroTarget == host.me || obj.aggroTarget == null)
                        && (obj.type != BotTypes.Player || (obj.type == BotTypes.Player && !CheckGuardsNear(obj) && host.isAttackable(obj))) 
                    //&& (zRange > -5 && zRange < 13)
                        && (host.isEnemy(obj) && obj.db.aggression && host.CircleIntersects(obj.X, obj.Y, 8, host.me.X, host.me.Y, bestObject.X, bestObject.Y) && obj.Z - host.getZFromHeightMap(obj.X, obj.Y) < 4)
                    )
                {
                    finalResult.Add(obj);
                }
            }

            double finalDist = 999999;
            Creature finalMob = null;
            foreach (var obj in finalResult)
            {
                if (finalDist > host.me.dist(obj))
                {
                    finalDist = host.me.dist(obj);
                    finalMob = obj;
                }
            }
            return finalMob;
        }

        private Creature GetBestAgroMob()
        {
            double bestDist = 999999;
            Creature bestMob = null;
            foreach (var obj in host.getCreatures())
            {
                if (obj.creatureId == 1676)
                    continue;
                if (host.isAlive(obj) && bestDist > host.me.dist(obj) && !host.isSpellImmune(obj)
                    && (obj.aggroTarget == host.me || isIntersect(obj))
                    && (obj.type != BotTypes.Player || (obj.type == BotTypes.Player && !CheckGuardsNear(obj) && host.isAttackable(obj))) 
                    && (IsSwim() || (!IsSwim() && host.me.Z - obj.Z < 15))
                    //&& (obj.creatureId != 791 || (obj.creatureId == 791 && obj.Z - host.me.Z > 2)) //mobs-casters, who stay on the walls
                    )
                {
                    bestDist = host.me.dist(obj);
                    bestMob = obj;
                }
            }

            //Если bestMob != null - это наш лучший моб. Но нужно еще проверить путь к нему теперь.
            var finalMob = CheckBestAgroMob(bestMob);
            while (finalMob != bestMob)
            {
                bestMob = finalMob;
                finalMob = CheckBestAgroMob(bestMob);
            }
            return finalMob;
        }
    }
}
