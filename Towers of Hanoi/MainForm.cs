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
		//private List<Disk> disks = new List<Disk>();
		//private DiskMove diskmove;
		private int targetPole = 0;
		//private List<DiskMove> moves = new List<DiskMove>();
		
		public MainForm()
        {
            InitializeComponent();
			//ResetBoard();

			//disks = new List<Disk>
			//	{
			//		new Disk(lblDisk1, 0, 3, 0),
			//		new Disk(lblDisk2, 0, 2, 0),
			//		new Disk(lblDisk3, 0, 1, 0),
			//		new Disk(lblDisk4, 0, 0, 0),
			//	};

			board = new Board(

						new Disk(lblDisk1, 0, 3, 0),
						new Disk(lblDisk2, 0, 2, 0),
						new Disk(lblDisk3, 0, 1, 0),
						new Disk(lblDisk4, 0, 0, 0)

				);
		}

		//private void ResetBoard()
		//{
		//	disks = new List<Disk>
		//	{
		//		new Disk(lblDisk1, 0, 3, 0),
		//		new Disk(lblDisk2, 0, 2, 0),
		//		new Disk(lblDisk3, 0, 1, 0),
		//		new Disk(lblDisk4, 0, 0, 0),
		//	};
		//	board = new Board(disks[0], disks[1], disks[2], disks[3]);
		//	moves.Clear();
		//}

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
				//var DINGUS = "WHATEBERr";

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

			//ResetBoard();
		}

		private void btnAnimate_Click(object sender, EventArgs e)
		{

		}
	}
}
