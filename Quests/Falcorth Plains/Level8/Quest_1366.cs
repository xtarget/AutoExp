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
    internal class Quest_1366 : Quest
    {
        public Quest_1366(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1366, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Sheodar")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1367))
                return false;
            if (!checkQuestCompletedOrAccepted(1365))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(23775.12, 9407.47, 15);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1366_1")) return false;
                host.farmModule.SetFarmMobsFromDoodads(zone, new uint[] { 4210 }, new uint[] { 6498, 6499 }, 4);
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.MobsFromDoodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1367))
                return false;
            if (!checkQuestCompletedOrPerfomed(1365))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_Sheodar")) return false;
                host.CompleteQuest(id, 2);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
