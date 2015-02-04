using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3537 : Quest
    {
        public Quest_3537(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3537, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Samid")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] < 2)
                {
                    Zone zone = new RoundZone(19395.91, 8561.98, 40);
                    if (!host.movementModule.GpsMove("Quest_3537_2"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 10144 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] < 2)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] < 3 && quest.steps[0] == 2)
                {
                    Zone zone = new RoundZone(19415.40, 8528.69, 5);
                    if (!host.movementModule.GpsMove("Quest_3537_1"))
                        return false;
                    host.farmModule.SetFarmDoodads(zone, new uint[] { 10504 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads && quest.steps[1] < 3)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Samid")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
