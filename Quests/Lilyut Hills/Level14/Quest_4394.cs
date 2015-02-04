using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4394 : Quest
    {
        public Quest_4394(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4394, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Melvas"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(1620))
                return false;
            if (!checkQuestCompletedOrAccepted(1619))
                return false;
            if (!checkQuestCompletedOrAccepted(1622))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Liliot_Sirota")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id, host.farmModule.GetNearestCreatureById(10988));
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1620))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Liliot_Melvas")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
