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
    internal class Quest_818 : Quest
    {
        public Quest_818(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(818, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Signland_Nioxin")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Quest_815_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(13334, host.getNearestDoodad(1441), true);
                Thread.Sleep(2000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
