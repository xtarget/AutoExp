using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2279 : Quest
    {
        public Quest_2279(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2279, minLvl, maxLvl, race, reqQuests)
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
                    if (!host.movementModule.GpsMove("Inistra_Solren"))
                        return false;
                    host.StartQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            if (!checkQuestCompletedOrAccepted(2346))
                return false;
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Inistra_Are")) return false;
                Thread.Sleep(1000);
                host.StandFromMount();
                host.SetTarget(host.farmModule.GetNearestCreatureById(1405));
                host.ExpressEmotion(0x14);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Tyra")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
