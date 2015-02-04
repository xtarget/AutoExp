﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_920 : Quest
    {
        public Quest_920(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests, uint[] reqUncompleteQuests)
            : base(920, minLvl, maxLvl, race, reqQuests, reqUncompleteQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(922))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Table1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(13228.27, 14239.21, 40);
                if (!host.movementModule.GpsMove("Quest_920_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 692, 693 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
