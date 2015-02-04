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
    internal class Quest_3983 : Quest
    {
        public Quest_3983(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3983, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (host.gameTime() > 300 && host.gameTime() < 1080)
                return false;

            if (!checkQuestCompletedOrPerfomed(3982))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Ryterd")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                Zone zone = new RoundZone(14541.15, 12256.27, 50);
                if (!host.movementModule.GpsMove("Quest_3983_1"))
                    return false;
                host.farmModule.SetFarmMobs(zone, new uint[] { 10513 });
                while (CheckWeCanContinueFarmQuest(quest.id) && host.farmModule.readyToActions && host.farmModule.farmState == Modules.FarmState.Enabled)
                    Thread.Sleep(100);
                host.farmModule.StopFarm();
                Thread.Sleep(1000);
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Star_Ryterd")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
