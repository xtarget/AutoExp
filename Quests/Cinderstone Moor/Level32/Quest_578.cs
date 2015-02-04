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
    internal class Quest_578 : Quest
    {
        public Quest_578(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(578, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if ((host.gameTime() < 300 ||  host.gameTime() > 1080) && !checkQuestCompleted(557))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Tess")) return false;
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(4988) == 0)
                {
                    Zone zone = new RoundZone(15503.07, 12513.07, 20);
                    if (!host.movementModule.GpsMove("Quest_578_1"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 4950 });
                    while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(4988) == 0)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(1000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Tess")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(14894, host.getNearestDoodad(1334), true);
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
