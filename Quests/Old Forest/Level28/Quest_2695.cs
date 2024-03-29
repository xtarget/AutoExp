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
    internal class Quest_2695 : Quest
    {
        public Quest_2695(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2695, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Piter")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1338))
                return false;
            if (!checkQuestCompletedOrPerfomed(1340))
                return false;
            if (!checkQuestCompletedOrAccepted(1331))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23777.46, 11398.45, 100);
                if (!host.movementModule.GpsMove("Quest_1337_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3160 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1338))
                return false;
            if (!checkQuestCompletedOrPerfomed(1340))
                return false;
            if (!checkQuestCompletedOrPerfomed(1331))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Piter")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
