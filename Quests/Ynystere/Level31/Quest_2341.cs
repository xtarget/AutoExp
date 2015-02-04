using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2341 : Quest
    {
        public Quest_2341(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2341, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Natan"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
                host.MoveTo(20344.69, 12981.06, 148.84);
                Thread.Sleep(1000);
                host.UseDoodadSkill(15428, host.getNearestDoodad(8348), true);
                Thread.Sleep(15000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

             if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Faben")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
