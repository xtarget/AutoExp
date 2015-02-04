using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3715 : Quest
    {
        public Quest_3715(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3715, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(76))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Soldat"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                for (int i = 0; i < 3; i++)
                {
                    host.farmModule.UseItemAndWait(20021);
                    Thread.Sleep(1250);
                    host.farmModule.UseItemAndWait(30206);
                    Thread.Sleep(1250);
                }
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Soldat")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
