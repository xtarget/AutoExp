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
    internal class Quest_3554 : Quest
    {
        public Quest_3554(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3554, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Singland_Yorun")) return false;
                    host.StartQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Singland_Haman")) return false;
                    Thread.Sleep(1000);
                    host.CompleteQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            return true;
        }
    }
}