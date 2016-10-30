﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Towers_of_Hanoi
{
    public partial class MainForm : Form
    {
		private Board board;
		private int targetPole = 0;
		
		public MainForm()
        {
            InitializeComponent();

			board = new Board(

						new Disk(lblDisk1, 0, 3, 0),
						new Disk(lblDisk2, 0, 2, 0),
						new Disk(lblDisk3, 0, 1, 0),
						new Disk(lblDisk4, 0, 0, 0)

				);
		}

		private void lblDisk1_MouseDown(object sender, MouseEventArgs e)
		{

			Label alabel = (sender as Label);

			DragDropEffects result = alabel.DoDragDrop(alabel, DragDropEffects.All);
			if (result != DragDropEffects.None){

				//MessageBox.Show(targetPole.ToString());

				if (board.canDrop(board.FindDisk(alabel), targetPole) && board.canStartMove(board.FindDisk(alabel))) { 

					board.move(board.FindDisk(alabel), targetPole);

					board.Display();

				}

				else
				{
					MessageBox.Show("Invalid move.");
				}
			}

		}

		private void lblPeg2_DragEnter(object sender, DragEventArgs e)
		{
			Label alabel = (sender as Label);

			if (board.canDrop(board.FindDisk(alabel), targetPole) && board.canStartMove(board.FindDisk(alabel)))
			{

				e.Effect = DragDropEffects.All;

			}

		}

		private void lblPeg2_DragDrop(object sender, DragEventArgs e)
		{
			Label alabel = (sender as Label);
			if (alabel == lblPeg1) targetPole = 0;
			else if (alabel == lblPeg2) targetPole = 1;
			else if (alabel == lblPeg3) targetPole = 2;

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			board.reset();
		}

		private void btnAnimate_Click(object sender, EventArgs e)
		{

		}
	}
}
