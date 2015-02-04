using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Quests
{
    internal class Quest_2301 : Quest
    {
        public Quest_2301(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(2301, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Inistra_Vasko"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }
            
            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (host.itemCount(18688) == 0)
                    {
                        Zone zone = new RoundZone(21743.07, 13046.48, 40);
                        if (!host.movementModule.GpsMove("Quest_2301_1")) return false;
                        host.farmModule.SetFarmMobs(zone, new uint[] { 8024 });
                        while (host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled && host.itemCount(18688) == 0)
                            Thread.Sleep(100);
                        host.farmModule.StopFarm();
                        Thread.Sleep(1000);
                    }
                    if (!host.movementModule.GpsMove("Quest_2301_2")) return false;
                    host.MoveTo(21732.22, 13088.23, 220.06);
                    Thread.Sleep(1000);
                    var d = host.getNearestDoodad(8214);
                    while (d == null || (d != null && host.dist(d) > 1.5))
                    {
                        host.MoveTo(21732.22, 13088.23, 220.06);
                        Thread.Sleep(1000);
                        d = host.getNearestDoodad(8214);
                    }
                    host.farmModule.UseDoodadSkill(15285, d, true, 2);
                    Thread.Sleep(2000);
                    host.TalkWithQuestNpc(id,host.farmModule.GetNearestCreatureById(8782));
                    host.MoveTo(21732.22, 13088.23, 220.06);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("Inistra_Vasko")) return false;
                    Thread.Sleep(1000);
                    host.CompleteQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }
            

            return true;
        }
    }
}
