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
    internal class Quest_2249 : Quest
    {
        public Quest_2249(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2249, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Ted"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(14188.62, 14372.92, 70);
                if (!host.movementModule.GpsMove("Quest_273_1"))
                    return false;
                host.farmModule.SetFarmDoodads(zone, new uint[] { 4201 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Doodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Blacksmith_31")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
