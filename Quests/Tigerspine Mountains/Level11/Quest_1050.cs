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
    internal class Quest_1050 : Quest
    {
        public Quest_1050(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1050, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Yarut")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Tiger_Yarut")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(11976, host.getNearestDoodad(2314), true);
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(11976, host.getNearestDoodad(2315), true);
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(11976, host.getNearestDoodad(2316), true);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Yarut")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }



            return true;
        }
    }
}
