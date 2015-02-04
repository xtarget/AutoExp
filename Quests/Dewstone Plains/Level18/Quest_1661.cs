using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1661 : Quest
    {
        public Quest_1661(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1661, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Stone_Frigg"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Quest_1661_1"))
                    return false;
                host.farmModule.farmState = Modules.FarmState.Disabled;
                host.MoveTo(12157.83, 12625.63, 152.25);
                Thread.Sleep(3000);
                host.farmModule.farmState = Modules.FarmState.AttackOnlyAgro;

                Zone zone = new RoundZone(12289.09, 12639.88, 40);
                if (!host.movementModule.GpsMove("Quest_1661_2"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 814, 7086, 7085 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(88))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Stone_Selma")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
