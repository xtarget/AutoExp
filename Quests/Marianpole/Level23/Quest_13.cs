using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_13 : Quest
    {
        public Quest_13(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(13, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Merianhold_Djilian"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(4403))
                return false;
            if (!checkQuestCompletedOrAccepted(264))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(10566.60, 12039.11, 100);
                if (!host.movementModule.GpsMove("Quest_13_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 532 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(264))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Marianpole_Klays")) return false;
                Thread.Sleep(1000);
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
