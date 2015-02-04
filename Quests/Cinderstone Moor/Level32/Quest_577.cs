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
    internal class Quest_577 : Quest
    {
        public Quest_577(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(577, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Sandra")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            /*
            if (!checkQuestCompletedOrAccepted(550))
                return false;
            if (!checkQuestCompletedOrAccepted(555))
                return false;
            if (!checkQuestCompletedOrAccepted(3976))
                return false;
            */

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Star_Tess")) return false;
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
