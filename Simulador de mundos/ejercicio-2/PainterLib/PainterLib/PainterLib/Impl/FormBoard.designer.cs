﻿namespace PainterLib
{
    partial class FormBoard
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
            this.SuspendLayout();
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "FormBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;            
            this.TopMost = true;            
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormBoard_Paint);
            this.Load += new System.EventHandler(this.FormBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion

    }
}