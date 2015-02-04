using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_4199 : Quest
    {
        public Quest_4199(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4199, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;
            if (!checkQuestCompletedOrAccepted(2310))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Maruva"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21317, 11835, 50);
                if (!host.movementModule.GpsMove("Quest_4199_1"))
                    return false;
                host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 10760 }, new uint[] { 11311 }, new uint[] { 23604 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.DoodadsFromMobs)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Maruva")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
