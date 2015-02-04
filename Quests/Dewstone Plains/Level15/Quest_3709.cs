using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3709 : Quest
    {
        public Quest_3709(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3709, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompleted(920))
                return false;
            if (!checkQuestCompletedOrPerfomed(922))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13332.51, 14262.35, 10);
                if (!host.movementModule.GpsMove("Quest_3709_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 10478 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
