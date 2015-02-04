using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2337 : Quest
    {
        public Quest_2337(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2337, minLvl, maxLvl, race, reqQuests)
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
                Zone zone = new RoundZone(20210.33, 12972.19, 35);
                if (!host.movementModule.GpsMove("Inistra_Savini")) return false;
                host.SetTarget(host.farmModule.GetNearestCreatureById(1475));
                host.farmModule.UseItemAndWait(17419);
                Thread.Sleep(2000);
                host.farmModule.SetFarmMobs(zone, new uint[] { 8778 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
