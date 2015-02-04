using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_82 : Quest
    {
        public Quest_82(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(82, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Balma"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(88))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    Zone zone = new RoundZone(12404.98, 12833.49, 15);
                    if (!host.movementModule.GpsMove("Quest_82_1"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 3733 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads && quest.steps[0] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    Zone zone = new RoundZone(12513.90, 12577.49, 15);
                    if (!host.movementModule.GpsMove("Quest_82_2"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 3735 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads && quest.steps[1] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }
            
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Frigg")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            
            return true;
        }
    }
}
