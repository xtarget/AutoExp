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
    internal class Quest_3906 : Quest
    {
        public Quest_3906(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3906, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Lai")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1488))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22876.68, 11557.18, 50);
                if (!host.movementModule.GpsMove("Quest_3906_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3150 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Lai")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
