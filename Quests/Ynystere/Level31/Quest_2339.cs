using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2339 : Quest
    {
        public Quest_2339(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2339, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_3Banshi"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20452.92, 12903.84, 80);
                if (!host.movementModule.GpsMove("Inistra_3Banshi")) return false;
                try
                {
                    host.farmModule.mobsToIgnore.Remove(8030);
                    host.farmModule.SetFarmMobs(zone, new uint[] { 8040 });
                    while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.farmModule.mobsToIgnore.Add(8030);
                }
            }
            
            return true;
        }
    }
}
