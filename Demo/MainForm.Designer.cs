namespace Example
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
            this.BtnLoad = new System.Windows.Forms.Button();
            this.LoadLbl = new System.Windows.Forms.Label();
            this.GeneralGB = new System.Windows.Forms.GroupBox();
            this.TrackLblHead = new System.Windows.Forms.Label();
            this.CopyLblHead = new System.Windows.Forms.Label();
            this.LengthLblHead = new System.Windows.Forms.Label();
            this.TrackLbl = new System.Windows.Forms.Label();
            this.CopyLbl = new System.Windows.Forms.Label();
            this.LengthLbl = new System.Windows.Forms.Label();
            this.DetailsGB = new System.Windows.Forms.GroupBox();
            this.TempoLbl = new System.Windows.Forms.Label();
            this.TimeSigLbl = new System.Windows.Forms.Label();
            this.KeySigLbl = new System.Windows.Forms.Label();
            this.TempoLblHead = new System.Windows.Forms.Label();
            this.TimeSigLblHead = new System.Windows.Forms.Label();
            this.KeySigLblHead = new System.Windows.Forms.Label();
            this.ReadMIDINoticeLbl = new System.Windows.Forms.Label();
            this.GeneralGB.SuspendLayout();
            this.DetailsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(12, 12);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // LoadLbl
            // 
            this.LoadLbl.AutoSize = true;
            this.LoadLbl.Location = new System.Drawing.Point(93, 17);
            this.LoadLbl.Name = "LoadLbl";
            this.LoadLbl.Size = new System.Drawing.Size(80, 13);
            this.LoadLbl.TabIndex = 1;
            this.LoadLbl.Text = "No file selected";
            // 
            // GeneralGB
            // 
            this.GeneralGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralGB.Controls.Add(this.LengthLbl);
            this.GeneralGB.Controls.Add(this.CopyLbl);
            this.GeneralGB.Controls.Add(this.TrackLbl);
            this.GeneralGB.Controls.Add(this.LengthLblHead);
            this.GeneralGB.Controls.Add(this.CopyLblHead);
            this.GeneralGB.Controls.Add(this.TrackLblHead);
            this.GeneralGB.Location = new System.Drawing.Point(12, 41);
            this.GeneralGB.Name = "GeneralGB";
            this.GeneralGB.Size = new System.Drawing.Size(280, 86);
            this.GeneralGB.TabIndex = 2;
            this.GeneralGB.TabStop = false;
            this.GeneralGB.Text = "General";
            // 
            // TrackLblHead
            // 
            this.TrackLblHead.AutoSize = true;
            this.TrackLblHead.Location = new System.Drawing.Point(6, 18);
            this.TrackLblHead.Name = "TrackLblHead";
            this.TrackLblHead.Size = new System.Drawing.Size(69, 13);
            this.TrackLblHead.TabIndex = 2;
            this.TrackLblHead.Text = "Track Name:";
            // 
            // CopyLblHead
            // 
            this.CopyLblHead.AutoSize = true;
            this.CopyLblHead.Location = new System.Drawing.Point(6, 38);
            this.CopyLblHead.Name = "CopyLblHead";
            this.CopyLblHead.Size = new System.Drawing.Size(54, 13);
            this.CopyLblHead.TabIndex = 3;
            this.CopyLblHead.Text = "Copyright:";
            // 
            // LengthLblHead
            // 
            this.LengthLblHead.AutoSize = true;
            this.LengthLblHead.Location = new System.Drawing.Point(6, 58);
            this.LengthLblHead.Name = "LengthLblHead";
            this.LengthLblHead.Size = new System.Drawing.Size(43, 13);
            this.LengthLblHead.TabIndex = 4;
            this.LengthLblHead.Text = "Length:";
            // 
            // TrackLbl
            // 
            this.TrackLbl.AutoSize = true;
            this.TrackLbl.Location = new System.Drawing.Point(92, 18);
            this.TrackLbl.Name = "TrackLbl";
            this.TrackLbl.Size = new System.Drawing.Size(10, 13);
            this.TrackLbl.TabIndex = 3;
            this.TrackLbl.Text = "-";
            // 
            // CopyLbl
            // 
            this.CopyLbl.AutoSize = true;
            this.CopyLbl.Location = new System.Drawing.Point(92, 38);
            this.CopyLbl.Name = "CopyLbl";
            this.CopyLbl.Size = new System.Drawing.Size(10, 13);
            this.CopyLbl.TabIndex = 5;
            this.CopyLbl.Text = "-";
            // 
            // LengthLbl
            // 
            this.LengthLbl.AutoSize = true;
            this.LengthLbl.Location = new System.Drawing.Point(92, 58);
            this.LengthLbl.Name = "LengthLbl";
            this.LengthLbl.Size = new System.Drawing.Size(10, 13);
            this.LengthLbl.TabIndex = 6;
            this.LengthLbl.Text = "-";
            // 
            // DetailsGB
            // 
            this.DetailsGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsGB.Controls.Add(this.TempoLbl);
            this.DetailsGB.Controls.Add(this.TimeSigLbl);
            this.DetailsGB.Controls.Add(this.KeySigLbl);
            this.DetailsGB.Controls.Add(this.TempoLblHead);
            this.DetailsGB.Controls.Add(this.TimeSigLblHead);
            this.DetailsGB.Controls.Add(this.KeySigLblHead);
            this.DetailsGB.Location = new System.Drawing.Point(12, 133);
            this.DetailsGB.Name = "DetailsGB";
            this.DetailsGB.Size = new System.Drawing.Size(280, 86);
            this.DetailsGB.TabIndex = 3;
            this.DetailsGB.TabStop = false;
            this.DetailsGB.Text = "Details";
            // 
            // TempoLbl
            // 
            this.TempoLbl.AutoSize = true;
            this.TempoLbl.Location = new System.Drawing.Point(92, 59);
            this.TempoLbl.Name = "TempoLbl";
            this.TempoLbl.Size = new System.Drawing.Size(10, 13);
            this.TempoLbl.TabIndex = 6;
            this.TempoLbl.Text = "-";
            // 
            // TimeSigLbl
            // 
            this.TimeSigLbl.AutoSize = true;
            this.TimeSigLbl.Location = new System.Drawing.Point(92, 39);
            this.TimeSigLbl.Name = "TimeSigLbl";
            this.TimeSigLbl.Size = new System.Drawing.Size(10, 13);
            this.TimeSigLbl.TabIndex = 5;
            this.TimeSigLbl.Text = "-";
            // 
            // KeySigLbl
            // 
            this.KeySigLbl.AutoSize = true;
            this.KeySigLbl.Location = new System.Drawing.Point(92, 18);
            this.KeySigLbl.Name = "KeySigLbl";
            this.KeySigLbl.Size = new System.Drawing.Size(10, 13);
            this.KeySigLbl.TabIndex = 3;
            this.KeySigLbl.Text = "-";
            // 
            // TempoLblHead
            // 
            this.TempoLblHead.AutoSize = true;
            this.TempoLblHead.Location = new System.Drawing.Point(6, 59);
            this.TempoLblHead.Name = "TempoLblHead";
            this.TempoLblHead.Size = new System.Drawing.Size(43, 13);
            this.TempoLblHead.TabIndex = 4;
            this.TempoLblHead.Text = "Tempo:";
            // 
            // TimeSigLblHead
            // 
            this.TimeSigLblHead.AutoSize = true;
            this.TimeSigLblHead.Location = new System.Drawing.Point(6, 39);
            this.TimeSigLblHead.Name = "TimeSigLblHead";
            this.TimeSigLblHead.Size = new System.Drawing.Size(81, 13);
            this.TimeSigLblHead.TabIndex = 3;
            this.TimeSigLblHead.Text = "Time Signature:";
            // 
            // KeySigLblHead
            // 
            this.KeySigLblHead.AutoSize = true;
            this.KeySigLblHead.Location = new System.Drawing.Point(6, 18);
            this.KeySigLblHead.Name = "KeySigLblHead";
            this.KeySigLblHead.Size = new System.Drawing.Size(76, 13);
            this.KeySigLblHead.TabIndex = 2;
            this.KeySigLblHead.Text = "Key Signature:";
            // 
            // ReadMIDINoticeLbl
            // 
            this.ReadMIDINoticeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReadMIDINoticeLbl.AutoSize = true;
            this.ReadMIDINoticeLbl.ForeColor = System.Drawing.Color.Gray;
            this.ReadMIDINoticeLbl.Location = new System.Drawing.Point(9, 232);
            this.ReadMIDINoticeLbl.Name = "ReadMIDINoticeLbl";
            this.ReadMIDINoticeLbl.Size = new System.Drawing.Size(212, 13);
            this.ReadMIDINoticeLbl.TabIndex = 4;
            this.ReadMIDINoticeLbl.Text = "ReadMIDI Library Demo, Chooper100 2016\r\n";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 254);
            this.Controls.Add(this.ReadMIDINoticeLbl);
            this.Controls.Add(this.DetailsGB);
            this.Controls.Add(this.GeneralGB);
            this.Controls.Add(this.LoadLbl);
            this.Controls.Add(this.BtnLoad);
            this.Name = "MainForm";
            this.Text = "ReadMIDI Demo Form";
            this.GeneralGB.ResumeLayout(false);
            this.GeneralGB.PerformLayout();
            this.DetailsGB.ResumeLayout(false);
            this.DetailsGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Label LoadLbl;
        private System.Windows.Forms.GroupBox GeneralGB;
        private System.Windows.Forms.Label LengthLblHead;
        private System.Windows.Forms.Label CopyLblHead;
        private System.Windows.Forms.Label TrackLblHead;
        private System.Windows.Forms.Label LengthLbl;
        private System.Windows.Forms.Label CopyLbl;
        private System.Windows.Forms.Label TrackLbl;
        private System.Windows.Forms.GroupBox DetailsGB;
        private System.Windows.Forms.Label TempoLbl;
        private System.Windows.Forms.Label TimeSigLbl;
        private System.Windows.Forms.Label KeySigLbl;
        private System.Windows.Forms.Label TempoLblHead;
        private System.Windows.Forms.Label TimeSigLblHead;
        private System.Windows.Forms.Label KeySigLblHead;
        private System.Windows.Forms.Label ReadMIDINoticeLbl;
    }
}

