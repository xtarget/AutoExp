using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_676 : Quest
    {
        public Quest_676(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(676, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!checkQuestCompletedOrAccepted(190))
                    return false;
                if (!checkQuestCompletedOrAccepted(192))
                    return false;
                if (!checkQuestCompletedOrAccepted(195))
                    return false;
                if (!host.movementModule.GpsMove("Marianhold_Evert"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(190))
                return false;
            if (!checkQuestCompletedOrPerfomed(192))
                return false;
            if (!checkQuestCompletedOrPerfomed(195))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Marianpol_Darlina")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
