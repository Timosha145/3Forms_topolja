using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PictureViewer_topolja
{
    public class Game : Form
    {
        private PictureBox valiPb, pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9, pb10, pb11, pb12, pb13, pb14, pb15, pb16;
        private string[] imageList = { };
        private PictureBox[] pbArray, pbArrayTyhi;
        private string tyhi = @"..\..\tyhi.png";
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4, rnupp5;
        int score = 0;
        int wrongScore = 0;
        int nColumns = 0; int nRows = 0;
        Random rnd = new Random();

        TableLayoutPanel tableLayoutPanel1, tableLayoutPanel2;

        public Game()
        {
            //InitializeComponent();
            questions();
        }

        internal void questions()
        {
            ClientSize = new Size(420, 130);
            BackColor = Color.Bisque;
            rnupp1 = new RadioButton
            {
                Text = "Teema - bussid",
                Name = "rnupp1",
                Width = 170,
                Location = new Point(),
                Enabled = false,
                Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Sienna
            };
            rnupp2 = new RadioButton
            {
                Text = "Teema - Inimesed",
                Name = "rnupp2",
                Width = 170,
                Location = new Point(0, rnupp1.Height),
                Enabled = false,
                Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Sienna
            };
            rnupp3 = new RadioButton
            {
                Text = "Teema - burgerid",
                Name = "rnupp3",
                Width = 170,
                Location = new Point(0, rnupp1.Height+rnupp2.Height),
                Enabled = false,
                Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Sienna
            };

            rnupp4 = new RadioButton
            {
                Text = "Raskus - kerge",
                Name = "kerge",
                Width = 170,
                Location = new Point(),
                Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.DarkRed
            };
            rnupp5 = new RadioButton
            {
                Text = "Raskus - normaalne",
                Name = "normaalne",
                Width = 170,
                Location = new Point(0, rnupp4.Height),
                Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.DarkRed
            };
            tableLayoutPanel2 = new TableLayoutPanel //tableLayoutPanel1 parameetrid
            {
                ColumnCount = 2,
                RowCount = 1,
                Size = new Size(300, 80),
                TabIndex = 0,
                Name = "tableLayoutPanel1",
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
            };
            GroupBox gb1 = new GroupBox
            {
                FlatStyle = FlatStyle.Standard
            };
            GroupBox gb2 = new GroupBox()
            {
                FlatStyle = FlatStyle.Standard
            };


            rnupp1.CheckedChanged += new EventHandler(rnupp_changed);
            rnupp2.CheckedChanged += new EventHandler(rnupp_changed);
            rnupp3.CheckedChanged += new EventHandler(rnupp_changed);
            rnupp4.CheckedChanged += new EventHandler(rnuppRaskus_changed);
            rnupp5.CheckedChanged += new EventHandler(rnuppRaskus_changed);

            Controls.Add(tableLayoutPanel2);
            tableLayoutPanel2.Controls.Add(gb1, 0, 0);
            tableLayoutPanel2.Controls.Add(gb2, 1, 0);

            gb1.Controls.Add(rnupp1);
            gb1.Controls.Add(rnupp2);
            gb1.Controls.Add(rnupp3);

            gb2.Controls.Add(rnupp4);
            gb2.Controls.Add(rnupp5);


        }

        internal void InitializeComponent()
        {
            SuspendLayout();
            if (nRows==4)
            {
                ClientSize = new Size(700, 700);
            }
            else
            {
                ClientSize = new Size(350, 700);
            }
            Name = "matchingGame";
            Text = "Matching Game";
            ResumeLayout(false);
            PerformLayout();

            imageList = imageList.OrderBy(x => rnd.Next()).ToArray(); //teeb imageList muutujad juhuslikus järjekorras

            int i = 0;

            //var vastus = MessageBox.Show("Kas soovite oma pildi valida?", "Küsimus", MessageBoxButtons.YesNo); //kui vastus on jah siis kasutaja saab valida oma mängu pildid
            //if (vastus == DialogResult.Yes)
            //{
            //    valiPb = new PictureBox //valiPb parameetrid
            //    {
            //        BorderStyle = BorderStyle.Fixed3D,
            //        Dock = DockStyle.Fill,
            //        Location = new Point(50),
            //        Size = new Size(169, 169),
            //        SizeMode = PictureBoxSizeMode.Zoom,
            //    };

            //    ClientSize = new Size(270, 200);
            //    Controls.Add(valiPb);
            //}

            tableLayoutPanel1 = new TableLayoutPanel //tableLayoutPanel1 parameetrid
            {
                ColumnCount = nColumns,
                RowCount = nRows,
                Size = new Size(700, 700),
                TabIndex = 0,
                Name = "tableLayoutPanel1",
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
            };

            foreach (PictureBox item in pbArray) //iga pb parameetrid
            {
                pbArray[i] = new PictureBox
                {
                    Image = new Bitmap(imageList[i]),
                    Size = new Size(169, 169),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = imageList[i]
                };
                i ++;
            }

            i = 0;

            foreach (PictureBox item in pbArrayTyhi) //iga pbTyhi parameetrid
            {
                pbArrayTyhi[i] = new PictureBox
                {
                    Image = new Bitmap(tyhi),
                    Size = new Size(169, 169),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = tyhi
                };
                i++;
            }
            pbArrayTyhi[0].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[1].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[2].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[3].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[4].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[5].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[6].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[7].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            if (nRows==4)
            {
            pbArrayTyhi[8].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[9].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[10].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[11].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[12].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[13].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[14].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            pbArrayTyhi[15].Click += new EventHandler(Game_Click); //kui pbTyhi pilt on vajutatud
            }
            Controls.Add(tableLayoutPanel1); //paneb tableLayoutPanel1 vormisse
            
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[0], 0, 0); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[1], 0, 1); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[2], 0, 2); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[3], 0, 3); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[4], 1, 0); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[5], 1, 1); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[6], 1, 2); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[7], 1, 3); //paneb pbTyhi tabelisse
            if (nRows==4)
            {
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[8], 2, 0); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[9], 2, 1); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[10], 2, 2); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[11], 2, 3); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[12], 3, 0); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[13], 3, 1); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[14], 3, 2); //paneb pbTyhi tabelisse
            tableLayoutPanel1.Controls.Add(pbArrayTyhi[15], 3, 3); //paneb pbTyhi tabelisse
            }
            
        }

        private void Game_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = (PictureBox)sender;
            int columnN = tableLayoutPanel1.GetColumn(pictureBox1);
            int rowN = tableLayoutPanel1.GetRow(pictureBox1);
            int c = columnN;
            int n = -1;
            //arvab veeru ja rida järgi milline picturebox on vaja näidata
            if (columnN < 1)
            {
                n = rowN;
            }
            while (c >= 1)
            {
                n += 4;
                c--;
                if (c < 1)
                {
                    rowN++;
                    n += rowN;
                }
            }
            //pictureBox1.Image = new Bitmap(pbArray[n].Image);

            //kui picture box ei ole juba õige
            if (pictureBox1.Name != "checked")
            {
                pictureBox1.ImageLocation = pbArray[n].ImageLocation;
                pictureBox1.Name = "";
            }

            PictureBox pictureBox2;

            pictureBox2 = new PictureBox
            {
                Name = "1"
            };

            //millise pildiga on vaja pildi võrdlema
            foreach (var item in pbArrayTyhi)
            {
                if (item.Name == "pictureBox1")
                {
                    pictureBox2 = item;
                }
            }
            if (pictureBox1.Name != "checked")
            {
            pictureBox1.Name = "pictureBox1";
            }
             
            //MessageBox.Show("pb2-" + pictureBox2.Name + " pb1-" + pictureBox1.Name);

            if (pictureBox1.Name == pictureBox2.Name && pictureBox2.Name != "checked")
            {
            PictureBoxCheck(pictureBox1, pictureBox2);
            }

        }

        //kui pildid on samad
        private void PictureBoxCheck(PictureBox pb1, PictureBox pb2 )
        {
            //MessageBox.Show(pb1.ImageLocation + " 2: " + pb2.ImageLocation);
            if (pb1.ImageLocation == pb2.ImageLocation)
            {
                score++;
                pb1.Name = "checked";
                pb2.Name = "checked";
                //MessageBox.Show("Samad!");
            }

            //pole vaja
            else if (pb1.ImageLocation != pb2.ImageLocation)
            {
                MessageBox.Show("vale");
                pb1.Image = pb2.Image = new Bitmap(tyhi);
                pb1.Name = pb2.Name = "";
                wrongScore += 1;
            }

            //kui kõi pildid on õigesti valitud tuleb võit
            if (score>=8)
            {
                MessageBox.Show("Võit! Teie valimus oli - "+wrongScore.ToString()+" korda valesti");
                DialogResult vastus = MessageBox.Show("Kas soovite veel üks kord mängida?", "Küsimus", MessageBoxButtons.YesNo); //kui vastus on jah siis toimub veel üks mäng
                newGame(vastus);
            }
        }

        private void newGame(DialogResult vastus)
        {
            if (vastus == DialogResult.Yes)
            {
                foreach (var item in pbArrayTyhi)
                {
                    item.ImageLocation = tyhi;
                    item.Name = null;
                }
                pbArray = pbArray.OrderBy(x => rnd.Next()).ToArray(); //teeb imageList muutujad juhuslikus järjekorras
                wrongScore = score = 0;
            }
            if (vastus == DialogResult.No)
                Close();
        }

        void rnupp_changed(object sender, EventArgs e)
        {
            RadioButton rnupp = (RadioButton)sender;

            if (rnupp.Name=="rnupp1")
            {
                imageList = new string[] { @"..\..\b1.jpg", @"..\..\b2.jpg", @"..\..\b3.jpg", @"..\..\b4.jpg", @"..\..\b5.jpg", @"..\..\b6.jpg", @"..\..\b7.jpg", @"..\..\b8.jpg"};
            }
            else if (rnupp.Name == "rnupp2")
            {
                imageList = new string[] { @"..\..\i1.jpg", @"..\..\i2.jpg", @"..\..\i3.jpg", @"..\..\i4.jpg", @"..\..\i5.jpg", @"..\..\i6.jpg", @"..\..\i7.jpg", @"..\..\i8.jpg"};
            }
            else if (rnupp.Name == "rnupp3")
            {
                imageList = new string[] { @"..\..\t1.jpg", @"..\..\t2.jpg", @"..\..\t3.jpg", @"..\..\t4.jpg", @"..\..\t5.jpg", @"..\..\t6.jpg", @"..\..\t7.jpg", @"..\..\t8.jpg"};
            }
            if (nRows==3)
            {
                imageList = imageList.OrderBy(x => rnd.Next()).ToArray();
                imageList = imageList.Take(imageList.Length-4).ToArray();
            }

            imageList = imageList.Concat(imageList).ToArray();

            if (rnupp4.Checked || rnupp5.Checked)
            {
                tableLayoutPanel2.Hide();
                InitializeComponent();
            }
        }
        void rnuppRaskus_changed(object sender, EventArgs e)
        {
            RadioButton rnupp = (RadioButton)sender;
            if (rnupp.Name == "kerge")
            {
                nColumns = 3;
                nRows = 3;
                score = 4;
                pbArray = new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8};
                pbArrayTyhi = new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8};
            }
            else if (rnupp.Name == "normaalne")
            {
                nColumns = 4;
                nRows = 4;
                pbArray = new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9, pb10, pb11, pb12, pb13, pb14, pb15, pb16 };
                pbArrayTyhi = new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9, pb10, pb11, pb12, pb13, pb14, pb15, pb16 };
            }

            rnupp1.Enabled = true;
            rnupp2.Enabled = true;
            rnupp3.Enabled = true;

            if (rnupp1.Checked || rnupp2.Checked || rnupp3.Checked)
            {
                tableLayoutPanel2.Hide();
                InitializeComponent();
            }
        }

    }
}