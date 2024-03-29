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
    internal class Quest_1851 : Quest
    {
        public Quest_1851(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1851, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Signland_Ubein")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(844))
                return false;
            if (!checkQuestCompletedOrAccepted(842))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22299.43, 10591.92, 80);
                if (!host.movementModule.GpsMove("Quest_842_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5005 }, 5126);
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(844))
                return false;
            if (!checkQuestCompletedOrPerfomed(842))
                return false;
            

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Signland_Ubein")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
