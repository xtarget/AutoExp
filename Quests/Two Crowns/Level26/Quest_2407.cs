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
    internal class Quest_2407 : Quest
    {
        public Quest_2407(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2407, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Twocrown_Kostak")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(4087))
                return false;
            if (!checkQuestCompletedOrAccepted(2694))
                return false;
            if (!checkQuestCompletedOrAccepted(2412))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12448.91, 12099.89, 80);
                if (!host.movementModule.GpsMove("Quest_2407_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 1594, 1592, 1595, 1593 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2694))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Twocrown_Kostak")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            return true;
        }
    }
}
