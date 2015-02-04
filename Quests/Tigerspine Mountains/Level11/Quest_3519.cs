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
    internal class Quest_3519 : Quest
    {
        public Quest_3519(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3519, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Tiger_Bagbat")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Tiger_Bagbat")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(16799, host.getNearestDoodad(10486), true);
                Thread.Sleep(1000);
            }

            

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Tiger_Bagbat")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }



            return true;
        }
    }
}
