﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1792 : Quest
    {
        public Quest_1792(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1792, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Golden_Senna"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(3916))
                return false;
            if (!checkQuestCompletedOrAccepted(1800))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Golden_Osmer")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
