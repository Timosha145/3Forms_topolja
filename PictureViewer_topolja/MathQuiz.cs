using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace PictureViewer_topolja
{
    public class MathQuiz : Form
    {
        public event EventHandler Tick;
        Random rnd = new Random();
        string[] Maths = { "Lisa", "Lahuta", "Korruta" };
        double total1, total2, total3, total4, score, correct, wrongScore;
        private int counter = 60;
        private Timer timer1;
        private Label lblScore, lblWrongScore;
        private Label lblTimer, lblSymbol1, lblSymbol2, lblSymbol3, lblSymbol4, lblNumB1, lblNumB2, lblNumB3, lblNumB4, lblEquals1, lblEquals2, lblEquals3, lblEquals4, lblAnswer, lblNumA1, lblNumA2, lblNumA3, lblNumA4;
        private TextBox txtAnswer1, txtAnswer2, txtAnswer3, txtAnswer4;
        private Button button1, buttonTimer;
        Label[] labelSymArray = { }, lblNumArrayA = { }, lblNumArrayB = { }, lblEqualsArray = { };
        TextBox[] txtAnswerArray = { };
        double[] totalArray = { };

        TableLayoutPanel tableLayoutPanel1;

        public MathQuiz()
        {
            InitializeComponent();
        }
        internal void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(350, 300);
            Name = "MathQuiz";
            Text = "Maths Quiz Game";
            BackColor = Color.Bisque;
            ResumeLayout(false);
            PerformLayout();
            labelSymArray = new Label[] { lblSymbol1, lblSymbol2, lblSymbol3, lblSymbol4 };
            lblNumArrayA = new Label[] { lblNumA1, lblNumA2, lblNumA3, lblNumA4 };
            lblNumArrayB = new Label[] { lblNumB1, lblNumB2, lblNumB3, lblNumB4 };
            lblEqualsArray = new Label[] { lblEquals1, lblEquals2, lblEquals3, lblEquals4 };
            txtAnswerArray = new TextBox[] { txtAnswer1, txtAnswer2, txtAnswer3, txtAnswer4 };
            totalArray = new double[] { total1, total2, total3, total4 };

            int i = 0;


            tableLayoutPanel1 = new TableLayoutPanel //tableLayoutPanel1 parameetrid
            {
                ColumnCount = 6,
                RowCount = 6,
                Size = new Size(310, 280),
                TabIndex = 0,
                Name = "tableLayoutPanel1",
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
            };

            lblScore = new Label //lblScore parameetrid
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Name = "lblScore",
                Size = new Size(50, 15),
                TabIndex = 0,
                Text = "Punktid: 0",
                Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.DarkGreen
            };

            lblWrongScore = new Label //lblScore parameetrid
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Name = "lblWrongScore",
                Size = new Size(50, 15),
                TabIndex = 0,
                Text = "Vale punktid: 0",
                Font = new Font("Calibri", 13F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.OrangeRed
            };

            foreach (Label sym in lblNumArrayA) //iga lblA parameetrid
            {
                lblNumArrayA[i] = new Label
                {
                    AutoSize = true,
                    Name = "lblNumA",
                    Size = new Size(50, 35),
                    TabIndex = 1,
                    Text = "?",
                    Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 200),
                    ForeColor = Color.Sienna
                };
                i++;
            }
            i = 0;

            foreach (Label sym in labelSymArray) //iga lblSymbol parameetrid
            {
                labelSymArray[i] = new Label
                {
                    AutoSize = true,
                    Name = "lblSymbol",
                    Size = new Size(35, 35),
                    TabIndex = 2,
                    Text = "*",
                    Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 200),
                    ForeColor = Color.Sienna
                };
                i++;
            }
            i = 0;

            foreach (Label sym in lblNumArrayB) //iga lblNumB parameetrid
            {
                lblNumArrayB[i] = new Label
                {
                    AutoSize = true,
                    Name = "lblNumB",
                    Size = new Size(50, 35),
                    TabIndex = 3,
                    Text = "?",
                    Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 200),
                    ForeColor = Color.Sienna
                };
                i++;
            }
            i = 0;

            foreach (Label sym in lblEqualsArray) //iga lblEquals parameetrid
            {
                lblEqualsArray[i] = new Label
                {
                    AutoSize = true,
                    Name = "label4",
                    Size = new Size(35, 35),
                    TabIndex = 4,
                    Text = "=",
                    Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 200),
                    ForeColor = Color.Sienna
                };
                i++;
            }
            i = 0;

            lblAnswer = new Label //lblAnswer parameetrid
            {
                AutoSize = true,
                Name = "lblAnswer",
                Size = new Size(50, 15),
                TabIndex = 5,
                Text = "",
                Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Green
            };

            foreach (TextBox sym in txtAnswerArray) //iga txtAnswer parameetrid
            {
                txtAnswerArray[i] = new TextBox
                {
                    Multiline = true,
                    Name = "txtAnswer",
                    Size = new Size(80, 35),
                    TabIndex = 6,
                    Enabled = false,
                    Font = new Font("Calibri", 15F, FontStyle.Bold, GraphicsUnit.Point, 200),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };
                i++;
            }
            i = 0;

            button1 = new Button //button1 parameetrid
            {
                Location = new Point(290, 40),
                Name = "button1",
                Size = new Size(75, 35),
                TabIndex = 7,
                Text = "Kontrolli",
                UseVisualStyleBackColor = true,
                Enabled = false,
                Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            buttonTimer = new Button //buttonTimer parameetrid
            {
                Location = new Point(290, 40),
                Name = "button1",
                Size = new Size(75, 35),
                TabIndex = 7,
                Text = "Alusta",
                UseVisualStyleBackColor = true,
                Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            lblTimer = new Label //lblTimer parameetrid
            {
                AutoSize = true,
                Name = "lblAnswer",
                Size = new Size(50, 15),
                TabIndex = 5,
                Text = "--",
                Font = new Font("Calibri", 20F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Sienna
            };
            timer1 = new Timer //timer1 parameetrid
            {
                Interval = 1000
            };
        

            Controls.Add(tableLayoutPanel1); //paneb tableLayoutPanel1 vormise

            timer1.Tick += timer1_Tick; //iga sekundi jargi hakkab töötama meetod timer1_Tick
            buttonTimer.Click += ButtonTimer_Click; //kui buttonTimer nupp on vajutatud

            txtAnswerArray[0].TextChanged += new EventHandler(CheckAnswer); //kui tekst on uuendatud hakkab töötama meetod CheckAnswer
            txtAnswerArray[1].TextChanged += new EventHandler(CheckAnswer); //kui tekst on uuendatud hakkab töötama meetod CheckAnswer
            txtAnswerArray[2].TextChanged += new EventHandler(CheckAnswer); //kui tekst on uuendatud hakkab töötama meetod CheckAnswer
            txtAnswerArray[3].TextChanged += new EventHandler(CheckAnswer); //kui tekst on uuendatud hakkab töötama meetod CheckAnswer

            button1.Click += new EventHandler(CheckButtonClickEvent);

            tableLayoutPanel1.Controls.Add(lblNumArrayA[0], 0, 0); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayA[1], 0, 1); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayA[2], 0, 2); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayA[3], 0, 3); //paneb lblNumA[n] tabelisse

            tableLayoutPanel1.Controls.Add(lblNumArrayB[0], 1, 0); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayB[1], 1, 1); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(labelSymArray[2], 1, 2); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(labelSymArray[3], 1, 3); //paneb lblNumA[n] tabelisse

            tableLayoutPanel1.Controls.Add(labelSymArray[0], 1, 0); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(labelSymArray[1], 1, 1); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayB[2], 1, 2); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblNumArrayB[3], 1, 3); //paneb lblNumA[n] tabelisse

            tableLayoutPanel1.Controls.Add(txtAnswerArray[0], 4, 0); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(txtAnswerArray[1], 4, 1); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(txtAnswerArray[2], 4, 2); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(txtAnswerArray[3], 4, 3); //paneb lblNumA[n] tabelisse

            tableLayoutPanel1.Controls.Add(lblEqualsArray[0], 3, 0); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblEqualsArray[1], 3, 1); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblEqualsArray[2], 3, 2); //paneb lblNumA[n] tabelisse
            tableLayoutPanel1.Controls.Add(lblEqualsArray[3], 3, 3); //paneb lblNumA[n] tabelisse

            tableLayoutPanel1.Controls.Add(lblAnswer, 4, 4); //paneb lblAnswer tabelisse
            tableLayoutPanel1.Controls.Add(lblScore, 4, 4); //paneb lblScore tabelisse
            tableLayoutPanel1.Controls.Add(button1, 4, 4); //paneb lbutton1 tabelisse
            tableLayoutPanel1.Controls.Add(lblWrongScore, 4, 5); //paneb lblWrongScore tabelisse
            tableLayoutPanel1.Controls.Add(buttonTimer, 4, 5); //paneb buttonTimer tabelisse
            tableLayoutPanel1.Controls.Add(lblTimer); //paneb llblTimer tabelisse

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter > 0) //kui on veel aega
            {
                counter = counter - 1;
                lblTimer.Text = "00:"+counter;
            }
            else //kui rohkem aega ei ole ülessaned teha rohkem ei saa
            {
                timer1.Stop();
                lblTimer.Text = "Rohkem aega ei ole!";
                foreach (var item in txtAnswerArray)
                {
                    item.Enabled = false;
                }
            }
        }
        private void ButtonTimer_Click(object sender, EventArgs e) //kui on vajutatud algab mäng
        {
            Game();
            foreach (var item in txtAnswerArray)
            {
                item.Enabled = true;
            }
            buttonTimer.Enabled = false;
            button1.Enabled = true;

            timer1.Start();
        }

        private void CheckAnswer(object sender, EventArgs e) //vaatab kas vastus on õige või ei
        {
            for (int i = 0; i < 4; i++)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtAnswerArray[i].Text, "[^0-9]"))
            {
                MessageBox.Show("Ainult numbrid palun!");
                txtAnswerArray[i].Text = txtAnswerArray[i].Text.Remove(txtAnswerArray[i].Text.Length - 1);
            }
            }
        }

        private void CheckButtonClickEvent(object sender, EventArgs e)//kui vastused on õige annab uut ülesannet
        {

            for (int i = 0; i < 4; i++) 
            {
                int userEntered = 0;
                try
                {
                    userEntered = Convert.ToInt32(txtAnswerArray[i].Text);
                }
                catch (FormatException)
                {
                    //MessageBox.Show("Kõik numbrid kirjuta!");
                }

                if (userEntered == totalArray[i])
                {
                    correct += 1;
                }
                else
                {
                }

            }

            if (correct>=4 ) //kui õige anab veel ülesannet
            {
                lblAnswer.Text = "Õige!";
                lblAnswer.ForeColor = Color.Green;
                score += 1;
                lblScore.Text = "Punktid: " + score;
                Motivation f = new Motivation();
                f.Show();
                Game();
            }
            else
            {
                wrongScore++;
                lblWrongScore.Text = "Vale punktid: " + wrongScore;
                lblAnswer.Text = "Vale!";
                lblAnswer.ForeColor = Color.Red;
            }
            correct = 0;
        }

        private void Game() //mängu meetod
        {
            ClientSize = new Size(380, 300);
            if (score==2)
            {
                Maths = new string[] { "Lisa", "Lahuta", "Korruta", "Ruut" };
            }
            for (int ii = 0; ii < 4; ii++)
            {

                int numA = rnd.Next(10, 20);
                int numB = rnd.Next(0, 9);

                txtAnswerArray[ii].Text = null;


                string Tsym = "";
                Color colorSym = Color.Black;
                    switch (Maths[rnd.Next(0, Maths.Length)])
                    {
                        case "Lisa": //kui on +
                            totalArray[ii] = numA + numB;
                            Tsym = "+";
                            colorSym = Color.Green;
                            break;

                        case "Lahuta": //kui on -
                        totalArray[ii] = numA - numB;
                            Tsym = "-";
                            colorSym = Color.Maroon;
                            break;

                        case "Korruta": //kui on *
                        totalArray[ii] = numA * numB;
                            Tsym = "x";
                            colorSym = Color.Purple;
                            break;

                        case "Ruut": //kui on ^2
                            numB = 2;
                            totalArray[ii] = (numA * numA);
                            Tsym = "^";
                            colorSym = Color.Aqua;
                            break;
                }
                    labelSymArray[ii].Text = Tsym;
                
                
                lblNumArrayA[ii].Text = numA.ToString();
                lblNumArrayB[ii].Text = numB.ToString();
            }
        }

    }
}
