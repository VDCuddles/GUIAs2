using System;
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
		private DiskMove diskmove;
		private int moveCounter = 0;


		public MainForm()
		{
			InitializeComponent();

			board = new Board(

						new Disk(lblDisk1, 0, 3, 0),
						new Disk(lblDisk2, 0, 2, 0),
						new Disk(lblDisk3, 0, 1, 0),
						new Disk(lblDisk4, 0, 0, 0)

				);

			diskmove = new DiskMove();
		}

		private void lblDisk1_MouseDown(object sender, MouseEventArgs e)
		{

			Label alabel = (sender as Label);

			Disk oldDiskState = board.FindDisk(alabel);

			//int oldDiskPeg = board.FindDisk(alabel).getPegNum();

			//MessageBox.Show("oldDisk.getDiameter() = " + (oldDiskState.getDiameter()) +
			//	"\r\r" + "oldDisk.getPegNum() = " + (oldDiskState.getPegNum()) +
			//	"\r\r" + "oldDisk.getLevel() = " + (oldDiskState.getLevel())
			//	);

			DragDropEffects result = alabel.DoDragDrop(alabel, DragDropEffects.All);
			if (result != DragDropEffects.None)
			{

				if (board.canDrop(oldDiskState, targetPole) && board.canStartMove(oldDiskState))
				{

					board.move(board.FindDisk(alabel), targetPole);

					board.Display();

					if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk1")
					{
						diskmove.diskInd = 0;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk2")
					{
						diskmove.diskInd = 1;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk3")
					{
						diskmove.diskInd = 2;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk4")
					{
						diskmove.diskInd = 3;
					}

					diskmove.pegInd = targetPole;

					txtMoves.AppendText(diskmove.AsText() + "\r\r");

					moveCounter++;

					txtMoveCount.Text = (moveCounter.ToString());


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
			tmrAnimationTimer.Stop();
			txtMoves.Text = null;
			txtMoveCount.Text = "0";
			moveCounter = 0;
		}

		private void btnAnimate_Click(object sender, EventArgs e)
		{
			board.reset();
			tmrAnimationTimer.Enabled = true;
			tmrAnimationTimer.Start();
		}

		private void tmrAnimationTimer_Tick(object sender, EventArgs e)
		{
			txtMoveCount.Text = moveCounter.ToString();

			switch (moveCounter)
			{

				case 1:
					board.move(board.FindDisk(lblDisk1), 1);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (2)\r\r");
					break;
				case 2:
					board.move(board.FindDisk(lblDisk2), 2);
					board.Display();
					txtMoves.AppendText("Disk (2) moved to Peg (3)\r\r");
					break;
				case 3:
					board.move(board.FindDisk(lblDisk1), 2);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (3)\r\r");
					break;
				case 4:
					board.move(board.FindDisk(lblDisk3), 1);
					board.Display();
					txtMoves.AppendText("Disk (3) moved to Peg (2)\r\r");
					break;
				case 5:
					board.move(board.FindDisk(lblDisk1), 0);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (1)\r\r");
					break;
				case 6:
					board.move(board.FindDisk(lblDisk2), 1);
					board.Display();
					txtMoves.AppendText("Disk (2) moved to Peg (2)\r\r");
					break;
				case 7:
					board.move(board.FindDisk(lblDisk1), 1);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (2)\r\r");
					break;
				case 8:
					board.move(board.FindDisk(lblDisk4), 2);
					board.Display();
					txtMoves.AppendText("Disk (4) moved to Peg (3)\r\r");
					break;
				case 9:
					board.move(board.FindDisk(lblDisk1), 2);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (3)\r\r");
					break;
				case 10:
					board.move(board.FindDisk(lblDisk2), 0);
					board.Display();
					txtMoves.AppendText("Disk (2) moved to Peg (1)\r\r");
					break;
				case 11:
					board.move(board.FindDisk(lblDisk1), 0);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (1)\r\r");
					break;
				case 12:
					board.move(board.FindDisk(lblDisk3), 2);
					board.Display();
					txtMoves.AppendText("Disk (3) moved to Peg (3)\r\r");
					break;
				case 13:
					board.move(board.FindDisk(lblDisk1), 1);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (2)\r\r");
					break;
				case 14:
					board.move(board.FindDisk(lblDisk2), 2);
					board.Display();
					txtMoves.AppendText("Disk (2) moved to Peg (3)\r\r");
					break;
				case 15:
					board.move(board.FindDisk(lblDisk1), 2);
					board.Display();
					txtMoves.AppendText("Disk (1) moved to Peg (3)\r\r");
					tmrAnimationTimer.Stop();
					break;

			}
			moveCounter++;

		}
	}
}
