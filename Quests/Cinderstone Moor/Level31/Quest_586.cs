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
    internal class Quest_586 : Quest
    {
        public Quest_586(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(586, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Irma")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(582))
                return false;
            if (!checkQuestCompletedOrPerfomed(3972))
                return false;
            if (!checkQuestCompletedOrPerfomed(581))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_586_1")) return false;
                Thread.Sleep(1000);
                var cl = host.getNearestDoodad(1114);
                host.farmModule.Climb(cl);
                Thread.Sleep(1500);
                host.ClimbUp();
                Thread.Sleep(2000);
                var d = host.getNearestDoodad(1341);
                if (host.dist(d) < 15)
                {
                    host.ComeTo(d, 1);
                    host.PickupAllDrop(d);
                }
                Thread.Sleep(1000);
                host.farmModule.Climb(cl);
                Thread.Sleep(1500);
                host.ClimbDown();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3972))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Irma")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
