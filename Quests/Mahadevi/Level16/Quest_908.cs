﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_908 : Quest
    {
        public Quest_908(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(908, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Ojat")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20128.50, 8489.46, 50);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_908_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5205 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Ojat")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
