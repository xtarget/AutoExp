using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_871 : Quest
    {
        public Quest_871(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(871, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Anatta")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Araham")) return false;
                while (host.farmModule.readyToActions &&  host.me.isAlive() && quest.status == QuestStatus.Accepted)
                {
                    host.farmModule.UseDoodadSkill(19558, host.getNearestDoodad(14643), true);
                    if (host.farmModule.aggroMobsCount() == 0)
                    {
                        var c = host.farmModule.GetNearestCreatureById(5213);
                        if (c != null)
                        {
                            host.SetTarget(c);
                            Thread.Sleep(1000);
                            host.UseItem(5206, true);
                            Thread.Sleep(1000);
                        }
                    }
                    Thread.Sleep(100);
                    if (host.itemCount(25737) > 0)
                    {
                        host.farmModule.UseItemAndWait(25737);
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(1000);
                }
            }

            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Anatta")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
