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
    internal class Quest_526 : Quest
    {
        public Quest_526(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(526, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (host.dist(14317.82, 11399.04, 194.25) > 6)
                {
                    if (!host.movementModule.GpsMove("Star_Istvyd")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                }
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.dist(14317.82, 11399.04, 194.25) > 6)
                {
                    if (!host.movementModule.GpsMove("Star_Istvyd")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                }
                host.UseDoodadSkill(11423, host.getNearestDoodad(1281), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (host.dist(14317.82, 11399.04, 194.25) > 6)
                {
                    if (!host.movementModule.GpsMove("Star_Istvyd")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(83));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                }
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
