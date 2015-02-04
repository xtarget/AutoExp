using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArcheBuddy.Bot.Classes;


namespace AutoExp.Quests
{
    internal class Quest_3532 : Quest
    {
        public Quest_3532(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(3532, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Sakkari")) return false;
                Thread.Sleep(1000);
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();
            
            if (quest.status == QuestStatus.Accepted)
            {
                host.farmModule.UseDoodadSkill(12889, host.getNearestDoodad(11086));
                if (!host.movementModule.GpsMove("Quest_3532_1")) return false;
                Thread.Sleep(1000);
                host.farmModule.UseDoodadSkill(12889, host.getNearestDoodad(11086));
                Thread.Sleep(2000);
                host.MoveTo(19476.57, 8953.89, 242.09);
                host.MoveTo(19466.85, 8971.40, 242.04);
                host.MoveTo(19465.28, 8972.26, 242.63);
                while (host.isAlive() && host.me.isMoving)
                    Thread.Sleep(250);
                host.farmModule.UseDoodadSkill(17035, host.getNearestDoodad(10515));
                Thread.Sleep(3000);
                while (host.isAlive() && host.me.inFight)
                    Thread.Sleep(1000);
                host.MoveTo(19466.85, 8971.40, 242.04);
                host.MoveTo(19481.98, 8946.11, 242.04);
                host.farmModule.UseDoodadSkill(12889, host.getNearestDoodad(11086));
                Thread.Sleep(2000);
                host.MoveTo(19488.33, 8936.75, 241.63);
            }
            
            if (quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Mahadevi_Ahmad")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }
            
            return true;
        }
    }
}
