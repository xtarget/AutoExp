﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_6224 : Quest
    {
        public Quest_6224(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(6224, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Liliot_Merienne"))
                    return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
