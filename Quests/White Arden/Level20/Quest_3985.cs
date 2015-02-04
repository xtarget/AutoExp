using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3985 : Quest
    {
        public Quest_3985(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3985, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Viktor"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(111))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("White_Viktor"))
                    return false;
                Thread.Sleep(1000);
                host.SetTarget(host.farmModule.GetNearestCreatureById(11255));
                host.farmModule.UseItemAndWait(23621);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(133))
                return false;
            if (!checkQuestCompletedOrPerfomed(905))
                return false;
            if (!checkQuestCompletedOrAccepted(127))
                return false;

            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Aldvin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
