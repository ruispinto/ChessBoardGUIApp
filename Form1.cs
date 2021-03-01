using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);

        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];

        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        private void populateGrid()
        {
            // create buttons and place them into panel1
            int buttonSize = panel1.Width / 8;


            // make the panel a perfect square
            panel1.Height = panel1.Height;


            // nested loops. create buttons and print them to the screen
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].Font = new Font("Microsoft Sans Serif", 12);

                    // add a click event to each button
                    btnGrid[i, j].Click += Grid_Button_Click;

                    // add the new button to panel1
                    panel1.Controls.Add(btnGrid[i, j]);

                    // set the location of each new button
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    btnGrid[i, j].Text = i + " | " + j;
                    btnGrid[i, j].Tag = new Point(i, j);

                }
            }
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            // get row and column number of the button clicked
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;

            int x = location.X;
            int y = location.Y;

            //int option = 0;

            Cell currentCell = myBoard.theGrid[x, y];

            /*
            // depending the option chosen it 'translates' to int
            if (comboBox1.SelectedText == "Knight")
                option = 1;
            else if (comboBox1.SelectedText == "King")
                option = 2;
            else if (comboBox1.SelectedText == "Rook")
                option = 3;
            else if (comboBox1.SelectedText == "Bishop")
                option = 4;
            else if (comboBox1.SelectedText == "Queen")
                option = 5;
            else
                option = 6;
            */

            // determine legal next moves
            myBoard.MarkNextLegalMoves(currentCell, comboBox1.SelectedIndex);

            // update the text on each button
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    if (myBoard.theGrid[i, j].LegalNexMove == true)
                    {
                        btnGrid[i, j].Text = "Legal";
                    }
                    else if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                    {
                        //btnGrid[i, j].Text = comboBox1.SelectedItem.ToString();
                        btnGrid[i, j].Text = "Knight";

                    }
                }
            }

            // MessageBox.Show("You clicked the button " + x + "|" + y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
