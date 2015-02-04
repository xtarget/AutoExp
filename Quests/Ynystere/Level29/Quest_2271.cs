using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2271 : Quest
    {
        public Quest_2271(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2271, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Nordala"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (host.itemCount(26386) == 0)
                {
                    if (!host.movementModule.GpsMove("Inistra_Nordala")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(20309, host.getNearestDoodad(15424), true);
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(20310, host.getNearestDoodad(12330), true);
                    Thread.Sleep(1000);
                }
                if (host.itemCount(26386) > 0)
                {
                    if (!host.movementModule.GpsMove("Inistra_Deilard")) return false;
                    Thread.Sleep(1000);
                    host.Equip(26386);
                    Thread.Sleep(1200);
                    host.farmModule.UseDoodadSkill(15168, host.getNearestDoodad(7870), true);
                    Thread.Sleep(1000);
                    host.commonModule.EquipBestArmorAndWeapon();
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Inistra_Deilard")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            

            return true;
        }
    }
}
