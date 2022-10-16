using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PictureViewer_topolja
{
    internal class Motivation : Form
    {
        private string[] imageList = { @"..\..\yes1.jpg", @"..\..\yes2.jpg", @"..\..\yes3.jpg" };
        PictureBox pb;
        Random rnd = new Random();
        public Motivation()
        {
            InitializeComponent();
        }

        internal void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(200, 200);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();

            pb = new PictureBox
            {
                Image = new Bitmap(imageList[rnd.Next(0,3)]),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Controls.Add(pb);
        }
    }
}
