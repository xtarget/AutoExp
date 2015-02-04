using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4226 : Quest
    {
        public Quest_4226(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4226, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Tyalan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] < 8)
                {
                    Zone zone = new RoundZone(9810.77, 12499.87, 50);
                    if (!host.movementModule.GpsMove("Quest_4226_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 10605 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[0] < 8)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (quest.steps[1] == 0)
                {
                    Zone zone = new RoundZone(10019.17, 12424.09, 40);
                    if (!host.movementModule.GpsMove("Quest_4226_2"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 10634 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.steps[1] == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Gein")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

         
            return true;
        }
    }
}
