﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_918 : Quest
    {
        public Quest_918(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(918, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Gron"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(3708))
                return false;
            if (!checkQuestCompletedOrPerfomed(1656))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12861.08, 14491.24, 100);
                if (!host.movementModule.GpsMove("Quest_918_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 696, 697 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1656))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Gron")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
