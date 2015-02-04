using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_258 : Quest
    {
        public Quest_258(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(258, minLvl, maxLvl, race, reqQuests)
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

            

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!checkQuestCompletedOrAccepted(28) && !checkQuestCompletedOrPerfomed(28))
                    return false;
                Zone zone = new RoundZone(10534.09, 12195.66, 20);
                if (!host.movementModule.GpsMove("Quest_258_1"))
                    return false;
                host.farmModule.SetFarmMobsFromDoodads(zone, new uint[] { 10446 }, new uint[] {10624});
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.MobsFromDoodads)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(28))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Merianhold_Djilian")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
