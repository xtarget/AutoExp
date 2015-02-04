using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    //
    internal class Quest_2393 : Quest
    {
        public Quest_2393(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2393, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Wyd"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Solrid_Wyd")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14006, host.getNearestDoodad(6378), true);
            }

            return true;
        }
    }
}
