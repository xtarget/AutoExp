using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_128 : Quest
    {
        public Quest_128(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(128, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("White_Alana"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (quest.steps[0] == 0)
                {
                    if (host.itemCount(4028) == 0)
                    {
                        host.CancelQuest(id);
                        return false;
                    }
                    if (!host.movementModule.GpsMove("Quest_128_Vrata1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12525, host.getNearestDoodad(209), true);
                    host.MoveTo(10595.57, 13186.85, 232.86);
                }
                if (quest.steps[1] == 0)
                {
                    if (host.itemCount(3950) == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_128_Ogon")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(13118, host.getNearestDoodad(357), true);
                    }
                    if (!host.movementModule.GpsMove("Quest_128_Vrata2")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12527, host.getNearestDoodad(260), true);
                    host.MoveTo(10569.84, 13237.06, 233.45);
                }
                if (quest.steps[2] == 0)
                {
                    if (host.itemCount(4031) == 0)
                    {
                        Zone zone = new RoundZone(10574.34, 13255.04, 50);
                        if (!host.movementModule.GpsMove("Quest_128_Krov"))
                            return false;
                        host.farmModule.SetFarmMobs(zone, new uint[] { 2110 });
                        while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(4031) == 0)
                            Thread.Sleep(100);
                        host.farmModule.StopFarm();
                    }
                    if (!host.movementModule.GpsMove("Quest_128_Vrata3")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12524, host.getNearestDoodad(403), true);
                    host.MoveTo(10619.87, 13266.77, 233.80);
                }
                if (quest.steps[3] == 0)
                {
                    if (host.itemCount(3951) == 0)
                    {
                        if (!host.movementModule.GpsMove("Quest_128_Statya")) return false;
                        Thread.Sleep(1000);
                        host.farmModule.UseDoodadSkill(13125, host.getNearestDoodad(392), true);
                    }
                    if (!host.movementModule.GpsMove("Quest_128_Vrata4")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(12528, host.getNearestDoodad(405), true);
                    host.MoveTo(10646.77, 13231.36, 233.00);
                }
            }
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("White_Alana")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
