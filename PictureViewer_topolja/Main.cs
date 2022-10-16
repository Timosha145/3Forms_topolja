using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PictureViewer_topolja
{
    internal class Main : Form
    {

        Button button1, button2, button3, button4;
        private Button[] btArray;
        public Main()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(530, 150);
            BackColor = Color.Bisque;
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();

            button1 = new Button()
            {
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new Point(50, 40),
                Name = "PictureViewer",
                Size = new Size(140, 70),
                Text = "Ava 'PictureViewer' vormi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            button2 = new Button()
            {
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new Point(200, 40),
                Name = "MathQuiz",
                Size = new Size(140, 70),
                Text = "Ava 'MathQuiz' vormi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            button3 = new Button()
            {
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 200),
                Location = new Point(350, 40),
                Name = "Game",
                Size = new Size(140, 70),
                Text = "Ava 'Game' vormi",
                UseVisualStyleBackColor = true,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;

            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f3 = new Form1();
            f3.Show();
            //this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MathQuiz f3 = new MathQuiz();
            f3.Show();//
            //this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Game f3 = new Game();
            f3.Show();
            //this.Close();
        }

    }
}
