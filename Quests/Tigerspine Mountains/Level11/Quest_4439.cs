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
    internal class Quest_4439  : Quest
    {
        public Quest_4439(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4439 , minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if ((host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre) && !host.movementModule.GpsMove("Tiger_Auctioneer")) return false;
                if ((host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf) && !host.movementModule.GpsMove("Liliot_Auctioneer")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if ((host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre) && !host.movementModule.GpsMove("Tiget_BlueSalt")) return false;
                if ((host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf) && !host.movementModule.GpsMove("Liliot_BlueSalt")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
