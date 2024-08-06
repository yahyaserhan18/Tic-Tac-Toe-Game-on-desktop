using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        
        private void btn_Start_Click(object sender, EventArgs e)
        {

           

            if (txb_Player1.Text == "" )
                MessageBox.Show("Enter player1 names !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txb_Player2.Text == "")
                MessageBox.Show("Enter player2 names !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Form1 gameForm = new Form1();
                gameForm.player1.name = txb_Player1.Text;
                gameForm.player2.name = txb_Player2.Text;
                this.Visible = false;
                gameForm.ShowDialog();
                this.Close();
            }
           

        }

    }
}
