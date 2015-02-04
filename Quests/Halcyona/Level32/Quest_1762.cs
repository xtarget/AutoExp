using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1762 : Quest
    {
        public Quest_1762(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1762, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1763))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Golden_Veidrin"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();



            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1762_1")) return false;
                Thread.Sleep(1000);
                var d = host.getNearestDoodad(8325);
                if (d != null && host.dist(d) < 5)
                {
                    host.farmModule.UseDoodadSkill(15410, d, true);
                    Thread.Sleep(1000);
                }
                host.MoveTo(11739.99, 9916.99, 98.41);
                Thread.Sleep(1000);
                host.farmModule.Climb(host.getNearestDoodad(30));
                Thread.Sleep(1500);
                host.ClimbUp();
                Thread.Sleep(1500);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Golden_Veidrin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
