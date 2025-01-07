﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM_BM_Roulette
{
    public partial class Form1 : Form
    {
        TextBox fixmoney = new TextBox();
        TextBox txtMoney = new TextBox();
        Button btnBet = new Button();
        Button button = new Button();
        Button Szabaly = new Button();
        Button clickedButton = new Button();
        Button piros = new Button();
        Button fekete = new Button();
        Button s1to12 = new Button();
        Button s13to24 = new Button();
        Button s25to36 = new Button();
        Panel panel1 = new Panel();
        Panel panel2 = new Panel();

        public static int BetOsszeg = 0;
        public static int Money = 0;
        public static bool gomb = false;
        public Form1()
        {
            InitializeComponent();
            SzamMatrix();
            this.Text = "Rulett";
            this.Icon = new Icon("favicon.ico");//kép: https://www.flaticon.com/free-icon/roulette_218417
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void SzamMatrix()
        {
            
            // szám mátrix felvétele
            string[,] numbers = new string[,]
            {
                { "", "", "", "", "", "", "", "", "", "", "", "", "" },
                { "", "3", "6", "9", "12", "15", "18", "21", "24", "27", "30", "33", "36" },
                { "0", "2", "5", "8", "11", "14", "17", "20", "23", "26", "29", "32", "35" },
                { "", "1", "4", "7", "10", "13", "16", "19", "22", "25", "28", "31", "34" }
            };
            // méretek
            int Oszlopok = numbers.GetLength(0);
            int Sorok = numbers.GetLength(1);

            // elhelyési érték 
            int startX = 270;
            int startY = 250;
            int buttonWidth = 50;
            int buttonHeight = 50;

            // Színek
            Color greenColor = Color.Green;
            Color redColor = Color.Red;
            Color blackColor = Color.Black;
            

            for (int Oszlop = 0; Oszlop < Oszlopok; Oszlop++)
            {
                for (int Sor = 0; Sor < Sorok; Sor++)
                {
                    // ellenörzi a mátrix celláját(van-e benne érték)
                    if (!string.IsNullOrEmpty(numbers[Oszlop, Sor]))
                    {
                        //gomb újra meghívása és állítása
                        button = new Button();
                        button.Size = new Size(buttonWidth, buttonHeight);
                        button.Location = new Point(startX + Sor * buttonWidth, startY + Oszlop * buttonHeight);
                        button.Text = numbers[Oszlop, Sor];
                        button.FlatStyle = FlatStyle.Popup;
                        button.Font = new Font(button.Font.FontFamily, 12);
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        
                        piros = new Button();
                        piros.Size = new Size(100, 60);
                        piros.FlatStyle = FlatStyle.Popup;
                        piros.Location = new Point(518, 500);
                        piros.BackColor = redColor; 
                        piros.ForeColor = Color.Red;
                        Controls.Add(piros);

                        fekete = new Button();
                        fekete.Size = new Size(100, 60);
                        fekete.FlatStyle = FlatStyle.Popup;
                        fekete.Location = new Point(618, 500);
                        fekete.BackColor = blackColor;
                        fekete.ForeColor = Color.Black;
                        Controls.Add(fekete);
                        
                        s13to24.Text = "13 to 24";
                        s13to24 = new Button();
                        s13to24.Size = new Size(200, 50);
                        s13to24.FlatStyle = FlatStyle.Popup;
                        s13to24.Location = new Point(520, 450);
                        s13to24.Font = new Font(s13to24.Font.FontFamily, 12);
                        s13to24.BackColor = Color.Gray;
                        s13to24.ForeColor = Color.White;
                        Controls.Add(s13to24);

                        s1to12.Text = "1 to 12";
                        s1to12 = new Button();
                        s1to12.Size = new Size(200, 50);
                        s1to12.FlatStyle = FlatStyle.Popup;
                        s1to12.Location = new Point(320, 450);
                        s1to12.Font = new Font(s1to12.Font.FontFamily, 12);
                        s1to12.BackColor = Color.Gray;
                        s1to12.ForeColor = Color.White;
                        Controls.Add(s1to12);
                        
                        s25to36.Text = "25 to 36";
                        s25to36 = new Button();
                        s25to36.Size = new Size(200, 50);
                        s25to36.FlatStyle = FlatStyle.Popup;
                        s25to36.Location = new Point(720, 450);
                        s25to36.Font = new Font(s25to36.Font.FontFamily, 12);
                        s25to36.BackColor = Color.Gray;
                        s25to36.ForeColor = Color.White;
                        Controls.Add(s25to36);

                        // színezések
                        if (numbers[Oszlop, Sor] == "0") //a 0-ás gomb zöld
                        {
                            button.BackColor = greenColor;
                            button.ForeColor = Color.White;
                            button.Size = new Size(60, 150);
                            button.Location = new Point(260, 300);
                        }
                        else if (numbers[Oszlop, Sor] == "3" || numbers[Oszlop, Sor] == "9" || numbers[Oszlop, Sor] == "12" || numbers[Oszlop, Sor] == "18" || numbers[Oszlop, Sor] == "21" || numbers[Oszlop, Sor] == "27" || numbers[Oszlop, Sor] == "30" || numbers[Oszlop, Sor] == "36" || numbers[Oszlop, Sor] == "5" || numbers[Oszlop, Sor] == "14" || numbers[Oszlop, Sor] == "23" || numbers[Oszlop, Sor] == "32" || numbers[Oszlop, Sor] == "1" || numbers[Oszlop, Sor] == "7" || numbers[Oszlop, Sor] == "16" || numbers[Oszlop, Sor] == "19" || numbers[Oszlop, Sor] == "25" || numbers[Oszlop, Sor] == "34")//piros gombok
                        {
                            button.BackColor = redColor;
                            button.ForeColor = Color.White;
                        }
                        else
                        {
                            button.BackColor = blackColor;
                            button.ForeColor = Color.White;
                        }
                        
                        //meghívás a button click-re
                        button.Click += (sender, e) =>
                        {
                           clickedButton = (Button)sender;
                           gomb = true;
                           BtnBet_Click(sender, e);
                            
                           /*Money -= BetOsszeg;
                           MessageBox.Show($"Megtett összeg: {txtMoney.Text}\nSzám:{clickedButton.Text}");*/

                        };
                       
                        //hozzáadás ablakhoz
                        Controls.Add(button);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fixmoney.Text = "Money: 1000";
            fixmoney.Location = new Point(35, 10);
            fixmoney.Size = new Size(200, 20);
            fixmoney.Enabled = false;
            fixmoney.TextAlign = HorizontalAlignment.Center;
            fixmoney.Font = new Font(txtMoney.Font, FontStyle.Bold);
            this.Controls.Add(fixmoney);

            txtMoney.Text = "összeg";
            txtMoney.Location = new Point(35, 40);
            txtMoney.Size = new Size(200, 20);
            txtMoney.BackColor = Color.Gray;
            txtMoney.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(txtMoney);

            btnBet.Text = "Bet";
            btnBet.FlatStyle = FlatStyle.Popup;
            btnBet.Location = new Point(35, 70);
            btnBet.Size = new Size(200, 30);
            btnBet.BackColor = Color.Green;
            btnBet.TextAlign = ContentAlignment.MiddleCenter;
            btnBet.Font = new Font(btnBet.Font, FontStyle.Bold);
            btnBet.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnBet.Click += BtnBet_Click;
            this.Controls.Add(btnBet);

            Szabaly.Text = "i";
            Szabaly.FlatStyle = FlatStyle.Popup;
            Szabaly.Location = new Point(8, 10);
            Szabaly.Size = new Size(20, 90);
            Szabaly.BackColor = Color.Blue;
            Szabaly.TextAlign = ContentAlignment.MiddleCenter;  // Szöveg középre igazítása
            Szabaly.Font = new Font(Szabaly.Font.FontFamily, 20, FontStyle.Bold);
            Szabaly.ForeColor = ColorTranslator.FromHtml("#ffffff");
            Szabaly.Click += new EventHandler(Szabaly_Click);
            this.Controls.Add(Szabaly);

            //panel bal oldal szín beállítás
            panel1.Dock = DockStyle.Left;
            panel1.BackColor = ColorTranslator.FromHtml("#08121A");
            panel1.Size = new Size(this.Width, this.Height);
            this.Controls.Add(panel1);

            //panel jobb oldal beállítás
            panel2.Dock = DockStyle.Left;
            panel2.BackColor = ColorTranslator.FromHtml("#213743");
            panel2.Size = new Size(250, this.Height);
            this.Controls.Add(panel2);
        }
        private void BtnBet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMoney.Text, out int Megtettosszeg) || Megtettosszeg <= 0)
            {
                MessageBox.Show("Kérjük, adjon meg egy érvényes fogadási összeget.", "Hibás Bet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string moneyText = fixmoney.Text.Replace("Money: ", "");
            if (!int.TryParse(moneyText, out int JelenlegiPenz))
            {
                MessageBox.Show("\r\nNem sikerült lekérni a jelenlegi pénzt.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Megtettosszeg > JelenlegiPenz)
            {
                MessageBox.Show("Nincs elég pénze a fogadás megtételéhez.", "Elégtelen pénzeszköz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            JelenlegiPenz -= Megtettosszeg;

            // Random spin logic
            Random random = new Random();
            int GySzam = random.Next(0, 37);
            int KiSzam;
            int Kifizetes;


            MessageBox.Show($"Győztes szám: {GySzam}", "Pörgetés eredménye", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (clickedButton != null && int.TryParse(clickedButton.Text, out KiSzam))
            {
                if (KiSzam == GySzam)
                {
                    Kifizetes = Megtettosszeg * 35;  // 35x szorzó a számokra tett fogadásnál
                    JelenlegiPenz += Kifizetes;
                    MessageBox.Show($"Nyertél! Kifizetés: {Kifizetes}", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vesztettél. Sok szerencsét legközelebb", "Próbáld újra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            fixmoney.Text = $"Money: {JelenlegiPenz}";
        }
        /*var BetOsszeg = 0;
        var Money = 0;
        var moneyText = fixmoney.Text.Replace("Money: ", "");
        if (!int.TryParse(moneyText, out Money))
        {
            MessageBox.Show("Hiba történt az aktuális pénz kiolvasásakor.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // txtmoney ellenőrzese
        if (!int.TryParse(txtMoney.Text, out BetOsszeg) || BetOsszeg <= 0)
        {
            MessageBox.Show("Kérjük, adjon meg egy érvényes tétösszeget!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Összeg ellenőrzése
        if (BetOsszeg > Money)
        {
            MessageBox.Show("A megadott összeg több mint amennyi pénzed van", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            Money -= BetOsszeg;//Megadott összeget kivonja a fix összegből
            fixmoney.Text = $"Money: {Money}";
        }*/

        private void Szabaly_Click(object sender, EventArgs e)
        {
            
            string szoveg = "További információk";
            Szabaly.Text = "i";
            var felirat = Szabaly.Text.Replace("Szabályzat: \n ", "");
            if (Szabaly.Text == "i")
            {
                Szabaly.Text = "i";
                MessageBox.Show("Szabályzat: \n ", "Alap Szabályzat", MessageBoxButtons.OK);
            }
            if (MessageBoxButtons.OK == MessageBoxButtons.OK)
            {
                Szabaly.Text = "i";
                MessageBox.Show("Esélyek: \n ", "Nyerési Esélyek",MessageBoxButtons.OK);
            }
        }
    }
}
