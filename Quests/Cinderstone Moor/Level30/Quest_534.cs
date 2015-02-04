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
    internal class Quest_534 : Quest
    {
        public Quest_534(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(534, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Raxel")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(3961))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Star_Peter")) return false;
                Thread.Sleep(1000);
                host.SetTarget(host.farmModule.GetNearestCreatureById(2426));
                Thread.Sleep(1000);
                host.farmModule.UseItemAndWait(4989);
                host.farmModule.UseItemAndWait(15961);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(3961))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Raxel")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
