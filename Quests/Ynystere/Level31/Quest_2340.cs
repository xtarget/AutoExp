using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2340    : Quest
    {
        public Quest_2340(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2340, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Savini"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20300.71, 12990.60, 35);
                if (!host.movementModule.GpsMove("Quest_2340_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8770 });
                while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && quest.status == QuestStatus.Accepted && host.itemCount(17419) == 0)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

             if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Natan")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
