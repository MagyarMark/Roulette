using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Button btnNull = new Button();
        Button button = new Button();
        Button zeroButton = new Button();
        Button Szabaly = new Button();
        Panel panel1 = new Panel();
        Panel panel2 = new Panel();

        public static int BetOsszeg = 0;
        public static int Money = 0;
        public Form1()
        {
            InitializeComponent();
            CreateMatrix();
            this.Text = "Rulett";
            this.Icon = new Icon("favicon.ico");//kép: https://www.flaticon.com/free-icon/roulette_218417
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
        private void CreateMatrix()
        {
            // szám mátrix felvétele
            string[,] numbers = new string[,]
            {
                { "", "", "", "", "", "", "", "", "", "", "", "", "" },
                { "0", "3", "6", "9", "12", "15", "18", "21", "24", "27", "30", "33", "36" },
                { "", "2", "5", "8", "11", "14", "17", "20", "23", "26", "29", "32", "35" },
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

                        zeroButton = new Button();
                        zeroButton.Size = new Size(60, 150);
                        zeroButton.Location = new Point(260, 300);
                        zeroButton.Text = numbers[Oszlop, Sor];
                        zeroButton.Font = new Font("Microsoft Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        zeroButton.FlatStyle = FlatStyle.Popup;
                        zeroButton.TextAlign = ContentAlignment.MiddleCenter;
                        zeroButton.BackColor = greenColor;
                        zeroButton.ForeColor = Color.White;
                        Controls.Add(zeroButton);

                        //gomb újra meghívása és állítása
                        button = new Button();
                        button.Size = new Size(buttonWidth, buttonHeight);
                        button.Location = new Point(startX + Sor * buttonWidth, startY + Oszlop * buttonHeight);
                        button.Text = numbers[Oszlop, Sor];
                        button.FlatStyle = FlatStyle.Popup;
                        button.Font = new Font("Microsoft Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
                        button.TextAlign = ContentAlignment.MiddleCenter;

                        // színezések
                        if (Oszlop == 0 && Sor == 0 && Sorok == 0 && Oszlopok == 0) //a 0-ás gomb zöld
                        {
                            button.BackColor = greenColor;
                            button.ForeColor = Color.White;
                        }
                        else if (Oszlop > 0 && (int.Parse(numbers[Oszlop, Sor]) % 2 == 0))//minden 2-vel osztható szám piros lesz
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
                            Button clickedButton = (Button)sender;
                            Money -= BetOsszeg;
                            MessageBox.Show($"Megtett összeg: {txtMoney.Text}\nSzám:{clickedButton.Text}");
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
            btnBet.Click += new EventHandler(btnBet_Click);
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


            panel1.Dock = DockStyle.Left;
            panel1.BackColor = ColorTranslator.FromHtml("#08121A");
            panel1.Size = new Size(this.Width, this.Height);
            this.Controls.Add(panel1);

            panel2.Dock = DockStyle.Left;
            panel2.BackColor = ColorTranslator.FromHtml("#213743");
            panel2.Size = new Size(250, this.Height);
            this.Controls.Add(panel2);
        }
        private void btnBet_Click(object sender, EventArgs e)
        {
            var BetOsszeg = 0;
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
            }
        }

        private void Szabaly_Click(object sender, EventArgs e)
        {   
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
