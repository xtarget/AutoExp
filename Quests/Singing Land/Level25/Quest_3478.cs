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
    internal class Quest_3478 : Quest
    {
        public Quest_3478(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3478, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    if (!host.movementModule.GpsMove("SigningLand_Grel2")) return false;
                    host.StartQuest(id);
                    Thread.Sleep(1000);
                }
                finally
                {
                    host.movementModule.disableMounting = false;
                }
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                try
                {
                    host.movementModule.disableMounting = true;
                    host.StandFromMount();
                    Zone zone = new RoundZone(20994.10, 10466.70, 10);
                    if (!host.movementModule.GpsMove("SigningLand_Grel2"))
                        return false;
                    host.farmModule.SetFarmMobs(zone, new uint[] { 10343 }, 3439);
                    while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                        Thread.Sleep(100);
                    host.farmModule.StopFarm();
                    Thread.Sleep(180000);
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
