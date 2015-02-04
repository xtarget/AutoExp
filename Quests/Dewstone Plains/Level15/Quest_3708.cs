﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3708 : Quest
    {
        public Quest_3708(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3708, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!checkQuestCompletedOrAccepted(2491))
                    return false;
                if (!checkQuestCompletedOrAccepted(918))
                    return false;
                if (!host.movementModule.GpsMove("Quest_918_1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(918))
                return false;
            if (!checkQuestCompletedOrAccepted(1656))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12861.08, 14491.24, 100);
                if (!host.movementModule.GpsMove("Quest_918_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 9979 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(918))
                return false;
            if (!checkQuestCompletedOrPerfomed(1656))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Quest_918_1")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
