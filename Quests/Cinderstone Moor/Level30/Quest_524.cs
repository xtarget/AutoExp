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
    internal class Quest_524 : Quest
    {
        public Quest_524(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(524, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Star_Murrey")) return false;
                Thread.Sleep(1000);
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
                    if (!host.movementModule.GpsMove("Star_Matlok")) return false;
                    Thread.Sleep(1000);
                    while (host.itemCount(15949) == 0)
                    {
                        host.SetTarget(host.farmModule.GetNearestCreatureById(2390));
                        Thread.Sleep(1000);
                        host.farmModule.UseItemAndWait(15950);
                        Thread.Sleep(1000);
                    }
                    if (!host.movementModule.GpsMove("Quest_524_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.UseDoodadSkill(13505, host.getNearestDoodad(1263), true);
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
                    if (!host.movementModule.GpsMove("Star_Murrey")) return false;
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
