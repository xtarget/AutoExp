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
    internal class Quest_4302 : Quest
    {
        public Quest_4302(int minLvl, int maxLvl, QuestRace race, uint[] reqQuests)
            : base(4302, minLvl, maxLvl, race, reqQuests)
        { }

        

        public override bool RunQuest(Host host)
        {
            if (!base.RunQuest(host))
                return false;

            if (getQuest() == null)
            {
                if (!host.movementModule.GpsMove("Ferre_Rarlag")) return false;
                host.StartQuest(id);
                Thread.Sleep(1000);
            }

            ArcheBuddy.Bot.Classes.Quest quest = getQuest();

            if (quest != null && quest.status == QuestStatus.Accepted)
            {
                if (!host.movementModule.GpsMove("Ferre_PlantFarm_1")) return false;
                RoundZone zone = new RoundZone(host.me.X, host.me.Y, 10);
                while (zone.ObjInZone(host.me) && host.itemCount(15694) < 3 && host.me.isAlive())
                {
                    host.farmModule.UseDoodadSkill(13154, host.getNearestDoodad(7348), true);
                    Thread.Sleep(1000);
                }

                if (host.itemCount(21847) > 0)
                {
                    host.PlantItemsInZone(21847, zone, 1);
                    Thread.Sleep(2000);
                }

                var myPet = getMyDoodadById(12403);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18035, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12404);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25961, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12408);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(18037, myPet, true);
                    Thread.Sleep(2000);
                }

                myPet = getMyDoodadById(12409);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(25962, myPet, true);
                    Thread.Sleep(32000);
                }

                myPet = getMyDoodadById(12413);
                if (myPet != null)
                {
                    if (host.dist(myPet) > 2)
                        host.ComeTo(myPet, 1, 1);
                    host.farmModule.UseDoodadSkill(17355, myPet, true);
                    Thread.Sleep(15000);
                }

                myPet = getMyDoodadById(12416);
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
                if (!host.movementModule.GpsMove("Ferre_Rarlag")) return false;
                host.CompleteQuest(id);
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
