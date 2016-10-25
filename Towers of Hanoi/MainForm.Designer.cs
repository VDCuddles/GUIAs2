﻿namespace Towers_of_Hanoi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.txtMoves = new System.Windows.Forms.TextBox();
			this.lblDisk1 = new System.Windows.Forms.Label();
			this.lblDisk2 = new System.Windows.Forms.Label();
			this.lblDisk3 = new System.Windows.Forms.Label();
			this.lblDisk4 = new System.Windows.Forms.Label();
			this.pnlBase = new System.Windows.Forms.Panel();
			this.lblPeg1 = new System.Windows.Forms.Label();
			this.lblPeg2 = new System.Windows.Forms.Label();
			this.lblPeg3 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMoves
			// 
			this.txtMoves.Location = new System.Drawing.Point(655, 102);
			this.txtMoves.Multiline = true;
			this.txtMoves.Name = "txtMoves";
			this.txtMoves.Size = new System.Drawing.Size(140, 261);
			this.txtMoves.TabIndex = 17;
			// 
			// lblDisk1
			// 
			this.lblDisk1.BackColor = System.Drawing.Color.Lime;
			this.lblDisk1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisk1.Location = new System.Drawing.Point(98, 219);
			this.lblDisk1.Name = "lblDisk1";
			this.lblDisk1.Size = new System.Drawing.Size(48, 24);
			this.lblDisk1.TabIndex = 16;
			// 
			// lblDisk2
			// 
			this.lblDisk2.BackColor = System.Drawing.Color.Lime;
			this.lblDisk2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisk2.Location = new System.Drawing.Point(82, 243);
			this.lblDisk2.Name = "lblDisk2";
			this.lblDisk2.Size = new System.Drawing.Size(80, 24);
			this.lblDisk2.TabIndex = 15;
			// 
			// lblDisk3
			// 
			this.lblDisk3.BackColor = System.Drawing.Color.Lime;
			this.lblDisk3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisk3.Location = new System.Drawing.Point(66, 267);
			this.lblDisk3.Name = "lblDisk3";
			this.lblDisk3.Size = new System.Drawing.Size(112, 24);
			this.lblDisk3.TabIndex = 14;
			// 
			// lblDisk4
			// 
			this.lblDisk4.BackColor = System.Drawing.Color.Lime;
			this.lblDisk4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisk4.Location = new System.Drawing.Point(50, 291);
			this.lblDisk4.Name = "lblDisk4";
			this.lblDisk4.Size = new System.Drawing.Size(144, 24);
			this.lblDisk4.TabIndex = 13;
			// 
			// pnlBase
			// 
			this.pnlBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.pnlBase.Location = new System.Drawing.Point(13, 315);
			this.pnlBase.Name = "pnlBase";
			this.pnlBase.Size = new System.Drawing.Size(584, 48);
			this.pnlBase.TabIndex = 9;
			// 
			// lblPeg1
			// 
			this.lblPeg1.AllowDrop = true;
			this.lblPeg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lblPeg1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPeg1.Location = new System.Drawing.Point(109, 187);
			this.lblPeg1.Name = "lblPeg1";
			this.lblPeg1.Size = new System.Drawing.Size(24, 144);
			this.lblPeg1.TabIndex = 10;
			// 
			// lblPeg2
			// 
			this.lblPeg2.AllowDrop = true;
			this.lblPeg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lblPeg2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPeg2.Location = new System.Drawing.Point(298, 187);
			this.lblPeg2.Name = "lblPeg2";
			this.lblPeg2.Size = new System.Drawing.Size(24, 144);
			this.lblPeg2.TabIndex = 11;
			// 
			// lblPeg3
			// 
			this.lblPeg3.AllowDrop = true;
			this.lblPeg3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lblPeg3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblPeg3.Location = new System.Drawing.Point(469, 187);
			this.lblPeg3.Name = "lblPeg3";
			this.lblPeg3.Size = new System.Drawing.Size(24, 144);
			this.lblPeg3.TabIndex = 12;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(50, 34);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 18;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 464);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.txtMoves);
			this.Controls.Add(this.lblDisk1);
			this.Controls.Add(this.lblDisk2);
			this.Controls.Add(this.lblDisk3);
			this.Controls.Add(this.lblDisk4);
			this.Controls.Add(this.pnlBase);
			this.Controls.Add(this.lblPeg1);
			this.Controls.Add(this.lblPeg2);
			this.Controls.Add(this.lblPeg3);
			this.Name = "MainForm";
			this.Text = "The Towers of Hanoi";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMoves;
        private System.Windows.Forms.Label lblDisk1;
        private System.Windows.Forms.Label lblDisk2;
        private System.Windows.Forms.Label lblDisk3;
        private System.Windows.Forms.Label lblDisk4;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Label lblPeg1;
        private System.Windows.Forms.Label lblPeg2;
        private System.Windows.Forms.Label lblPeg3;
		private System.Windows.Forms.Button btnReset;
	}
}

