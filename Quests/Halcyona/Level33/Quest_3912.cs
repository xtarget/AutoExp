using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3912 : Quest
    {
        public Quest_3912(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3912, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Golden_Sanchita"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(21289) == 0)
                {
                    Zone zone = new RoundZone(10325.30, 10581.28, 70);
                    if (!host.movementModule.GpsMove("Quest_3912_1")) return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2857, 2859, 2858 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(21289) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (host.itemCount(21288) == 0)
                {
                    Zone zone = new RoundZone(10283.72, 10653.26, 80);
                    if (!host.movementModule.GpsMove("Quest_3912_2")) return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] {2796, 2706, 2709, 2707, 2708});
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(21288) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                host.farmModule.UseItemAndWait(21288);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Golden_Sanchita")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
