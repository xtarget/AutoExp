﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_192 : Quest
    {
        public Quest_192(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(192, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Marianhold_Darel"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(195))
                return false;
            if (!checkQuestCompletedOrAccepted(190))
                return false;
            if (!checkQuestCompletedOrAccepted(676))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(10956.86, 12387.82, 12);
                if (!host.movementModule.GpsMove("Quest_192_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1356 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(677))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Marianhold_Darel")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
