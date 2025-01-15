using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MM_BM_Roulette
{
    public partial class Form2 : Form
    {
        private TextBox txtName;
        private TextBox txtBalance;
        private Button btnSubmit;
        private Panel pnlForm2;
        private Label lblbev;
        private ComboBox cmbOptions;
        private Label lblvalaszt;

        public Form2()
        {
            Form2_Load(null, null);
            this.Icon = new Icon("favicon.ico"); // kép: https://www.flaticon.com/free-icon/roulette_218417
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Text = "Rulett Játék";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            txtName = new TextBox
            {
                Text = "Add meg a neved",
                Location = new Point(145, 30),
                Size = new Size(210, 30),
                BackColor = ColorTranslator.FromHtml("#213743"),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(txtName);

            txtBalance = new TextBox
            {
                Text = "Add meg az egyenlegedet",
                Location = new Point(145, 70),
                Size = new Size(210, 30),
                BackColor = ColorTranslator.FromHtml("#213743"),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center
            };
            this.Controls.Add(txtBalance);

            cmbOptions = new ComboBox
            {
                Location = new Point(145, 110),
                Size = new Size(210, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = ColorTranslator.FromHtml("#213743"),
                ForeColor = Color.White
            };

            // Opciók hozzáadása
            cmbOptions.Items.AddRange(new object[]
            {
                "1 játékos",
                "2 játékos",
                "3 játékos",
                "4 játékos",
                "5 játékos"
            });
            cmbOptions.SelectedIndex = 0;
            this.Controls.Add(cmbOptions);

            lblvalaszt = new Label
            {
                Text = "Add meg a játékosok számat:",
                Location = new Point(145, 95),
                Size = new Size(210, 30),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White
            };
            this.Controls.Add(lblvalaszt);

            btnSubmit = new Button
            {
                Text = "Megadás",
                Location = new Point(145, 150),
                Size = new Size(210, 40),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.Green,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btnSubmit.Click += btnSubmit_Click;
            this.Controls.Add(btnSubmit);

            lblbev = new Label
            {
                Text = "Üdvözöllek a Rulett Játékben!\nKészítette: Magyar Márk és Butty Máté\nSok szerencsét a játék során!",
                Location = new Point(5, 185),
                Size = new Size(500, 140),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White
            };
            this.Controls.Add(lblbev);

            pnlForm2 = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(500, 350),
                BackColor = ColorTranslator.FromHtml("#08121A")
            };
            this.Controls.Add(pnlForm2);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string playerName = txtName.Text;
            string balanceInput = txtBalance.Text;
            decimal playerBalance;

            // Név ellenőrzése
            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Kérlek, add meg a neved!", "Hiányzó név", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Egyenleg ellenőrzése
            if (!decimal.TryParse(balanceInput, out playerBalance) || playerBalance <= 0)
            {
                MessageBox.Show("Kérlek, adj meg egy érvényes, pozitív egyenleget!", "Hiányzó vagy érvénytelen egyenleg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedPlayers = cmbOptions.SelectedIndex + 1;

            Random random = new Random();
            string[] randomNames = {
                "János",
                "Éva",
                "Péter",
                "Anna",
                "Gábor",
                "Lilla",
                "Tamás",
                "Zsófia",
                "Vivien",
                "Márk",
                "Máté",
                "Zoltán",
                "Albert",
                "Ábel",
                "Bettina",
                "Balázs",
                "Dorottya",
                "Erika",
                "Ferenc",
                "Gábor",
                "Bence",
                "Hajnalka",
                "Ildiko",
                "József",
                "Katalin",
                "László",
                "Miklós",
            };
            List<string> players = new List<string>();
            HashSet<int> usedBalances = new HashSet<int>();

            int randomBalance = random.Next(0, 5000);
            for (int i = 0; i < selectedPlayers; i++)
            {
                do
                {
                    randomBalance = random.Next(1, 5000);
                } while (!usedBalances.Add(randomBalance));//ismétlés szűrése
                string randomName = randomNames[random.Next(randomNames.Length)];
                players.Add($"{randomName} - {randomBalance} Ft");
            }

            string playersInfo = string.Join("\n", players);
            MessageBox.Show($"Üdv, {playerName}!\nAz egyenleged: {playerBalance} Ft\n\nEllenfél Játékosok:\n{playersInfo}",
                "Játék indul", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form1 mainForm = new Form1(playerName, playerBalance, players, randomBalance);
            mainForm.Show();
            this.Hide();
        }
    }
}