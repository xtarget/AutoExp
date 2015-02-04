using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4200 : Quest
    {
        public Quest_4200(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4200, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrAccepted(2311))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Mbdna"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21220.37, 12219.22, 70);
                if (!host.movementModule.GpsMove("Quest_4200_1")) return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 8800 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
