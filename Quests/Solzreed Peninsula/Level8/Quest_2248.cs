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
    internal class Quest_2248 : Quest
    {
        public Quest_2248(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2248, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Kits"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2263))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(14814.65, 13579.04, 80);
                if (!host.movementModule.GpsMove("Quest_2248_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10584, 3489, 3463 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(346))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Solrid_Chet")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithArmorSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
