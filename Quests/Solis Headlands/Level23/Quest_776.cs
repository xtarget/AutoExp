﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_776 : Quest
    {
        public Quest_776(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(776, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Headlands_Sanjei")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(3692))
                return false;
            if (!checkQuestCompletedOrPerfomed(3693))
                return false;
            if (!checkQuestCompletedOrPerfomed(777))
                return false;

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_776_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14852, host.getNearestDoodad(7452), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(792))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Headlands_Sanjei"))
                    return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
