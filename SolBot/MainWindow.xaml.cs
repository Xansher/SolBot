using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Speech.Synthesis;


namespace SolBot
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Objects.Client Client = null;

        public MainWindow(Process realesta)
        {
            this.Client = new Objects.Client(realesta, true);
            /*int pid = 0;

            if (pid != 0)
            {
                Process p = null;
                try { p = Process.GetProcessById(pid); }
                catch { return; }
                if (p == null || p.HasExited) return;

                this.Client = new Objects.Client(p, true);

            }
            else
            {
                Process[] p = Process.GetProcessesByName("RealestaOGL");
                if (p.Length == 0)
                {
                    //Write console
                }
                else
                {
                    Process realesta = p[0];
                    this.Client = new Objects.Client(realesta, true);
                }
            }*/
            /*ObservableCollection<Objects.Rune> List = new ObservableCollection<Objects.Rune>();
            List.Add(new Objects.Rune("SD", "SD", "adori vita vis"));
            List.Add(new Objects.Rune("GFB", "GFB", "adori gran flam"));
            List.Add(new Objects.Rune("UH", "UH", "adura vita"));
            SpellComboBox.ItemsSource = List;*/
            
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();


        }
        private void HealChecked(object sender, RoutedEventArgs e)
        {
            if (HealEnabled.IsChecked.Value != this.Client.Modules.Healer.IsRunning)
            {

                if (HealEnabled.IsChecked.Value)
                {
                    this.Client.Addresses.SetAddresses(this.Client);
                    console.Blocks.Add(new Paragraph(new Run("Healer Enabled")));
                    this.Client.Modules.Healer.Health = Convert.ToInt32(HealthCount.Text); ;
                    this.Client.Modules.Healer.Mana = Convert.ToInt32(ManaCount.Text); ;
                    this.Client.Modules.Healer.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("Healer Disabled")));
                    this.Client.Modules.Healer.Stop();
                }
                
            }
        }
        private void AlarmsChecked(object sender, RoutedEventArgs e)
        {
            if (AlarmsEnabled.IsChecked.Value != this.Client.Modules.Alarms.IsRunning)
            {

                if (AlarmsEnabled.IsChecked.Value)
                {
                    //int mainOffset = 0;
                    //int bAdd = 0x0048DA2C;
                    
                    //int off = 0xC;
                    //int baseAdd = this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32();
                    //int battleListAdd=this.Client.Memory.ReadInt32(this.Client.TibiaProcess.MainModule.BaseAddress.ToInt32() +bAdd);

                    //int offset_posx = 0xC;
                    //int offset_posy = 0x10;
                    //int offset_posz = 0x14;
                    //int offset_id = 0x1C;
                    //int offset_name = 0x20;
                    //int offset_hpperc = 0x38;
                    //int offset_type = 0x20+ 0x12A;
                    //int offset_direction = 0x3C;


                    //for (int i = 0; i < 200; i++)
                    //{
                    //    int main = i * 0x4;
                    //    int offset = battleListAdd + main;
                    //    int temp = this.Client.Memory.ReadInt32(offset);
                    //    int first = this.Client.Memory.ReadInt32(temp + off);
                    //    string tempname = this.Client.Memory.ReadStdString(first + offset_name);
                    //    int x = this.Client.Memory.ReadInt32(first + offset_posx);
                    //    System.Console.WriteLine(main.ToString() + tempname);
                    //    if (tempname.Length > 2 && tempname.Length < 32)
                    //    {
                    //        mainOffset = main;
                    //        break;
                    //    }
                    //}
                    //List<int> offsets = new List<int>();
                    //offsets.Add(mainOffset);
                    //offsets.Add(0xC);
                    
                    //int battleList = this.Client.Memory.FindDMAAddy(battleListAdd, offsets);
                    //string name = this.Client.Memory.ReadStdString(battleList + offset_name);
                    //string firstName = "";
                    //int lp = 0;
                    //while (name != firstName/*name.Length>2 && name.Length<32*/)
                    //{
                    //    if (lp == 0)
                    //        firstName = name;
                    //    uint posx = this.Client.Memory.ReadUInt32(battleList + offset_posx);
                    //    uint posy = this.Client.Memory.ReadUInt32(battleList + offset_posy);
                    //    uint posz = this.Client.Memory.ReadUInt16(battleList + offset_posz);
                    //    uint uid = this.Client.Memory.ReadUInt32(battleList + offset_id);
                    //    uint type=9;
                    //    if (uid < 0x40000000)//player
                    //        type = 0;
                    //    if (uid >= 0x40000000 && uid < 0x80000000) //monster
                    //        type = 1;
                    //    if (uid >= 0x80000000) //npc
                    //        type = 2;
                    //    //console.Blocks.Add(new Paragraph(new Run(this.Client.Player.ZPos.ToString())));
                    //    uint myXPos = this.Client.Player.XPos;
                    //    uint myYPos = this.Client.Player.YPos;

                    //    if (posx < (myXPos+8) && posx> (myXPos - 8) && posy < (myYPos + 6) && posy > (myYPos - 6)  && posz == this.Client.Player.ZPos && name !=this.Client.Player.Name)
                    //    {
                    //        console.Blocks.Add(new Paragraph(new Run("x: " + posx.ToString() + " y: " + posy.ToString() + " z: " + posz.ToString() + " name: " + name + " uid: " + uid.ToString()+ " type: " + type.ToString())));
                    //    }
                    //    //find next one
                    //    offsets.Insert(1, 0x0);
                    //    battleList= this.Client.Memory.FindDMAAddy(battleListAdd, offsets);
                    //    name = this.Client.Memory.ReadStdString(battleList + 0x20);
                    //    lp++;
                    //}
                    ///*for (int i=0;i<250;i++)
                    //{
                    //    int main = i * 0x4;
                    //    int offset=battleListAdd + main;
                    //    int temp=this.Client.Memory.ReadInt32(offset);
                    //    int first=this.Client.Memory.ReadInt32(temp+off);
                    //    string name = this.Client.Memory.ReadStdString(first + nameOff);
                    //    int x = this.Client.Memory.ReadInt32(first + offset_posx);
                    //    System.Console.WriteLine(main.ToString()+name);
                    //    if (name.Length>2 && name.Length<32)
                    //    {
                    //        console.Blocks.Add(new Paragraph(new Run(main.ToString())));
                    //        mainOffset = main;
                    //        List<int> offsets = new List<int>();
                    //        offsets.Add(mainOffset);
                    //        offsets.Add(0xC);
                    //        for (int ij = 0; ij < 60; ij++)
                    //        {
                                
                    //            int battleList = this.Client.Memory.FindDMAAddy(battleListAdd, offsets);
                    //            uint posx = this.Client.Memory.ReadUInt32(battleList + offset_posx);

                    //            uint posy = this.Client.Memory.ReadUInt32(battleList + offset_posy);
                    //            uint posz = this.Client.Memory.ReadUInt16(battleList + offset_posz);
                    //            string sname = this.Client.Memory.ReadString(battleList + 0x20);
                    //            string stdString = this.Client.Memory.ReadStdString(battleList + 0x20);

                    //            int uid = this.Client.Memory.ReadInt32(battleList + 0x1C);
                               
                    //            if (posx < 60000 && posy < 60000 && posz == 7)
                    //            {
                    //                //console.Blocks.Add(new Paragraph(new Run(a)));
                    //                console.Blocks.Add(new Paragraph(new Run("x: " + posx.ToString() + " y: " + posy.ToString() + " z: " + posz.ToString() + " name: " + stdString + " uid: " + uid.ToString())));
                    //            }
                    //            offsets.Insert(1, 0x0);
                    //             //console.Blocks.Add(new Paragraph(new Run("x:" + x.ToString() + "y:" + y.ToString() + "z:" + z.ToString() + "name:" + sname + uid.ToString())));
                    //        }
                    //    }

                    //   // int add = this.Client.Memory.ReadInt32(battleListAdd + mainOffset);
                    //    //  console.Blocks.Add(new Paragraph(new Run(add.ToString())));


                    //}*/
                    
                    //this.Client.Functions.SendChangeFightModes(1, 1, 1, 0);
                    ////this.Client.Functions.SendTurn(1);
                    //this.Client.Functions.SendAttack(268454980, 1);
                    console.Blocks.Add(new Paragraph(new Run("Alarms Enabled")));
                    this.Client.Modules.Alarms.HealthBelow = Convert.ToInt32(HelthBelow.Text);
                    this.Client.Modules.Alarms.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("Alarms Disabled")));
                    this.Client.Modules.Alarms.Stop();
                }

            }
        }

            private void EnableLightHack(object sender, RoutedEventArgs e)
        {
            //this.Client.Player.EnableLightHack();
            console.Blocks.Add(new Paragraph(new Run("LightHack Enabled")));
            double mana = this.Client.Player.Mana;
            console.Blocks.Add(new Paragraph(new Run(mana.ToString())));
            this.Client.Functions.SendTalk(new Objects.Client.StdString("adori flam"), new Objects.Client.StdString(""), 1, 0);

        }

        private void AutoSpeedChecked(object sender, RoutedEventArgs e)
        {
            if (AutoSpeedEnabled.IsChecked.Value != this.Client.Modules.AutoSpeed.IsRunning)
            {

                if (AutoSpeedEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("AutoSpeed Enabled")));
                    this.Client.Modules.AutoSpeed.MinMana = Convert.ToInt32(MinMana.Text);
                    this.Client.Modules.AutoSpeed.MinHealth = Convert.ToInt32(MinHealth.Text);
                    this.Client.Modules.AutoSpeed.MinSpeed = Convert.ToInt32(MinSpeed.Text);
                    this.Client.Modules.AutoSpeed.Spell = new Objects.Client.StdString(AutoSpeedSpell.Text);
                    this.Client.Modules.AutoSpeed.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("AutoSpeed Disabled")));
                    this.Client.Modules.AutoSpeed.Stop();
                }

            }

      

        }


        private void RuneMakerChecked(object sender, RoutedEventArgs e)
        {
            if (RuneMakerEnabled.IsChecked.Value != this.Client.Modules.RuneMaker.IsRunning)
            {

                if (RuneMakerEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("RuneMaker Enabled")));
                    this.Client.Modules.RuneMaker.ManaHigh = Convert.ToInt32(ManaHigh.Text);
                    this.Client.Modules.RuneMaker.ManaLow = Convert.ToInt32(ManaLow.Text);
                    this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString(Spell.Text);
                    Objects.Rune rune = (Objects.Rune)SpellComboBox.SelectedItem;
                    this.Client.Modules.RuneMaker.Soul = rune.Soul;
                    this.Client.Modules.RuneMaker.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("RuneMaker Disabled")));
                    this.Client.Modules.RuneMaker.Stop();
                }

            }

            /*if (HealEnabled.IsChecked.Value != this.Client.Modules.Healer.IsRunning)
            {

                if (HealEnabled.IsChecked.Value)
                {
                    this.Client.Addresses.SetAddresses(this.Client);
                    console.Blocks.Add(new Paragraph(new Run("Healer Enabled")));
                    this.Client.Modules.Healer.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("Healer Disabled")));
                    this.Client.Modules.Healer.Stop();
                }

            }*/


        }

        private void FoodEaterChecked(object sender, RoutedEventArgs e)
        {
            if (FoodEaterEnabled.IsChecked.Value != this.Client.Modules.FoodEater.IsRunning)
            {

                if (FoodEaterEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("FoodEater Enabled")));
                    this.Client.Modules.FoodEater.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("FoodEater Disabled")));
                    this.Client.Modules.FoodEater.Stop();
                }

            }
        }

        private void TargetingChecked(object sender, RoutedEventArgs e)
        {
            if (TargetingEnabled.IsChecked.Value != this.Client.Modules.Targeting.IsRunning)
            {

                if (TargetingEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("Targeting Enabled")));
                    
                    this.Client.Modules.Targeting.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("Targeting Disabled")));
                    this.Client.Modules.Targeting.Stop();
                }

            }

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
            switch (SpellComboBox.SelectedItem)
            {
                case "SD":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adori vita vis");
                        console.Blocks.Add(new Paragraph(new Run("WYbrano")));
                        break;
                    }
                case "HMM":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adori gran");
                        break;
                    }
                case "UH":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adura vita");
                        break;
                    }
                case "GFB":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adori gran flam");
                        break;
                    }
                case "FB":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adori flam");
                        break;
                    }
                case "MW":
                    {
                        this.Client.Modules.RuneMaker.spell = new Objects.Client.StdString("adori vita vis");
                        break;
                    }
                default:
                    {
                        console.Blocks.Add(new Paragraph(new Run("Pusty")));
                        break;
                    }

            }
            
        }

        private void RuneChanged(object sender, SelectionChangedEventArgs e)
        {
            Objects.Rune rune= (Objects.Rune)SpellComboBox.SelectedItem;

            Spell.Text = rune.Spell;
            ManaHigh.Text = rune.ManaHigh.ToString();
            ManaLow.Text = rune.ManaLow.ToString();
        }

        private void AutoFisherChecked(object sender, RoutedEventArgs e)
        {
            if (AutoFisherEnabled.IsChecked.Value != this.Client.Modules.AutoFisher.IsRunning)
            {

                if (AutoFisherEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("AutoFisher Enabled")));
                    
                    this.Client.Modules.AutoFisher.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("RuneMaker Disabled")));
                    this.Client.Modules.AutoFisher.Stop();
                }

            }
        }

        private void TrainPointsChecked(object sender, RoutedEventArgs e)
        {
            if (TrainPointsEnabled.IsChecked.Value != this.Client.Modules.TrainPoints.IsRunning)
            {

                if (TrainPointsEnabled.IsChecked.Value)
                {
                    console.Blocks.Add(new Paragraph(new Run("TrainPoints Enabled")));

                    this.Client.Modules.TrainPoints.Start();
                }
                else
                {
                    console.Blocks.Add(new Paragraph(new Run("TrainPoints Disabled")));
                    this.Client.Modules.TrainPoints.Stop();
                }

            }
        }
    }

    
}
