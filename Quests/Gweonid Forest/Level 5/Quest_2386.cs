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
    internal class Quest_2386 : Quest
    {
        public Quest_2386(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2386, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Gweonid_Breken")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_2386")) return false;

                var d = host.getNearestDoodad("Dagger Table");
                host.farmModule.UseDoodadSkill(14234, d);

                Thread.Sleep(5000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Gweonid_Breken")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
