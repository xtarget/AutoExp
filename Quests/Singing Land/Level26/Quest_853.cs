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
    internal class Quest_853 : Quest
    {
        public Quest_853(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(853, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Syan")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(854))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21642.24, 11243.00, 3);
                if (!host.movementModule.GpsMove("Quest_853_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1486 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(847))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Singland_Syan"))
                    return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
