﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Towers_of_Hanoi
{
	class Board
	{
		private const int NUM_DISKS = 4;
		private const int NUM_PEGS = 3;
		private const int poleStart = 126;
		private const int poleGap = 180;
		private const int deckHeight = 291;
		private const int diskHeight = 24;

		Disk[,] board; //condition says TWO dimentional array            
		ArrayList movements;
		Disk[] disks; //Array of disks
		Disk diskToReturn;

		int updateLevel;
		public Disk newDisk;
		public int oldPos;
		public int newPos;
		public Disk savedOldDiskState;

		public Board()
		{
			updateLevel = 3;
			newDisk = null;
			oldPos = 0;
			newPos = 0;
			board = new Disk[NUM_PEGS, NUM_DISKS];
			movements = new ArrayList();
			diskToReturn = null;

			//Array of disk objects
			disks = new Disk[NUM_DISKS];
			disks[0] = null;
			disks[1] = null;
			disks[2] = null;
			disks[3] = null;

			//Storing disk object into board array(Two dimensional arrray) 
			board = new Disk[NUM_PEGS, NUM_DISKS]; //condition says TWO dimentional array  

			board[0, 3] = new Disk();
			board[0, 2] = new Disk();
			board[0, 1] = new Disk();
			board[0, 0] = new Disk();



			//Creating arraylist of movement 
			movements = new ArrayList();
		}

		//Alterntative constructor
		public Board(Disk d1, Disk d2, Disk d3, Disk d4)
		{
			//Storing into disks array
			disks = new Disk[NUM_DISKS];
			disks[0] = d1;
			disks[1] = d2;
			disks[2] = d3;
			disks[3] = d4;

			//Storing disk object into board array(Two dimensional arrray) 
			board = new Disk[NUM_PEGS, NUM_DISKS]; //condition says TWO dimentional array  
			board[0, 3] = d1;
			board[0, 2] = d2;
			board[0, 1] = d3;
			board[0, 0] = d4;

			//Arraylist of movement.
			movements = new ArrayList();
		}


		public void reset()
		{
			for (int iP = 0; iP < NUM_PEGS; iP++)
			{
				//Remove all elements from board array
				for (int iD = 0; iD < NUM_DISKS; iD++)
				{
					board[iP, iD] = null;

					//Update disks array
					disks[iD].setPegNum(0);
					disks[iD].setLevel(NUM_DISKS - 1 - iD);

				}
			}

			//Reallocate elements 
			board[0, 3] = disks[0]; //Peg 1/Level4 
			board[0, 2] = disks[1]; //Peg 1/Level3 
			board[0, 1] = disks[2]; //Peg 1/Level2
			board[0, 0] = disks[3]; //Peg 1/Level1 

			//Reallocate display positioning

			board[0, 3].thisDisk.Left = 98;
			board[0, 3].thisDisk.Top = 219;
			board[0, 2].thisDisk.Left = 82;
			board[0, 2].thisDisk.Top = 243;
			board[0, 1].thisDisk.Left = 66;
			board[0, 1].thisDisk.Top = 267;
			board[0, 0].thisDisk.Left = 50;
			board[0, 0].thisDisk.Top = 291;

			//Remove all elements from movement arraylist
			movements.Clear();
		}


		public bool canStartMove(Disk aDisk)
		{


			if ((aDisk.getLevel() < 3) && (board[aDisk.getPegNum(), (aDisk.getLevel() + 1)] != null))
			{
				return false;
			}


			else {
				return true;
			}

		}


		public bool canDrop(Disk aDisk, int aPeg)
		{

			if (board[aPeg, 3] != null)
			{
				MessageBox.Show("Invalid Move - pole is full");
				return false;
			}
			else if (board[savedOldDiskState.getPegNum(), savedOldDiskState.getLevel()] == null)
			{
				MessageBox.Show("Invalid Move - no disk at start point");
				return false;
			}

			if (savedOldDiskState.getLevel() < 3)
			{
				if (board[savedOldDiskState.getPegNum(), savedOldDiskState.getLevel() + 1] != null)
				{
					MessageBox.Show("Invalid Move - can only move top disk");
					return false;
				}
			}

			int newLevel = aDisk.getLevel();
			for (int i = 0; i < 4; i++)
			{
				if (board[aPeg, i] == null)
				{
					newLevel = i;
					break;
				}
			}

			if (newLevel > 0)
			{
				if (board[savedOldDiskState.getPegNum(), savedOldDiskState.getLevel()].thisDisk.Width > board[aPeg, newLevel - 1].thisDisk.Width)
				{
					MessageBox.Show("Invalid Move - cannot drop bigger disk on smaller");
					return false;
				}
			}

			return true;


			//Disk highestOnPeg = null;

			//for (int i = 4; i < 0; i--)
			//{

			//	MessageBox.Show(i.ToString());

			//	if (board[aPeg, i] != null)
			//	{
			//		highestOnPeg = board[aPeg, i];
			//		break;
			//	}

			//}
			////MessageBox.Show("highestOnPeg = " + highestOnPeg.getDiameter() + "\r\rboard[aPeg, i] =" + aDisk.getDiameter());


			////if (aDisk.getDiameter() > highestOnPeg.getDiameter())
			////{
			////	return false;
			////}

			//else {
			//	return true;
			//}
		}


		public void move(Disk aDisk, int newLevel)
		{

			//oldDisk = board[aDisk.getPegNum(), aDisk.getLevel()];
			//oldPos = board[aDisk.getPegNum(), aDisk.getLevel()].getPegNum() ;
			board[aDisk.getPegNum(), aDisk.getLevel()] = null;

			newDisk = aDisk;
			newPos = aDisk.getPegNum();
			newDisk.setPegNum(newLevel);
			updateLevel = 3;

			for (int i = 0; i < 4; i++)
			{
				if (board[newLevel, i] == null)
				{
					updateLevel = i;
					newDisk.setLevel(updateLevel);
					break;
				}

			}


			board[newLevel, updateLevel] = aDisk;

			//MessageBox.Show("aDisk data:\r\r level:" + (aDisk.getLevel()) + "\r\rpeg:" + (aDisk.getPegNum()));

		}


		public string allMovesAsString()
		{
			return "dummy";  // Dummy return to avoid syntax error - must be changed
		}


		public void Display()
		{
			//MessageBox.Show("oldDisk.getDiameter() = " + (oldDisk.getDiameter()) +
			//	"\r\r" + "oldDisk.getPegNum() = " + (oldDisk.getPegNum()) +
			//	"\r\r" + "oldDisk.getLevel() = " + (oldDisk.getLevel())
			//	);


			newDisk.getLabel().Hide();
			newDisk.getLabel().Left = poleStart + ((newDisk.getPegNum()) * poleGap) - (newDisk.getDiameter() / 2);
			newDisk.getLabel().Top = deckHeight - (newDisk.getLevel() * diskHeight);
			newDisk.getLabel().Show();



			//MessageBox.Show("newDisk.getPegNum() = " + (newDisk.getPegNum()) +
			//	"\r\r" + "newDisk.getLevel() = " + (newDisk.getLevel())
			//	);


			//for (int ipole = 0; ipole < 3; ipole++)
			//{
			//	for (int jlevel = 0; jlevel < 4; jlevel++)
			//	{
			//		if (board[ipole, jlevel] == null)
			//		{

			//			MessageBox.Show("no data at  board[" + (ipole) + "," + (jlevel) + "]");

			//		}

			//		else {
			//			MessageBox.Show("level data at board[" + (ipole) + "," + (jlevel) + "]: " + board[ipole, jlevel].getLevel().ToString() +
			//				"\r\rlabel data at board[" + (ipole) + "," + (jlevel) + "]: " + board[ipole, jlevel].getLabel().Name.ToString() +
			//				"\r\rpeg data at board[" + (ipole) + "," + (jlevel) + "]: " + board[ipole, jlevel].getPegNum().ToString() +
			//				"\r\rdiameter data at board[" + (ipole) + "," + (jlevel) + "]: " + board[ipole, jlevel].getDiameter().ToString()
			//				);
			//		}
			//	}
			//}
		}


		public Disk FindDisk(Label aLabel)
		{

			for (int ipole = 0; ipole < 3; ipole++)
			{
				for (int jlevel = 0; jlevel < 4; jlevel++)
				{
					if (board[ipole, jlevel] != null)
					{
						if (board[ipole, jlevel].thisDisk == aLabel)
						{
							diskToReturn = board[ipole, jlevel];
							break;
						}
					}
				}
			}
			return diskToReturn;  // Dummy return to avoid syntax error - must be changed
		}


		public int newLevInPeg(int pegNum)
		{
			return 1;    // Dummy return to avoid syntax error - must be changed
		}


		public String getText(int cnt)
		{
			return "1";    // Dummy return to avoid syntax error - must be changed
		}


		public void backToSelected(int ind)
		{

		}


		public int getPegInd(int ind)
		{
			return 1;    // Dummy return to avoid syntax error - must be changed
		}


		public int getLevel(int ind)
		{
			return 1;    // Dummy return to avoid syntax error - must be changed
		}


		public void unDo()
		{

		}


		public void loadData(ArrayList dm)
		{

		}
	}
}
