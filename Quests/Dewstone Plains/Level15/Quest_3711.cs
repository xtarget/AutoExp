using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_3711 : Quest
    {
        public Quest_3711(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3711, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Sten"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Stone_Sten"))
                    return false;
                host.MoveTo(13018.02, 14254.28, 116.00);
                Thread.Sleep(2000);
                host.farmModule.UseItemAndWait(20069);
                Thread.Sleep(1250);
                host.farmModule.UseItemAndWait(20076);
                Thread.Sleep(1250);
                host.farmModule.UseItemAndWait(20070);
                Thread.Sleep(1250);
                host.farmModule.UseItemAndWait(20075);
                Thread.Sleep(1250);
                host.farmModule.UseItemAndWait(20072);
                Thread.Sleep(1250);
                host.farmModule.UseItemAndWait(20073);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Sten")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
