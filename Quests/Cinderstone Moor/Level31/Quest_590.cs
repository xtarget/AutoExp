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
    internal class Quest_590 : Quest
    {
        public Quest_590(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(590, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (host.gameTime() > 300 && host.gameTime() < 1080)
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Atensa")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            //if (!checkQuestCompletedOrAccepted(560))
                //return false;
            if (!checkQuestCompletedOrAccepted(549))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(4977) == 0)
                {
                    Zone zone = new RoundZone(14600.42, 11943.83, 22);
                    if (!host.movementModule.GpsMove("Quest_590_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2323,2324,2320 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(4977) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (!host.movementModule.GpsMove("Quest_590_2"))
                    return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(13614, host.getNearestDoodad(1639), true);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompleted(549))
                return false;

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Atensa")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
