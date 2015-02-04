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
    internal class Quest_4479   : Quest
    {
        public Quest_4479(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4479 , minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if ((host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre) && !host.movementModule.GpsMove("Tiget_BlueSalt")) return false;
                if ((host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf) && !host.movementModule.GpsMove("Liliot_BlueSalt")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(15694) == 0)
                {
                    if ((host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre) && !host.movementModule.GpsMove("Tiger_BlueSaltWell")) return false;
                    if ((host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf) && !host.movementModule.GpsMove("Lilit_Kolodec")) return false;
                    Thread.Sleep(1000);
                    if (host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre)
                        host.farmModule.UseDoodadSkill(13154, host.getNearestDoodad(7348), true);
                    if (host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf)
                        host.farmModule.UseDoodadSkill(13154, host.getNearestDoodad(4581), true);
                }
                if ((host.me.charRace == CharRace.Hariharan || host.me.charRace == CharRace.Ferre) && !host.movementModule.GpsMove("Tiget_BlueSalt")) return false;
                if ((host.me.charRace == CharRace.Nuian || host.me.charRace == CharRace.Elf) && !host.movementModule.GpsMove("Liliot_BlueSalt")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(18320, host.getNearestDoodad(13169), true);
                Thread.Sleep(1000);
            }

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
