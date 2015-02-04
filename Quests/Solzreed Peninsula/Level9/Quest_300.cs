using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_300 : Quest
    {
        public Quest_300(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(300, minLvl, maxLvl, race, reqQuests)
        { }

        public bool IsInsideCastle()
        {
            var z = new PolygonZone(new List<ZonePoint>() {
            new ZonePoint(14123.42, 14875.55),
            new ZonePoint(14151.70, 14852.56),
            new ZonePoint(14201.73, 14831.67),
            new ZonePoint(14223.04, 14848.60),
            new ZonePoint(14246.71, 14880.66),
            new ZonePoint(14258.03, 14912.58),
            new ZonePoint(14257.79, 14929.53),
            new ZonePoint(14236.33, 14963.89),
            new ZonePoint(14221.91, 14998.59),
            new ZonePoint(14216.17, 15012.19),
            new ZonePoint(14200.55, 15022.48),
            new ZonePoint(14160.88, 15019.36),
            new ZonePoint(14135.53, 15012.85),
            new ZonePoint(14102.04, 14984.35),
            new ZonePoint(14091.03, 14963.13),
            new ZonePoint(14097.88, 14925.52)});
            return z.ObjInZone(host.me);
        }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Friderig"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(291))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!IsInsideCastle())
                {
                    if (!host.movementModule.GpsMove("Solrid_Yilm")) return false;
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(148);
                    host.ComeTo(d, 1);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(d);
                    Thread.Sleep(1500);
                    if (!host.me.isClimb)
                        return false;
                    try
                    {
                        host.MoveForward(true);
                        Thread.Sleep(47000);
                    }
                    finally
                    {
                        host.MoveForward(false);
                        try
                        {
                            host.Jump(true);
                            Thread.Sleep(750);
                        }
                        finally
                        {
                            host.Jump(false);
                        }
                    }
                }
                if (IsInsideCastle())
                {
                    Zone zone = new RoundZone(14196.05, 14935.81, 80);
                    if (!host.movementModule.GpsMove("Quest_300_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 3486 });
                    while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (!checkQuestCompleted(291))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (IsInsideCastle())
                {
                    if (!host.movementModule.GpsMove("Solrid_Castle")) return false;
                    Thread.Sleep(1000);
                    host.MoveTo(14238.78, 14971.43, 118.36);
                }
                if (!IsInsideCastle())
                {
                    if (!host.movementModule.GpsMove("Solrid_Friderig")) return false;
                    Thread.Sleep(1000);
                    CompleteQuestWithArmorSelect();
                    Thread.Sleep(1000);
                }
            }

            return true;
        }
    }
}
