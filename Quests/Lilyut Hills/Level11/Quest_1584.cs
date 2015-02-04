using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1584 : Quest
    {
        public Quest_1584(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1584, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Liliot_Rondalf"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrAccepted(2485))
                return false;
            if (!checkQuestCompletedOrAccepted(1583))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();


            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(12929.58, 15213.13, 100);
                if (!host.movementModule.GpsMove("Quest_1584_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 1857 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(2485))
                return false;
            if (!checkQuestCompletedOrPerfomed(1583))
                return false;

            
            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Liliot_Rondalf"))
                    return false;
                CompleteQuestWithSecondaryWeaponSelect();
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
