﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_943 : Quest
    {
        public Quest_943(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(943, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Sidur")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompleted(3646))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(17230.77, 8313.72, 60);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Headlands_Archealogy")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2906, 2907 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                {
                    if (quest.steps[0] >= 8)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 2906 });
                    if (quest.steps[1] >= 8)
                        host.farmModule.SetFarmMobs(zone, new uint[] { 2907 });
                    Thread.Sleep(100);
                }
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(951))
                return false;
            if (!checkQuestCompletedOrPerfomed(942))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Sidur")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
