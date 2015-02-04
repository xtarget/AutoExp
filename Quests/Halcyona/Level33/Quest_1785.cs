using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1785 : Quest
    {
        public Quest_1785(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(1785, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Golden_Senna"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1787))
                return false;
            if (!checkQuestCompletedOrPerfomed(1786))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(10435.60, 10678.22, 100);
                if (!host.movementModule.GpsMove("Quest_1786_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2707, 2706, 2796 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
