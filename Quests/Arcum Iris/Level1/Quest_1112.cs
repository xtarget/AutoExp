﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoExp.Quests
{
    internal class Quest_1112 : Quest
    {
        public Quest_1112(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1112, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Said"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Ifendi"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
