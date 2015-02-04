using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3724 : Quest
    {
        public Quest_3724(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3724, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Rymin"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    Zone zone = new RoundZone(11710.71, 13964.03, 15);
                    if (!host.movementModule.GpsMove("Quest_3724_2"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 9999, 839 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    Zone zone = new RoundZone(11647.98, 14012.99, 15);
                    if (!host.movementModule.GpsMove("Quest_3724_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 840, 836});
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[1] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Rymin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
             
            
            return true;
        }
    }
}
