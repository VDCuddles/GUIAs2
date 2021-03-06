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

//Some code referenced from HanoiTowers1 solution; most notably the rule enforcement logic.

namespace Towers_of_Hanoi
{
	public partial class MainForm : Form
	{
		private Board board;
		private int targetPole = 0;
		private DiskMove diskMove;
		private int moveCounter = 0;


		public MainForm()
		{
			/// <summary>
			/// Initialising MainForm, Board, and Diskmove classes
			/// </summary>
			InitializeComponent();

			board = new Board(

						new Disk(lblDisk1, 0, 3, 0),
						new Disk(lblDisk2, 0, 2, 0),
						new Disk(lblDisk3, 0, 1, 0),
						new Disk(lblDisk4, 0, 0, 0)

				);

			diskMove = new DiskMove();
		}

		/// <summary>
		/// Event handler on mousedown of a label. This handles rule enforcement, re-rendering, movement,
		/// game logic, board reference, and win conditions through internal and external classes.
		/// </summary>
		private void lblDisk1_MouseDown(object sender, MouseEventArgs e)
		{

			Label alabel = (sender as Label);

			//stores old data for use in rule enforcement
			Disk oldDiskState = board.FindDisk(alabel);
			board.savedOldDiskState = oldDiskState;

			DragDropEffects result = alabel.DoDragDrop(alabel, DragDropEffects.All);
			if (result != DragDropEffects.None)
			{
				//checks rule enforcement
				if (board.canDrop(board.FindDisk(alabel), targetPole) && board.canStartMove(oldDiskState))
				{
					//performs move if legal
					board.move(board.FindDisk(alabel), targetPole);
					//re-renders move if legal
					board.Display();

					//appends diskmove data for use in rendering txtMoves content (move record)
					if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk1")
					{
						diskMove.diskInd = 0;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk2")
					{
						diskMove.diskInd = 1;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk3")
					{
						diskMove.diskInd = 2;
					}

					else if (board.FindDisk(alabel).getLabel().Name.ToString() == "lblDisk4")
					{
						diskMove.diskInd = 3;
					}

					diskMove.pegInd = targetPole;

					txtMoves.AppendText(diskMove.AsText() + "\r\r");
					board.movements.Add(diskMove.AsText());


					moveCounter++;

					txtMoveCount.Text = (moveCounter.ToString());

					//perfect win condition
					if (moveCounter == 15 &&

						board.FindDisk(lblDisk1).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk1).getLevel().ToString() == "3" &&
						board.FindDisk(lblDisk2).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk2).getLevel().ToString() == "2" &&
						board.FindDisk(lblDisk3).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk3).getLevel().ToString() == "1" &&
						board.FindDisk(lblDisk4).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk4).getLevel().ToString() == "0"

						)
					{
						MessageBox.Show("You have successfully completed the game with the minimum number of moves.");
					}

					//imperfect win condition
					if (moveCounter > 15 &&

						board.FindDisk(lblDisk1).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk1).getLevel().ToString() == "3" &&
						board.FindDisk(lblDisk2).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk2).getLevel().ToString() == "2" &&
						board.FindDisk(lblDisk3).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk3).getLevel().ToString() == "1" &&
						board.FindDisk(lblDisk4).getPegNum().ToString() == "2" &&
						board.FindDisk(lblDisk4).getLevel().ToString() == "0"

	)
					{
						MessageBox.Show("You have successfully completed the game but not with the minimum number of moves.");
					}


				}

			}

		}

		private void lblPeg2_DragEnter(object sender, DragEventArgs e)
		{

			e.Effect = DragDropEffects.All;

		}

		private void lblPeg2_DragDrop(object sender, DragEventArgs e)
		{
			/// <summary>
			/// provides target pole information for use in the MouseDown method.
			/// </summary>
			Label alabel = (sender as Label);
			if (alabel == lblPeg1) targetPole = 0;
			else if (alabel == lblPeg2) targetPole = 1;
			else if (alabel == lblPeg3) targetPole = 2;

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			/// <summary>
			/// resets game, resets positioning, stops animation if applicable, resets move records.
			/// </summary>
			board.reset();
			tmrAnimationTimer.Stop();
			txtMoves.Text = null;
			txtMoveCount.Text = "0";
			moveCounter = 0;
		}

		private void btnAnimate_Click(object sender, EventArgs e)
		{
			/// <summary>
			/// resets game, resets positioning, resets move records, starts animation.
			/// </summary>
			board.reset();
			tmrAnimationTimer.Enabled = true;
			tmrAnimationTimer.Start();
		}

		private void tmrAnimationTimer_Tick(object sender, EventArgs e)
		{
			/// <summary>
			/// applies a scripted move for each second that goes by, using the tick to update the current move.
			/// Tick also updates move record data, board data, and re-renders board.
			/// </summary>
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
