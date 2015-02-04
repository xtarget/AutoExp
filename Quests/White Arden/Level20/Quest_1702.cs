using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_1702 : Quest
    {
        public Quest_1702(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1702, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Eili"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            if (!checkQuestCompletedOrPerfomed(4257))
                return false;

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(15284) == 0)
                {
                    Zone zone = new RoundZone(11055.11, 13574.54, 30);
                    if (!host.movementModule.GpsMove("Quest_135_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 2042, 2036, 2037 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(15284) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
                if (!host.movementModule.GpsMove("Quest_1702_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(12706, host.getNearestDoodad(4022), true);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
