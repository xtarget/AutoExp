using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_127 : Quest
    {
        public Quest_127(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(127, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;


            if (!checkQuestCompletedOrPerfomed(133))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Viktor"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(4399))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("White_Osgar")) return false;
                Thread.Sleep(1000);
                host.TalkWithQuestNpc(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(134))
                return false;
            
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Alana")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
