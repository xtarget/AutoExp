﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1694 : Quest
    {
        public Quest_1694(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1694, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (host.me.charRace == CharRace.Hariharan && !checkQuestCompletedOrPerfomed(3543))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Rudal")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(2134))
                return false;

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Hassemia")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
