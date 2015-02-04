using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4122 : Quest
    {
        public Quest_4122(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4122, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Red"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(1604))
                return false;
            if (!checkQuestCompletedOrAccepted(1605))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13895.72, 16034.37, 15);
                if (!host.movementModule.GpsMove("Quest_4122_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 13447 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1604))
                return false;
            if (!checkQuestCompletedOrPerfomed(1605))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Liliot_Red")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(30000);
            }

            return true;
        }
    }
}
