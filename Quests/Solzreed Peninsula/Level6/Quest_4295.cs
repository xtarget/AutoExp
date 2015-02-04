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
    internal class Quest_4295 : Quest
    {
        public Quest_4295(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4295, minLvl, maxLvl, race, reqQuests)
        { }

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Solrid_Yaet"))
                    return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Solrid_Yaet")) return false;
                RoundZone zone = new RoundZone(14868.60, 14265.47, 10);
                while (host.itemCount(15694) < 3 && host.me.isAlive())
                {
                    host.farmModule.UseDoodadSkill(13154, host.getNearestDoodad(7339), true);
                    Thread.Sleep(1000);
                }

                if (host.itemCount(23682) > 0)
                {
                    host.PlantItemsInZone(23682, zone, 1);
                    Thread.Sleep(2000);
                }

                var myPet = getMyDoodadById(12833);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18035, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12834);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25961, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12838);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18037, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12839);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25962, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12843);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(17355, myPet, true);
                    Thread.Sleep(15000);
                }

                myPet = getMyDoodadById(12846);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(17387, myPet, true);
                    Thread.Sleep(3000);
                }
            }

            if (quest != null && quest.status == QuestStatus.Performed)
            {
                if (!host.movementModule.GpsMove("Solrid_Yaet")) return false;
                Thread.Sleep(1000);
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
