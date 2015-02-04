using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3539 : Quest
    {
        public Quest_3539(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3539, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Samid")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest.status == QuestStatus.Accepted)
            {
                host.farmModule.UseItemAndWait(20051);
                host.farmModule.UseItemAndWait(20052);
                host.farmModule.UseItemAndWait(20053);
                host.farmModule.UseItemAndWait(21337);
                host.farmModule.UseItemAndWait(23625);
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Samid")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
