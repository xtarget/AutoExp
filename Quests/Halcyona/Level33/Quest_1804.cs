using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_1804 : Quest
    {
        public Quest_1804(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(1804, minLvl, maxLvl, race, reqQuests)
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
                    if (!host.movementModule.GpsMove("Golden_Bruse"))
                        return false;
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
                    if (!host.movementModule.GpsMove("Golden_Bruse")) return false;
                    if (!host.movementModule.GpsMove("Quest_1804_1")) return false;
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.MoveTo(9705.70, 10406.82, 233.06);
                    Thread.Sleep(1000);
                    host.farmModule.Climb(host.getNearestDoodad(30));
                    Thread.Sleep(1500);
                    host.ClimbUp();
                    Thread.Sleep(1500);
                    host.farmModule.UseDoodadSkill(15365, host.getNearestDoodad(8378), true);
                    Thread.Sleep(1000);
                    host.MoveTo(9709.44, 10409.86, 224.56);
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
                    if (!host.movementModule.GpsMove("Golden_Bruse")) return false;
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
