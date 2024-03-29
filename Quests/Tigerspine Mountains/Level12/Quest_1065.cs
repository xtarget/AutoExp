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
    internal class Quest_1065 : Quest
    {
        public Quest_1065(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1065, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Amutar")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(22366.30, 8633.96, 20);
                if (!host.movementModule.GpsMove("Quest_1065_1")) return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 2453 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Amutar")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(30000);
            }
            return true;
        }
    }
}
