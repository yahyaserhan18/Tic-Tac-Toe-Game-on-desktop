using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
         public class clsPlayer
        {
            public string name;
            public Image image;
            public bool isTurn = false;
        }
      
       public clsPlayer player1 = new clsPlayer();
       public clsPlayer player2 = new clsPlayer();
        clsPlayer CurrentPlayer = new clsPlayer();
        byte usedPictureNumber = 0;

       void updateCurrentPlayer(clsPlayer curr)
        {
            CurrentPlayer = curr;
            lb_Turn.Text = CurrentPlayer.name;
        }
        void start()
        {
            updateCurrentPlayer(player1);
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        bool isAvailable(PictureBox pb)
        {
            var array1 = ImageToByteArray(pb.Image);
            var array2 = ImageToByteArray(Resources.question_mark_96);
            return (array1.Length == array2.Length);
            
        }

        private bool AreImagesEqual(PictureBox pb1, PictureBox pb2, PictureBox pb3)
        {
            if (pb1.Image == pb2.Image && pb2.Image == pb3.Image && pb1.Image != null)
            {
                pb1.BackColor = Color.GreenYellow;
                pb2.BackColor = Color.GreenYellow;
                pb3.BackColor = Color.GreenYellow;
                return true;
            }
            return false;
        }


        bool plasyIsFinish()
        {
            if (AreImagesEqual(pictureBox1, pictureBox2, pictureBox3)   ||
                  AreImagesEqual(pictureBox4, pictureBox5, pictureBox6) ||
                  AreImagesEqual(pictureBox7, pictureBox8, pictureBox9) ||
                  AreImagesEqual(pictureBox3, pictureBox5, pictureBox9) ||
                  AreImagesEqual(pictureBox1, pictureBox5, pictureBox7) ||
                  AreImagesEqual(pictureBox1, pictureBox6, pictureBox9) ||
                  AreImagesEqual(pictureBox5, pictureBox2, pictureBox8) ||
                  AreImagesEqual(pictureBox3, pictureBox4, pictureBox7))
            {
                lb_Turn.Text = "Game Over";
                lb_Winner.Text = CurrentPlayer.name;
                MessageBox.Show("Game Over");
                RestGame();
                return true;
            }

            if (usedPictureNumber == 9)
            {
                lb_Turn.Text = "Game Over";
                lb_Winner.Text = "Draw";
                MessageBox.Show("Game Over");
                RestGame();
                return true;
            }
            return false;
        }
        void RestGame()
        {
            usedPictureNumber = 0;
            lb_Winner.Text = "In Progress";
            pictureBox1.Image = Resources.question_mark_96;
            pictureBox1.BackColor = Color.Transparent;

            pictureBox2.Image = Resources.question_mark_96;
            pictureBox2.BackColor = Color.Transparent;

            pictureBox3.Image = Resources.question_mark_96;
            pictureBox3.BackColor = Color.Transparent;

            pictureBox4.Image = Resources.question_mark_96;
            pictureBox4.BackColor = Color.Transparent;

            pictureBox5.Image = Resources.question_mark_96;
            pictureBox5.BackColor = Color.Transparent;

            pictureBox6.Image = Resources.question_mark_96;
            pictureBox6.BackColor = Color.Transparent;

            pictureBox7.Image = Resources.question_mark_96;
            pictureBox7.BackColor = Color.Transparent;

            pictureBox8.Image = Resources.question_mark_96;
            pictureBox8.BackColor = Color.Transparent;

            pictureBox9.Image = Resources.question_mark_96;
            pictureBox9.BackColor = Color.Transparent;

            start();
        }

        void play(PictureBox pb)
        {
            if (!isAvailable(pb))
            {
                MessageBox.Show("it already choosed,\nPlease choose another", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usedPictureNumber++;
            pb.Image = CurrentPlayer.image;
            if (plasyIsFinish())
                return;

            if(CurrentPlayer == player1)
                 updateCurrentPlayer(player2);
            else
                updateCurrentPlayer(player1);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            main mainF = new main();

            player1.image = Resources.X;
            player2.image = Resources.O;

            start();

        }
        public Form1()
        {
          
            InitializeComponent();

        }

       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White);
            pen.Width = 10;


            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(pen, 450, 150, 450, 450);
            e.Graphics.DrawLine(pen, 550, 150, 550, 450);
          

            e.Graphics.DrawLine(pen, 350, 250, 650, 250);
            e.Graphics.DrawLine(pen, 350, 350, 650, 350);
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            play((PictureBox)sender);
        }

        private void btn_Rest_Click(object sender, EventArgs e)
        {
            RestGame();

        }
    }
}
