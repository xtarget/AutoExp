using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2922 : Quest
    {
        public Quest_2922(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2922, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Isubar"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Inistra_Izabel")) return false;
                Thread.Sleep(1000);
                host.SetTarget(host.farmModule.GetNearestCreatureById(1456));
                host.farmModule.UseItemAndWait(18670);
                Thread.Sleep(1000);
                if (!host.movementModule.GpsMove("Quest_2922_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(15249, host.getNearestDoodad(7845), true);
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Izabel")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
