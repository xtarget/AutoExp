using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_343 : Quest
    {
        public Quest_343(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(343, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Marianpole_Atenbori"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(26391) == 0)
                {
                    if (!host.movementModule.GpsMove("Marianpole_Atenbori"))
                        return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(20309, host.getNearestDoodad(15438), true);
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(20324, host.getNearestDoodad(15440), true);
                    Thread.Sleep(1000);
                    host.Equip(26391);
                    Thread.Sleep(1000);
                }
                Zone zone = new RoundZone(11512.38, 11521.13, 80);
                if (!host.movementModule.GpsMove("Quest_343_1"))
                    return false;
                host.farmModule.SetFarmDoodadsFromMobs(zone, new uint[] { 5152 }, new uint[] { 10701 }, new uint[] { }, 0, new uint[] { 12610 });
                while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.DoodadsFromMobs && quest.status == QuestStatus.Accepted && host.itemCount(26391) > 0)
                    Thread.Sleep(10);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
                host.commonModule.EquipBestArmorAndWeapon();
            }

            if (!checkQuestCompleted(335))
                return false;
            
            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Marianpole_Atenbori")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
