using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_112 : Quest
    {
        public Quest_112(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(112, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Mikael"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2498))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(11030.33, 12931.93, 45);
                if (!host.movementModule.GpsMove("Quest_112_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 2033, 2031 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Mikael")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
