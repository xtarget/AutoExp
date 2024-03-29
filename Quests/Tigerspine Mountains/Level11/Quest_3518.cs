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
    internal class Quest_3518 : Quest
    {
        public Quest_3518(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3518, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(2989))
                return false;
            if (!checkQuestCompletedOrPerfomed(1158))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Radj")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Bagbat")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }



            return true;
        }
    }
}
