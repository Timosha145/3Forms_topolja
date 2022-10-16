using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace PictureViewer_topolja
{
    public partial class Form1 : Form
    {

        TableLayoutPanel tableLayoutPanel1;
        PictureBox pictureBox1;
        CheckBox checkBoxScretch;
        FlowLayoutPanel flowLayoutPanel1;
        Button buttonClose, buttonColor, buttonClear, buttonShow, buttonPictureRotate, buttonSave, pesumasin;
        OpenFileDialog openFileDialog1;
        ColorDialog colorDialog1;
        TrackBar trackBar1;
        Size imageSize1;
        int widthA = 0;
        int heightA = 0;
        int trackBarValue = 0;
        int time=250;
        Image image1, imageStandart;
        ComboBox comboBox1;
        Label label1;
        Timer timer1;
        SoundPlayer m1, m2;

        int rotationAngle = 90;

        public Form1()
        {
            InitializeComponent();
        }

        internal void InitializeComponent() //avab vormi
        {

            Text = "Picture Viewer";
            Size = new Size(1000, 900);
            AllowDrop = true;
            BackColor = Color.Bisque;
            m1 = new SoundPlayer(@"..\..\lgSound1.wav");
            m2 = new SoundPlayer(@"..\..\lgSound2.wav");


            tableLayoutPanel1 = new TableLayoutPanel //TableLayoutPanel parameetrid
            {
                ColumnCount = 2,
                RowCount = 2,
                Size = new Size(800, 450),
                TabIndex = 0,
                Name = "tableLayoutPanel1",
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
            };
            Controls.Add(tableLayoutPanel1); //paneb tableLayoutPanel1 vormise

            pictureBox1 = new PictureBox //PictureBox parameetrid
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill,
                Name = "pictureBox1",
                Size = new Size(800, 800)
            };
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2); //pictureBox1 koht tabelis
            Controls.Add(pictureBox1); //paneb pictureBox1 vormise

            checkBoxScretch = new CheckBox //CheckBox parameetrid
            {
                AutoSize = true,
                Location = new Point(0, 400),
                Name = "checkBoxScretch",
                Size = new Size(65, 20),
                TabIndex = 1,
                Text = "Kriimusta",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            checkBoxScretch.CheckedChanged += CheckBoxScretch_CheckedChanged; //kui checked CheckedChanged hakkab töötama meetod CheckBoxScretch_CheckedChanged
            Controls.Add(checkBoxScretch); //paneb checkBoxScretch vormise

            flowLayoutPanel1 = new FlowLayoutPanel //flowLayoutPanel1 parameetrid
            {
                Dock = DockStyle.Fill,
                Location = new Point(125, 410),
                Name = "flowLayoutPanel1",
                Size = new Size(675, 40),
                TabIndex = 2
            };

            buttonClose = new Button //buttonClose parameetrid
            {
                AutoSize = true,
                Name = "buttonClose",
                TabIndex = 0,
                Text = "Kinni",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            buttonColor = new Button //buttonColor parameetrid
            {
                AutoSize = true,
                Name = "buttonColor",
                TabIndex = 1,
                Text = "Vali tagaplani värv",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            buttonClear = new Button //buttonClear parameetrid
            {
                AutoSize = true,
                Name = "buttonClear",
                TabIndex = 2,
                Text = "Kustuta pildi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            buttonShow = new Button //buttonShow parameetrid
            {
                AutoSize = true,
                Name = "buttonShow",
                TabIndex = 5,
                Text = "Vali pildi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            buttonPictureRotate = new Button //buttonPictureRotate parameetrid
            {
                AutoSize = true,
                Name = "buttonRotate",
                TabIndex = 1,
                Text = "Pöörata pildi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            buttonSave = new Button //buttonPictureRotate parameetrid
            {
                AutoSize = true,
                Name = "buttonRotate",
                TabIndex = 1,
                Text = "Salvesta pildi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            trackBar1 = new TrackBar
            {
                Size = new Size(200, 15),
                Minimum = 0,
                Maximum = 20,
                Value = 20,
                BackColor = Color.Sienna,
                ForeColor = Color.White            
            };

            comboBox1 = new ComboBox
            {
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            label1 = new Label
            {
                AutoSize = true,
                Name = "filter",
                Size = new Size(50, 15),
                TabIndex = 5,
                Text = "Pildi filter - ",
                Font = new Font("Calibri", 15, FontStyle.Bold, GraphicsUnit.Point, 200),
                ForeColor = Color.Sienna

            };

            pesumasin = new Button //buttonColor parameetrid
            {
                AutoSize = true,
                Name = "pesumasin",
                TabIndex = 1,
                Text = "Pesumasin",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            timer1 = new Timer //timer1 parameetrid
            {
                Interval = 40
            };

            comboBox1.Items.Add("Esialgne");
            comboBox1.Items.Add("Punane");
            comboBox1.Items.Add("Roheline");
            comboBox1.Items.Add("Sinine");

            flowLayoutPanel1.Controls.Add(buttonClose); //paneb buttonClose vormise
            flowLayoutPanel1.Controls.Add(buttonColor); //paneb buttonColor vormise
            flowLayoutPanel1.Controls.Add(buttonClear); //paneb buttonClear vormise
            flowLayoutPanel1.Controls.Add(buttonShow); //paneb buttonShow vormise
            flowLayoutPanel1.Controls.Add(buttonPictureRotate); //paneb buttonPictureColor vormise
            flowLayoutPanel1.Controls.Add(buttonSave); //paneb buttonPictureColor vormise
            flowLayoutPanel1.Controls.Add(trackBar1);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(comboBox1);
            flowLayoutPanel1.Controls.Add(pesumasin);

            buttonClose.Click += ButtonClose_Click; //kui buttonClose nupp on vajutatud
            buttonColor.Click += ButtonColor_Click; //kui buttonColor nupp on vajutatud
            buttonClear.Click += ButtonClear_Click; //kui buttonClear nupp on vajutatud
            buttonShow.Click += ButtonShow_Click; //kui buttonShow nupp on vajutatud
            buttonSave.Click += ButtonSave_Click;
            buttonPictureRotate.Click += ButtonPictureRotate_Click;
            trackBar1.Scroll += zoomSlider_Scroll;
            pesumasin.Click += Pesumasin_Click;
            timer1.Tick += Timer1_Tick;

            comboBox1.SelectedValueChanged += ComboBox1_ValueMemberChanged;

            openFileDialog1 = new OpenFileDialog //openFileDialog1 parameetrid
            {
                FileName = "openFileDialog1",
                Filter = "All files (*.*)|*.*",
                Title = "Vali pildi fail"
            };

            colorDialog1 = new ColorDialog //colorDialog1 parameetrid
            {
                AllowFullOpen = true,
                AnyColor = true,
                SolidColorOnly = false
            };

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F)); //lisab ColumnStyles
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F)); //lisab ColumnStyles
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0); //paneb pictureBox1 tabelisse
            tableLayoutPanel1.Controls.Add(checkBoxScretch, 0, 1); //paneb checkBoxScretch tabelisse
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1); //paneb flowLayoutPanel1 tabelisse
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F)); //lisab RowStyles
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); //lisab RowStyles
            flowLayoutPanel1.PerformLayout();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0) //kui on veel aega
            {
                time = time - 1;
                image1 = RotateImage(image1, rotationAngle);
                pictureBox1.Image = image1;
            }
            else
            {
                m2.Play();
                timer1.Stop();
                rotationAngle = 90;
                time = 250;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void Pesumasin_Click(object sender, EventArgs e)
        {
            rotationAngle = 3;
            m1.Play();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();
        }

        private void ComboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
            Color color = Color.Black; //Your desired colour

            switch (comboBox1.SelectedItem)
            {
                case "Esialgne": break;
                case "Punane": color = Color.Red; break;
                case "Roheline": color = Color.Green; break;
                case "Sinine": color = Color.Blue; break;
            }

            byte r = color.R; //For Red colour

            Bitmap bmp = new Bitmap(image1);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color gotColor = bmp.GetPixel(x, y);
                    gotColor = Color.FromArgb(r, gotColor.G, gotColor.B);
                    bmp.SetPixel(x, y, gotColor);
                }
            }

            if (color == Color.Black)
            {
                bmp = new Bitmap(imageStandart);
            }
            pictureBox1.Image = bmp;
            image1 = bmp;
            pictureBox1.Show();
        }

        private void ButtonPictureRotate_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = RotateImage(pictureBox1.Image, rotationAngle);
            image1 = pictureBox1.Image;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Salvesta pildi...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.FileName = "tore_pilt";
                savedialog.Filter = "Image Files(*.JPG)|*.JPG";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(savedialog.FileName, ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Pilt ei ole salvestanud!", "Viga",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //kui vastus on OK näitab faili
            {
                pictureBox1.Load(openFileDialog1.FileName);
                imageSize1 = pictureBox1.Size;
                image1 = pictureBox1.Image;
                imageStandart = pictureBox1.Image;
                imageSize1 = new Size(pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null; //tühistab pildi
        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) //kui vastus on OK paneb tagaplaani värv
                pictureBox1.BackColor = colorDialog1.Color;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close(); //paneb vormi kinni
        }

        private void CheckBoxScretch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScretch.Checked)//kui checked on valitud siis vahetab pildi suurust
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void zoomSlider_Scroll(object sender, EventArgs e)
        {
            widthA = pictureBox1.Width;
            heightA = pictureBox1.Height;
            if (trackBar1.Value>trackBarValue)
            {
                double w = pictureBox1.Width - (trackBar1.Value * (pictureBox1.Width * 0.05));
                double h = pictureBox1.Height - (trackBar1.Value * (pictureBox1.Height * 0.05));

                widthA -= (int)w;
                heightA -= (int)h;

                imageSize1 = new Size(widthA, heightA);
            }
            else if (trackBar1.Value < trackBarValue)
            {
                double w = imageSize1.Width - ((19-trackBar1.Value) * (imageSize1.Width * 0.05));
                double h = imageSize1.Height - ((19-trackBar1.Value) * (imageSize1.Height * 0.05));

                //MessageBox.Show(imageSize1.Width.ToString()+ " width"+ ", "+ imageSize1.Height.ToString()+ " height");
                widthA = (int)w;
                heightA = (int)h;

            }

            //MessageBox.Show(trackBarValue.ToString()+" "+trackBar1.Value.ToString());
            trackBarValue =trackBar1.Value;
            //imageSize1 = new Size(widthA, heightA);
            if (pictureBox1.Image != null)
            {
            Bitmap finalImg = new Bitmap(image1, widthA, heightA); //Muudab pildi suurust vastavalt etteantud parameetritele
            pictureBox1.Image = finalImg;
            pictureBox1.Show();
            }
        }

    }
}
