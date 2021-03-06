﻿namespace PoolLevelMonitor
{
    partial class PoolLevel
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
            this.btn_Measure = new System.Windows.Forms.Button();
            this.rtb_RawData = new System.Windows.Forms.RichTextBox();
            this.rtb_Readings = new System.Windows.Forms.RichTextBox();
            this.tb_Base = new System.Windows.Forms.TextBox();
            this.btn_ResetBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_LevelChange = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ErrorList = new System.Windows.Forms.TextBox();
            this.tb_ReadingsPerCycle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Period = new System.Windows.Forms.TextBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Measure
            // 
            this.btn_Measure.Location = new System.Drawing.Point(739, 12);
            this.btn_Measure.Name = "btn_Measure";
            this.btn_Measure.Size = new System.Drawing.Size(124, 23);
            this.btn_Measure.TabIndex = 0;
            this.btn_Measure.Text = "Measure";
            this.btn_Measure.UseVisualStyleBackColor = true;
            this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // rtb_RawData
            // 
            this.rtb_RawData.Location = new System.Drawing.Point(71, 86);
            this.rtb_RawData.Name = "rtb_RawData";
            this.rtb_RawData.Size = new System.Drawing.Size(142, 447);
            this.rtb_RawData.TabIndex = 1;
            this.rtb_RawData.Text = "";
            // 
            // rtb_Readings
            // 
            this.rtb_Readings.Location = new System.Drawing.Point(340, 86);
            this.rtb_Readings.Name = "rtb_Readings";
            this.rtb_Readings.Size = new System.Drawing.Size(366, 447);
            this.rtb_Readings.TabIndex = 2;
            this.rtb_Readings.Text = "";
            // 
            // tb_Base
            // 
            this.tb_Base.Location = new System.Drawing.Point(289, 11);
            this.tb_Base.Name = "tb_Base";
            this.tb_Base.Size = new System.Drawing.Size(100, 20);
            this.tb_Base.TabIndex = 3;
            this.tb_Base.Text = "17.85434";
            this.tb_Base.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_ResetBase
            // 
            this.btn_ResetBase.Location = new System.Drawing.Point(510, 11);
            this.btn_ResetBase.Name = "btn_ResetBase";
            this.btn_ResetBase.Size = new System.Drawing.Size(75, 23);
            this.btn_ResetBase.TabIndex = 4;
            this.btn_ResetBase.Text = "Reset Base";
            this.btn_ResetBase.UseVisualStyleBackColor = true;
            this.btn_ResetBase.Click += new System.EventHandler(this.btn_ResetBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "cm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "in";
            // 
            // tb_LevelChange
            // 
            this.tb_LevelChange.Location = new System.Drawing.Point(289, 37);
            this.tb_LevelChange.Name = "tb_LevelChange";
            this.tb_LevelChange.Size = new System.Drawing.Size(100, 20);
            this.tb_LevelChange.TabIndex = 6;
            this.tb_LevelChange.Text = "0.0";
            this.tb_LevelChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Base Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Change";
            // 
            // tb_ErrorList
            // 
            this.tb_ErrorList.Location = new System.Drawing.Point(105, 590);
            this.tb_ErrorList.Multiline = true;
            this.tb_ErrorList.Name = "tb_ErrorList";
            this.tb_ErrorList.Size = new System.Drawing.Size(588, 100);
            this.tb_ErrorList.TabIndex = 10;
            // 
            // tb_ReadingsPerCycle
            // 
            this.tb_ReadingsPerCycle.Location = new System.Drawing.Point(71, 8);
            this.tb_ReadingsPerCycle.Name = "tb_ReadingsPerCycle";
            this.tb_ReadingsPerCycle.Size = new System.Drawing.Size(78, 20);
            this.tb_ReadingsPerCycle.TabIndex = 11;
            this.tb_ReadingsPerCycle.Text = "50";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Readings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Period";
            // 
            // tb_Period
            // 
            this.tb_Period.Location = new System.Drawing.Point(71, 36);
            this.tb_Period.Name = "tb_Period";
            this.tb_Period.Size = new System.Drawing.Size(78, 20);
            this.tb_Period.TabIndex = 14;
            this.tb_Period.Text = "900";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Location = new System.Drawing.Point(714, 685);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(41, 13);
            this.lbl_Version.TabIndex = 15;
            this.lbl_Version.Text = "Ver 2.0";
            // 
            // PoolLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 728);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.tb_Period);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_ReadingsPerCycle);
            this.Controls.Add(this.tb_ErrorList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_LevelChange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ResetBase);
            this.Controls.Add(this.tb_Base);
            this.Controls.Add(this.rtb_Readings);
            this.Controls.Add(this.rtb_RawData);
            this.Controls.Add(this.btn_Measure);
            this.Name = "PoolLevel";
            this.Text = "Pool Level";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Measure;
        private System.Windows.Forms.RichTextBox rtb_RawData;
        private System.Windows.Forms.RichTextBox rtb_Readings;
        private System.Windows.Forms.TextBox tb_Base;
        private System.Windows.Forms.Button btn_ResetBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_LevelChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ErrorList;
        private System.Windows.Forms.TextBox tb_ReadingsPerCycle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Period;
        private System.Windows.Forms.Label lbl_Version;
    }
}

