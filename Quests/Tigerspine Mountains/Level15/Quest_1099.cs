﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1099 : Quest
    {
        public Quest_1099(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1099, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Jaras")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(1098))
                return false;
            if (!checkQuestCompletedOrAccepted(1100))
                return false;

            if (quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21202.12, 9118.55, 30);
                if (!zone.ObjInZone(host.me))
                    if (!host.movementModule.GpsMove("Quest_1099_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 3371 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1098))
                return false;
            if (!checkQuestCompletedOrPerfomed(1100))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Jaras")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
