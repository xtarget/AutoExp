using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArcheBuddy.Bot.Classes;

namespace AutoExp.Modules
{
    internal class CommonModule : Module
    {
        private class NpcInfo
        {
            public double X;
            public double Y;
            public double Z;
            public string gpsPointName;
            public NpcInfo(string gpsPointName, double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
                this.gpsPointName = gpsPointName;
            }
        }
        //Коэфициенты для шмоток
        double str_coef = 0.2;
        double int_coef = 1.00;
        double dex_coef = 0.2;
        double wit_coef = 0.5;
        double con_coef = 0.4;
        double heavy_coef = 1.00;
        double light_coef = 0.8;
        double magic_coef = 0.7;
        double level_coef = 3.0;
        double inviteDist = 150;
        internal double invitePosX = 0;
        internal double invitePosY = 0;
        internal double invitePosZ = 0;

        /*private List<uint> itemsToSell = new List<uint>() 
        { 32110, 32134, 32102, 32123, 32099, 32166, 32113, 32145, 32152, 32170, 32175, 33000, 32169, 32176, 32173, 22103, 33213, 33005, 22159, 32184, 22230, 33226, 32996, 33224, 32984, 33233, 32981, 33234, 32978, 
          33225, 32990, 32987, 33235, 21620, 21628, 21640, 21651, 21660, 23058, 32140, 32142, 32147, 32149, 32157, 32159, 32186, 32133, 32101, 32163, 32109, 32098, 32122, 32112, 32139, 32141, 32146, 32148, 32156,
          32158, 32183, 32988, 32985, 32010, 32005, 32114, 32001, 32118, 32011, 32012, 32007, 32009, 32008, 33008, 32022, 33007, 31993, 32116, 31995, 31969, 31998, 32117, 31997, 31971, 32021, 14767 };
         */

        private List<uint> itemsToDelete = new List<uint>() 
        { 5569, 6177, 23390, 23388, 23387, 6077, 6152, 6127, 6202, 7992, 8012, 15694, 29498, 19563, 17801, 19960, 14482, 17825, 15822, 14830, 23700, 26106, 16006, 21131, 24422, 5151, 14694, 15811, 14727, 14717,
          5318, 17827, 14519, 17826, 14757, 14833, 17947, 32002, 32003, 14702, 29482, 14742, 14793, 32004, 32006, 14767, 26383, 18736};

        private List<uint> itemsToWareHouse = new List<uint>() 
        { 25800, 25798, 25799, 23092, 15596, 8337, 31892, 25253, 14677, 8343, 8000083, 8327, 23633, 21588, 16347, 16348, 16349, 16350, 16351, 16352, 23663, 31929, 17863, 23603, 23701, 23702, 8235 };

        private List<uint> itemsToUnseal = new List<uint>() 
        { 33066, 33067, 33116, 33117, 33271, 33274, 33307, 33310, 33493, 33496, 33534, 33551, 33609, 33612, 33771, 33774, 33777, 33780, 33814, 33817, 33849, 33852, 33888, 33891, 33949, 33952, 33916, 33919, 32017, 
          32202, 32204, 32462, 32464, 32474, 32478, 33059, 33061, 33114, 33115, 33270, 33273, 33306, 33309, 33492, 33495, 33517, 33547, 33608, 33611, 33770, 33773, 33776, 33779, 33813, 33816, 33848, 33851, 33887, 
          33890, 33915, 33918, 33948, 33951, 31968, 31991, 32201, 32203, 32442, 32458, 32463, 32470, 33057, 33058, 33112, 33113, 33269, 33272, 33305, 33308, 33491, 33494, 33513, 33541, 33607, 33610, 33769, 33772, 
          33775, 33778, 33812, 33815, 33847, 33850, 33886, 33889, 33914, 33917, 33947, 33950, 31998 };

        /*private List<uint> itemsToDisenchant = new List<uint>() 
        { 33440, 33350, 33360, 33361, 33362, 33374, 33370, 33369, 33351, 33371, 33466, 33468, 33467, 33439, 22132, 22763, 33221, 22201, 33230, 32995, 33367, 32983, 32977, 22425, 33223, 32989, 32980, 32986, 33222,
          33214, 33212, 33349, 32177, 32179, 22510, 32185, 32167, 32171, 33366, 33357, 22091, 33231, 33002, 33232, 33358, 33359, 33373, 33472, 33352, 33437, 22104, 22258, 32180, 32178, 33211, 33215, 33348, 33006, 
          22594, 33004, 22399, 33479, 22315, 33476, 22426, 33462, 22369, 22650, 33464, 22285, 22734, 33465, 22622, 33587, 33368, 33474, 21993, 33543, 33475, 33481, 33554, 33575, 33573, 33556, 33577, 33555, 21853, 
          22203, 33546, 22175, 22075, 33559, 22705, 33477, 33445, 22481, 33482, 22509, 22791, 33588, 33582, 33580, 33562, 33584, 33561, 33548, 22131, 22161, 32165, 33218, 33219, 33355, 33229, 33356, 33227, 33228, 
          33354, 32144, 32151, 32994, 32979, 32982, 32976, 33220, 33003, 22538, 21963, 32972, 32960, 32969, 32963, 32966, 32957, 33183, 33187, 33205, 33195, 33196, 33198, 33206, 33207, 32968, 32962, 32971, 32956, 
          32959, 32965, 33186, 33202, 33191, 33192, 33194, 33203, 33204, 32997, 32970, 32955, 32961, 33185, 32964, 32967, 32958, 33189, 33190, 33191, 33199, 33200, 33201, 33208, 33364, 21922, 33448, 33449, 33372,
          33365, 22595, 22455, 21880, 21921, 22160, 22314, 33363, 22735, 33545, 33480, 33470, 33469, 33456, 33471, 33550, 33552, 33553};
         */ 
        private List<NpcInfo> stablers = new List<NpcInfo>() { 
            //Haranya
            new NpcInfo("Stabler_1", 24135.98, 10071.31, 593.02),
            new NpcInfo("Stabler_2", 24034.56, 8656.34, 565.99),
            new NpcInfo("Stabler_3", 23745.06, 9220.23, 580.52),
            new NpcInfo("Stabler_4", 23271.82, 9097.97, 650.50),
            new NpcInfo("Ferre_Rarlag", 23332.50, 9005.20, 657.12),
            new NpcInfo("Stabler_5", 21756.60, 8088.50, 404.26),
            new NpcInfo("Stabler_6", 20996.35, 8306.63, 369.80),
            new NpcInfo("Stabler_7", 21514.25, 8677.30, 461.58),
            new NpcInfo("Tiger_Ubari", 21109.00, 8899.14, 426.35),
            new NpcInfo("Stabler_8", 20099.01, 8431.51, 210.31),
            new NpcInfo("Stabler_9", 19663.46, 8756.31, 224.85),
            new NpcInfo("Stabler_10", 19213.08, 7788.93, 152.71),
            new NpcInfo("Stabler_11", 18713.26, 8194.34, 192.35),
            new NpcInfo("Stabler_12", 18760.50, 8852.31, 190.32),
            new NpcInfo("Mahadevi_Habib", 18743.49, 9255.82, 178.64),
            new NpcInfo("Stabler_13", 17780.15, 8326.04, 261.60),
            new NpcInfo("Stabler_14", 16839.79, 8048.84, 144.76),
            new NpcInfo("Stabler_15", 15730.10, 7650.44, 153.16),
            new NpcInfo("Stabler_16", 17278.19, 7925.54, 161.21),
            new NpcInfo("Stabler_17", 16803.58, 8839.23, 134.47),
            new NpcInfo("Stabler_18", 20281.17, 9357.99, 280.89),
            new NpcInfo("Stabler_19", 21097.95, 10336.52, 106.73),
            new NpcInfo("Stabler_20", 20635.17, 10442.55, 107.28),
            new NpcInfo("Stabler_21", 21228.04, 10610.31, 119.16),
            new NpcInfo("Stabler_22", 21784.95, 10280.52, 152.04),
            new NpcInfo("Stabler_23", 22114.93, 11296.54, 217.56),
            new NpcInfo("Stabler_24", 22328.06, 11975.53, 220.68),
            new NpcInfo("Stabler_25", 22713.22, 12104.73, 261.42),
            new NpcInfo("Stabler_26", 22696.41, 11589.42, 255.67),
            new NpcInfo("Stabler_27", 23796.65, 11290.06, 362.50),
            new NpcInfo("Stabler_28", 24351.79, 11423.75, 420.04),
            new NpcInfo("StablerAndBlacksmith_1", 23567.73, 12169.99, 252.86),
            new NpcInfo("Stabler_29", 19947.45, 7579.61, 180.44),
            new NpcInfo("Stabler_30", 21434.06, 7379.70, 234.73),
            new NpcInfo("Stabler_31", 22148.11, 7026.32, 278.39),
            new NpcInfo("Stabler_59", 21756.63, 13040.21, 220.68),
            new NpcInfo("Stabler_60", 21192.99, 12646.71, 194.96),
            new NpcInfo("Stabler_61", 20936.51, 13131.45, 114.41),
            new NpcInfo("Stabler_62", 21573.54, 12489.51, 242.40),
            new NpcInfo("Stabler_63", 21362.54, 12208.26, 175.01),
            new NpcInfo("Stabler_64", 21433.09, 11914.08, 109.21),
            new NpcInfo("Stabler_65", 20063.38, 12621.36, 135.84),

            //Nuia
            new NpcInfo("Stabler_32", 14844.36, 14334.51, 117.35),
            new NpcInfo("Stabler_33", 15315.46, 13952.72, 145.84),
            new NpcInfo("Stabler_34", 13008.46, 15152.65, 233.55),
            new NpcInfo("Stabler_35", 12591.82, 15406.94, 156.31),
            new NpcInfo("Stabler_36", 13618.37, 15884.48, 188.84),
            new NpcInfo("Stabler_37", 12723.33, 16134.11, 333.18),
            new NpcInfo("Stabler_38", 12883.96, 14428.91, 141.34),
            new NpcInfo("Stabler_39", 12392.76, 13989.25, 118.80),
            new NpcInfo("Stabler_40", 12200.56, 13837.61, 130.31),
            new NpcInfo("Stabler_41", 12126.34, 13373.10, 165.67),
            new NpcInfo("Stabler_42", 11711.01, 12940.21, 139.05),
            new NpcInfo("Stabler_43", 11044.02, 12894.62, 157.48),
            new NpcInfo("Stabler_44", 10615.24, 13249.77, 234.31),
            new NpcInfo("Stabler_45", 9644.33, 12797.77, 164.08),
            new NpcInfo("Stabler_46", 8729.34, 12550.07, 266.36),
            new NpcInfo("Stabler_47", 10697.22, 11911.66, 126.45),
            new NpcInfo("Stabler_48", 10872.95, 12074.72, 124.43),
            new NpcInfo("Stabler_49", 11115.70, 11770.09, 121.62),
            new NpcInfo("Stabler_50", 10829.18, 11691.62, 131.46),
            new NpcInfo("Stabler_51", 11260.69, 11475.50, 131.65),
            new NpcInfo("Stabler_52", 11111.56, 12492.29, 113.89),
            new NpcInfo("Stabler_53", 12414.79, 11513.40, 132.94),
            new NpcInfo("Stabler_54", 12498.65, 11132.79, 140.48),
            new NpcInfo("Stabler_55", 13294.49, 11797.75, 140.45),
            new NpcInfo("Stabler_56", 13148.85, 11230.01, 128.44),
            new NpcInfo("Stabler_57", 13342.12, 10740.88, 156.04),
            new NpcInfo("Stabler_58", 14346.61, 11341.68, 177.30),
            new NpcInfo("Stabler_66", 11294.10, 10793.74, 130.77),
            new NpcInfo("Stabler_67", 10629.39, 10727.83, 170.41),
            new NpcInfo("Stabler_68", 10074.37, 10550.28, 182.40),
            
        };
        private List<NpcInfo> blacksmiths = new List<NpcInfo>() { 
            //Haranya
            new NpcInfo("Blacksmith_1", 24129.03, 10044.91, 593.63),
            new NpcInfo("Blacksmith_2", 24049.80, 8607.41, 567.28),
            new NpcInfo("Blacksmith_3", 23778.49, 9152.79, 581.00),
            new NpcInfo("Tiger_Lufil", 21736.77, 8120.05, 404.06),
            new NpcInfo("Blacksmith_4", 21017.07, 8301.60, 371.12),
            new NpcInfo("Blacksmith_5", 21786.84, 8662.37, 517.75),
            new NpcInfo("Tiger_Jorga", 21099.74, 8887.84, 426.22),
            new NpcInfo("Blacksmith_6", 20104.32, 8446.99, 210.03),
            new NpcInfo("Blacksmith_7", 19392.44, 8481.75, 208.63),
            new NpcInfo("Blacksmith_8", 19212.40, 8417.43, 204.94),
            new NpcInfo("Blacksmith_9", 19197.11, 7802.50, 152.78),
            new NpcInfo("Blacksmith_10", 18708.50, 8185.45, 192.33),
            new NpcInfo("Blacksmith_11", 18766.98, 8893.57, 189.23),
            new NpcInfo("Blacksmith_12", 18706.81, 9267.54, 178.88),
            new NpcInfo("Blacksmith_13", 17773.14, 8336.02, 261.46),
            new NpcInfo("Blacksmith_14", 16815.42, 8022.28, 144.05),
            new NpcInfo("Blacksmith_15", 15693.89, 7683.87, 161.83),
            new NpcInfo("Blacksmith_16", 17275.72, 7902.60, 161.49),
            new NpcInfo("Blacksmith_17", 16750.70, 8989.09, 120.22),
            new NpcInfo("Blacksmith_18", 20305.30, 9317.77, 281.31),
            new NpcInfo("Blacksmith_19", 21023.67, 10576.27, 103.98),
            new NpcInfo("Blacksmith_20", 20629.08, 10442.79, 107.28),
            new NpcInfo("Blacksmith_21", 21760.19, 10237.58, 152.38),
            new NpcInfo("Blacksmith_22", 22136.44, 11285.10, 217.53),
            new NpcInfo("Blacksmith_23", 22294.07, 12093.38, 260.28),
            new NpcInfo("Blacksmith_24", 22722.59, 12126.34, 261.42),
            new NpcInfo("Blacksmith_25", 22704.96, 11622.98, 255.70),
            new NpcInfo("OldForest_Magaz", 23799.40, 11277.42, 362.53),
            new NpcInfo("Blacksmith_26", 24343.35, 11422.48, 420.04),
            new NpcInfo("StablerAndBlacksmith_1", 23567.73, 12169.99, 252.86),
            new NpcInfo("Blacksmith_27", 20010.41, 7574.40, 179.01),
            new NpcInfo("Arcum_Katara", 21433.81, 7391.29, 234.75),
            new NpcInfo("Blacksmith_28", 22278.15, 7035.83, 277.54),
            new NpcInfo("Blacksmith_54", 21765.28, 13046.37, 220.74),
            new NpcInfo("Blacksmith_55", 21166.63, 12673.21, 195.23),
            new NpcInfo("Blacksmith_56", 20768.91, 13120.58, 116.82),
            new NpcInfo("Blacksmith_57", 21597.81, 12407.81, 249.90),
            new NpcInfo("Blacksmith_58", 21373.77, 12218.21, 175.01),
            new NpcInfo("Blacksmith_59", 21416.00, 11912.71, 109.21),
            new NpcInfo("Blacksmith_60", 20289.71, 12047.87, 121.73),
            new NpcInfo("Blacksmith_61", 20067.14, 12597.97, 135.99),

            //Nuia
            new NpcInfo("Blacksmith_29", 14795.53, 14321.85, 119.59),
            new NpcInfo("Blacksmith_30", 15327.00, 13906.69, 152.77),
            new NpcInfo("Blacksmith_31", 13652.35, 14595.12, 110.27),
            new NpcInfo("Blacksmith_32", 13034.34, 15149.84, 233.49),
            new NpcInfo("Blacksmith_33", 12553.85, 15471.91, 163.47),
            new NpcInfo("Blacksmith_34", 13574.96, 15914.38, 175.53),
            new NpcInfo("Blacksmith_35", 12764.97, 16165.00, 352.10),
            new NpcInfo("Blacksmith_36", 12877.92, 14440.53, 141.73),
            new NpcInfo("Stabler_39", 12392.76, 13989.25, 118.80),
            new NpcInfo("Stabler_40", 12200.56, 13837.61, 130.31),
            new NpcInfo("Blacksmith_37", 12133.97, 13325.54, 165.89),
            new NpcInfo("Blacksmith_38", 11720.98, 12942.71, 139.12),
            new NpcInfo("Blacksmith_39", 11048.96, 12888.76, 156.71),
            new NpcInfo("Blacksmith_40", 10586.17, 13227.79, 233.60),
            new NpcInfo("Blacksmith_41", 9668.64, 12791.53, 162.70),
            new NpcInfo("Blacksmith_42", 8717.79, 12546.98, 266.41),
            new NpcInfo("Blacksmith_43", 10679.39, 11866.25, 129.66),
            new NpcInfo("Blacksmith_44", 11110.20, 11946.78, 142.59),
            new NpcInfo("Blacksmith_45", 10839.32, 11689.73, 131.18),
            new NpcInfo("Blacksmith_46", 11261.14, 11489.82, 131.84),
            new NpcInfo("Stabler_52", 11111.56, 12492.29, 113.89),
            new NpcInfo("Blacksmith_47", 12409.80, 11519.69, 133.15),
            new NpcInfo("Blacksmith_48", 12363.02, 11358.06, 124.79),
            new NpcInfo("Blacksmith_49", 12494.50, 11173.43, 141.56),
            new NpcInfo("Blacksmith_50", 12368.16, 10894.63, 148.70),
            new NpcInfo("Blacksmith_51", 13283.29, 11773.69, 140.63),
            new NpcInfo("Blacksmith_52", 13437.42, 10725.48, 181.56),
            new NpcInfo("Blacksmith_53", 14314.02, 11354.18, 180.95),
            new NpcInfo("Blacksmith_62", 11317.19, 10806.79, 131.32),
            new NpcInfo("Blacksmith_63", 10610.62, 10736.72, 171.43),
            new NpcInfo("Blacksmith_64", 10076.20, 10536.28, 182.25),
        };

        private List<uint> passiveBuffsToLearn;
        private List<uint> activeSkillsToLearn;
        private List<int> abilitiesToLearn;
        private Random randGenerator;

        public void InitSkillSets()
        {
            passiveBuffsToLearn = new List<uint>()
            {
                //Sorcery
                15,//Mana pool increase
                38,//Magic Range Boost
                39, //Efficient Sorcery
                257, //Mana Flurry

                //Battlerage
                3, //Weapon Maneuvers

                //Widthcraft
                4,//Folding Time

                //Occultism
                17 //Enhanced Mana Recovery
            };
            activeSkillsToLearn = new List<uint>()
            {
                //Sorcery
                10153,//Insulating Lens

                //Occultism
                10135,//Hell Spear

                //Vitalism
                11379, //Mirror Light
                10547, //Resurgence
                10534, //Antithesis

                //Shadowplay
                18125, //Rapid Strike
                12139, //Stalker's Mark

                //Auramancy
                11869, //Conversion Shield
                16486, //Thwart

                //Defense
                10645, //Refreshment
                11365, //Toughen
                12048, //Boastful Roar

                //Songcraft
                11377, //Hummingbird Ditty

            };
            //If no Sorcery - add Mana Start - Occultism
            if (!host.isAbilityTaken(Ability.Sorcery))
                activeSkillsToLearn.Add(14810);
            //If no Shadowplay - add Triple slash - Battlerage
            if (!host.isAbilityTaken(Ability.Shadowplay))
                activeSkillsToLearn.Add(18132);

            //If no main dps abilities - add additional skills
            if (!host.isAbilityTaken(Ability.Sorcery)
                && !host.isAbilityTaken(Ability.Occultism)
                && !host.isAbilityTaken(Ability.Battlerage)
                && !host.isAbilityTaken(Ability.Shadowplay)
                && !host.isAbilityTaken(Ability.Archery))
            {
                //Defense
                activeSkillsToLearn.Add(10399); //Shield Slam
                activeSkillsToLearn.Add(10501); //Bull Rush
            }

            if (host.characterSettings.weaponPriority == 0)
            {
                //Sorcery
                activeSkillsToLearn.Add(10752);//Flamebolt
                activeSkillsToLearn.Add(10667);//Freezing arrow
                
                //Witchcraft
                activeSkillsToLearn.Add(10159); //Enervate
                activeSkillsToLearn.Add(14376); //Earthen Grip
                activeSkillsToLearn.Add(10712); //Purge

                //Songcraft
                activeSkillsToLearn.Add(11973); //Critical Discord
                activeSkillsToLearn.Add(11934); //Startling Strain

                //Occultism
                activeSkillsToLearn.Add(12759); //Mana Force
            }
            else if (host.characterSettings.weaponPriority == 1)
            {
                //Archery
                activeSkillsToLearn.Add(16210);//Charged Bolt
                activeSkillsToLearn.Add(13564);//Piercing Shot
                activeSkillsToLearn.Add(14835);//Endless Arrows
                activeSkillsToLearn.Add(11368);//Double Recurve
                activeSkillsToLearn.Add(15073);//Deadeye

                //Shadowplay
                activeSkillsToLearn.Add(12049);//Drop Back

            }
            else if (host.characterSettings.weaponPriority == 2)
            { 
                //Shadowplay
                activeSkillsToLearn.Add(10648);//Overwhelm
                activeSkillsToLearn.Add(12029);//Wallop

                //Archery
                activeSkillsToLearn.Add(16210);//Charged Bolt
                activeSkillsToLearn.Add(13564);//Piercing Shot

                //Battlerage
                activeSkillsToLearn.Add(11918); //Charge
                activeSkillsToLearn.Add(13282); //Whirlwind Slash
                activeSkillsToLearn.Add(10644); //Sunder Earth
            }

            abilitiesToLearn = new List<int>() { host.characterSettings.skillset1, host.characterSettings.skillset2, host.characterSettings.skillset3 };
        }

        public void InitEquipConfig()
        {
            foreach (var item in host.me.getItems())
            {
                host.SetVar(item, "coef", null);
            }

            //Heavy
            if (host.characterSettings.armorSet == 0)
            {
                heavy_coef = 1.5;
                light_coef = 0.7;
                magic_coef = 0.6;
            }
            //Light
            if (host.characterSettings.armorSet == 1)
            {
                heavy_coef = 0.7;
                light_coef = 1.5;
                magic_coef = 0.6;
            }
            //Magic
            if (host.characterSettings.armorSet == 2)
            {
                heavy_coef = 0.6;
                light_coef = 0.7;
                magic_coef = 1.5;
            }

            //Mage - Magic staff
            if (host.characterSettings.weaponPriority == 0)
            {
                str_coef = 0.2;
                int_coef = 1.2;
                dex_coef = 0.2;
                wit_coef = 0.5;
                con_coef = 0.4;
            }
            //Range - Bow
            if (host.characterSettings.weaponPriority == 1)
            {
                str_coef = 1.2;
                int_coef = 0.2;
                dex_coef = 0.2;
                wit_coef = 0.5;
                con_coef = 0.4;
            }
            //Melee - Swords\Blunts
            if (host.characterSettings.weaponPriority == 2)
            {
                str_coef = 0.2;
                int_coef = 0.2;
                dex_coef = 1.2;
                wit_coef = 0.5;
                con_coef = 0.4;
            }
        }

        public override void Start(Host host)
        {
            base.Start(host);
            randGenerator = new Random();
            InitSkillSets();
            InitEquipConfig();
            host.onPartyInvite += handleInvite;
            host.onRaidInvite += handleInvite;
            host.onLootDice += handleLootDice;
            host.onNewInvItem += handleNewInvItem;
        }

        void handleNewInvItem(Item item, int count)
        {
            if (item != null && (item.id == 26383 || item.id == 18736))
                item.DeleteItem();
        }

        void handleLootDice(Item item)
        {
            item.Dice(true);
        }

        public void handleInvite(String nick)
        {
            System.Random RandNum = new System.Random();
            int waitTime = RandNum.Next(2000, 4000);
            Thread.Sleep(waitTime);
            if (isPlayerNearby(nick))
            {
                invitePosX = host.me.X;
                invitePosY = host.me.Y;
                invitePosZ = host.me.Z;
                host.RaidInviteAnswer(true);
                host.PartyInviteAnswer(true);
            }
            else
            {
                host.RaidInviteAnswer(false);
                host.PartyInviteAnswer(false);
            }
        }

        public bool isPlayerNearby(String name)
        {
            foreach (var c in host.getCreatures())
            {
                if (c.name.Equals(name))
                {
                    if (host.me.dist(c) <= inviteDist) 
                        return true;
                }
            }
            return false;
        }

        public bool validParty()
        {
            //if (host.getPartyLeaderObj() == host.me)
                //return true;
            if (host.partyInRange(140, false) <= 0)
                return false;
            else if (host.me.dist(invitePosX, invitePosY, invitePosZ) >= 300)
                return false;
            return true;
        }


        public void CheckWeNeedRessurectOurMount()
        {
            var mountItem = host.getInvItem(4941);
            if (mountItem == null) mountItem = host.getInvItem(19517);
            if (mountItem == null) mountItem = host.getInvItem(8161);
            
            if (mountItem != null && !mountItem.mountAlive)
            {
                NpcInfo nearestStabler = null;
                double nearestDist = 9999;
                foreach (var stabler in stablers)
                { 
                    if (host.dist(stabler.X, stabler.Y, stabler.Z) < nearestDist)
                    {
                        nearestDist = host.dist(stabler.X, stabler.Y, stabler.Z);
                        nearestStabler = stabler;
                    }
                }

                if (nearestStabler != null)
                {
                    while (!host.movementModule.GpsMove(nearestStabler.gpsPointName) && host.isAlive())
                        Thread.Sleep(1000);
                    if (host.isAlive())
                    {
                        Thread.Sleep(1000);
                        if (!host.RessurectMount(true))
                            host.Log("Failed res mount " + host.GetLastError());
                    }
                }
            }
        }

        public void CheckWeNeedFreeInventory()
        {
            if (host.inventoryItemsCount() >= 40)
            {
                DeleteTrashItems();
                WareHouseTrashItems();
                if (host.inventoryItemsCount() >= 40)
                {
                    NpcInfo nearestBlacksmith = null;
                    double nearestDist = 9999;
                    foreach (var blacksmith in blacksmiths)
                    {
                        if (host.dist(blacksmith.X, blacksmith.Y, blacksmith.Z) < nearestDist)
                        {
                            nearestDist = host.dist(blacksmith.X, blacksmith.Y, blacksmith.Z);
                            nearestBlacksmith = blacksmith;
                        }
                    }

                    if (nearestBlacksmith != null)
                    {
                        while (host.isAlive() && !host.movementModule.GpsMove(nearestBlacksmith.gpsPointName))
                            Thread.Sleep(1000);
                        if (host.isAlive())
                        {
                            Thread.Sleep(1000);
                            DisenchantTrashItems();
                        }
                    }
                    WareHouseTrashItems();
                }
            }
        }

        public void CheckWeNeedRepair()
        {
            bool needRepair = false;
            foreach (var item in host.me.getItems())
            {
                if (item.place == ItemPlace.Equiped && item.durability < 10 && item.equipCell != EquipItemPlace.Undershirt && item.equipCell != EquipItemPlace.Underpants && item.equipCell != EquipItemPlace.Unknown
                    && item.equipCell != EquipItemPlace.Face && item.equipCell != EquipItemPlace.Hair && item.equipCell != EquipItemPlace.Glasses
                    && item.equipCell != EquipItemPlace.Tail && item.equipCell != EquipItemPlace.Body && item.equipCell != EquipItemPlace.Beard && item.equipCell != EquipItemPlace.Back)
                {
                    host.Log("Need repair item " + item.name + "[" + item.id + "]");
                    needRepair = true;
                    break;
                }
            }
            if (needRepair)
            {
                NpcInfo nearestBlacksmith = null;
                double nearestDist = 9999;
                foreach (var blacksmith in blacksmiths)
                {
                    if (host.dist(blacksmith.X, blacksmith.Y, blacksmith.Z) < nearestDist)
                    {
                        nearestDist = host.dist(blacksmith.X, blacksmith.Y, blacksmith.Z);
                        nearestBlacksmith = blacksmith;
                    }
                }

                if (nearestBlacksmith != null)
                {
                    while (host.isAlive() && !host.movementModule.GpsMove(nearestBlacksmith.gpsPointName))
                        Thread.Sleep(1000);
                    if (host.isAlive())
                    {
                        Thread.Sleep(1000);
                        host.RepairAllEquipment();
                    }
                }
            }
        }

        public void CheckSealedEquips()
        {
            if (host.isInPeaceZone()) //cant unseal in peace zone
                return;
            foreach (var i in host.me.getItems())
            {
                if (i.place != ItemPlace.Bag)
                    continue;
                if ((host.maxInventoryItemsCount() - host.inventoryItemsCount()) > 4 && i.categoryId == 153 || itemsToUnseal.Contains(i.id)) //Unidentified or chests with closes.
                {
                    if (i.id == 29203 || i.id == 29204 || i.id == 29205)
                    {
                        if (!host.characterSettings.autoOpenCoinpurses)
                            continue;
                        while (i.count > 0 && host.me.laborPoints > 150 && host.me.isAlive() && (host.maxInventoryItemsCount() - host.inventoryItemsCount()) > 4)
                        {
                            if (host.isMounted())
                                host.StandFromMount();
                            Thread.Sleep(150);
                            i.UseItem();
                            Thread.Sleep(500);
                            while (host.me.isCasting || host.me.isGlobalCooldown)
                                Thread.Sleep(50);
                        }
                    }
                    else
                    {
                        while (i.count > 0 && host.me.isAlive())
                        {
                            if (host.sqlCore.sqlSkills.ContainsKey(i.skillId))
                            {
                                if (host.me.laborPoints < 70 && host.sqlCore.sqlSkills[i.skillId].consumeLp > 0)
                                    break;
                            }
                            if (host.isMounted())
                                host.StandFromMount();
                            Thread.Sleep(500);
                            i.UseItem();
                            Thread.Sleep(1000);
                            while (host.me.isCasting || host.me.isGlobalCooldown)
                                Thread.Sleep(50);
                        }
                    }
                }
            }
        }

        private Creature GetWareHouseManager()
        {
            double minDist = 999999;
            Creature best = null;
            foreach (var creature in host.getCreatures())
            {
                if (creature.db.banker)
                {
                    if (minDist > host.me.dist(creature))
                    {
                        minDist = host.me.dist(creature);
                        best = creature;
                    }
                }

            }
            return best;
        }

        public void DeleteTrashItems()
        {
            foreach (var i in host.me.getItems())
            {
                if (i.place == ItemPlace.Bag && itemsToDelete.Exists(s => s == i.id))
                {
                    if (!i.DeleteItem())
                        host.Log("Fail delete item " + i.name);
                    Thread.Sleep(500);
                }
            }
        }

        public void WareHouseTrashItems()
        {
            host.SetTarget(GetWareHouseManager());
            foreach (var i in host.me.getItems())
            {
                if (i.place == ItemPlace.Bag && itemsToWareHouse.Exists(s => s == i.id))
                {
                    if (!i.MoveItemToWh())
                        host.Log("Fail move to warehouse " + i.name);
                    Thread.Sleep(500);
                }
            }
        }

        public void DisenchantTrashItems()
        {
            if (host.characterSettings.autoDisenchant)
            {
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && i.reqLevel <= host.me.level && (i.armorType == ArmorType.Heavy || i.armorType == ArmorType.Light || i.armorType == ArmorType.Magic || i.weaponType != WeaponType.Unknown || i.db.accessorySlotTypeId != 0))
                    //if (i.place == ItemPlace.Bag && itemsToDisenchant.Exists(s => s == i.id))
                    {
                        if (host.me.laborPoints > 100 && i.reqLevel > 15 && i.grade != ItemGrade.Common && i.grade != ItemGrade.Poor)
                        {
                            if (host.itemCount(19812) == 0)
                            {
                                host.BuyItems(19812, 5);
                                Thread.Sleep(500);
                            }
                            if (!i.Disenchant())
                                host.Log("Fail disenchant item " + i.name);
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            if (!i.SellItem())
                                host.Log("Fail sell item " + i.name);
                            Thread.Sleep(500);
                        }
                    }
                }
            }
            else
            {
                foreach (var i in host.me.getItems())
                {
                    if (i.place == ItemPlace.Bag && i.reqLevel <= host.me.level && (i.armorType == ArmorType.Heavy || i.armorType == ArmorType.Light || i.armorType == ArmorType.Magic || i.weaponType != WeaponType.Unknown || i.db.accessorySlotTypeId != 0))
                    //if (i.place == ItemPlace.Bag && itemsToDisenchant.Exists(s => s == i.id))
                    {
                        if (!i.SellItem())
                            host.Log("Fail sell item " + i.name);
                        Thread.Sleep(500);
                    }
                }
            }
        }

        public void EquipBestArmorAndWeapon()
        {
            //Считаем коэф шмоток.
            var tempItems = host.me.getItems();
            for (int i = 0; i < tempItems.Count; i++)
            {
                if ((tempItems[i].place == ItemPlace.Bag || tempItems[i].place == ItemPlace.Equiped) && tempItems[i].equipCell != EquipItemPlace.Unknown && host.GetVar(tempItems[i], "coef") == null)
                {
                    double result_coef = 0;
                    result_coef += tempItems[i].statStr * str_coef;
                    result_coef += tempItems[i].statInt * int_coef;
                    result_coef += tempItems[i].statDex * dex_coef;
                    result_coef += tempItems[i].statWit * wit_coef;
                    result_coef += tempItems[i].statCon * con_coef;
                    if (tempItems[i].armorType == ArmorType.Heavy)
                        result_coef += 100 * heavy_coef;
                    if (tempItems[i].armorType == ArmorType.Light)
                        result_coef += 100 * light_coef;
                    if (tempItems[i].armorType == ArmorType.Magic)
                        result_coef += 100 * magic_coef;
                    result_coef += tempItems[i].db.itemLevel * level_coef;
                    host.SetVar(tempItems[i], "coef", result_coef);
                    host.SetVar(tempItems[i], "bestToEquip", false);
                }
            }

            //Ищем лучший шмот
            Dictionary<byte, Item> equipCells = new Dictionary<byte, Item>();
            foreach (var value in Enum.GetValues(typeof(EquipItemPlace)))
            {
                equipCells.Add((byte)value, null);
            }

            //Для пушки с хилом
            bool healBluntExists = false;
            foreach (var item in host.me.getItems())
            {
                if ((item.place == ItemPlace.Bag || item.place == ItemPlace.Equiped) && item.db.requirementLevel <= host.me.level && (item.weaponType == WeaponType.BluntMace || item.weaponType == WeaponType.HealShortspear || item.weaponType == WeaponType.TwoHandBluntMace))
                {
                    host.Log("Have heal item = " + item.name);
                    healBluntExists = true;
                    break;
                }
            }

            double bestCoef = 0;
            double curCoef = 0;
            foreach (var item in host.me.getItems())
            {
                bestCoef = 0;
                curCoef = 0;
                if ((item.place == ItemPlace.Bag || item.place == ItemPlace.Equiped) && item.db.requirementLevel <= host.me.level)
                {
                    bool shouldCheckThisItem = false;
                    if (item.equipCell == EquipItemPlace.Finger || item.equipCell == EquipItemPlace.Ear || item.equipCell == EquipItemPlace.Neck ||
                        item.armorType == ArmorType.Heavy || item.armorType == ArmorType.Light || item.armorType == ArmorType.Magic ||
                        item.weaponType == WeaponType.Bow || item.weaponType == WeaponType.TubeInstrument || item.weaponType == WeaponType.StringInstument || item.weaponType == WeaponType.PercussionInstrument)
                        shouldCheckThisItem = true;
                    //Mystic
                    if (host.characterSettings.weaponPriority == 0 && item.weaponType == WeaponType.TwoHandBluntStaff)
                        shouldCheckThisItem = true;
                    //Range
                    if (host.characterSettings.weaponPriority == 1)
                    {
                        if (host.clientVersion != ClientVersion.RussiaMailRu && healBluntExists && host.isAbilityTaken(Ability.Vitalism))
                        {
                            if (item.weaponType == WeaponType.BluntMace || item.weaponType == WeaponType.HealShortspear || item.weaponType == WeaponType.TwoHandBluntMace)
                                shouldCheckThisItem = true;
                        }
                        else
                        {
                            if (item.weaponType == WeaponType.Shield)
                                shouldCheckThisItem = true;
                            if (item.weaponType == WeaponType.SlashingSword || item.weaponType == WeaponType.FastPiercingDagger || item.weaponType == WeaponType.FastSlashingBlade || item.weaponType == WeaponType.FastSlashingDagger || item.weaponType == WeaponType.NormalPiercingSword || item.weaponType == WeaponType.SlashingBlade || item.weaponType == WeaponType.SlowSlashingSword || item.weaponType == WeaponType.SlowSlashingAxe || item.weaponType == WeaponType.SlowPiercingSpear)
                                shouldCheckThisItem = true;
                        }
                    }
                    //Melee
                    if (host.characterSettings.weaponPriority == 2)
                    {

                        if (host.clientVersion != ClientVersion.RussiaMailRu && healBluntExists && host.isAbilityTaken(Ability.Vitalism))
                        {
                            if (item.weaponType == WeaponType.BluntMace || item.weaponType == WeaponType.HealShortspear || item.weaponType == WeaponType.TwoHandBluntMace)
                                shouldCheckThisItem = true;
                        }
                        else
                        {
                            if (item.weaponType == WeaponType.Shield)
                                shouldCheckThisItem = true;
                            if (item.weaponType == WeaponType.SlashingSword || item.weaponType == WeaponType.FastPiercingDagger || item.weaponType == WeaponType.FastSlashingBlade || item.weaponType == WeaponType.FastSlashingDagger || item.weaponType == WeaponType.NormalPiercingSword || item.weaponType == WeaponType.SlashingBlade || item.weaponType == WeaponType.SlowSlashingSword || item.weaponType == WeaponType.SlowSlashingAxe || item.weaponType == WeaponType.SlowPiercingSpear)
                                shouldCheckThisItem = true;
                        }
                    }
                    if (shouldCheckThisItem)
                    {
                        if (host.GetVar(equipCells[(byte)item.equipCell], "coef") != null)
                            bestCoef = (double)host.GetVar(equipCells[(byte)item.equipCell], "coef");
                        if (host.GetVar(item, "coef") != null)
                            curCoef = (double)host.GetVar(item, "coef");
                        if (equipCells[(byte)item.equipCell] == null || (equipCells[(byte)item.equipCell] != null && bestCoef < curCoef))
                            equipCells[(byte)item.equipCell] = item;
                    }
                }
            }

            foreach (var b in equipCells.Keys.ToList())
            {
                if (equipCells[b] != null && host.GetVar(equipCells[b], "coef") != null)
                    if (equipCells[b].Equip())
                        host.Log(equipCells[b].equipCell + "  best item = " + equipCells[b].name + "   " + equipCells[b].armorType + "   " + equipCells[b].weaponType);

            }
        }

        public void RunRoute()
        {
            if (host.isInParty() && !validParty())
                host.LeaveFromParty();


            //Изучение умений
            foreach (var skill in host.me.getSkillsCanBeLearned())
            {
                if (skill.type == BotTypes.Buff)
                {
                    if (passiveBuffsToLearn.Contains((skill as Buff).dbPassiveBuff.id))
                    {
                        if (skill.Learn())
                            host.Log("Learn passive buff " + (skill as Buff).name);
                        Thread.Sleep(2000);
                    }
                }
                else if (skill.type == BotTypes.Skill)
                {
                    if (activeSkillsToLearn.Contains((skill as Skill).db.id))
                    {
                        if (skill.Learn())
                        {
                            host.Log("Learn skill " + (skill as Skill).name);
                            List<ActionSlot> slotsCanBeUsed = host.me.getActionSlots().FindAll(s => s.slotId >= 1 && s.slotId <= 48 && s.actionId == 0);
                            byte randCell = (byte)randGenerator.Next(0, slotsCanBeUsed.Count);
                            if (slotsCanBeUsed.Count > 0)
                            {
                                host.getSkill((skill as Skill).db.id).AddToActionPanel(slotsCanBeUsed[randCell].slotId);
                                host.Log("Move skill to panel " + (skill as Skill).name + " to cell #" + slotsCanBeUsed[randCell].slotId);
                            }
                        }
                        Thread.Sleep(2000);
                    }
                }
            }
            //Изучение классов
            int activeAbilitiesCount = host.me.getAbilities().Count(i => i.active);
            if (activeAbilitiesCount < 3)
            {
                if (host.me.level >= 5 && activeAbilitiesCount < 2)
                {
                    foreach (var a in abilitiesToLearn)
                    {
                        if (host.LearnSpecialisation((Ability)a))
                            host.Log("Learn specialization " + ((Ability)a).ToString());
                        Thread.Sleep(1000);
                    }
                }
                if (host.me.level >= 10)
                {
                    foreach (var a in abilitiesToLearn)
                    {
                        if (host.LearnSpecialisation((Ability)a))
                            host.Log("Learn specialization " + ((Ability)a).ToString());
                        Thread.Sleep(1000);
                    }
                }
            }
            
            /*if (host.me.inFight || !host.me.isAlive())
                return;
            EquipBestArmorAndWeapon();*/
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

                    Thread.Sleep(30000);
                    try
                    {
                        if (host.me.inFight)
                            continue;
                        if (!host.isAlive(host.me))
                            continue;
                        if (!host.farmModule.readyToActions)
                            continue;
                        RunRoute();
                    }
                    catch (Exception error)
                    {
                        host.Log(error.ToString());
                    }
                }
#if !DEBUG
            }
            catch (Exception error)
            {
                Console.WriteLine("Thread abort. Common module.");
            }
#endif
        }
    }
}
