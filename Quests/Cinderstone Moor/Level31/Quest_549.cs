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
    internal class Quest_549 : Quest
    {
        public Quest_549(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(549, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (host.gameTime() > 300 && host.gameTime() < 1080)
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Atensa")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            //if (!checkQuestCompletedOrAccepted(560))
                //return false;
            if (!checkQuestCompletedOrPerfomed(590))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_549_1")) return false;
                Thread.Sleep(1000);
                host.StandFromMount();
                Thread.Sleep(1000);
                host.UseItem(4985, 14660.71, 11909.71, 143.37);
                Thread.Sleep(1000);
            }

            //if (!checkQuestCompleted(560))
                //return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Atensa")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
