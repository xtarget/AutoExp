using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1126 : Quest
    {
        public Quest_1126(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1126, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Yamani"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Arcum_PlantFarm_1")) return false;
                RoundZone zone = new RoundZone(host.me.X, host.me.Y, 10);
                if (quest.steps[0] == 0)
                {
                    host.PlantItemsInZone(23635, zone, 1);
                    Thread.Sleep(35000);
                }
                else if (quest.steps[0] == 1)
                {
                    if (getMyDoodadById(11307) != null)
                    {
                        host.farmModule.UseDoodadSkill(17752, getMyDoodadById(11307), true);
                    }
                    Thread.Sleep(3000);
                }
            }

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Yamani"))
                    return false;
                host.CompleteQuest(id,3);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
