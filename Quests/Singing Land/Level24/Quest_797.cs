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
    internal class Quest_797 : Quest
    {
        public Quest_797(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(797, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("SigningLands_Ukun")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrAccepted(798))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(20872.47, 10195.28, 60);
                if (!host.movementModule.GpsMove("Quest_798_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 5089 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(798))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("SigningLands_Ukun")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
