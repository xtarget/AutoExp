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
    internal class Quest_2309 : Quest
    {
        public Quest_2309(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2309, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Eshhan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1234))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_GrayVillage"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
