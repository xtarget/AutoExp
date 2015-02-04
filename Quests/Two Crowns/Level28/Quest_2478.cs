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
    internal class Quest_2478 : Quest
    {
        public Quest_2478(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(2478, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(2484))
                return false;
            if (!checkQuestCompletedOrAccepted(1480))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("TwoCrown_Table3")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1480))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13473, 11585.41, 200);
                if (!host.movementModule.GpsMove("Quest_2478_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8089 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
