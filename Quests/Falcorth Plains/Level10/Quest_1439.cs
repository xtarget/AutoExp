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
    internal class Quest_1439 : Quest
    {
        public Quest_1439(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1439, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_KoiCaster")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_KoiCaster")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(12316, host.getNearestDoodad(3987), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Ferre_KoiCaster")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
