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
    internal class Quest_849 : Quest
    {
        public Quest_849(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(849, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (host.me != null && host.me.charGender != CharGender.Female)
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Singland_Mei")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!(checkQuestCompletedOrAccepted(1852) || checkQuestCompletedOrAccepted(812)))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21292.14, 10353.15, 10);
                if (!host.movementModule.GpsMove("Singland_Mei"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 1435 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
