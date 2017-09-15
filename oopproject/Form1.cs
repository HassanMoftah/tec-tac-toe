using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oopproject
{
    public partial class Form1 : Form
    {
        bool turn = true;
        bool agains_com = false;
        int turn_count = 0; 
       


        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Hassan Moftah", "About Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkforwinner();
            if((!turn)&&(agains_com))
            {
                computermove();
            }
            
        }
        private void checkforwinner()
        {
            bool there_is_a_winner=false;
            //HORIZENTAL_CHECKS;
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            //VERTICAL_CHECKS;
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //DIAGONAL_CHECKS;
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if(there_is_a_winner)
            {
                disabledbuttons();
                string winner;
                if (turn)
                {
                    winner = "O";
                    owincount.Text = (Int32.Parse(owincount.Text) + 1).ToString();
                }
                else
                {
                    winner = "X";
                    xwincount.Text = (Int32.Parse(xwincount.Text) + 1).ToString();

                }
                MessageBox.Show(winner + "winner","yay");
            }
            else
            {
                if(turn_count==9)
                {
                    MessageBox.Show("Draw!", "Bummer");
                    drawcount.Text = (Int32.Parse(drawcount.Text) + 1).ToString();

                }
               
            }
        }
        private void disabledbuttons()
        {
            
            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                    
                }
            
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            agains_com = false;
            turn_count = 0;
            againstcomputer.Enabled = true;
            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }  
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
                b.Text = "";
        }

        private void resetCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            owincount.Text = "0";
            xwincount.Text = "0";
            drawcount.Text = "0";
        }

        private void computer(object sender, EventArgs e)
        {
            agains_com = true;
            againstcomputer.Enabled = false;
        }
        private Button look_for_winorblock(string hassan)
        {
             //HORIZONTAL TESTS
            if ((A1.Text == hassan) && (A2.Text == hassan) && (A3.Text == ""))
                return A3;
            if ((A2.Text == hassan) && (A3.Text == hassan) && (A1.Text == ""))
                return A1;
            if ((A1.Text == hassan) && (A3.Text == hassan) && (A2.Text == ""))
                return A2;
 
            if ((B1.Text == hassan) && (B2.Text == hassan) && (B3.Text == ""))
                return B3;
            if ((B2.Text == hassan) && (B3.Text == hassan) && (B1.Text == ""))
                return B1;
            if ((B1.Text == hassan) && (B3.Text == hassan) && (B2.Text == ""))
                return B2;
 
            if ((C1.Text == hassan) && (C2.Text == hassan) && (C3.Text == ""))
                return C3;
            if ((C2.Text == hassan) && (C3.Text == hassan) && (C1.Text == ""))
                return C1;
            if ((C1.Text == hassan) && (C3.Text == hassan) && (C2.Text == ""))
                return C2;
 
            //VERTICAL TESTS
            if ((A1.Text == hassan) && (B1.Text == hassan) && (C1.Text == ""))
                return C1;
            if ((B1.Text == hassan) && (C1.Text == hassan) && (A1.Text == ""))
                return A1;
            if ((A1.Text == hassan) && (C1.Text == hassan) && (B1.Text == ""))
                return B1;
 
            if ((A2.Text == hassan) && (B2.Text ==hassan) && (C2.Text == ""))
                return C2;
            if ((B2.Text == hassan) && (C2.Text == hassan) && (A2.Text == ""))
                return A2;
            if ((A2.Text == hassan) && (C2.Text == hassan) && (B2.Text == ""))
                return B2;
 
            if ((A3.Text == hassan) && (B3.Text == hassan) && (C3.Text == ""))
                return C3;
            if ((B3.Text == hassan) && (C3.Text == hassan) && (A3.Text == ""))
                return A3;
            if ((A3.Text == hassan) && (C3.Text == hassan) && (B3.Text == ""))
                return B3;
 
            //DIAGONAL TESTS
            if ((A1.Text == hassan) && (B2.Text == hassan) && (C3.Text == ""))
                return C3;
            if ((B2.Text == hassan) && (C3.Text == hassan) && (A1.Text == ""))
                return A1;
            if ((A1.Text == hassan) && (C3.Text == hassan) && (B2.Text == ""))
                return B2;
 
            if ((A3.Text == hassan) && (B2.Text == hassan) && (C1.Text == ""))
                return C1;
            if ((B2.Text == hassan) && (C1.Text == hassan) && (A3.Text == ""))
                return A3;
            if ((A3.Text == hassan) && (C1.Text == hassan) && (B2.Text == ""))
                return B2;
 
            return null;
        }
        private Button look_for_betterplace()
        {
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
                if (B1.Text == "")
                    return B1;
                if (B3.Text == "")
                    return B3;
            }
 
            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
                if (B1.Text == "")
                    return B1;
                if (B3.Text == "")
                    return B3;
            }
 
            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
                if (B1.Text == "")
                    return B1;
                if (B3.Text == "")
                    return B3;
            }
 
            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (B1.Text == "")
                    return B1;
                if (B3.Text == "")
                    return B3;
            }
           
            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;
            if (A2.Text == "")
                return A2;
            if (C2.Text == "")
                return C2;
            if (B1.Text == "")
                return B1;
            if (B3.Text == "")
                return B3;
                
 
            return null;
        }
        private Button look_for_space()
        {
         
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }

            return null;
        }
        private void computermove()
        {
            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_winorblock("O"); //look for win
            if (move == null)
            {
                move = look_for_winorblock("X"); //look for block
                if (move == null)
                {
                    move = look_for_betterplace();
                    if (move == null)
                    {
                        move = look_for_space();
                    }//end if
                }//end if
            }//end if
            if (turn_count < 9)
            {
                move.PerformClick();
            }
        }
    }
}
