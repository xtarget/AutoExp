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
    internal class Quest_567 : Quest
    {
        public Quest_567(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(567, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Sientist")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(566))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_567_1")) return false;
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
