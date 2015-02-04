using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Runtime.InteropServices;
using ArcheBuddy.Bot.Classes;
using AutoExp.Modules;
using AutoExp.Forms;

namespace AutoExp
{
    public class Host : Core
    {
        public bool cancelRequested;
        internal CharacterSettings characterSettings;
        internal List<AutoExp.Modules.Module> modules;
        internal CommonModule commonModule { get; set; }
        internal FarmModule farmModule { get; set; }
        internal MovementModule movementModule { get; set; }
        internal QuestModule questModule { get; set; }
        internal Main mainForm { get; set; }
        private Thread formThread;

        private void RegisterModule(AutoExp.Modules.Module module)
        {
            modules.Add(module);
            module.Start(this);
        }

        private void RunForm()
        {
            try
            {
                Application.Run(mainForm);
            }
            catch (Exception error)
            {
                Log(error.ToString());
            }
        }

        

        public bool isAbilityTaken(Ability ability)
        {
            if (characterSettings.skillset1 == (int)ability || characterSettings.skillset2 == (int)ability || characterSettings.skillset3 == (int)ability)
                return true;
            return false;
        }

        internal bool CircleIntersects(double x, double y, double R, double AX, double AY, double BX, double BY)
        {
            double L = Math.Sqrt(Math.Pow((BX - AX), 2) + Math.Pow((BY - AY), 2));
            // единичный вектор отрезка AB 
            double Xv = (BX - AX) / L;
            double Yv = (BY - AY) / L;
            double Xd = (AX - x);
            double Yd = (AY - y);
            double b = 2 * (Xd * Xv + Yd * Yv);
            double c = Xd * Xd + Yd * Yd - R * R;
            double c4 = c + c; c4 += c4;
            double D = b * b - c4;
            if (D < 0) return false; // нет корней, нет пересечений

            D = Math.Sqrt(D);
            double l1 = (-b + D) * 0.5;
            double l2 = (-b - D) * 0.5;
            bool intersects1 = ((l1 >= 0.0) && (l1 <= L));
            bool intersects2 = ((l2 >= 0.0) && (l2 <= L));
            bool intersects = intersects1 || intersects2;
            return intersects;
        }

        public void PluginStop()
        {
            cancelRequested = true;
            foreach (var module in modules)
            {
                try
                {
                    module.Stop();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.ToString());
                }
            }

            try
            {
                if (mainForm != null)
                {
                    mainForm.Invoke(new Action(() => {
                        try { mainForm.Close(); }
                        catch { }
                        try { mainForm.Dispose(); }
                        catch { }
                    }));
                }
                Application.Exit();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
            try
            {
                formThread.Abort();
                Console.WriteLine("Aborted!");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error on stopping questing Thread!");
            }
        }

        static internal string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


        public bool CheckBeforeStart()
        {
            if (me == null || gameState != GameState.Ingame)
            {
                MessageBox.Show("Please, launch plugin when your character ingame.");
                return false;
            }
            return true;
        }

        public bool LoadSettings()
        {

            string cfgName = AssemblyDirectory + "\\Configs\\" + me.name + "[" + serverName() + "_" + me.uniqId + "].xml";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(cfgName);
            }
            catch 
            {
                if (File.Exists(cfgName))
                    File.Move(cfgName, cfgName + ".bak");
                var settingsForm = new Settings(this, true);
                if (settingsForm.ShowDialog() == DialogResult.OK)
                    return LoadSettings();
                return false;
            }
            
            return true;
        }

        public void ApplySettings()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(CharacterSettings));
                using (var fs = File.Open(AssemblyDirectory + "\\Configs\\" + me.name + "[" + serverName() + "_" + me.uniqId + "].xml", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    characterSettings = (CharacterSettings)reader.Deserialize(fs);
                }
            }
            catch { }
        }

        public void PluginRun()
        {
            try
            {
                while (gameState != GameState.Ingame)
                    Thread.Sleep(100);
                Thread.Sleep(new Random().Next(10000, 20000));
                cancelRequested = false;
                characterSettings = new CharacterSettings();
                modules = new List<AutoExp.Modules.Module>();
                if (!CheckBeforeStart())
                    return;
                if (!Directory.Exists(AssemblyDirectory + "\\Configs"))
                    Directory.CreateDirectory(AssemblyDirectory + "\\Configs");
                if (!LoadSettings())
                    return;
                ApplySettings();
                
                mainForm = new Main();
                mainForm.SetHost(this);
                mainForm.Text = "AutoExp v0.7: " + serverName() + "[" + me.name + "]";
                commonModule = new CommonModule();
                movementModule = new MovementModule();
                questModule = new QuestModule();
                farmModule = new FarmModule();
                ClearLogs();
                ResumeMoveTo();
                RegisterModule(commonModule);
                RegisterModule(farmModule);
                RegisterModule(movementModule);
                RegisterModule(questModule);

                formThread = new Thread(RunForm);
                formThread.IsBackground = true;
                formThread.SetApartmentState(ApartmentState.STA);
                formThread.Start();
                while (!cancelRequested)
                    Thread.Sleep(100);
            }
            catch (Exception error) {
                Log(error.ToString());
            }

        }
    }
}
