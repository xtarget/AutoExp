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
    internal class Quest_1493 : Quest
    {
        public Quest_1493(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1493, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("OldForest_Verjin"))
                    return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                host.farmModule.UseItemAndWait(14322);
                Thread.Sleep(2500);
                host.farmModule.UseItemAndWait(14323);
                Thread.Sleep(2500);
                host.farmModule.UseItemAndWait(14324);
                Thread.Sleep(15000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("OldForest_Verjin")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
