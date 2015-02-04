using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_44 : Quest
    {
        public Quest_44(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(44, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (!checkQuestCompletedOrPerfomed(1631))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Afindel"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12817.39, 14619.63, 80);
                if (!host.movementModule.GpsMove("Quest_44_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 668 }, new uint[] { 5265, 5263 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Afindel")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
