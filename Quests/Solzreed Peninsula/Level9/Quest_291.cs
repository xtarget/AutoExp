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
    internal class Quest_291 : Quest
    {
        public Quest_291(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(291, minLvl, maxLvl, race, reqQuests)
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
                if (!host.movementModule.GpsMove("Solrid_Yilm"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!IsInsideCastle())
                {
                    Console.WriteLine("111111");
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
                else if (IsInsideCastle())
                {
                    Console.WriteLine("222222");
                    if (!host.movementModule.GpsMove("Solrid_Richag")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(18224, host.getNearestDoodad(12994), true);
                    Thread.Sleep(1000);
                    if (!host.movementModule.GpsMove("Solrid_Bri")) return false;
                    Thread.Sleep(1000);
                    host.TalkWithQuestNpc(id);
                }
            }

            if (!checkQuestCompletedOrPerfomed(300))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (IsInsideCastle())
                {
                    Console.WriteLine("333333");
                    if (!host.movementModule.GpsMove("Solrid_Castle")) return false;
                    Thread.Sleep(1000);
                    host.MoveTo(14238.78, 14971.43, 118.36);
                    host.MoveTo(14252.53, 15000.80, 121.74);
                }
                else if (!IsInsideCastle())
                {
                    Console.WriteLine("444444");
                    if (!host.movementModule.GpsMove("Solrid_Yilm")) return false;
                    Thread.Sleep(1000);
                    host.CompleteQuest(id);
                    Thread.Sleep(1000);
                }
            }
             

            return true;
        }
    }
}
