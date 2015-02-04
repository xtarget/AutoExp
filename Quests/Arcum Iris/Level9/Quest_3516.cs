﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3516 : Quest
    {
        public Quest_3516(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3516, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
           
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Osman1"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(1151))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Amani"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
