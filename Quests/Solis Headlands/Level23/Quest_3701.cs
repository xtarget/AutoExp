﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3701 : Quest
    {
        public Quest_3701(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3701, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Marjiana")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_3701_1"))
                    return false;
                Thread.Sleep(1000);
                var d1 = host.getNearestDoodad(9922);
                if (d1 != null && host.dist(d1) < 6)
                    host.farmModule.UseDoodadSkill(16461, d1, true, 1);
                Thread.Sleep(1000);
                var d2 = host.getNearestDoodad(10221);
                if (d2 != null && host.dist(d2) < 6)
                    host.farmModule.UseDoodadSkill(16460, d2, true, 1);
                Thread.Sleep(1000);
            }
            

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Marjiana"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
