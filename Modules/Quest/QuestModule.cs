using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoExp.Quests;

namespace AutoExp.Modules
{
    internal class QuestModule : Module
    {
        internal List<Quest> questsCanBeRun;
        public uint currentQuestId = 0;
        public override void Start(Host host)
        {
            base.Start(host);
            questsCanBeRun = new List<Quest>();

            #region Arcum Iris
            questsCanBeRun.Add(new Quest_1112(1, 15, QuestRace.Hariharan, new uint[] { }));
            questsCanBeRun.Add(new Quest_1113(1, 15, QuestRace.Hariharan, new uint[] { 1112 }));
            questsCanBeRun.Add(new Quest_1117(1, 15, QuestRace.Hariharan, new uint[] { 1113 }));
            questsCanBeRun.Add(new Quest_1116(1, 15, QuestRace.Hariharan, new uint[] { 1113 }, new uint[] { 1120 })); //daily  
            questsCanBeRun.Add(new Quest_1135(1, 15, QuestRace.Hariharan, new uint[] { 1116, 1117 }));
            questsCanBeRun.Add(new Quest_3505(1, 15, QuestRace.Hariharan, new uint[] { 1116, 1117 })); //epic
            questsCanBeRun.Add(new Quest_3506(1, 15, QuestRace.Hariharan, new uint[] { 3505 })); //epic
            questsCanBeRun.Add(new Quest_3507(1, 15, QuestRace.Hariharan, new uint[] { 3506 })); //epic
            questsCanBeRun.Add(new Quest_1119(1, 15, QuestRace.Hariharan, new uint[] { 3507, 1135 }));
            questsCanBeRun.Add(new Quest_3508(1, 15, QuestRace.Hariharan, new uint[] { 3507, 1135 })); //epic
            questsCanBeRun.Add(new Quest_1120(1, 15, QuestRace.Hariharan, new uint[] { 1119 }));
            questsCanBeRun.Add(new Quest_1121(1, 15, QuestRace.Hariharan, new uint[] { 1120 }));
            questsCanBeRun.Add(new Quest_1192(1, 15, QuestRace.Hariharan, new uint[] { 1121 }));
            questsCanBeRun.Add(new Quest_1122(1, 15, QuestRace.Hariharan, new uint[] { 1192 }));
            questsCanBeRun.Add(new Quest_3509(1, 15, QuestRace.Hariharan, new uint[] { 3508 })); //epic
            questsCanBeRun.Add(new Quest_3510(1, 15, QuestRace.Hariharan, new uint[] { 3509 })); //epic
            questsCanBeRun.Add(new Quest_1123(1, 15, QuestRace.Hariharan, new uint[] { 1122 }));
            questsCanBeRun.Add(new Quest_4778(1, 15, QuestRace.Hariharan, new uint[] { 1122 }));
            questsCanBeRun.Add(new Quest_1125(1, 15, QuestRace.Hariharan, new uint[] { 1123 }));
            questsCanBeRun.Add(new Quest_1127(1, 15, QuestRace.Hariharan, new uint[] { 1125 }));
            questsCanBeRun.Add(new Quest_2349(1, 15, QuestRace.Hariharan, new uint[] { 1125 })); //epic
            questsCanBeRun.Add(new Quest_1114(1, 15, QuestRace.Hariharan, new uint[] { 2349 }));
            questsCanBeRun.Add(new Quest_1126(1, 15, QuestRace.Hariharan, new uint[] { 1114 }));
            questsCanBeRun.Add(new Quest_1182(1, 15, QuestRace.Hariharan, new uint[] { 1126 }));
            questsCanBeRun.Add(new Quest_2350(1, 15, QuestRace.Hariharan, new uint[] { 1182 })); //epic
            questsCanBeRun.Add(new Quest_3511(1, 15, QuestRace.Hariharan, new uint[] { 2350 })); //epic
            questsCanBeRun.Add(new Quest_3512(1, 15, QuestRace.Hariharan, new uint[] { 3511 })); //epic
            questsCanBeRun.Add(new Quest_1193(1, 15, QuestRace.Hariharan, new uint[] { 3511 }));
            questsCanBeRun.Add(new Quest_4777(1, 15, QuestRace.Hariharan, new uint[] { 1193 }));
            questsCanBeRun.Add(new Quest_4877(1, 15, QuestRace.Hariharan, new uint[] { 4777 }));
            questsCanBeRun.Add(new Quest_4878(1, 15, QuestRace.Hariharan, new uint[] { 4877 }));
            questsCanBeRun.Add(new Quest_1133(1, 15, QuestRace.Hariharan, new uint[] { 4878 }));
            questsCanBeRun.Add(new Quest_1129(1, 15, QuestRace.Hariharan, new uint[] { 1133 }));
            questsCanBeRun.Add(new Quest_4879(1, 15, QuestRace.Hariharan, new uint[] { 1127 }));
            questsCanBeRun.Add(new Quest_4775(1, 15, QuestRace.Hariharan, new uint[] { 4879 }));
            questsCanBeRun.Add(new Quest_4880(1, 15, QuestRace.Hariharan, new uint[] { 4775 }));
            questsCanBeRun.Add(new Quest_1134(1, 15, QuestRace.Hariharan, new uint[] { 4880, 3512, 1129 }));
            questsCanBeRun.Add(new Quest_1140(1, 15, QuestRace.Hariharan, new uint[] { 4880, 3512, 1129 })); //epic
            questsCanBeRun.Add(new Quest_1138(1, 15, QuestRace.Hariharan, new uint[] { 4880, 3512, 1129 }, new uint[] { 1143 })); //daily
            questsCanBeRun.Add(new Quest_1139(1, 15, QuestRace.Hariharan, new uint[] { 1134, 1140 }));
            questsCanBeRun.Add(new Quest_1143(1, 15, QuestRace.Hariharan, new uint[] { 1139 }));
            questsCanBeRun.Add(new Quest_3513(1, 15, QuestRace.Hariharan, new uint[] { 1139 })); //epic
            questsCanBeRun.Add(new Quest_4776(1, 15, QuestRace.Hariharan, new uint[] { 1139 }, new uint[] { 1118 })); //daily
            questsCanBeRun.Add(new Quest_3514(1, 15, QuestRace.Hariharan, new uint[] { 3513 })); //epic
            questsCanBeRun.Add(new Quest_3515(1, 15, QuestRace.Hariharan, new uint[] { 3514 })); //epic
            questsCanBeRun.Add(new Quest_1118(1, 15, QuestRace.Hariharan, new uint[] { 3514 }));
            questsCanBeRun.Add(new Quest_1142(1, 15, QuestRace.Hariharan, new uint[] { 1118 }));
            questsCanBeRun.Add(new Quest_1141(1, 15, QuestRace.Hariharan, new uint[] { 1118 }));
            questsCanBeRun.Add(new Quest_1145(1, 15, QuestRace.Hariharan, new uint[] { 1141, 1142 }));
            questsCanBeRun.Add(new Quest_1136(1, 15, QuestRace.Hariharan, new uint[] { 1141, 1142 }));
            questsCanBeRun.Add(new Quest_1144(1, 15, QuestRace.Hariharan, new uint[] { 1141, 1142 }));
            questsCanBeRun.Add(new Quest_1137(1, 15, QuestRace.Hariharan, new uint[] { 1145 }));
            questsCanBeRun.Add(new Quest_1153(1, 15, QuestRace.Hariharan, new uint[] { 1145 }));
            questsCanBeRun.Add(new Quest_1155(1, 15, QuestRace.Hariharan, new uint[] { 1144, 3515, 1136 }));
            questsCanBeRun.Add(new Quest_1154(1, 15, QuestRace.Hariharan, new uint[] { 1144, 3515, 1136 }));
            questsCanBeRun.Add(new Quest_1151(1, 15, QuestRace.Hariharan, new uint[] { 1154, 1155 }));
            questsCanBeRun.Add(new Quest_3516(1, 15, QuestRace.Hariharan, new uint[] { 1154, 1155 })); //epic
            questsCanBeRun.Add(new Quest_2354(1, 15, QuestRace.Hariharan, new uint[] { 1151, 3516 })); //epic
            questsCanBeRun.Add(new Quest_1160(1, 15, QuestRace.Hariharan, new uint[] { 1151, 3516 }));
            questsCanBeRun.Add(new Quest_1156(1, 15, QuestRace.Hariharan, new uint[] { 1151, 3516 }));
            questsCanBeRun.Add(new Quest_1170(1, 15, QuestRace.Hariharan, new uint[] { 1160 }));
            questsCanBeRun.Add(new Quest_1157(1, 15, QuestRace.Hariharan, new uint[] { 1156 }));
            questsCanBeRun.Add(new Quest_4742(1, 15, QuestRace.Hariharan, new uint[] { 1157 }));
            questsCanBeRun.Add(new Quest_1169(1, 15, QuestRace.Hariharan, new uint[] { 1157 }));
            questsCanBeRun.Add(new Quest_3517(1, 15, QuestRace.Hariharan, new uint[] { 2354 })); //epic
            questsCanBeRun.Add(new Quest_1158(1, 15, QuestRace.Hariharan, new uint[] { 4742, 1169 }));
            questsCanBeRun.Add(new Quest_2989(1, 15, QuestRace.Hariharan, new uint[] { 4742, 1169 }));
            
            
            #endregion
            #region Falcorth Plains
            questsCanBeRun.Add(new Quest_1212(1, 15, QuestRace.Ferre, new uint[] { }));
            questsCanBeRun.Add(new Quest_1213(1, 15, QuestRace.Ferre, new uint[] { 1212 }));
            questsCanBeRun.Add(new Quest_1573(1, 15, QuestRace.Ferre, new uint[] { 1213 }));
            questsCanBeRun.Add(new Quest_1218(1, 15, QuestRace.Ferre, new uint[] { 1573 }));
            questsCanBeRun.Add(new Quest_1574(1, 15, QuestRace.Ferre, new uint[] { 1573 }));
            questsCanBeRun.Add(new Quest_4477(1, 15, QuestRace.Ferre, new uint[] { 1218 }));
            questsCanBeRun.Add(new Quest_953(1, 15, QuestRace.Ferre, new uint[] { 4477 }));
            questsCanBeRun.Add(new Quest_1215(1, 15, QuestRace.Ferre, new uint[] { 4477 }));
            questsCanBeRun.Add(new Quest_1216(1, 15, QuestRace.Ferre, new uint[] { 1215 }));
            questsCanBeRun.Add(new Quest_1222(1, 15, QuestRace.Ferre, new uint[] { 1574 }));
            questsCanBeRun.Add(new Quest_2300(1, 15, QuestRace.Ferre, new uint[] { 1222 }));
            questsCanBeRun.Add(new Quest_4289(1, 15, QuestRace.Ferre, new uint[] { 1222 }, new uint[] { 1644 }));     //daily
            questsCanBeRun.Add(new Quest_3435(1, 15, QuestRace.Ferre, new uint[] { 1216 }));
            questsCanBeRun.Add(new Quest_3436(1, 15, QuestRace.Ferre, new uint[] { 3435 }));
            questsCanBeRun.Add(new Quest_3437(1, 15, QuestRace.Ferre, new uint[] { 3436 }));
            questsCanBeRun.Add(new Quest_2309(1, 15, QuestRace.Ferre, new uint[] { 3437 }));
            questsCanBeRun.Add(new Quest_1233(1, 15, QuestRace.Ferre, new uint[] { 3437 }));
            questsCanBeRun.Add(new Quest_1644(1, 15, QuestRace.Ferre, new uint[] { 1233 }));
            questsCanBeRun.Add(new Quest_2538(1, 15, QuestRace.Ferre, new uint[] { 1644 }));
            questsCanBeRun.Add(new Quest_1234(1, 15, QuestRace.Ferre, new uint[] { 2538 }));
            questsCanBeRun.Add(new Quest_2315(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1570(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1301(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1240(1, 15, QuestRace.Ferre, new uint[] { 1301 }));
            questsCanBeRun.Add(new Quest_1241(1, 15, QuestRace.Ferre, new uint[] { 1301 }, new uint[] { 1239 }));       //daily
            questsCanBeRun.Add(new Quest_3438(1, 15, QuestRace.Ferre, new uint[] { 1570 }));
            questsCanBeRun.Add(new Quest_1236(1, 15, QuestRace.Ferre, new uint[] { 1570 }));
            questsCanBeRun.Add(new Quest_1571(1, 15, QuestRace.Ferre, new uint[] { 1236 }));
            questsCanBeRun.Add(new Quest_1239(1, 15, QuestRace.Ferre, new uint[] { 1571 }));
            questsCanBeRun.Add(new Quest_3439(1, 15, QuestRace.Ferre, new uint[] { 1239 }));
            questsCanBeRun.Add(new Quest_1696(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_3440(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_1565(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_2764(1, 15, QuestRace.Ferre, new uint[] { 3439, 1565 }));
            questsCanBeRun.Add(new Quest_1363(1, 15, QuestRace.Ferre, new uint[] { 2764, 1565 }));
            questsCanBeRun.Add(new Quest_1364(1, 15, QuestRace.Ferre, new uint[] { 1363 }));
            questsCanBeRun.Add(new Quest_1417(1, 15, QuestRace.Ferre, new uint[] { 1364 }));
            questsCanBeRun.Add(new Quest_1366(1, 15, QuestRace.Ferre, new uint[] { 1417, 3440 }));
            questsCanBeRun.Add(new Quest_1367(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_1365(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_1413(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_6352(1, 15, QuestRace.Ferre, new uint[] { 1366, 1367, 1365 }));
            questsCanBeRun.Add(new Quest_1369(1, 15, QuestRace.Ferre, new uint[] { 1366, 1367, 1365 }));
            questsCanBeRun.Add(new Quest_1407(1, 15, QuestRace.Ferre, new uint[] { 1369 }));
            questsCanBeRun.Add(new Quest_2326(1, 15, QuestRace.Ferre, new uint[] { 4302 }));
            questsCanBeRun.Add(new Quest_2517(1, 15, QuestRace.Ferre, new uint[] { 4302 }));
            questsCanBeRun.Add(new Quest_4296(1, 15, QuestRace.Ferre, new uint[] { 1407, 3440, 6352 }));
            questsCanBeRun.Add(new Quest_4301(1, 15, QuestRace.Ferre, new uint[] { 4296 }));
            questsCanBeRun.Add(new Quest_4302(1, 15, QuestRace.Ferre, new uint[] { 4301 }));
            questsCanBeRun.Add(new Quest_2533(1, 15, QuestRace.Ferre, new uint[] { 2517 }));
            questsCanBeRun.Add(new Quest_1438(1, 15, QuestRace.Ferre, new uint[] { 2533 }));
            questsCanBeRun.Add(new Quest_2328(1, 15, QuestRace.Ferre, new uint[] { 2533, 2326 }));
            questsCanBeRun.Add(new Quest_1439(1, 15, QuestRace.Ferre, new uint[] { 1438, 2328 }));
            questsCanBeRun.Add(new Quest_1237(1, 15, QuestRace.Ferre, new uint[] { 1439 }));
            questsCanBeRun.Add(new Quest_3442(1, 15, QuestRace.Ferre, new uint[] { 1439 }));
            questsCanBeRun.Add(new Quest_1440(1, 15, QuestRace.Ferre, new uint[] { 1439 }, new uint[] { 1433 }));        //daily
            questsCanBeRun.Add(new Quest_2535(1, 15, QuestRace.Ferre, new uint[] { 1237 }));
            questsCanBeRun.Add(new Quest_3443(1, 15, QuestRace.Ferre, new uint[] { 3442 }));
            questsCanBeRun.Add(new Quest_2537(1, 15, QuestRace.Ferre, new uint[] { 3444 }));
            questsCanBeRun.Add(new Quest_3444(1, 15, QuestRace.Ferre, new uint[] { 2535, 3443 }));
            questsCanBeRun.Add(new Quest_3445(1, 15, QuestRace.Ferre, new uint[] { 3444 }));
            questsCanBeRun.Add(new Quest_6353(1, 15, QuestRace.Ferre, new uint[] { 2537 }));
            questsCanBeRun.Add(new Quest_1433(1, 15, QuestRace.Ferre, new uint[] { 2537 }));
            questsCanBeRun.Add(new Quest_1436(1, 15, QuestRace.Ferre, new uint[] { 2537 }, new uint[] { 1437 }));        //daily
            questsCanBeRun.Add(new Quest_5145(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            questsCanBeRun.Add(new Quest_1441(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            questsCanBeRun.Add(new Quest_1437(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            #endregion
            #region Tigerspine Mountains
            questsCanBeRun.Add(new Quest_3518(8, 17, QuestRace.Hariharan, new uint[] { 4742, 1169 })); //epic
            questsCanBeRun.Add(new Quest_3519(8, 17, QuestRace.Hariharan, new uint[] { 3518 })); //epic
            questsCanBeRun.Add(new Quest_3520(8, 17, QuestRace.Hariharan, new uint[] { 3519 })); //epic
            questsCanBeRun.Add(new Quest_1048(8, 17, QuestRace.Ferre, new uint[] { 1441, 1437 }));
            questsCanBeRun.Add(new Quest_1476(8, 17, QuestRace.Ferre, new uint[] { 1048 }));
            questsCanBeRun.Add(new Quest_1254(8, 17, QuestRace.Ferre, new uint[] { 3445 }));
            questsCanBeRun.Add(new Quest_1257(8, 17, QuestRace.Ferre, new uint[] { 1254 }));
            questsCanBeRun.Add(new Quest_1572(8, 17, QuestRace.Ferre, new uint[] { 1257 }));
            questsCanBeRun.Add(new Quest_4862(8, 17, QuestRace.Ferre, new uint[] { 1257 }));
            questsCanBeRun.Add(new Quest_4415(8, 17, QuestRace.Ferre, new uint[] { 5145 })); 
            questsCanBeRun.Add(new Quest_4415(8, 17, QuestRace.Hariharan, new uint[] { 2989 }));
            questsCanBeRun.Add(new Quest_4479(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4415 }));
            questsCanBeRun.Add(new Quest_4417(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4479 }));
            questsCanBeRun.Add(new Quest_4424(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4417 }));
            questsCanBeRun.Add(new Quest_4439(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4424 }));
            questsCanBeRun.Add(new Quest_4438(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4439 }));
            questsCanBeRun.Add(new Quest_1049(8, 17, QuestRace.Ferre, new uint[] { 1476 }));
            questsCanBeRun.Add(new Quest_1049(8, 17, QuestRace.Hariharan, new uint[] { 1158 }));
            questsCanBeRun.Add(new Quest_3521(8, 17, QuestRace.Hariharan, new uint[] { 3520 })); //epic 
            questsCanBeRun.Add(new Quest_3541(8, 17, QuestRace.Hariharan, new uint[] { 3521 })); //epic 
            questsCanBeRun.Add(new Quest_1050(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1049 }));
            questsCanBeRun.Add(new Quest_1084(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1050 }));
            questsCanBeRun.Add(new Quest_1051(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1084 }));
            questsCanBeRun.Add(new Quest_1052(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1051 }));
            questsCanBeRun.Add(new Quest_1059(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1052 }));
            questsCanBeRun.Add(new Quest_1060(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1059 }));
            questsCanBeRun.Add(new Quest_1053(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1060 }));
            questsCanBeRun.Add(new Quest_3542(8, 17, QuestRace.Hariharan, new uint[] { 3541 })); //epic 
            questsCanBeRun.Add(new Quest_3522(8, 17, QuestRace.Hariharan, new uint[] { 3542 })); //epic 
            questsCanBeRun.Add(new Quest_3446(8, 17, QuestRace.Ferre, new uint[] { 1572 })); //epic
            questsCanBeRun.Add(new Quest_1054(8, 17, QuestRace.Ferre, new uint[] { 1572 }));
            questsCanBeRun.Add(new Quest_1054(8, 17, QuestRace.Hariharan, new uint[] { 3542 }));
            questsCanBeRun.Add(new Quest_1058(8, 17, QuestRace.Ferre, new uint[] { 1572 }, new uint[] { 1061 }));       //daily
            questsCanBeRun.Add(new Quest_1058(8, 17, QuestRace.Hariharan, new uint[] { 3542 }, new uint[] { 1061 }));       //daily
            questsCanBeRun.Add(new Quest_1061(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1054 }));
            questsCanBeRun.Add(new Quest_1064(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1061 }));
            questsCanBeRun.Add(new Quest_1062(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1061 }));
            questsCanBeRun.Add(new Quest_1055(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1061 }, new uint[] { 1065 }));       //daily
            questsCanBeRun.Add(new Quest_1065(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1064 }));
            questsCanBeRun.Add(new Quest_1066(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1065 }));
            questsCanBeRun.Add(new Quest_6031(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1066, 1062 }, new uint[] { 1071 }));
            questsCanBeRun.Add(new Quest_1068(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1066, 1062 }));
            questsCanBeRun.Add(new Quest_1069(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1068 }));
            questsCanBeRun.Add(new Quest_1445(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1069 }));
            questsCanBeRun.Add(new Quest_3447(8, 17, QuestRace.Ferre, new uint[] { 3446 })); //epic
            questsCanBeRun.Add(new Quest_1076(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_1076(8, 17, QuestRace.Hariharan, new uint[] { 1069 }));
            questsCanBeRun.Add(new Quest_1171(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_1171(8, 17, QuestRace.Hariharan, new uint[] { 1069 }));
            questsCanBeRun.Add(new Quest_3448(8, 17, QuestRace.Ferre, new uint[] { 3447 })); //epic
            questsCanBeRun.Add(new Quest_3449(8, 17, QuestRace.Ferre, new uint[] { 3448 })); //epic
            questsCanBeRun.Add(new Quest_3523(8, 17, QuestRace.Hariharan, new uint[] { 3522 })); //epic
            questsCanBeRun.Add(new Quest_1071(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1171 }));
            questsCanBeRun.Add(new Quest_1070(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1069 }));
            questsCanBeRun.Add(new Quest_1172(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1076 }));
            questsCanBeRun.Add(new Quest_1075(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1172 }));
            questsCanBeRun.Add(new Quest_2423(8, 17, QuestRace.Ferre, new uint[] { 3449 })); //epic
            questsCanBeRun.Add(new Quest_2424(8, 17, QuestRace.Ferre, new uint[] { 2423 })); //epic
            questsCanBeRun.Add(new Quest_1078(8, 17, QuestRace.Ferre, new uint[] { 2423 }));
            questsCanBeRun.Add(new Quest_1078(8, 17, QuestRace.Hariharan, new uint[] { 3523 }));
            questsCanBeRun.Add(new Quest_3524(8, 17, QuestRace.Hariharan, new uint[] { 3523 })); //epic
            questsCanBeRun.Add(new Quest_1081(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1078 }));
            questsCanBeRun.Add(new Quest_1080(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1081 }));
            questsCanBeRun.Add(new Quest_1063(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1080 }));
            questsCanBeRun.Add(new Quest_3525(8, 17, QuestRace.Hariharan, new uint[] { 3524 })); //epic
            questsCanBeRun.Add(new Quest_1083(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1063 }));
            questsCanBeRun.Add(new Quest_1085(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1083 }));
            questsCanBeRun.Add(new Quest_1086(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1083 }));
            questsCanBeRun.Add(new Quest_1077(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1085 }));
            questsCanBeRun.Add(new Quest_1174(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1077 }));
            questsCanBeRun.Add(new Quest_6216(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_6214(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_1090(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_1092(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1090 }));
            questsCanBeRun.Add(new Quest_1102(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1092 }));
            questsCanBeRun.Add(new Quest_1088(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1102 }));
            questsCanBeRun.Add(new Quest_1093(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1088 }));
            questsCanBeRun.Add(new Quest_1094(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1093 }));
            questsCanBeRun.Add(new Quest_2425(8, 17, QuestRace.Ferre, new uint[] { 2424 })); //epic
            questsCanBeRun.Add(new Quest_3451(8, 17, QuestRace.Ferre, new uint[] { 2425 })); //epic
            questsCanBeRun.Add(new Quest_3452(8, 17, QuestRace.Ferre, new uint[] { 3451 })); //epic
            questsCanBeRun.Add(new Quest_3526(8, 17, QuestRace.Hariharan, new uint[] { 3525 })); //epic
            questsCanBeRun.Add(new Quest_3527(8, 17, QuestRace.Hariharan, new uint[] { 3526 })); //epic
            questsCanBeRun.Add(new Quest_3528(8, 17, QuestRace.Hariharan, new uint[] { 3527 })); //epic
            questsCanBeRun.Add(new Quest_3529(8, 17, QuestRace.Hariharan, new uint[] { 3528 })); //epic
            questsCanBeRun.Add(new Quest_1073(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1094 }));
            questsCanBeRun.Add(new Quest_1104(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1094 }));
            questsCanBeRun.Add(new Quest_1096(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1104, 1073 }));
            questsCanBeRun.Add(new Quest_1105(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1104, 1073 }));
            questsCanBeRun.Add(new Quest_1106(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1105 }));
            questsCanBeRun.Add(new Quest_1175(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1106 }));
            questsCanBeRun.Add(new Quest_1108(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1175, 1096 }));
            questsCanBeRun.Add(new Quest_1099(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1175, 1096 }));
            questsCanBeRun.Add(new Quest_1098(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1175, 1096 }, new uint[] { 1110 }));     //daily
            questsCanBeRun.Add(new Quest_1100(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1108 }));
            questsCanBeRun.Add(new Quest_1109(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1099, 1100 }));
            questsCanBeRun.Add(new Quest_3538(8, 17, QuestRace.Hariharan, new uint[] { 3529 })); //epic
            questsCanBeRun.Add(new Quest_1107(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1109 }));
            questsCanBeRun.Add(new Quest_1110(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1107 }));
            questsCanBeRun.Add(new Quest_1095(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1107 }));
            questsCanBeRun.Add(new Quest_1111(8, 17, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1095, 1110 }));
            #endregion
            #region Mahadevi
            questsCanBeRun.Add(new Quest_2128(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1095, 1110 }));
            questsCanBeRun.Add(new Quest_2124(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1095, 1110 }));
            questsCanBeRun.Add(new Quest_2125(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2124, 2128 }));
            questsCanBeRun.Add(new Quest_857(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2124, 2128 }));
            questsCanBeRun.Add(new Quest_861(12, 22, QuestRace.Ferre, new uint[] { 857, 1111, 2125, 3452 }));
            questsCanBeRun.Add(new Quest_861(12, 22, QuestRace.Hariharan, new uint[] { 857, 1111, 2125, 3538 }));
            questsCanBeRun.Add(new Quest_908(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 861 }));
            questsCanBeRun.Add(new Quest_858(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 908 }));
            questsCanBeRun.Add(new Quest_1500(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 858 }));
            questsCanBeRun.Add(new Quest_3530(12, 22, QuestRace.Hariharan, new uint[] { 1500 })); //epic
            questsCanBeRun.Add(new Quest_3531(12, 22, QuestRace.Hariharan, new uint[] { 3530 })); //epic
            questsCanBeRun.Add(new Quest_3453(12, 22, QuestRace.Ferre, new uint[] { 1500 })); //epic
            questsCanBeRun.Add(new Quest_3454(12, 22, QuestRace.Ferre, new uint[] { 3453 })); //epic
            questsCanBeRun.Add(new Quest_3455(12, 22, QuestRace.Ferre, new uint[] { 3454 })); //epic
            questsCanBeRun.Add(new Quest_2129(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_2129(12, 22, QuestRace.Hariharan, new uint[] { 3530 }));
            questsCanBeRun.Add(new Quest_859(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_859(12, 22, QuestRace.Hariharan, new uint[] { 3530 }));
            questsCanBeRun.Add(new Quest_893(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_893(12, 22, QuestRace.Hariharan, new uint[] { 3530 }));
            questsCanBeRun.Add(new Quest_888(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 859 }));
            questsCanBeRun.Add(new Quest_3307(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 859 }));
            questsCanBeRun.Add(new Quest_3306(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3307 }));
            questsCanBeRun.Add(new Quest_3305(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3306 }));
            questsCanBeRun.Add(new Quest_3308(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3305 }));
            questsCanBeRun.Add(new Quest_3456(12, 22, QuestRace.Ferre, new uint[] { 888, 3455, 2129 })); //epic
            questsCanBeRun.Add(new Quest_3532(12, 22, QuestRace.Hariharan, new uint[] { 3531 })); //epic
            questsCanBeRun.Add(new Quest_3533(12, 22, QuestRace.Hariharan, new uint[] { 3532 })); //epic
            questsCanBeRun.Add(new Quest_3534(12, 22, QuestRace.Hariharan, new uint[] { 3533 })); //epic
            questsCanBeRun.Add(new Quest_3535(12, 22, QuestRace.Hariharan, new uint[] { 3534 })); //epic
            questsCanBeRun.Add(new Quest_3561(12, 22, QuestRace.Hariharan, new uint[] { 3535 })); //epic
            questsCanBeRun.Add(new Quest_3536(12, 22, QuestRace.Hariharan, new uint[] { 3561 })); //epic
            questsCanBeRun.Add(new Quest_3537(12, 22, QuestRace.Hariharan, new uint[] { 3536 })); //epic
            questsCanBeRun.Add(new Quest_3539(12, 22, QuestRace.Hariharan, new uint[] { 3537 })); //epic
            questsCanBeRun.Add(new Quest_3540(12, 22, QuestRace.Hariharan, new uint[] { 3539 })); //epic
            questsCanBeRun.Add(new Quest_2896(12, 22, QuestRace.Ferre, new uint[] { 888, 3455, 2129 }));
            questsCanBeRun.Add(new Quest_2896(12, 22, QuestRace.Hariharan, new uint[] { 888, 3539, 2129 }));
            questsCanBeRun.Add(new Quest_3491(12, 22, QuestRace.Ferre, new uint[] { 3456 })); //epic
            questsCanBeRun.Add(new Quest_3457(12, 22, QuestRace.Ferre, new uint[] { 3491 })); //epic
            questsCanBeRun.Add(new Quest_3459(12, 22, QuestRace.Ferre, new uint[] { 3457 })); //epic
            questsCanBeRun.Add(new Quest_3460(12, 22, QuestRace.Ferre, new uint[] { 3459 })); //epic
            questsCanBeRun.Add(new Quest_3461(12, 22, QuestRace.Ferre, new uint[] { 3460 })); //epic
            questsCanBeRun.Add(new Quest_3462(12, 22, QuestRace.Ferre, new uint[] { 3461 })); //epic
            questsCanBeRun.Add(new Quest_2897(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2896 }));
            questsCanBeRun.Add(new Quest_2898(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2897 }));
            questsCanBeRun.Add(new Quest_885(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2898 }));
            questsCanBeRun.Add(new Quest_3543(12, 22, QuestRace.Hariharan, new uint[] { 3540 })); //epic
            questsCanBeRun.Add(new Quest_3463(12, 25, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_1694(12, 22, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_1694(12, 22, QuestRace.Hariharan, new uint[] { 2898 }));
            questsCanBeRun.Add(new Quest_2133(12, 22, QuestRace.Ferre, new uint[] { 3462 }, new uint[] { 1502 }));   //daily
            questsCanBeRun.Add(new Quest_2133(12, 22, QuestRace.Hariharan, new uint[] { 2898 }, new uint[] { 1502 }));   //daily
            questsCanBeRun.Add(new Quest_3598(12, 22, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_3598(12, 22, QuestRace.Hariharan, new uint[] { 2898 }));
            questsCanBeRun.Add(new Quest_2134(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3598 }));
            questsCanBeRun.Add(new Quest_2135(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2134, 885, 1694 }));
            questsCanBeRun.Add(new Quest_2136(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2135 }));
            questsCanBeRun.Add(new Quest_3604(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2136 }));
            questsCanBeRun.Add(new Quest_1502(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2136 }));
            questsCanBeRun.Add(new Quest_1503(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1502 }));
            questsCanBeRun.Add(new Quest_886(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3604 }));
            questsCanBeRun.Add(new Quest_1686(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 886 }));
            questsCanBeRun.Add(new Quest_4036(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1503 }));
            questsCanBeRun.Add(new Quest_3310(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_3309(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_4035(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_1504(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1686 }));
            questsCanBeRun.Add(new Quest_2902(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1686 }, new uint[] { 1505 }));    //daily
            questsCanBeRun.Add(new Quest_1687(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1504 }));
            questsCanBeRun.Add(new Quest_2901(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1504 }));
            questsCanBeRun.Add(new Quest_1505(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1687 }));
            questsCanBeRun.Add(new Quest_1507(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1505 }));
            questsCanBeRun.Add(new Quest_876(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1507 }));
            questsCanBeRun.Add(new Quest_870(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 876 }));
            questsCanBeRun.Add(new Quest_871(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 870 }));
            questsCanBeRun.Add(new Quest_873(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 871 }));
            questsCanBeRun.Add(new Quest_879(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 871 }));
            questsCanBeRun.Add(new Quest_872(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_880(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_2904(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 873, 879 }, new uint[] { 2138 }));   //daily
            questsCanBeRun.Add(new Quest_2903(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_917(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 872 }));
            questsCanBeRun.Add(new Quest_2138(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 917 }));
            questsCanBeRun.Add(new Quest_875(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2138 }));
            questsCanBeRun.Add(new Quest_874(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2138 }));
            questsCanBeRun.Add(new Quest_3606(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 874, 875 }));
            questsCanBeRun.Add(new Quest_863(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3606 }));
            questsCanBeRun.Add(new Quest_1508(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 863 }));
            questsCanBeRun.Add(new Quest_1509(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1508 }));
            questsCanBeRun.Add(new Quest_1510(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1514(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_899(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1512(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1511(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1691(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1511 }));
            questsCanBeRun.Add(new Quest_925(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1510, 1512, 1514, 899 }));
            questsCanBeRun.Add(new Quest_2139(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 925 }));
            questsCanBeRun.Add(new Quest_2906(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2139 }));
            questsCanBeRun.Add(new Quest_900(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2139 }));
            questsCanBeRun.Add(new Quest_877(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2139 }, new uint[] { 3312 }));        //daily
            questsCanBeRun.Add(new Quest_1517(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2906, 900 }));
            questsCanBeRun.Add(new Quest_3609(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2906, 900 }));
            questsCanBeRun.Add(new Quest_4311(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1517, 3609 }));
            questsCanBeRun.Add(new Quest_878(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1517, 3609 }));
            questsCanBeRun.Add(new Quest_3312(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4311 }));
            questsCanBeRun.Add(new Quest_3313(12, 22, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4311 }));
            #endregion
            #region Solis Headlands
            questsCanBeRun.Add(new Quest_1668(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 878 }));
            questsCanBeRun.Add(new Quest_1667(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1668 }));
            questsCanBeRun.Add(new Quest_1731(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1667 }));
            questsCanBeRun.Add(new Quest_951(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1731 }, new uint[] { 949 }));    //daily
            questsCanBeRun.Add(new Quest_942(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_943(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_3645(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_3646(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3645 }));
            questsCanBeRun.Add(new Quest_949(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 942, 943 }));
            questsCanBeRun.Add(new Quest_950(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 949 }));
            questsCanBeRun.Add(new Quest_748(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 950 }));
            questsCanBeRun.Add(new Quest_3544(17, 27, QuestRace.Hariharan, new uint[] { 3543 }));//epic
            questsCanBeRun.Add(new Quest_3464(17, 27, QuestRace.Ferre, new uint[] { 3463 }));//epic
            questsCanBeRun.Add(new Quest_3466(17, 27, QuestRace.Ferre, new uint[] { 3464 }));//epic
            questsCanBeRun.Add(new Quest_3450(17, 27, QuestRace.Ferre, new uint[] { 3466 }));//epic
            questsCanBeRun.Add(new Quest_3467(17, 27, QuestRace.Ferre, new uint[] { 3450 })); //epic
            questsCanBeRun.Add(new Quest_3649(17, 27, QuestRace.Ferre, new uint[] { 3450 }));
            questsCanBeRun.Add(new Quest_3649(17, 27, QuestRace.Hariharan, new uint[] { 3543 }));
            questsCanBeRun.Add(new Quest_3651(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3649 }));
            questsCanBeRun.Add(new Quest_3652(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3651 }));
            questsCanBeRun.Add(new Quest_752(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3652 }));
            questsCanBeRun.Add(new Quest_764(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 752 }, new uint[] { 3653 }));     //daily
            questsCanBeRun.Add(new Quest_765(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_766(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_750(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_4443(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_3707(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4443 }));
            questsCanBeRun.Add(new Quest_3653(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 750, 765, 766 }));
            questsCanBeRun.Add(new Quest_756(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3653 }));
            questsCanBeRun.Add(new Quest_1675(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_753(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_754(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_3658(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_755(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_1677(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1675 }));
            questsCanBeRun.Add(new Quest_1678(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1677 }));
            questsCanBeRun.Add(new Quest_1679(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1678 }));
            questsCanBeRun.Add(new Quest_1676(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1679 }));
            questsCanBeRun.Add(new Quest_3657(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 753, 754, 755, 3658 }));
            questsCanBeRun.Add(new Quest_1732(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3657 }));
            questsCanBeRun.Add(new Quest_3660(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1732 }));
            questsCanBeRun.Add(new Quest_3661(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3660 }));
            questsCanBeRun.Add(new Quest_3663(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3660 }));
            questsCanBeRun.Add(new Quest_3664(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3661, 3663 }));
            questsCanBeRun.Add(new Quest_3666(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3664 }));
            questsCanBeRun.Add(new Quest_3668(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3666 }));
            questsCanBeRun.Add(new Quest_3667(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3668 }));
            questsCanBeRun.Add(new Quest_3669(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3667 }));
            questsCanBeRun.Add(new Quest_3545(17, 27, QuestRace.Hariharan, new uint[] { 3544 })); //epic
            questsCanBeRun.Add(new Quest_3546(17, 27, QuestRace.Hariharan, new uint[] { 3545 })); //epic
            questsCanBeRun.Add(new Quest_3547(17, 27, QuestRace.Hariharan, new uint[] { 3546 })); //epic
            questsCanBeRun.Add(new Quest_3548(17, 27, QuestRace.Hariharan, new uint[] { 3547 })); //epic
            questsCanBeRun.Add(new Quest_3549(17, 27, QuestRace.Hariharan, new uint[] { 3548 })); //epic
            questsCanBeRun.Add(new Quest_3468(17, 27, QuestRace.Ferre, new uint[] { 3467 }));//epic
            questsCanBeRun.Add(new Quest_3469(17, 27, QuestRace.Ferre, new uint[] { 3468 }));//epic
            questsCanBeRun.Add(new Quest_3470(17, 27, QuestRace.Ferre, new uint[] { 3469 }));//epic
            questsCanBeRun.Add(new Quest_3471(17, 27, QuestRace.Ferre, new uint[] { 3470 }));//epic
            questsCanBeRun.Add(new Quest_3472(17, 27, QuestRace.Ferre, new uint[] { 3471 }));//epic
            questsCanBeRun.Add(new Quest_3670(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3669 }));
            questsCanBeRun.Add(new Quest_3672(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3669 }));
            questsCanBeRun.Add(new Quest_3674(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3672 }));
            questsCanBeRun.Add(new Quest_3677(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3674, 3670 }, new uint[] { 773 }));     //daily
            questsCanBeRun.Add(new Quest_3678(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_784(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_1709(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_947(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_3675(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3678, 784, 1709, 947 }));
            questsCanBeRun.Add(new Quest_773(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3675 }));
            questsCanBeRun.Add(new Quest_783(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 773 }));
            questsCanBeRun.Add(new Quest_3680(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 773 }));
            questsCanBeRun.Add(new Quest_782(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3680, 783 }));
            questsCanBeRun.Add(new Quest_3679(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 782 }));
            questsCanBeRun.Add(new Quest_774(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3679 }));
            questsCanBeRun.Add(new Quest_775(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 774 }));
            questsCanBeRun.Add(new Quest_3683(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 775 }));
            questsCanBeRun.Add(new Quest_3686(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3683 }));
            questsCanBeRun.Add(new Quest_3689(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3686 }));
            questsCanBeRun.Add(new Quest_3690(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3689 }));
            questsCanBeRun.Add(new Quest_3701(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3690 }));
            questsCanBeRun.Add(new Quest_3704(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3701 }));
            questsCanBeRun.Add(new Quest_3691(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3704 }));
            questsCanBeRun.Add(new Quest_3696(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3691 }));
            questsCanBeRun.Add(new Quest_3692(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_3693(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3696 }, new uint[] { 1688 }));       //daily
            questsCanBeRun.Add(new Quest_777(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_776(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_792(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_1688(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 792, 3692, 3693, 777, 776 }));
            questsCanBeRun.Add(new Quest_785(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1688 }));
            questsCanBeRun.Add(new Quest_788(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_3699(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_793(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_1682(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_3700(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1682, 793, 3699, 788 }));
            questsCanBeRun.Add(new Quest_795(17, 27, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3700 }));
            #endregion
            #region Singing Land
            questsCanBeRun.Add(new Quest_1857(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 795 }));
            questsCanBeRun.Add(new Quest_1858(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 795 }));
            questsCanBeRun.Add(new Quest_1859(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1857, 1858 }));
            questsCanBeRun.Add(new Quest_855(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1859 }));
            questsCanBeRun.Add(new Quest_1861(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 855 }));
            questsCanBeRun.Add(new Quest_1863(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1861 }));
            questsCanBeRun.Add(new Quest_1860(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1863 }));
            questsCanBeRun.Add(new Quest_1864(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1860 }));
            questsCanBeRun.Add(new Quest_799(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1864 }));
            questsCanBeRun.Add(new Quest_800(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 799 }));
            questsCanBeRun.Add(new Quest_798(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 800 }));
            questsCanBeRun.Add(new Quest_797(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 800 }));
            questsCanBeRun.Add(new Quest_802(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 798, 797 }));
            questsCanBeRun.Add(new Quest_796(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 802 }));
            questsCanBeRun.Add(new Quest_813(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_801(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_810(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_809(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 796 }));
            //814  - бот не умеет стрелять из чужого слейва
            questsCanBeRun.Add(new Quest_2045(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 809, 810, 801, 813 }));
            questsCanBeRun.Add(new Quest_3550(20, 30, QuestRace.Hariharan, new uint[] { 2045, 3549 })); //epic
            questsCanBeRun.Add(new Quest_3473(20, 30, QuestRace.Ferre, new uint[] { 2045, 3472 })); //epic
            questsCanBeRun.Add(new Quest_806(20, 30, QuestRace.Ferre, new uint[] { 2045, 3472 }));
            questsCanBeRun.Add(new Quest_806(20, 30, QuestRace.Hariharan, new uint[] { 2045, 3549 }));
            questsCanBeRun.Add(new Quest_3551(20, 30, QuestRace.Hariharan, new uint[] { 3550 })); //epic
            questsCanBeRun.Add(new Quest_3552(20, 30, QuestRace.Hariharan, new uint[] { 3551 })); //epic
            questsCanBeRun.Add(new Quest_3553(20, 30, QuestRace.Hariharan, new uint[] { 3552 })); //epic
            questsCanBeRun.Add(new Quest_3554(20, 30, QuestRace.Hariharan, new uint[] { 3553 })); //epic
            questsCanBeRun.Add(new Quest_3555(20, 30, QuestRace.Hariharan, new uint[] { 3554 })); //epic
            questsCanBeRun.Add(new Quest_3556(20, 30, QuestRace.Hariharan, new uint[] { 3555 })); //epic
            questsCanBeRun.Add(new Quest_3557(20, 30, QuestRace.Hariharan, new uint[] { 3556 })); //epic
            questsCanBeRun.Add(new Quest_3474(20, 30, QuestRace.Ferre, new uint[] { 3473 }));//epic
            questsCanBeRun.Add(new Quest_3475(20, 30, QuestRace.Ferre, new uint[] { 3474 }));//epic
            questsCanBeRun.Add(new Quest_3476(20, 30, QuestRace.Ferre, new uint[] { 3475 }));//epic
            questsCanBeRun.Add(new Quest_3478(20, 30, QuestRace.Ferre, new uint[] { 3476 }));//epic
            questsCanBeRun.Add(new Quest_3479(20, 30, QuestRace.Ferre, new uint[] { 3478 }));//epic
            questsCanBeRun.Add(new Quest_807(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_849(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_811(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_1852(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_812(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_819(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 807 }));
            questsCanBeRun.Add(new Quest_820(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 807 }));
            //questsCanBeRun.Add(new Quest_1227(20, 30, QuestRace.Ferre| QuestRace.Hariharan, new uint[] { 807 }, new uint[] { 824 }));        //daily можно сделать только днем адекватно.
            questsCanBeRun.Add(new Quest_815(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 807 }));
            questsCanBeRun.Add(new Quest_2057(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 815 }));
            questsCanBeRun.Add(new Quest_816(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2057 }));
            questsCanBeRun.Add(new Quest_1876(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 816 }));
            questsCanBeRun.Add(new Quest_824(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1876, 820, 819 }));
            questsCanBeRun.Add(new Quest_825(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 824 }));
            questsCanBeRun.Add(new Quest_818(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 825 }));
            questsCanBeRun.Add(new Quest_822(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 818 }));
            questsCanBeRun.Add(new Quest_823(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 822 }));
            questsCanBeRun.Add(new Quest_821(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 823 }));
            questsCanBeRun.Add(new Quest_826(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 821 }));
            questsCanBeRun.Add(new Quest_836(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 826 }));
            questsCanBeRun.Add(new Quest_817(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 826 }));
            questsCanBeRun.Add(new Quest_833(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 836 }));
            questsCanBeRun.Add(new Quest_830(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 836 }));
            questsCanBeRun.Add(new Quest_835(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 833 }));
            questsCanBeRun.Add(new Quest_831(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 835 }));
            questsCanBeRun.Add(new Quest_832(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 831, 830 }));
            questsCanBeRun.Add(new Quest_837(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_834(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_838(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_1856(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 834 }));
            questsCanBeRun.Add(new Quest_829(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1856 }));
            questsCanBeRun.Add(new Quest_1854(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 829, 837, 838 }));
            questsCanBeRun.Add(new Quest_841(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 829, 837, 838 }));
            questsCanBeRun.Add(new Quest_843(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 841, 1854 }));
            questsCanBeRun.Add(new Quest_839(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 841, 1854 }));
            questsCanBeRun.Add(new Quest_1851(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_844(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_842(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_840(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1851, 844, 842 }));
            questsCanBeRun.Add(new Quest_1464(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1851, 844, 842 }));
            questsCanBeRun.Add(new Quest_1463(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_906(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_856(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_963(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 906 }));
            questsCanBeRun.Add(new Quest_1415(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 906 }));
            questsCanBeRun.Add(new Quest_1435(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 856 }));
            questsCanBeRun.Add(new Quest_846(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1435 }));
            questsCanBeRun.Add(new Quest_848(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 846 }));
            questsCanBeRun.Add(new Quest_845(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 848 }));
            questsCanBeRun.Add(new Quest_851(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_852(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_853(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_854(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 852 }));
            questsCanBeRun.Add(new Quest_847(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 854 }));
            questsCanBeRun.Add(new Quest_1865(20, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 853 }));
            #endregion
            #region Old Forest
            questsCanBeRun.Add(new Quest_1303(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1865 }));
            questsCanBeRun.Add(new Quest_1305(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1865 }));
            questsCanBeRun.Add(new Quest_1304(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1303, 1305 }));
            questsCanBeRun.Add(new Quest_3905(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1303, 1305 }));
            questsCanBeRun.Add(new Quest_1311(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1304 }));
            questsCanBeRun.Add(new Quest_1312(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1311 }));
            questsCanBeRun.Add(new Quest_1313(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1312 }));
            questsCanBeRun.Add(new Quest_1310(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1306(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1307(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_2060(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1308(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1310, 1306, 1307 }));
            questsCanBeRun.Add(new Quest_3480(23, 30, QuestRace.Ferre, new uint[] { 1310, 1306, 1307 })); //epic
            questsCanBeRun.Add(new Quest_1320(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1308 }));
            questsCanBeRun.Add(new Quest_1834(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1320 }));
            questsCanBeRun.Add(new Quest_1316(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1314(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_2559(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1329(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1317(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1316 }));
            questsCanBeRun.Add(new Quest_1315(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1329, 1314 }));
            questsCanBeRun.Add(new Quest_2087(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_1330(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_2560(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_2561(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2560 }));
            questsCanBeRun.Add(new Quest_1321(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2560 }));
            questsCanBeRun.Add(new Quest_3558(23, 30, QuestRace.Hariharan, new uint[] { 2560 })); //epic 
            questsCanBeRun.Add(new Quest_1322(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2087 }));
            questsCanBeRun.Add(new Quest_1323(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1322 }));
            questsCanBeRun.Add(new Quest_3906(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1323 }));
            questsCanBeRun.Add(new Quest_1488(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1323 }));
            questsCanBeRun.Add(new Quest_1489(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1488, 3906 }));
            questsCanBeRun.Add(new Quest_1490(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1489 }));
            questsCanBeRun.Add(new Quest_1491(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1334(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1346(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1335(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1334 }));
            questsCanBeRun.Add(new Quest_3481(23, 30, QuestRace.Ferre, new uint[] { 3480 }));
            questsCanBeRun.Add(new Quest_2047(23, 30, QuestRace.Ferre, new uint[] { 3480 }));
            questsCanBeRun.Add(new Quest_2047(23, 30, QuestRace.Hariharan, new uint[] { 3558 }));
            questsCanBeRun.Add(new Quest_3559(23, 30, QuestRace.Hariharan, new uint[] { 3558, 2047 })); //epic 
            questsCanBeRun.Add(new Quest_2048(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2047 }));
            questsCanBeRun.Add(new Quest_2051(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2047 }));
            questsCanBeRun.Add(new Quest_3482(23, 30, QuestRace.Ferre, new uint[] { 3481 }));
            questsCanBeRun.Add(new Quest_3483(23, 30, QuestRace.Ferre, new uint[] { 3482 }));
            questsCanBeRun.Add(new Quest_3908(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1491 }));
            questsCanBeRun.Add(new Quest_2049(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2048 }));
            questsCanBeRun.Add(new Quest_2052(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2049 }));
            questsCanBeRun.Add(new Quest_1337(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1337(23, 30, QuestRace.Hariharan, new uint[] { 1330, 2561, 3559 }));
            questsCanBeRun.Add(new Quest_1331(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1331(23, 30, QuestRace.Hariharan, new uint[] { 1330, 2561, 3559 }));
            questsCanBeRun.Add(new Quest_1338(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1338(23, 30, QuestRace.Hariharan, new uint[] { 1330, 2561, 3559 }));
            questsCanBeRun.Add(new Quest_2695(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_2695(23, 30, QuestRace.Hariharan, new uint[] { 1330, 2561, 3559 }));
            questsCanBeRun.Add(new Quest_1340(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1340(23, 30, QuestRace.Hariharan, new uint[] { 1330, 2561, 3559 }));
            questsCanBeRun.Add(new Quest_1332(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1340, 1338, 2695, 1331 }));
            questsCanBeRun.Add(new Quest_3560(23, 30, QuestRace.Hariharan, new uint[] { 1332, 3559 })); //epic
            questsCanBeRun.Add(new Quest_1341(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_2696(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_1339(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_1342(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1339 }));
            questsCanBeRun.Add(new Quest_1343(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1342 }));
            questsCanBeRun.Add(new Quest_1744(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1343 }));
            questsCanBeRun.Add(new Quest_1344(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1744 }));
            questsCanBeRun.Add(new Quest_1492(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1344 }));
            questsCanBeRun.Add(new Quest_1493(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1492 }));
            questsCanBeRun.Add(new Quest_1345(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1493 }));
            questsCanBeRun.Add(new Quest_1743(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 1493 }));
            questsCanBeRun.Add(new Quest_2697(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_1348(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_1494(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_2907(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2697, 1348, 1494 }));
            questsCanBeRun.Add(new Quest_2767(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2907 }));
            questsCanBeRun.Add(new Quest_2106(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2907 }));
            questsCanBeRun.Add(new Quest_3909(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2907 }, new uint[] { 2065 }));           //daily
            questsCanBeRun.Add(new Quest_1745(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2907 }));
            questsCanBeRun.Add(new Quest_2068(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2767 }));
            questsCanBeRun.Add(new Quest_2065(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2068 }));
            questsCanBeRun.Add(new Quest_2067(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2068 }));
            questsCanBeRun.Add(new Quest_2066(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2067, 2065 }));
            questsCanBeRun.Add(new Quest_2069(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2106 }));
            questsCanBeRun.Add(new Quest_2951(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2069 }));
            #endregion
            #region Ynystere
            questsCanBeRun.Add(new Quest_2271(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2951 }));
            questsCanBeRun.Add(new Quest_2275(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2271 }));
            questsCanBeRun.Add(new Quest_2272(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2275 }));
            questsCanBeRun.Add(new Quest_2273(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2272 }));
            questsCanBeRun.Add(new Quest_2274(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2273 }));
            questsCanBeRun.Add(new Quest_2276(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2274 }));
            questsCanBeRun.Add(new Quest_2278(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2276 }));
            questsCanBeRun.Add(new Quest_2283(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2278 }));
            questsCanBeRun.Add(new Quest_2301(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2283 }));
            questsCanBeRun.Add(new Quest_2288(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2301 }));
            questsCanBeRun.Add(new Quest_2285(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2301 }));
            questsCanBeRun.Add(new Quest_2286(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2285 }));
            questsCanBeRun.Add(new Quest_2290(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2288 }));
            questsCanBeRun.Add(new Quest_2292(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2290 }));
            questsCanBeRun.Add(new Quest_2293(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2292 }));
            questsCanBeRun.Add(new Quest_2280(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2293 }));
            questsCanBeRun.Add(new Quest_2973(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2293 }));
            questsCanBeRun.Add(new Quest_2920(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2973, 2280 }));
            questsCanBeRun.Add(new Quest_4193(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2920 }));
            questsCanBeRun.Add(new Quest_2918(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4193 }));
            questsCanBeRun.Add(new Quest_2277(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2918 }));
            questsCanBeRun.Add(new Quest_2279(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2277 }));
            questsCanBeRun.Add(new Quest_4194(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2277 }));
            questsCanBeRun.Add(new Quest_2819(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4194 }));
            questsCanBeRun.Add(new Quest_2346(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2819 }));
            questsCanBeRun.Add(new Quest_2282(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2279 }));
            questsCanBeRun.Add(new Quest_2289(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2346 }));
            questsCanBeRun.Add(new Quest_2922(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2289 }));
            questsCanBeRun.Add(new Quest_2281(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2922 }));
            questsCanBeRun.Add(new Quest_2932(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2282 }));
            questsCanBeRun.Add(new Quest_2915(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2282 }));
            questsCanBeRun.Add(new Quest_4195(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2915 }));
            questsCanBeRun.Add(new Quest_2930(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2915 }));
            questsCanBeRun.Add(new Quest_2294(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2930, 4195 }));
            questsCanBeRun.Add(new Quest_2295(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2294 }));
            questsCanBeRun.Add(new Quest_2296(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2294 }));
            questsCanBeRun.Add(new Quest_2297(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2296 }));
            questsCanBeRun.Add(new Quest_2298(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2297 }));
            questsCanBeRun.Add(new Quest_2299(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2295, 2298 }));
            questsCanBeRun.Add(new Quest_2305(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2299 }));
            questsCanBeRun.Add(new Quest_4206(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2305 }));
            questsCanBeRun.Add(new Quest_2306(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4206 }));
            questsCanBeRun.Add(new Quest_2308(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4206 }));
            questsCanBeRun.Add(new Quest_4197(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4206 }));
            questsCanBeRun.Add(new Quest_4198(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4197 }));
            questsCanBeRun.Add(new Quest_2344(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2306 }));
            questsCanBeRun.Add(new Quest_2307(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2344 }));
            questsCanBeRun.Add(new Quest_2310(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2307 }));
            questsCanBeRun.Add(new Quest_4199(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2307 }));
            questsCanBeRun.Add(new Quest_2311(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2310 }));
            questsCanBeRun.Add(new Quest_4200(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2310 }));
            questsCanBeRun.Add(new Quest_2312(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2311 }));
            questsCanBeRun.Add(new Quest_2313(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2311 }));
            questsCanBeRun.Add(new Quest_4202(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2313 }));
            questsCanBeRun.Add(new Quest_2316(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4202 }));
            questsCanBeRun.Add(new Quest_4201(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2313 }));
            questsCanBeRun.Add(new Quest_2314(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2312 }));
            questsCanBeRun.Add(new Quest_4203(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2314 }));
            questsCanBeRun.Add(new Quest_2929(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2314 }));
            questsCanBeRun.Add(new Quest_2320(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4203 }));
            questsCanBeRun.Add(new Quest_4205(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4203 }));
            questsCanBeRun.Add(new Quest_2928(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4203 }));
            questsCanBeRun.Add(new Quest_2927(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2928 }));
            questsCanBeRun.Add(new Quest_2322(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2320 }));
            questsCanBeRun.Add(new Quest_2919(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2322 }));
            questsCanBeRun.Add(new Quest_2327(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2919 }));
            questsCanBeRun.Add(new Quest_4207(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2919 }));
            questsCanBeRun.Add(new Quest_2343(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4207, 2327 }));
            questsCanBeRun.Add(new Quest_2331(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4207, 2327 }));
            questsCanBeRun.Add(new Quest_4208(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2331, 2343 }));
            questsCanBeRun.Add(new Quest_4210(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4208 }));
            questsCanBeRun.Add(new Quest_4209(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4208 }));
            questsCanBeRun.Add(new Quest_4211(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4209, 4210 }));
            questsCanBeRun.Add(new Quest_4212(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4209, 4210 }));
            questsCanBeRun.Add(new Quest_4213(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4209, 4210 }));
            questsCanBeRun.Add(new Quest_2334(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4211, 4212, 4213 }));
            questsCanBeRun.Add(new Quest_2515(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2334 }));
            questsCanBeRun.Add(new Quest_2335(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2515 }));
            questsCanBeRun.Add(new Quest_2333(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2335 }));
            questsCanBeRun.Add(new Quest_2336(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2335 }));
            questsCanBeRun.Add(new Quest_2337(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2333 }));
            questsCanBeRun.Add(new Quest_2340(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2337 }));
            questsCanBeRun.Add(new Quest_2341(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2340 }));
            questsCanBeRun.Add(new Quest_2338(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2341 }));
            questsCanBeRun.Add(new Quest_2937(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2341 }, new uint[] { 4214 }));  //daily
            questsCanBeRun.Add(new Quest_2339(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2338 }));
            questsCanBeRun.Add(new Quest_2923(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2339 }));
            questsCanBeRun.Add(new Quest_4214(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2923 }));
            questsCanBeRun.Add(new Quest_2924(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 4214 }));
            questsCanBeRun.Add(new Quest_2345(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2924 }));
            questsCanBeRun.Add(new Quest_3227(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 2345 }));
            
            #endregion
            #region Gweonid Forest
            questsCanBeRun.Add(new Quest_16(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { }));
            questsCanBeRun.Add(new Quest_10(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 16 }));
            questsCanBeRun.Add(new Quest_11(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 10 }));
            questsCanBeRun.Add(new Quest_15(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 11 }));
            questsCanBeRun.Add(new Quest_17(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 15 }));
            questsCanBeRun.Add(new Quest_64(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 17 }));
            questsCanBeRun.Add(new Quest_2476(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 64 }));
            questsCanBeRun.Add(new Quest_52(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 2476 }));
            questsCanBeRun.Add(new Quest_24(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 52 }));
            questsCanBeRun.Add(new Quest_38(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 24 }));
            questsCanBeRun.Add(new Quest_2385(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 38 }));
            questsCanBeRun.Add(new Quest_2386(1, 15, QuestRace.Elf | QuestRace.Nuian, new uint[] { 2385 }));

            #endregion
            #region Solzreed Peninsula
            questsCanBeRun.Add(new Quest_330(1, 15, QuestRace.Nuian, new uint[] { }));
            questsCanBeRun.Add(new Quest_250(1, 15, QuestRace.Nuian, new uint[] { 330 }, new uint[] { 325 })); //daily
            questsCanBeRun.Add(new Quest_6198(1, 15, QuestRace.Nuian, new uint[] { 250 }));
            questsCanBeRun.Add(new Quest_2531(1, 15, QuestRace.Nuian, new uint[] { 250 })); //epic
            questsCanBeRun.Add(new Quest_251(1, 15, QuestRace.Nuian, new uint[] { 6198, 2531 }));
            questsCanBeRun.Add(new Quest_324(1, 15, QuestRace.Nuian, new uint[] { 251 }));
            questsCanBeRun.Add(new Quest_2532(1, 15, QuestRace.Nuian, new uint[] { 251 })); //epic
            questsCanBeRun.Add(new Quest_252(1, 15, QuestRace.Nuian, new uint[] { 251 }));
            questsCanBeRun.Add(new Quest_325(1, 15, QuestRace.Nuian, new uint[] { 324 }));
            questsCanBeRun.Add(new Quest_254(1, 15, QuestRace.Nuian, new uint[] { 325 }));
            questsCanBeRun.Add(new Quest_329(1, 15, QuestRace.Nuian, new uint[] { 325 }, new uint[] { 1725 })); //daily
            questsCanBeRun.Add(new Quest_255(1, 15, QuestRace.Nuian, new uint[] { 254 }));
            questsCanBeRun.Add(new Quest_256(1, 15, QuestRace.Nuian, new uint[] { 255 }));
            questsCanBeRun.Add(new Quest_1725(1, 15, QuestRace.Nuian, new uint[] { 256 }));
            questsCanBeRun.Add(new Quest_257(1, 15, QuestRace.Nuian, new uint[] { 256 }));
            questsCanBeRun.Add(new Quest_260(1, 15, QuestRace.Nuian, new uint[] { 1725 }));
            questsCanBeRun.Add(new Quest_261(1, 15, QuestRace.Nuian, new uint[] { 260 }));
            questsCanBeRun.Add(new Quest_1652(1, 15, QuestRace.Nuian, new uint[] { 261 }, new uint[] { 259 })); //daily
            questsCanBeRun.Add(new Quest_259(1, 15, QuestRace.Nuian, new uint[] { 257 }));
            questsCanBeRun.Add(new Quest_2255(1, 15, QuestRace.Nuian, new uint[] { 2532 })); //epic
            questsCanBeRun.Add(new Quest_2256(1, 15, QuestRace.Nuian, new uint[] { 2255 })); //epic
            questsCanBeRun.Add(new Quest_2257(1, 15, QuestRace.Nuian, new uint[] { 2256 })); //epic
            questsCanBeRun.Add(new Quest_266(1, 15, QuestRace.Nuian, new uint[] { 259 }));
            questsCanBeRun.Add(new Quest_354(1, 15, QuestRace.Nuian, new uint[] { 266 }));
            questsCanBeRun.Add(new Quest_2762(1, 15, QuestRace.Nuian, new uint[] { 266 }));
            questsCanBeRun.Add(new Quest_2258(1, 15, QuestRace.Nuian, new uint[] { 2257 })); //epic
            questsCanBeRun.Add(new Quest_265(1, 15, QuestRace.Nuian, new uint[] { 354 }));
            questsCanBeRun.Add(new Quest_4292(1, 15, QuestRace.Nuian, new uint[] { 265 }));
            questsCanBeRun.Add(new Quest_4294(1, 15, QuestRace.Nuian, new uint[] { 4292 }));
            questsCanBeRun.Add(new Quest_4295(1, 15, QuestRace.Nuian, new uint[] { 4294 }));
            questsCanBeRun.Add(new Quest_263(1, 15, QuestRace.Nuian, new uint[] { 4295 }));
            questsCanBeRun.Add(new Quest_2400(1, 15, QuestRace.Nuian, new uint[] { 263 }));
            questsCanBeRun.Add(new Quest_350(1, 15, QuestRace.Nuian, new uint[] { 263 }));
            questsCanBeRun.Add(new Quest_6161(1, 15, QuestRace.Nuian, new uint[] { 350 }));
            questsCanBeRun.Add(new Quest_2259(1, 15, QuestRace.Nuian, new uint[] { 2258 })); //epic
            questsCanBeRun.Add(new Quest_2245(1, 15, QuestRace.Nuian, new uint[] { 2400 }));
            questsCanBeRun.Add(new Quest_2260(1, 15, QuestRace.Nuian, new uint[] { 2259 })); //epic
            questsCanBeRun.Add(new Quest_2393(1, 15, QuestRace.Nuian, new uint[] { 2245 }));
            questsCanBeRun.Add(new Quest_2246(1, 15, QuestRace.Nuian, new uint[] { 2393 }));
            questsCanBeRun.Add(new Quest_1525(1, 15, QuestRace.Nuian, new uint[] { 2260 })); //epic
            questsCanBeRun.Add(new Quest_2248(1, 15, QuestRace.Nuian, new uint[] { 2260 }));
            questsCanBeRun.Add(new Quest_2263(1, 15, QuestRace.Nuian, new uint[] { 1525 })); //epic
            questsCanBeRun.Add(new Quest_2413(1, 15, QuestRace.Nuian, new uint[] { 1525 }));
            questsCanBeRun.Add(new Quest_2261(1, 15, QuestRace.Nuian, new uint[] { 2263 })); //epic
            questsCanBeRun.Add(new Quest_3503(1, 15, QuestRace.Nuian, new uint[] { 2261 })); //epic
            questsCanBeRun.Add(new Quest_346(1, 15, QuestRace.Nuian, new uint[] { 2261 }, new uint[] { 345 })); //daily
            questsCanBeRun.Add(new Quest_345(1, 15, QuestRace.Nuian, new uint[] { 2248 }));
            questsCanBeRun.Add(new Quest_347(1, 15, QuestRace.Nuian, new uint[] { 345 }));
            questsCanBeRun.Add(new Quest_269(1, 15, QuestRace.Nuian, new uint[] { 347 }));
            questsCanBeRun.Add(new Quest_271(1, 15, QuestRace.Nuian, new uint[] { 269 }));
            questsCanBeRun.Add(new Quest_270(1, 15, QuestRace.Nuian, new uint[] { 269 }));
            questsCanBeRun.Add(new Quest_2251(1, 15, QuestRace.Nuian, new uint[] { 270, 271 }));
            questsCanBeRun.Add(new Quest_273(1, 15, QuestRace.Nuian, new uint[] { 2251 }));
            questsCanBeRun.Add(new Quest_2249(1, 15, QuestRace.Nuian, new uint[] { 273 }));
            questsCanBeRun.Add(new Quest_2262(1, 15, QuestRace.Nuian, new uint[] { 3503 })); //epic
            questsCanBeRun.Add(new Quest_299(1, 15, QuestRace.Nuian, new uint[] { 3503 }));
            questsCanBeRun.Add(new Quest_300(1, 15, QuestRace.Nuian, new uint[] { 299 }));
            questsCanBeRun.Add(new Quest_290(1, 15, QuestRace.Nuian, new uint[] { 299 }));
            questsCanBeRun.Add(new Quest_2264(1, 15, QuestRace.Nuian, new uint[] { 2262 })); //epic
            questsCanBeRun.Add(new Quest_291(1, 15, QuestRace.Nuian, new uint[] { 290 }));
            questsCanBeRun.Add(new Quest_2265(1, 15, QuestRace.Nuian, new uint[] { 2264 })); //epic
            questsCanBeRun.Add(new Quest_298(1, 15, QuestRace.Nuian, new uint[] { 2264 }));
            questsCanBeRun.Add(new Quest_5146(1, 15, QuestRace.Nuian, new uint[] { 2264 }));
            questsCanBeRun.Add(new Quest_303(1, 15, QuestRace.Nuian, new uint[] { 2264 }));
            questsCanBeRun.Add(new Quest_304(1, 15, QuestRace.Nuian, new uint[] { 303 }));
            questsCanBeRun.Add(new Quest_2266(1, 15, QuestRace.Nuian, new uint[] { 2265 })); //epic
            
            #endregion
            #region Lilyut Hills
            questsCanBeRun.Add(new Quest_2485(1, 15, QuestRace.Nuian, new uint[] { 2266 })); //epic
            questsCanBeRun.Add(new Quest_1584(1, 15, QuestRace.Nuian, new uint[] { 2266 }));
            questsCanBeRun.Add(new Quest_1583(1, 15, QuestRace.Nuian, new uint[] { 2266 }));
            questsCanBeRun.Add(new Quest_1586(1, 15, QuestRace.Nuian, new uint[] { 1583, 1584 }));
            questsCanBeRun.Add(new Quest_4393(1, 15, QuestRace.Nuian, new uint[] { 2485 })); //epic
            questsCanBeRun.Add(new Quest_4415(1, 15, QuestRace.Nuian, new uint[] { 5146 }));
            questsCanBeRun.Add(new Quest_4479(1, 15, QuestRace.Nuian, new uint[] { 4415 }));
            questsCanBeRun.Add(new Quest_4417(1, 15, QuestRace.Nuian, new uint[] { 4479 }));
            questsCanBeRun.Add(new Quest_4424(1, 15, QuestRace.Nuian, new uint[] { 4417 }));
            questsCanBeRun.Add(new Quest_4439(1, 15, QuestRace.Nuian, new uint[] { 4424 }));
            questsCanBeRun.Add(new Quest_4438(1, 15, QuestRace.Nuian, new uint[] { 4439 }));
            questsCanBeRun.Add(new Quest_1588(1, 15, QuestRace.Nuian, new uint[] { 4438 }));
            questsCanBeRun.Add(new Quest_1591(1, 15, QuestRace.Nuian, new uint[] { 4438 }));
            questsCanBeRun.Add(new Quest_1582(1, 15, QuestRace.Nuian, new uint[] { 1588, 1591 }));
            questsCanBeRun.Add(new Quest_1580(1, 15, QuestRace.Nuian, new uint[] { 1588, 1591 }));
            questsCanBeRun.Add(new Quest_1638(1, 15, QuestRace.Nuian, new uint[] { 1580, 1582 }));
            questsCanBeRun.Add(new Quest_6024(1, 15, QuestRace.Nuian, new uint[] { 1580, 1582 }));
            questsCanBeRun.Add(new Quest_1690(1, 15, QuestRace.Nuian, new uint[] { 1638 }));
            questsCanBeRun.Add(new Quest_1590(1, 15, QuestRace.Nuian, new uint[] { 1638 }, new uint[] { 1597 })); //daily
            questsCanBeRun.Add(new Quest_1596(1, 15, QuestRace.Nuian, new uint[] { 1638 }));
            questsCanBeRun.Add(new Quest_1595(1, 15, QuestRace.Nuian, new uint[] { 1690 }));
            questsCanBeRun.Add(new Quest_1597(1, 15, QuestRace.Nuian, new uint[] { 1690 }));
            questsCanBeRun.Add(new Quest_1598(1, 15, QuestRace.Nuian, new uint[] { 1597, 1595 }));
            questsCanBeRun.Add(new Quest_2684(1, 15, QuestRace.Nuian, new uint[] { 1597, 1595 }));
            questsCanBeRun.Add(new Quest_2486(1, 15, QuestRace.Nuian, new uint[] { 4393 })); //epic
            questsCanBeRun.Add(new Quest_3573(1, 15, QuestRace.Nuian, new uint[] { 2486 })); //epic
            questsCanBeRun.Add(new Quest_2488(1, 15, QuestRace.Nuian, new uint[] { 3573 })); //epic
            questsCanBeRun.Add(new Quest_1601(1, 15, QuestRace.Nuian, new uint[] { 3573 })); 
            questsCanBeRun.Add(new Quest_1599(1, 15, QuestRace.Nuian, new uint[] { 3573 })); 
            questsCanBeRun.Add(new Quest_1600(1, 15, QuestRace.Nuian, new uint[] { 3573 })); 
            questsCanBeRun.Add(new Quest_1602(1, 15, QuestRace.Nuian, new uint[] { 3573 }));
            questsCanBeRun.Add(new Quest_6213(1, 15, QuestRace.Nuian, new uint[] { 1600, 1599 }));
            questsCanBeRun.Add(new Quest_6224(1, 15, QuestRace.Nuian, new uint[] { 6213 }));
            questsCanBeRun.Add(new Quest_4121(1, 15, QuestRace.Nuian, new uint[] { 6224 }));
            questsCanBeRun.Add(new Quest_1604(1, 15, QuestRace.Nuian, new uint[] { 4121 }));
            questsCanBeRun.Add(new Quest_1605(1, 15, QuestRace.Nuian, new uint[] { 4121 }));
            questsCanBeRun.Add(new Quest_4122(1, 15, QuestRace.Nuian, new uint[] { 4121 }));
            questsCanBeRun.Add(new Quest_4123(1, 15, QuestRace.Nuian, new uint[] { 4122, 1604, 1605 }));
            questsCanBeRun.Add(new Quest_1607(1, 15, QuestRace.Nuian, new uint[] { 4123 }));
            questsCanBeRun.Add(new Quest_1608(1, 15, QuestRace.Nuian, new uint[] { 4123 }));
            questsCanBeRun.Add(new Quest_1609(1, 15, QuestRace.Nuian, new uint[] { 1608 }));
            questsCanBeRun.Add(new Quest_1610(1, 15, QuestRace.Nuian, new uint[] { 1609 }));
            questsCanBeRun.Add(new Quest_1612(1, 15, QuestRace.Nuian, new uint[] { 1610 }));
            questsCanBeRun.Add(new Quest_2489(1, 15, QuestRace.Nuian, new uint[] { 2488 })); //epic
            questsCanBeRun.Add(new Quest_1614(1, 15, QuestRace.Nuian, new uint[] { 2488 }));
            questsCanBeRun.Add(new Quest_1615(1, 15, QuestRace.Nuian, new uint[] { 1614 }));
            questsCanBeRun.Add(new Quest_1618(1, 15, QuestRace.Nuian, new uint[] { 1615 }));
            questsCanBeRun.Add(new Quest_1593(1, 15, QuestRace.Nuian, new uint[] { 1615 }, new uint[] { 1618 }));  //daily
            questsCanBeRun.Add(new Quest_1613(1, 15, QuestRace.Nuian, new uint[] { 1618 }));
            questsCanBeRun.Add(new Quest_4394(1, 15, QuestRace.Nuian, new uint[] { 2489 }));//epic
            questsCanBeRun.Add(new Quest_1622(1, 15, QuestRace.Nuian, new uint[] { 2489 }));
            questsCanBeRun.Add(new Quest_1620(1, 15, QuestRace.Nuian, new uint[] { 2489 }));
            questsCanBeRun.Add(new Quest_1619(1, 15, QuestRace.Nuian, new uint[] { 2489 }));
            questsCanBeRun.Add(new Quest_4218(1, 15, QuestRace.Nuian, new uint[] { 2489 }));
            questsCanBeRun.Add(new Quest_1623(1, 15, QuestRace.Nuian, new uint[] { 1619, 1622, 1620, 4394 }));
            questsCanBeRun.Add(new Quest_4396(1, 15, QuestRace.Nuian, new uint[] { 1619, 1622, 1620, 4394 }));//epic
            questsCanBeRun.Add(new Quest_1634(1, 15, QuestRace.Nuian, new uint[] { 1623 }));
            questsCanBeRun.Add(new Quest_1624(1, 15, QuestRace.Nuian, new uint[] { 1634 }));
            questsCanBeRun.Add(new Quest_1625(1, 15, QuestRace.Nuian, new uint[] { 1624 }));
            questsCanBeRun.Add(new Quest_1633(1, 15, QuestRace.Nuian, new uint[] { 1625 }));
            questsCanBeRun.Add(new Quest_1635(1, 15, QuestRace.Nuian, new uint[] { 1633 }));
            questsCanBeRun.Add(new Quest_2490(1, 15, QuestRace.Nuian, new uint[] { 4396 }));//epic
            questsCanBeRun.Add(new Quest_1631(1, 15, QuestRace.Nuian, new uint[] { 1635 }));
            #endregion
            #region Dewstone Plains
            questsCanBeRun.Add(new Quest_43(1, 15, QuestRace.Nuian, new uint[] { 1635 }));
            questsCanBeRun.Add(new Quest_44(1, 15, QuestRace.Nuian, new uint[] { 43, 1631 }));
            questsCanBeRun.Add(new Quest_328(1, 15, QuestRace.Nuian, new uint[] { 44 }));
            questsCanBeRun.Add(new Quest_1656(1, 15, QuestRace.Nuian, new uint[] { 328 }));
            questsCanBeRun.Add(new Quest_2491(1, 15, QuestRace.Nuian, new uint[] { 2490 }));//epic
            questsCanBeRun.Add(new Quest_3708(1, 15, QuestRace.Nuian, new uint[] { 2490 }));
            questsCanBeRun.Add(new Quest_918(1, 15, QuestRace.Nuian, new uint[] { 2490 }));
            questsCanBeRun.Add(new Quest_71(1, 15, QuestRace.Nuian, new uint[] { 918 }));
            questsCanBeRun.Add(new Quest_48(1, 15, QuestRace.Nuian, new uint[] { 71 }));
            questsCanBeRun.Add(new Quest_3758(1, 15, QuestRace.Nuian, new uint[] { 71 }));
            questsCanBeRun.Add(new Quest_3706(1, 15, QuestRace.Nuian, new uint[] { 3758 }));
            questsCanBeRun.Add(new Quest_921(1, 15, QuestRace.Nuian, new uint[] { 3706 }));
            questsCanBeRun.Add(new Quest_55(1, 15, QuestRace.Nuian, new uint[] { 48 }));
            questsCanBeRun.Add(new Quest_922(1, 15, QuestRace.Nuian, new uint[] { 921 }));
            questsCanBeRun.Add(new Quest_920(1, 15, QuestRace.Nuian, new uint[] { 921 }, new uint[] { 3712 })); //daily
            questsCanBeRun.Add(new Quest_3709(1, 15, QuestRace.Nuian, new uint[] { 921 }));
            questsCanBeRun.Add(new Quest_3712(1, 15, QuestRace.Nuian, new uint[] { 922 }));
            questsCanBeRun.Add(new Quest_3710(1, 15, QuestRace.Nuian, new uint[] { 922 }));
            questsCanBeRun.Add(new Quest_3713(1, 15, QuestRace.Nuian, new uint[] { 3712 }));
            questsCanBeRun.Add(new Quest_3714(1, 15, QuestRace.Nuian, new uint[] { 3713 }));
            questsCanBeRun.Add(new Quest_3711(1, 15, QuestRace.Nuian, new uint[] { 3710 }));
            questsCanBeRun.Add(new Quest_76(1, 15, QuestRace.Nuian, new uint[] { 3711 }));
            questsCanBeRun.Add(new Quest_3715(1, 15, QuestRace.Nuian, new uint[] { 3711 }));
            questsCanBeRun.Add(new Quest_3716(1, 15, QuestRace.Nuian, new uint[] { 76 }));
            questsCanBeRun.Add(new Quest_77(1, 15, QuestRace.Nuian, new uint[] { 76 }));
            questsCanBeRun.Add(new Quest_45(1, 15, QuestRace.Nuian, new uint[] { 3716 }));
            questsCanBeRun.Add(new Quest_49(1, 15, QuestRace.Nuian, new uint[] { 3716 }));
            questsCanBeRun.Add(new Quest_59(1, 15, QuestRace.Nuian, new uint[] { 55, 45 }));
            questsCanBeRun.Add(new Quest_54(1, 15, QuestRace.Nuian, new uint[] { 55, 45 })); 
            questsCanBeRun.Add(new Quest_1424(1, 15, QuestRace.Nuian, new uint[] { 59 })); //epic
            questsCanBeRun.Add(new Quest_2492(1, 15, QuestRace.Nuian, new uint[] { 1424 })); //epic
            questsCanBeRun.Add(new Quest_4397(1, 15, QuestRace.Nuian, new uint[] { 2492 })); //epic
            questsCanBeRun.Add(new Quest_331(1, 15, QuestRace.Nuian, new uint[] { 2492 }));
            questsCanBeRun.Add(new Quest_3719(1, 15, QuestRace.Nuian, new uint[] { 331 }));
            questsCanBeRun.Add(new Quest_46(1, 15, QuestRace.Nuian, new uint[] { 331 }));
            questsCanBeRun.Add(new Quest_931(1, 15, QuestRace.Nuian, new uint[] { 331 }));
            questsCanBeRun.Add(new Quest_79(1, 15, QuestRace.Nuian, new uint[] { 3719 }));
            questsCanBeRun.Add(new Quest_3720(1, 15, QuestRace.Nuian, new uint[] { 3719 }));
            questsCanBeRun.Add(new Quest_3721(1, 15, QuestRace.Nuian, new uint[] { 3720, 79 }));
            questsCanBeRun.Add(new Quest_47(1, 15, QuestRace.Nuian, new uint[] { 3720, 79 }));
            questsCanBeRun.Add(new Quest_67(1, 15, QuestRace.Nuian, new uint[] { 47 }));
            questsCanBeRun.Add(new Quest_317(1, 15, QuestRace.Nuian, new uint[] { 67 }));
            questsCanBeRun.Add(new Quest_65(1, 15, QuestRace.Nuian, new uint[] { 317 }));
            questsCanBeRun.Add(new Quest_3722(1, 15, QuestRace.Nuian, new uint[] { 3721 }));
            questsCanBeRun.Add(new Quest_3723(1, 15, QuestRace.Nuian, new uint[] { 3722 }));
            questsCanBeRun.Add(new Quest_3724(1, 15, QuestRace.Nuian, new uint[] { 3723 }));
            questsCanBeRun.Add(new Quest_3725(1, 15, QuestRace.Nuian, new uint[] { 3724 }));
            questsCanBeRun.Add(new Quest_2494(1, 15, QuestRace.Nuian, new uint[] { 4397 })); //epic
            questsCanBeRun.Add(new Quest_2495(1, 15, QuestRace.Nuian, new uint[] { 2494 })); //epic
            questsCanBeRun.Add(new Quest_84(1, 15, QuestRace.Nuian, new uint[] { 65 }));
            questsCanBeRun.Add(new Quest_3730(1, 15, QuestRace.Nuian, new uint[] { 84 }));
            questsCanBeRun.Add(new Quest_78(1, 15, QuestRace.Nuian, new uint[] { 3730 }));
            questsCanBeRun.Add(new Quest_3731(1, 15, QuestRace.Nuian, new uint[] { 3730 }));
            questsCanBeRun.Add(new Quest_333(1, 15, QuestRace.Nuian, new uint[] { 3730 }));
            questsCanBeRun.Add(new Quest_3732(1, 15, QuestRace.Nuian, new uint[] { 3730 }));
            questsCanBeRun.Add(new Quest_96(1, 15, QuestRace.Nuian, new uint[] { 3730 }));
            questsCanBeRun.Add(new Quest_3733(1, 15, QuestRace.Nuian, new uint[] { 3731 }));
            questsCanBeRun.Add(new Quest_3734(1, 15, QuestRace.Nuian, new uint[] { 3731 }));
            questsCanBeRun.Add(new Quest_88(1, 15, QuestRace.Nuian, new uint[] { 3731 }));
            questsCanBeRun.Add(new Quest_94(1, 15, QuestRace.Nuian, new uint[] { 3731 }));
            questsCanBeRun.Add(new Quest_928(1, 15, QuestRace.Nuian, new uint[] { 3731 }));
            questsCanBeRun.Add(new Quest_3735(1, 15, QuestRace.Nuian, new uint[] { 3734 }));
            questsCanBeRun.Add(new Quest_3737(1, 15, QuestRace.Nuian, new uint[] { 3734 }));
            questsCanBeRun.Add(new Quest_3738(1, 15, QuestRace.Nuian, new uint[] { 3737 }));
            questsCanBeRun.Add(new Quest_61(1, 15, QuestRace.Nuian, new uint[] { 3737 }));
            questsCanBeRun.Add(new Quest_63(1, 15, QuestRace.Nuian, new uint[] { 61 }));
            questsCanBeRun.Add(new Quest_935(1, 15, QuestRace.Nuian, new uint[] { 63 }));
            questsCanBeRun.Add(new Quest_82(1, 15, QuestRace.Nuian, new uint[] { 63 }));
            questsCanBeRun.Add(new Quest_961(1, 15, QuestRace.Nuian, new uint[] { 63 }));
            questsCanBeRun.Add(new Quest_3746(1, 15, QuestRace.Nuian, new uint[] { 63 }));
            questsCanBeRun.Add(new Quest_3747(1, 15, QuestRace.Nuian, new uint[] { 3746 }));
            questsCanBeRun.Add(new Quest_99(1, 15, QuestRace.Nuian, new uint[] { 82 }));
            questsCanBeRun.Add(new Quest_319(1, 15, QuestRace.Nuian, new uint[] { 99 }));
            questsCanBeRun.Add(new Quest_1661(1, 15, QuestRace.Nuian, new uint[] { 319 }));
            questsCanBeRun.Add(new Quest_80(1, 15, QuestRace.Nuian, new uint[] { 961 }));
            questsCanBeRun.Add(new Quest_1664(1, 15, QuestRace.Nuian, new uint[] { 961 }));
            questsCanBeRun.Add(new Quest_2496(1, 15, QuestRace.Nuian, new uint[] { 2495 })); //epic
            questsCanBeRun.Add(new Quest_4398(1, 15, QuestRace.Nuian, new uint[] { 2496 })); //epic
            questsCanBeRun.Add(new Quest_3740(1, 15, QuestRace.Nuian, new uint[] { 1664 }));
            questsCanBeRun.Add(new Quest_86(1, 15, QuestRace.Nuian, new uint[] { 1664 }));
            questsCanBeRun.Add(new Quest_91(1, 15, QuestRace.Nuian, new uint[] { 3740, 86 }));
            questsCanBeRun.Add(new Quest_3741(1, 15, QuestRace.Nuian, new uint[] { 3740, 86 }));
            questsCanBeRun.Add(new Quest_109(1, 15, QuestRace.Nuian, new uint[] { 3741 }));
            questsCanBeRun.Add(new Quest_3745(1, 15, QuestRace.Nuian, new uint[] { 3741 }));
            #endregion
            #region White Arden
            questsCanBeRun.Add(new Quest_2498(1, 15, QuestRace.Nuian, new uint[] { 4398 })); //epic
            questsCanBeRun.Add(new Quest_112(1, 15, QuestRace.Nuian, new uint[] { 4398 }));
            questsCanBeRun.Add(new Quest_111(1, 15, QuestRace.Nuian, new uint[] { 4398 }));
            questsCanBeRun.Add(new Quest_4235(1, 15, QuestRace.Nuian, new uint[] { 111, 112 }));
            questsCanBeRun.Add(new Quest_113(1, 15, QuestRace.Nuian, new uint[] { 4235 }));
            questsCanBeRun.Add(new Quest_124(1, 15, QuestRace.Nuian, new uint[] { 113 }));
            questsCanBeRun.Add(new Quest_3985(1, 15, QuestRace.Nuian, new uint[] { 2498 })); //epic
            questsCanBeRun.Add(new Quest_135(1, 15, QuestRace.Nuian, new uint[] { 2498 }));
            questsCanBeRun.Add(new Quest_4256(1, 15, QuestRace.Nuian, new uint[] { 2498 }));
            questsCanBeRun.Add(new Quest_134(1, 15, QuestRace.Nuian, new uint[] { 2498 }));
            questsCanBeRun.Add(new Quest_1702(1, 15, QuestRace.Nuian, new uint[] { 2498 }));
            questsCanBeRun.Add(new Quest_4257(1, 15, QuestRace.Nuian, new uint[] { 4256 }));
            questsCanBeRun.Add(new Quest_2565(1, 15, QuestRace.Nuian, new uint[] { 1702 }));
            questsCanBeRun.Add(new Quest_1730(1, 15, QuestRace.Nuian, new uint[] { 4257 }));
            questsCanBeRun.Add(new Quest_133(1, 15, QuestRace.Nuian, new uint[] { 1730 }));
            questsCanBeRun.Add(new Quest_127(1, 15, QuestRace.Nuian, new uint[] { 1730 }));
            questsCanBeRun.Add(new Quest_905(1, 15, QuestRace.Nuian, new uint[] { 1730 }));
            questsCanBeRun.Add(new Quest_3986(1, 15, QuestRace.Nuian, new uint[] { 3985 })); //epic
            questsCanBeRun.Add(new Quest_4399(1, 15, QuestRace.Nuian, new uint[] { 3986 })); //epic
            questsCanBeRun.Add(new Quest_4400(1, 15, QuestRace.Nuian, new uint[] { 4399 })); //epic
            questsCanBeRun.Add(new Quest_128(1, 15, QuestRace.Nuian, new uint[] { 4399 }));
            questsCanBeRun.Add(new Quest_131(1, 15, QuestRace.Nuian, new uint[] { 128 }));
            questsCanBeRun.Add(new Quest_132(1, 15, QuestRace.Nuian, new uint[] { 128 }));
            questsCanBeRun.Add(new Quest_130(1, 15, QuestRace.Nuian, new uint[] { 132 }));
            questsCanBeRun.Add(new Quest_4270(1, 15, QuestRace.Nuian, new uint[] { 130 }));
            questsCanBeRun.Add(new Quest_116(1, 15, QuestRace.Nuian, new uint[] { 130 }));
            questsCanBeRun.Add(new Quest_3987(1, 15, QuestRace.Nuian, new uint[] { 4400 })); //epic
            questsCanBeRun.Add(new Quest_117(1, 15, QuestRace.Nuian, new uint[] { 4400 }));
            questsCanBeRun.Add(new Quest_4252(1, 15, QuestRace.Nuian, new uint[] { 4400 }));
            questsCanBeRun.Add(new Quest_4251(1, 15, QuestRace.Nuian, new uint[] { 4252 }));
            questsCanBeRun.Add(new Quest_4240(1, 15, QuestRace.Nuian, new uint[] { 4252 }));
            questsCanBeRun.Add(new Quest_4253(1, 15, QuestRace.Nuian, new uint[] { 4251 }));
            questsCanBeRun.Add(new Quest_4254(1, 15, QuestRace.Nuian, new uint[] { 4253 }));
            questsCanBeRun.Add(new Quest_118(1, 15, QuestRace.Nuian, new uint[] { 4254 }));
            questsCanBeRun.Add(new Quest_119(1, 15, QuestRace.Nuian, new uint[] { 4254 }));
            questsCanBeRun.Add(new Quest_4223(1, 15, QuestRace.Nuian, new uint[] { 118 }));
            questsCanBeRun.Add(new Quest_4224(1, 15, QuestRace.Nuian, new uint[] { 4223 }));
            questsCanBeRun.Add(new Quest_136(1, 15, QuestRace.Nuian, new uint[] { 4224 }));
            questsCanBeRun.Add(new Quest_144(1, 15, QuestRace.Nuian, new uint[] { 136 }));
            questsCanBeRun.Add(new Quest_2754(1, 15, QuestRace.Nuian, new uint[] { 144 }));
            questsCanBeRun.Add(new Quest_1698(1, 15, QuestRace.Nuian, new uint[] { 2754 }));
            questsCanBeRun.Add(new Quest_4225(1, 15, QuestRace.Nuian, new uint[] { 119 }));
            questsCanBeRun.Add(new Quest_147(1, 15, QuestRace.Nuian, new uint[] { 119 }));
            questsCanBeRun.Add(new Quest_149(1, 15, QuestRace.Nuian, new uint[] { 4225 }));
            questsCanBeRun.Add(new Quest_2567(1, 15, QuestRace.Nuian, new uint[] { 4225 }));
            questsCanBeRun.Add(new Quest_2566(1, 15, QuestRace.Nuian, new uint[] { 4225 }));
            questsCanBeRun.Add(new Quest_4250(1, 15, QuestRace.Nuian, new uint[] { 2567 }));
            questsCanBeRun.Add(new Quest_150(1, 15, QuestRace.Nuian, new uint[] { 149, 4250 }));
            questsCanBeRun.Add(new Quest_151(1, 15, QuestRace.Nuian, new uint[] { 149, 4250 }));
            questsCanBeRun.Add(new Quest_152(1, 15, QuestRace.Nuian, new uint[] { 149, 4250 }));
            questsCanBeRun.Add(new Quest_4273(1, 15, QuestRace.Nuian, new uint[] { 149, 4250 }));
            questsCanBeRun.Add(new Quest_154(1, 15, QuestRace.Nuian, new uint[] { 149, 4250 }, new uint[] { 155 })); //daily
            questsCanBeRun.Add(new Quest_4274(1, 15, QuestRace.Nuian, new uint[] { 150 }));
            questsCanBeRun.Add(new Quest_153(1, 15, QuestRace.Nuian, new uint[] { 4274 }));
            questsCanBeRun.Add(new Quest_155(1, 15, QuestRace.Nuian, new uint[] { 153 }));
            questsCanBeRun.Add(new Quest_158(1, 15, QuestRace.Nuian, new uint[] { 155 }));
            questsCanBeRun.Add(new Quest_4246(1, 15, QuestRace.Nuian, new uint[] { 158 }));
            questsCanBeRun.Add(new Quest_4245(1, 15, QuestRace.Nuian, new uint[] { 158 }));
            questsCanBeRun.Add(new Quest_140(1, 15, QuestRace.Nuian, new uint[] { 4246 }));
            questsCanBeRun.Add(new Quest_138(1, 15, QuestRace.Nuian, new uint[] { 4246 }));
            questsCanBeRun.Add(new Quest_4228(1, 15, QuestRace.Nuian, new uint[] { 138 }));
            questsCanBeRun.Add(new Quest_4229(1, 15, QuestRace.Nuian, new uint[] { 138 }));
            questsCanBeRun.Add(new Quest_139(1, 15, QuestRace.Nuian, new uint[] { 4229 }));
            questsCanBeRun.Add(new Quest_141(1, 15, QuestRace.Nuian, new uint[] { 139 }));
            questsCanBeRun.Add(new Quest_142(1, 15, QuestRace.Nuian, new uint[] { 141 }));
            questsCanBeRun.Add(new Quest_143(1, 15, QuestRace.Nuian, new uint[] { 142 }));
            questsCanBeRun.Add(new Quest_145(1, 15, QuestRace.Nuian, new uint[] { 142 }));
            questsCanBeRun.Add(new Quest_146(1, 15, QuestRace.Nuian, new uint[] { 143, 145 }));
            questsCanBeRun.Add(new Quest_4241(1, 15, QuestRace.Nuian, new uint[] { 146 }));
            questsCanBeRun.Add(new Quest_4242(1, 15, QuestRace.Nuian, new uint[] { 4241 }));
            questsCanBeRun.Add(new Quest_4243(1, 15, QuestRace.Nuian, new uint[] { 4242 }));
            questsCanBeRun.Add(new Quest_4244(1, 15, QuestRace.Nuian, new uint[] { 4243 }));
            questsCanBeRun.Add(new Quest_4226(1, 15, QuestRace.Nuian, new uint[] { 4244 }));
            questsCanBeRun.Add(new Quest_4249(1, 15, QuestRace.Nuian, new uint[] { 4226 }));
            questsCanBeRun.Add(new Quest_2564(1, 15, QuestRace.Nuian, new uint[] { 4226 }));
            questsCanBeRun.Add(new Quest_2563(1, 15, QuestRace.Nuian, new uint[] { 4226 }));
            questsCanBeRun.Add(new Quest_4248(1, 15, QuestRace.Nuian, new uint[] { 2563 }));
            questsCanBeRun.Add(new Quest_4221(1, 15, QuestRace.Nuian, new uint[] { 2563 }));
            questsCanBeRun.Add(new Quest_4220(1, 15, QuestRace.Nuian, new uint[] { 4221 }));
            questsCanBeRun.Add(new Quest_1704(1, 15, QuestRace.Nuian, new uint[] { 4220 }));
            questsCanBeRun.Add(new Quest_121(1, 15, QuestRace.Nuian, new uint[] { 1704 }));
            questsCanBeRun.Add(new Quest_125(1, 15, QuestRace.Nuian, new uint[] { 121 }));
            questsCanBeRun.Add(new Quest_4232(1, 15, QuestRace.Nuian, new uint[] { 125 }));
            questsCanBeRun.Add(new Quest_4233(1, 15, QuestRace.Nuian, new uint[] { 4232 }));
            questsCanBeRun.Add(new Quest_4234(1, 15, QuestRace.Nuian, new uint[] { 4233 }));
            questsCanBeRun.Add(new Quest_137(1, 15, QuestRace.Nuian, new uint[] { 4234 }));
            #endregion
            #region Marianpole
            questsCanBeRun.Add(new Quest_4402(1, 15, QuestRace.Nuian, new uint[] { 3987 })); //epic
            questsCanBeRun.Add(new Quest_258(1, 15, QuestRace.Nuian, new uint[] { 4402 }));
            questsCanBeRun.Add(new Quest_28(1, 15, QuestRace.Nuian, new uint[] { 4402 }));
            questsCanBeRun.Add(new Quest_13(1, 15, QuestRace.Nuian, new uint[] { 28, 258 }));
            questsCanBeRun.Add(new Quest_264(1, 15, QuestRace.Nuian, new uint[] { 28, 258 }));
            questsCanBeRun.Add(new Quest_4403(1, 15, QuestRace.Nuian, new uint[] { 4402 })); //epic
            questsCanBeRun.Add(new Quest_4404(1, 15, QuestRace.Nuian, new uint[] {4403 })); //epic
            questsCanBeRun.Add(new Quest_3988(1, 15, QuestRace.Nuian, new uint[] { 4404 })); //epic
            questsCanBeRun.Add(new Quest_3989(1, 15, QuestRace.Nuian, new uint[] { 3988 })); //epic
            questsCanBeRun.Add(new Quest_253(1, 15, QuestRace.Nuian, new uint[] { 3988 }));
            questsCanBeRun.Add(new Quest_321(1, 15, QuestRace.Nuian, new uint[] { 3988 }));
            questsCanBeRun.Add(new Quest_110(1, 15, QuestRace.Nuian, new uint[] { 321, 253 }));
            questsCanBeRun.Add(new Quest_181(1, 15, QuestRace.Nuian, new uint[] { 321, 253 }));
            questsCanBeRun.Add(new Quest_166(1, 15, QuestRace.Nuian, new uint[] { 321, 253 }));
            questsCanBeRun.Add(new Quest_176(1, 15, QuestRace.Nuian, new uint[] { 321, 253 }));
            questsCanBeRun.Add(new Quest_322(1, 15, QuestRace.Nuian, new uint[] { 176 }));
            questsCanBeRun.Add(new Quest_173(1, 15, QuestRace.Nuian, new uint[] { 181, 110, 166 }));
            questsCanBeRun.Add(new Quest_4405(1, 15, QuestRace.Nuian, new uint[] { 3989 })); //epic
            questsCanBeRun.Add(new Quest_4406(1, 15, QuestRace.Nuian, new uint[] { 4405 })); //epic
            questsCanBeRun.Add(new Quest_4407(1, 15, QuestRace.Nuian, new uint[] { 4406 })); //epic
            questsCanBeRun.Add(new Quest_174(1, 15, QuestRace.Nuian, new uint[] { 4406 }));
            questsCanBeRun.Add(new Quest_197(1, 15, QuestRace.Nuian, new uint[] { 4406 }));
            //questsCanBeRun.Add(new Quest_281(1, 15, QuestRace.Nuian, new uint[] { 4406 }));//Not always available
            //questsCanBeRun.Add(new Quest_283(1, 15, QuestRace.Nuian, new uint[] { 281 }));//Not always available
            //questsCanBeRun.Add(new Quest_284(1, 15, QuestRace.Nuian, new uint[] { 283 }));//Not always available
            questsCanBeRun.Add(new Quest_198(1, 15, QuestRace.Nuian, new uint[] { 197 }));
            questsCanBeRun.Add(new Quest_199(1, 15, QuestRace.Nuian, new uint[] { 198 }));
            //questsCanBeRun.Add(new Quest_604(1, 15, QuestRace.Nuian, new uint[] { 199 })); //Not always available
            questsCanBeRun.Add(new Quest_188(1, 15, QuestRace.Nuian, new uint[] { 199 }));
            questsCanBeRun.Add(new Quest_162(1, 15, QuestRace.Nuian, new uint[] { 188 }));
            questsCanBeRun.Add(new Quest_175(1, 15, QuestRace.Nuian, new uint[] { 162 }));
            questsCanBeRun.Add(new Quest_189(1, 15, QuestRace.Nuian, new uint[] { 175 }));
            questsCanBeRun.Add(new Quest_177(1, 15, QuestRace.Nuian, new uint[] { 189 }));
            questsCanBeRun.Add(new Quest_272(1, 15, QuestRace.Nuian, new uint[] { 189 }));
            questsCanBeRun.Add(new Quest_286(1, 15, QuestRace.Nuian, new uint[] { 189 }));
            questsCanBeRun.Add(new Quest_179(1, 15, QuestRace.Nuian, new uint[] { 272 }));
            questsCanBeRun.Add(new Quest_285(1, 15, QuestRace.Nuian, new uint[] { 179 }));
            questsCanBeRun.Add(new Quest_171(1, 15, QuestRace.Nuian, new uint[] { 286 }));
            questsCanBeRun.Add(new Quest_289(1, 15, QuestRace.Nuian, new uint[] { 286 }));
            questsCanBeRun.Add(new Quest_306(1, 15, QuestRace.Nuian, new uint[] { 171 }));
            questsCanBeRun.Add(new Quest_201(1, 15, QuestRace.Nuian, new uint[] { 289 }));
            questsCanBeRun.Add(new Quest_170(1, 15, QuestRace.Nuian, new uint[] { 289 }));
            questsCanBeRun.Add(new Quest_200(1, 15, QuestRace.Nuian, new uint[] { 201 }));
            questsCanBeRun.Add(new Quest_337(1, 15, QuestRace.Nuian, new uint[] { 170 }));
            questsCanBeRun.Add(new Quest_335(1, 15, QuestRace.Nuian, new uint[] { 170 }, new uint[] { 168 })); //daily
            questsCanBeRun.Add(new Quest_348(1, 15, QuestRace.Nuian, new uint[] { 337 }));
            questsCanBeRun.Add(new Quest_336(1, 15, QuestRace.Nuian, new uint[] { 348 })); //item
            questsCanBeRun.Add(new Quest_168(1, 15, QuestRace.Nuian, new uint[] { 336 }));
            questsCanBeRun.Add(new Quest_339(1, 15, QuestRace.Nuian, new uint[] { 336 }));
            questsCanBeRun.Add(new Quest_334(1, 15, QuestRace.Nuian, new uint[] { 168 }));
            questsCanBeRun.Add(new Quest_338(1, 15, QuestRace.Nuian, new uint[] { 168 }));
            questsCanBeRun.Add(new Quest_183(1, 15, QuestRace.Nuian, new uint[] { 334, 338 }));
            questsCanBeRun.Add(new Quest_340(1, 15, QuestRace.Nuian, new uint[] { 339 }));
            questsCanBeRun.Add(new Quest_343(1, 15, QuestRace.Nuian, new uint[] { 340 }));
            questsCanBeRun.Add(new Quest_341(1, 15, QuestRace.Nuian, new uint[] { 343 }));
            questsCanBeRun.Add(new Quest_178(1, 15, QuestRace.Nuian, new uint[] { 183 }));
            questsCanBeRun.Add(new Quest_184(1, 15, QuestRace.Nuian, new uint[] { 183 }));
            questsCanBeRun.Add(new Quest_349(1, 15, QuestRace.Nuian, new uint[] { 183 }));
            questsCanBeRun.Add(new Quest_186(1, 15, QuestRace.Nuian, new uint[] { 178, 184, 349 }));
            questsCanBeRun.Add(new Quest_344(1, 15, QuestRace.Nuian, new uint[] { 186 }));
            questsCanBeRun.Add(new Quest_351(1, 15, QuestRace.Nuian, new uint[] { 344 }));
            questsCanBeRun.Add(new Quest_185(1, 15, QuestRace.Nuian, new uint[] { 351 }));
            questsCanBeRun.Add(new Quest_202(1, 15, QuestRace.Nuian, new uint[] { 185 }));
            questsCanBeRun.Add(new Quest_187(1, 15, QuestRace.Nuian, new uint[] { 202 }));
            questsCanBeRun.Add(new Quest_203(1, 15, QuestRace.Nuian, new uint[] { 187 }));
            questsCanBeRun.Add(new Quest_355(1, 15, QuestRace.Nuian, new uint[] { 203 }));
            questsCanBeRun.Add(new Quest_191(1, 15, QuestRace.Nuian, new uint[] { 355 }));
            questsCanBeRun.Add(new Quest_193(1, 15, QuestRace.Nuian, new uint[] { 355 }));
            questsCanBeRun.Add(new Quest_194(1, 15, QuestRace.Nuian, new uint[] { 355 }));
            questsCanBeRun.Add(new Quest_196(1, 15, QuestRace.Nuian, new uint[] { 191, 193, 194 }));
            questsCanBeRun.Add(new Quest_955(1, 15, QuestRace.Nuian, new uint[] { 196 }));
            questsCanBeRun.Add(new Quest_195(1, 15, QuestRace.Nuian, new uint[] { 955 }));
            questsCanBeRun.Add(new Quest_190(1, 15, QuestRace.Nuian, new uint[] { 955 }));
            questsCanBeRun.Add(new Quest_192(1, 15, QuestRace.Nuian, new uint[] { 955 }));
            questsCanBeRun.Add(new Quest_676(1, 15, QuestRace.Nuian, new uint[] { 955 }));
            questsCanBeRun.Add(new Quest_677(1, 15, QuestRace.Nuian, new uint[] { 676 }));
            questsCanBeRun.Add(new Quest_357(1, 15, QuestRace.Nuian, new uint[] { 195, 192, 190 }));
            #endregion
            #region Two Crowns
            questsCanBeRun.Add(new Quest_2405(1, 15, QuestRace.Nuian, new uint[] { 357 }));
            questsCanBeRun.Add(new Quest_2513(1, 15, QuestRace.Nuian, new uint[] { 357 }));
            questsCanBeRun.Add(new Quest_2411(1, 15, QuestRace.Nuian, new uint[] { 2405, 2513 }));
            questsCanBeRun.Add(new Quest_3990(1, 15, QuestRace.Nuian, new uint[] { 4407 }));//epic
            questsCanBeRun.Add(new Quest_3991(1, 15, QuestRace.Nuian, new uint[] { 3990 }));//epic
            questsCanBeRun.Add(new Quest_4409(1, 15, QuestRace.Nuian, new uint[] { 3991 }));//epic
            questsCanBeRun.Add(new Quest_4410(1, 15, QuestRace.Nuian, new uint[] { 4409 }));//epic
            questsCanBeRun.Add(new Quest_3993(1, 15, QuestRace.Nuian, new uint[] { 4410 }));//epic
            questsCanBeRun.Add(new Quest_4411(1, 15, QuestRace.Nuian, new uint[] { 3993 }));//epic
            questsCanBeRun.Add(new Quest_4064(1, 15, QuestRace.Nuian, new uint[] { 3993 }));
            questsCanBeRun.Add(new Quest_4087(1, 15, QuestRace.Nuian, new uint[] { 4064 }));
            questsCanBeRun.Add(new Quest_2694(1, 15, QuestRace.Nuian, new uint[] { 4064 }));
            questsCanBeRun.Add(new Quest_2407(1, 15, QuestRace.Nuian, new uint[] { 4064 }));
            questsCanBeRun.Add(new Quest_2412(1, 15, QuestRace.Nuian, new uint[] { 4064 }));
            questsCanBeRun.Add(new Quest_630(1, 15, QuestRace.Nuian, new uint[] { 2407, 2412 }));
            questsCanBeRun.Add(new Quest_628(1, 15, QuestRace.Nuian, new uint[] { 630 }));
            questsCanBeRun.Add(new Quest_2460(1, 15, QuestRace.Nuian, new uint[] { 628 }));
            questsCanBeRun.Add(new Quest_2408(1, 15, QuestRace.Nuian, new uint[] { 628 }));
            questsCanBeRun.Add(new Quest_2719(1, 15, QuestRace.Nuian, new uint[] { 2694 }));
            questsCanBeRun.Add(new Quest_2409(1, 15, QuestRace.Nuian, new uint[] { 4411 }));
            questsCanBeRun.Add(new Quest_631(1, 15, QuestRace.Nuian, new uint[] { 2409 }));
            questsCanBeRun.Add(new Quest_620(1, 15, QuestRace.Nuian, new uint[] { 631 }));
            questsCanBeRun.Add(new Quest_618(1, 15, QuestRace.Nuian, new uint[] { 631 }));
            questsCanBeRun.Add(new Quest_621(1, 15, QuestRace.Nuian, new uint[] { 618, 620 }));
            questsCanBeRun.Add(new Quest_2415(1, 15, QuestRace.Nuian, new uint[] { 618, 620 }));
            questsCanBeRun.Add(new Quest_626(1, 15, QuestRace.Nuian, new uint[] { 2415 }));
            questsCanBeRun.Add(new Quest_609(1, 15, QuestRace.Nuian, new uint[] { 2415 }));
            questsCanBeRun.Add(new Quest_4065(1, 15, QuestRace.Nuian, new uint[] { 2415 }, new uint[] { 608 }));//daily
            questsCanBeRun.Add(new Quest_2698(1, 15, QuestRace.Nuian, new uint[] { 2719 }));
            questsCanBeRun.Add(new Quest_4900(1, 15, QuestRace.Nuian, new uint[] { 2719 }));
            questsCanBeRun.Add(new Quest_4115(1, 15, QuestRace.Nuian, new uint[] { 2719 }));
            questsCanBeRun.Add(new Quest_608(1, 15, QuestRace.Nuian, new uint[] { 2719 }));
            
            questsCanBeRun.Add(new Quest_611(1, 15, QuestRace.Nuian, new uint[] { 608 })); //Removed 612 temporary

            /*questsCanBeRun.Add(new Quest_612(1, 15, QuestRace.Nuian, new uint[] { 608 }));
            questsCanBeRun.Add(new Quest_2416(1, 15, QuestRace.Nuian, new uint[] { 612 }));
            questsCanBeRun.Add(new Quest_614(1, 15, QuestRace.Nuian, new uint[] { 612 }));
            questsCanBeRun.Add(new Quest_2457(1, 15, QuestRace.Nuian, new uint[] { 612 }));*/
            questsCanBeRun.Add(new Quest_2416(1, 15, QuestRace.Nuian, new uint[] { 611 }));
            questsCanBeRun.Add(new Quest_614(1, 15, QuestRace.Nuian, new uint[] { 611 }));
            questsCanBeRun.Add(new Quest_2457(1, 15, QuestRace.Nuian, new uint[] { 611 }));



            questsCanBeRun.Add(new Quest_615(1, 15, QuestRace.Nuian, new uint[] { 2457 }));
            questsCanBeRun.Add(new Quest_2430(1, 15, QuestRace.Nuian, new uint[] { 615 }));
            questsCanBeRun.Add(new Quest_2700(1, 15, QuestRace.Nuian, new uint[] { 615 }));
            questsCanBeRun.Add(new Quest_4116(1, 15, QuestRace.Nuian, new uint[] { 2430 }));
            questsCanBeRun.Add(new Quest_2433(1, 15, QuestRace.Nuian, new uint[] { 4116 }));
            questsCanBeRun.Add(new Quest_1478(1, 15, QuestRace.Nuian, new uint[] { 2433 }));
            questsCanBeRun.Add(new Quest_4114(1, 15, QuestRace.Nuian, new uint[] { 2433 }, new uint[] { 2482 })); //daily
            questsCanBeRun.Add(new Quest_2479(1, 15, QuestRace.Nuian, new uint[] { 4114 }));
            questsCanBeRun.Add(new Quest_2482(1, 15, QuestRace.Nuian, new uint[] { 1478 }));
            questsCanBeRun.Add(new Quest_636(1, 15, QuestRace.Nuian, new uint[] { 1478 }));
            questsCanBeRun.Add(new Quest_4119(1, 15, QuestRace.Nuian, new uint[] { 2482, 636 }));
            questsCanBeRun.Add(new Quest_637(1, 15, QuestRace.Nuian, new uint[] { 2482, 636 }));
            questsCanBeRun.Add(new Quest_4120(1, 15, QuestRace.Nuian, new uint[] { 2482, 636 }));
            questsCanBeRun.Add(new Quest_4117(1, 15, QuestRace.Nuian, new uint[] { 2482, 636 }));
            questsCanBeRun.Add(new Quest_4118(1, 15, QuestRace.Nuian, new uint[] { 2482, 636 }));
            questsCanBeRun.Add(new Quest_4267(1, 15, QuestRace.Nuian, new uint[] { 4120 }));
            questsCanBeRun.Add(new Quest_1481(1, 15, QuestRace.Nuian, new uint[] { 4120 }));
            questsCanBeRun.Add(new Quest_2481(1, 15, QuestRace.Nuian, new uint[] { 4120 }));
            questsCanBeRun.Add(new Quest_4268(1, 15, QuestRace.Nuian, new uint[] { 4267 }));
            questsCanBeRun.Add(new Quest_2701(1, 15, QuestRace.Nuian, new uint[] { 4267 }));
            questsCanBeRun.Add(new Quest_1480(1, 15, QuestRace.Nuian, new uint[] { 4268 }));
            questsCanBeRun.Add(new Quest_2484(1, 15, QuestRace.Nuian, new uint[] { 4268 }));
            questsCanBeRun.Add(new Quest_2478(1, 15, QuestRace.Nuian, new uint[] { 4268 }, new uint[] { 2477 })); //daily
            questsCanBeRun.Add(new Quest_2475(1, 15, QuestRace.Nuian, new uint[] { 2484 }));
            questsCanBeRun.Add(new Quest_2477(1, 15, QuestRace.Nuian, new uint[] { 2484 }));
            questsCanBeRun.Add(new Quest_633(1, 15, QuestRace.Nuian, new uint[] { 2484 }));
            questsCanBeRun.Add(new Quest_4124(1, 15, QuestRace.Nuian, new uint[] { 2475 }));
            questsCanBeRun.Add(new Quest_642(1, 15, QuestRace.Nuian, new uint[] { 2475 }));
            questsCanBeRun.Add(new Quest_1475(1, 15, QuestRace.Nuian, new uint[] { 2475 }));
            questsCanBeRun.Add(new Quest_644(1, 15, QuestRace.Nuian, new uint[] { 4124 }));
            questsCanBeRun.Add(new Quest_2501(1, 15, QuestRace.Nuian, new uint[] { 633 }));
            questsCanBeRun.Add(new Quest_2502(1, 15, QuestRace.Nuian, new uint[] { 2501 }));
            questsCanBeRun.Add(new Quest_605(1, 15, QuestRace.Nuian, new uint[] { 2502 }));
            questsCanBeRun.Add(new Quest_2414(1, 15, QuestRace.Nuian, new uint[] { 605 }));
            questsCanBeRun.Add(new Quest_2529(1, 15, QuestRace.Nuian, new uint[] { 644 }));
            questsCanBeRun.Add(new Quest_2435(1, 15, QuestRace.Nuian, new uint[] { 2529 }));
            questsCanBeRun.Add(new Quest_4125(1, 15, QuestRace.Nuian, new uint[] { 2529 }));
            questsCanBeRun.Add(new Quest_2436(1, 15, QuestRace.Nuian, new uint[] { 2414 }));
            questsCanBeRun.Add(new Quest_650(1, 15, QuestRace.Nuian, new uint[] { 4125 }));
            questsCanBeRun.Add(new Quest_1621(1, 15, QuestRace.Nuian, new uint[] { 650 }));
            questsCanBeRun.Add(new Quest_653(1, 15, QuestRace.Nuian, new uint[] { 650 }));
            questsCanBeRun.Add(new Quest_2465(1, 15, QuestRace.Nuian, new uint[] { 1621 }));
            questsCanBeRun.Add(new Quest_2437(1, 15, QuestRace.Nuian, new uint[] { 1621 }));
            questsCanBeRun.Add(new Quest_2464(1, 15, QuestRace.Nuian, new uint[] { 1621 }));
            questsCanBeRun.Add(new Quest_2439(1, 15, QuestRace.Nuian, new uint[] { 2465 }));
            questsCanBeRun.Add(new Quest_2467(1, 15, QuestRace.Nuian, new uint[] { 2465 }));
            questsCanBeRun.Add(new Quest_2466(1, 15, QuestRace.Nuian, new uint[] { 2465 }));
            questsCanBeRun.Add(new Quest_2469(1, 15, QuestRace.Nuian, new uint[] { 2466 }));
            questsCanBeRun.Add(new Quest_1474(1, 15, QuestRace.Nuian, new uint[] { 2469 }));
            questsCanBeRun.Add(new Quest_2470(1, 15, QuestRace.Nuian, new uint[] { 2469 }));
            questsCanBeRun.Add(new Quest_4192(1, 15, QuestRace.Nuian, new uint[] { 2469 }));
            questsCanBeRun.Add(new Quest_2472(1, 15, QuestRace.Nuian, new uint[] { 2470 }));
            questsCanBeRun.Add(new Quest_2473(1, 15, QuestRace.Nuian, new uint[] { 2472 }));
            questsCanBeRun.Add(new Quest_2474(1, 15, QuestRace.Nuian, new uint[] { 2473 }));
            questsCanBeRun.Add(new Quest_2471(1, 15, QuestRace.Nuian, new uint[] { 1474 }));
            questsCanBeRun.Add(new Quest_2765(1, 15, QuestRace.Nuian, new uint[] { 2471 }));
            questsCanBeRun.Add(new Quest_645(1, 15, QuestRace.Nuian, new uint[] { 2795, 588, 557 }));
            questsCanBeRun.Add(new Quest_610(1, 15, QuestRace.Nuian, new uint[] { 2795, 588, 557 }));
            questsCanBeRun.Add(new Quest_648(1, 15, QuestRace.Nuian, new uint[] { 610, 645 }));
            #endregion
            #region Cinderstone Moor
            questsCanBeRun.Add(new Quest_519(1, 15, QuestRace.Nuian, new uint[] { 2765 }));
            questsCanBeRun.Add(new Quest_948(1, 15, QuestRace.Nuian, new uint[] { 2765 }));
            questsCanBeRun.Add(new Quest_561(1, 15, QuestRace.Nuian, new uint[] { 519 }));
            questsCanBeRun.Add(new Quest_526(1, 15, QuestRace.Nuian, new uint[] { 561 }));
            questsCanBeRun.Add(new Quest_527(1, 15, QuestRace.Nuian, new uint[] { 526 }));
            questsCanBeRun.Add(new Quest_521(1, 15, QuestRace.Nuian, new uint[] { 526 }));
            questsCanBeRun.Add(new Quest_520(1, 15, QuestRace.Nuian, new uint[] { 526 }));
            questsCanBeRun.Add(new Quest_525(1, 15, QuestRace.Nuian, new uint[] { 527 }));
            questsCanBeRun.Add(new Quest_524(1, 15, QuestRace.Nuian, new uint[] { 525 }));
            questsCanBeRun.Add(new Quest_528(1, 15, QuestRace.Nuian, new uint[] { 524 }));
            questsCanBeRun.Add(new Quest_535(1, 15, QuestRace.Nuian, new uint[] { 528 }));
            questsCanBeRun.Add(new Quest_532(1, 15, QuestRace.Nuian, new uint[] { 535 }));
            questsCanBeRun.Add(new Quest_529(1, 15, QuestRace.Nuian, new uint[] { 532 }));
            questsCanBeRun.Add(new Quest_533(1, 15, QuestRace.Nuian, new uint[] { 532 }));
            questsCanBeRun.Add(new Quest_536(1, 15, QuestRace.Nuian, new uint[] { 532 }));
            questsCanBeRun.Add(new Quest_534(1, 15, QuestRace.Nuian, new uint[] { 529 }));
            questsCanBeRun.Add(new Quest_3961(1, 15, QuestRace.Nuian, new uint[] { 529 }));
            questsCanBeRun.Add(new Quest_537(1, 15, QuestRace.Nuian, new uint[] { 534, 3961 }));
            questsCanBeRun.Add(new Quest_2794(1, 15, QuestRace.Nuian, new uint[] { 537 }));
            questsCanBeRun.Add(new Quest_2795(1, 15, QuestRace.Nuian, new uint[] { 2794 }));
            questsCanBeRun.Add(new Quest_538(1, 15, QuestRace.Nuian, new uint[] { 537 }));
            questsCanBeRun.Add(new Quest_540(1, 15, QuestRace.Nuian, new uint[] { 537 }));
            questsCanBeRun.Add(new Quest_3963(1, 15, QuestRace.Nuian, new uint[] { 537 }));
            questsCanBeRun.Add(new Quest_3964(1, 15, QuestRace.Nuian, new uint[] { 537 }, new uint[] { 3967 }));  //daily
            questsCanBeRun.Add(new Quest_544(1, 15, QuestRace.Nuian, new uint[] { 540 }));
            questsCanBeRun.Add(new Quest_545(1, 15, QuestRace.Nuian, new uint[] { 544 }));
            questsCanBeRun.Add(new Quest_546(1, 15, QuestRace.Nuian, new uint[] { 545 }));
            questsCanBeRun.Add(new Quest_3967(1, 15, QuestRace.Nuian, new uint[] { 546 }));
            questsCanBeRun.Add(new Quest_541(1, 15, QuestRace.Nuian, new uint[] { 3967 }));
            questsCanBeRun.Add(new Quest_547(1, 15, QuestRace.Nuian, new uint[] { 541 }));
            questsCanBeRun.Add(new Quest_548(1, 15, QuestRace.Nuian, new uint[] { 541 }));
            questsCanBeRun.Add(new Quest_551(1, 15, QuestRace.Nuian, new uint[] { 541 }));
            questsCanBeRun.Add(new Quest_3965(1, 15, QuestRace.Nuian, new uint[] { 541 }));
            questsCanBeRun.Add(new Quest_937(1, 15, QuestRace.Nuian, new uint[] { 548 }));
            questsCanBeRun.Add(new Quest_600(1, 15, QuestRace.Nuian, new uint[] { 937 }));
            questsCanBeRun.Add(new Quest_3968(1, 15, QuestRace.Nuian, new uint[] { 937 }));
            questsCanBeRun.Add(new Quest_569(1, 15, QuestRace.Nuian, new uint[] { 937 }));
            questsCanBeRun.Add(new Quest_562(1, 15, QuestRace.Nuian, new uint[] { 600 }));
            //Только ночью (0-360, X-0)
            questsCanBeRun.Add(new Quest_2083(1, 15, QuestRace.Nuian, new uint[] { 562 }));
            questsCanBeRun.Add(new Quest_2084(1, 15, QuestRace.Nuian, new uint[] { 2083 }));
            //questsCanBeRun.Add(new Quest_560(1, 15, QuestRace.Nuian, new uint[] { 2084 })); //хуета квест
            questsCanBeRun.Add(new Quest_549(1, 15, QuestRace.Nuian, new uint[] { 2084 }));
            questsCanBeRun.Add(new Quest_590(1, 15, QuestRace.Nuian, new uint[] { 2084 }));
            questsCanBeRun.Add(new Quest_3982(1, 15, QuestRace.Nuian, new uint[] { 590, 549 })); //560 убран
            questsCanBeRun.Add(new Quest_3983(1, 15, QuestRace.Nuian, new uint[] { 590, 549 })); //560 убран
            questsCanBeRun.Add(new Quest_3984(1, 15, QuestRace.Nuian, new uint[] { 3982, 3983 }));
            questsCanBeRun.Add(new Quest_557(1, 15, QuestRace.Nuian, new uint[] { 3984 })); 
            //Вторая цепочка (нужно проверять что либо день, либо сделан ночной)
            questsCanBeRun.Add(new Quest_566(1, 15, QuestRace.Nuian, new uint[] { 562 }));
            questsCanBeRun.Add(new Quest_567(1, 15, QuestRace.Nuian, new uint[] { 562 }));
            questsCanBeRun.Add(new Quest_573(1, 15, QuestRace.Nuian, new uint[] { 567 }));
            questsCanBeRun.Add(new Quest_565(1, 15, QuestRace.Nuian, new uint[] { 573 }));
            questsCanBeRun.Add(new Quest_571(1, 15, QuestRace.Nuian, new uint[] { 573 }));
            questsCanBeRun.Add(new Quest_580(1, 15, QuestRace.Nuian, new uint[] { 573 }));
            questsCanBeRun.Add(new Quest_552(1, 15, QuestRace.Nuian, new uint[] { 573 }, new uint[] { 584 })); //daily
            questsCanBeRun.Add(new Quest_582(1, 15, QuestRace.Nuian, new uint[] { 580, 571, 565 }));
            questsCanBeRun.Add(new Quest_581(1, 15, QuestRace.Nuian, new uint[] { 580, 571, 565 }));
            questsCanBeRun.Add(new Quest_586(1, 15, QuestRace.Nuian, new uint[] { 580, 571, 565 }));
            questsCanBeRun.Add(new Quest_3972(1, 15, QuestRace.Nuian, new uint[] { 580, 571, 565 }));
            questsCanBeRun.Add(new Quest_584(1, 15, QuestRace.Nuian, new uint[] { 581, 582, 586 }));
            questsCanBeRun.Add(new Quest_575(1, 15, QuestRace.Nuian, new uint[] { 581, 582, 586 }));
            questsCanBeRun.Add(new Quest_576(1, 15, QuestRace.Nuian, new uint[] { 575 }));
            questsCanBeRun.Add(new Quest_579(1, 15, QuestRace.Nuian, new uint[] { 576 }));
            questsCanBeRun.Add(new Quest_572(1, 15, QuestRace.Nuian, new uint[] { 579 }));
            questsCanBeRun.Add(new Quest_2089(1, 15, QuestRace.Nuian, new uint[] { 572 }));
            questsCanBeRun.Add(new Quest_3973(1, 15, QuestRace.Nuian, new uint[] { 584 }));
            questsCanBeRun.Add(new Quest_583(1, 15, QuestRace.Nuian, new uint[] { 3973 }));
            questsCanBeRun.Add(new Quest_577(1, 15, QuestRace.Nuian, new uint[] { 3973 })); //removed 550 555 3976
            questsCanBeRun.Add(new Quest_3974(1, 15, QuestRace.Nuian, new uint[] { 3973 }));
            questsCanBeRun.Add(new Quest_3975(1, 15, QuestRace.Nuian, new uint[] { 3974 }));
            questsCanBeRun.Add(new Quest_597(1, 15, QuestRace.Nuian, new uint[] { 3975 }));
            questsCanBeRun.Add(new Quest_593(1, 15, QuestRace.Nuian, new uint[] { 3975 }));
            //questsCanBeRun.Add(new Quest_550(1, 15, QuestRace.Nuian, new uint[] { 597 }));
            //questsCanBeRun.Add(new Quest_555(1, 15, QuestRace.Nuian, new uint[] { 597 }));
            //questsCanBeRun.Add(new Quest_3976(1, 15, QuestRace.Nuian, new uint[] { 597 }));
            questsCanBeRun.Add(new Quest_578(1, 15, QuestRace.Nuian, new uint[] { 577, 597 }));
            questsCanBeRun.Add(new Quest_592(1, 15, QuestRace.Nuian, new uint[] { 578 }));
            questsCanBeRun.Add(new Quest_596(1, 15, QuestRace.Nuian, new uint[] { 578 }));
            questsCanBeRun.Add(new Quest_588(1, 15, QuestRace.Nuian, new uint[] { 596, 592 }));
            #endregion

            #region Halcyona
            questsCanBeRun.Add(new Quest_1754(23, 30, QuestRace.Ferre | QuestRace.Hariharan, new uint[] { 3227 }));
            questsCanBeRun.Add(new Quest_1754(23, 30, QuestRace.Nuian | QuestRace.Elf, new uint[] { 648 }));
            questsCanBeRun.Add(new Quest_1756(23, 30, QuestRace.All, new uint[] { 1754 }));
            questsCanBeRun.Add(new Quest_1755(23, 30, QuestRace.All, new uint[] { 1754 }));
            questsCanBeRun.Add(new Quest_1757(23, 30, QuestRace.All, new uint[] { 1756 }));
            questsCanBeRun.Add(new Quest_1759(23, 30, QuestRace.All, new uint[] { 1757, 1755 }));
            questsCanBeRun.Add(new Quest_1763(23, 30, QuestRace.All, new uint[] { 1759 }));
            questsCanBeRun.Add(new Quest_1762(23, 30, QuestRace.All, new uint[] { 1759 }));
            questsCanBeRun.Add(new Quest_1764(23, 30, QuestRace.All, new uint[] { 1762 }));
            questsCanBeRun.Add(new Quest_1760(23, 30, QuestRace.All, new uint[] { 1763 }));
            questsCanBeRun.Add(new Quest_1772(23, 30, QuestRace.All, new uint[] { 1760, 1764 }));
            questsCanBeRun.Add(new Quest_1771(23, 30, QuestRace.All, new uint[] { 1760, 1764 }));
            questsCanBeRun.Add(new Quest_1766(23, 30, QuestRace.All, new uint[] { 1771, 1772 }));
            questsCanBeRun.Add(new Quest_1823(23, 30, QuestRace.All, new uint[] { 1766 }));
            questsCanBeRun.Add(new Quest_3237(23, 30, QuestRace.All, new uint[] { 1823 }));
            questsCanBeRun.Add(new Quest_1784(23, 30, QuestRace.All, new uint[] { 3237 }));
            questsCanBeRun.Add(new Quest_1773(23, 30, QuestRace.All, new uint[] { 3237 }));
            questsCanBeRun.Add(new Quest_1774(23, 30, QuestRace.All, new uint[] { 3237 }));
            questsCanBeRun.Add(new Quest_1776(23, 30, QuestRace.All, new uint[] { 3237 }));
            questsCanBeRun.Add(new Quest_1777(23, 30, QuestRace.All, new uint[] { 1776, 1774, 1773, 1784 }));
            questsCanBeRun.Add(new Quest_1783(23, 30, QuestRace.All, new uint[] { 1777 }));
            questsCanBeRun.Add(new Quest_1781(23, 30, QuestRace.All, new uint[] { 1777 }));
            questsCanBeRun.Add(new Quest_1775(23, 30, QuestRace.All, new uint[] { 1781, 1783 }));
            questsCanBeRun.Add(new Quest_1790(23, 30, QuestRace.All, new uint[] { 1775 }));
            questsCanBeRun.Add(new Quest_1779(23, 30, QuestRace.All, new uint[] { 1790 }));
            questsCanBeRun.Add(new Quest_3913(23, 30, QuestRace.All, new uint[] { 1779 }));
            questsCanBeRun.Add(new Quest_1788(23, 30, QuestRace.All, new uint[] { 1779 }));
            questsCanBeRun.Add(new Quest_1786(23, 30, QuestRace.All, new uint[] { 1788 }));
            questsCanBeRun.Add(new Quest_1787(23, 30, QuestRace.All, new uint[] { 1788 }));
            questsCanBeRun.Add(new Quest_1785(23, 30, QuestRace.All, new uint[] { 1788 }, new uint[] { 3912 })); //daily
            questsCanBeRun.Add(new Quest_1792(23, 30, QuestRace.All, new uint[] { 1786, 1787, 1785 }));
            questsCanBeRun.Add(new Quest_3911(23, 30, QuestRace.All, new uint[] { 1786, 1787, 1785 }));
            questsCanBeRun.Add(new Quest_3912(23, 30, QuestRace.All, new uint[] { 3911 }));
            questsCanBeRun.Add(new Quest_3915(23, 30, QuestRace.All, new uint[] { 3912 }));
            questsCanBeRun.Add(new Quest_1799(23, 30, QuestRace.All, new uint[] { 3915 }));
            questsCanBeRun.Add(new Quest_1800(23, 30, QuestRace.All, new uint[] { 1799 }));
            questsCanBeRun.Add(new Quest_3916(23, 30, QuestRace.All, new uint[] { 1799 }));
            questsCanBeRun.Add(new Quest_1794(23, 30, QuestRace.All, new uint[] { 1792 }));
            questsCanBeRun.Add(new Quest_3917(23, 30, QuestRace.All, new uint[] { 3916 }));
            questsCanBeRun.Add(new Quest_3918(23, 30, QuestRace.All, new uint[] { 3917 }));
            questsCanBeRun.Add(new Quest_1804(23, 30, QuestRace.All, new uint[] { 3917 }));
            questsCanBeRun.Add(new Quest_1805(23, 30, QuestRace.All, new uint[] { 1804 }));
            questsCanBeRun.Add(new Quest_1801(23, 30, QuestRace.All, new uint[] { 1800 }));
            questsCanBeRun.Add(new Quest_1803(23, 30, QuestRace.All, new uint[] { 1801 }));
                   
            //1805
            #endregion
            #region Hellswamp
            #endregion
            #region Sanddeep
            #endregion
        }

        private void CheckHiddenQuests()
        {
            var quests = host.getQuests();
            foreach (var q in quests)
            {
                if (q.questType == ArcheBuddy.Bot.Classes.QuestType.Hidden && q.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
                {
                    host.Log("Try to complete hidden quest " + q.name + "[" + q.id + "]");
                    host.CompleteQuest(q.id);
                }
            }
        }

        private void CheckFailedQuests()
        {
            var quests = host.getQuests();
            foreach (var q in quests)
            {
                if (q.status == ArcheBuddy.Bot.Classes.QuestStatus.Failed)
                {
                    host.Log("Try to cancel failed quest " + q.name + "[" + q.id + "]");
                    host.CancelQuest(q.id);
                }
            }
        }

#if DEBUG
        public override void Run(CancellationToken ct)
#elif !DEBUG
        public override void Run()
#endif
        {
#if !DEBUG
            try
            {
#endif
                while (!host.cancelRequested)
                {
#if DEBUG
                    base.Run(ct);
#elif !DEBUG
                    base.Run();
#endif

                    Thread.Sleep(1000);
                    try
                    {
                        if (!host.farmModule.readyToActions)
                            continue;
                        host.mainForm.SetQuestModuleText("Try find quest to run");
                        CheckHiddenQuests();
                        CheckFailedQuests();
                        host.commonModule.CheckWeNeedRepair();
                        if (host.mobsInRange(25, false) == 0)
                        {
                            host.commonModule.CheckSealedEquips();
                            host.commonModule.EquipBestArmorAndWeapon();
                            host.commonModule.CheckWeNeedFreeInventory();
                        }
                        host.commonModule.CheckWeNeedRessurectOurMount();
                        var qList = questsCanBeRun.ToList();
                        foreach (var q in qList)
                        {
                            currentQuestId = q.id;
                            q.RunQuest(host);
                            if (!host.farmModule.readyToActions)
                                break;
                        }
                    }
                    catch { }
                }
#if !DEBUG
            }
            catch (Exception error)
            {
                Console.WriteLine("Thread abort. Questing module.");
            }
#endif
        }
    }
}
