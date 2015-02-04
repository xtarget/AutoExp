using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2336 : Quest
    {
        public Quest_2336(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2336, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(2333))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistre_Lisbet"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_2336_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(15279, host.getNearestDoodad(7853), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2924))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Lisbet")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
