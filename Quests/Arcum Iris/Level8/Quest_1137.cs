using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1137 : Quest
    {
        public Quest_1137(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1137, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1144))
                return false;
            if (!checkQuestCompletedOrPerfomed(1136))
                return false;
            
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Zyhra"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(1153))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1137_1"))
                    return false;
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
