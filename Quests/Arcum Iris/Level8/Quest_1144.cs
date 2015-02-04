using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1144 : Quest
    {
        public Quest_1144(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1144, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Arcum_Megrab"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (!checkQuestCompletedOrPerfomed(1145))
                return false;
            if (!checkQuestCompletedOrAccepted(1136))
                return false;


            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(21513.65, 6563.52, 35);
                if (!host.movementModule.GpsMove("Quest_1144_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 7907,2230 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(1137))
                return false;

            if (quest != null && quest.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Arcum_Kiki"))
                    return false;
                CompleteQuestWithPrimaryWeaponSelect();
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
