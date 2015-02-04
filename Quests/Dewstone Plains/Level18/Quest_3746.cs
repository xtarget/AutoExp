using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3746 : Quest
    {
        public Quest_3746(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3746, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(82))
                return false;
            if (!checkQuestCompletedOrAccepted(961))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Faramin"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Stone_Luraria")) return false;
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
