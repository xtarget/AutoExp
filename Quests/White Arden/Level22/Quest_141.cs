using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_141 : Quest
    {
        public Quest_141(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(141, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Reinhilda"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(8931.49, 12399.50, 80);
                if (!host.movementModule.GpsMove("Quest_141_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2051, 2049 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (quest.steps[0] >= 5)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 2051 });
                    if (quest.steps[1] >= 5)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 2049 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(4228))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Reinhilda")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }
             

            return true;
        }
    }
}
