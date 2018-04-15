namespace Admin
{
    partial class Row
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LastNodeLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.NextNodeLbl = new System.Windows.Forms.Label();
            this.TimeStampLbl = new System.Windows.Forms.Label();
            this.DataLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LastNodeLbl
            // 
            this.LastNodeLbl.AutoSize = true;
            this.LastNodeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LastNodeLbl.Location = new System.Drawing.Point(3, 0);
            this.LastNodeLbl.Name = "LastNodeLbl";
            this.LastNodeLbl.Size = new System.Drawing.Size(60, 24);
            this.LastNodeLbl.TabIndex = 0;
            this.LastNodeLbl.Text = "label1";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NameLbl.Location = new System.Drawing.Point(195, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(60, 24);
            this.NameLbl.TabIndex = 1;
            this.NameLbl.Text = "label2";
            this.NameLbl.Click += new System.EventHandler(this.label2_Click);
            // 
            // NextNodeLbl
            // 
            this.NextNodeLbl.AutoSize = true;
            this.NextNodeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NextNodeLbl.Location = new System.Drawing.Point(413, 0);
            this.NextNodeLbl.Name = "NextNodeLbl";
            this.NextNodeLbl.Size = new System.Drawing.Size(60, 24);
            this.NextNodeLbl.TabIndex = 2;
            this.NextNodeLbl.Text = "label3";
            // 
            // TimeStampLbl
            // 
            this.TimeStampLbl.AutoSize = true;
            this.TimeStampLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TimeStampLbl.Location = new System.Drawing.Point(652, 0);
            this.TimeStampLbl.Name = "TimeStampLbl";
            this.TimeStampLbl.Size = new System.Drawing.Size(60, 24);
            this.TimeStampLbl.TabIndex = 3;
            this.TimeStampLbl.Text = "label4";
            // 
            // DataLbl
            // 
            this.DataLbl.AutoSize = true;
            this.DataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DataLbl.Location = new System.Drawing.Point(900, 0);
            this.DataLbl.Name = "DataLbl";
            this.DataLbl.Size = new System.Drawing.Size(60, 24);
            this.DataLbl.TabIndex = 4;
            this.DataLbl.Text = "label5";
            this.DataLbl.Click += new System.EventHandler(this.DataLbl_Click);
            // 
            // Row
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.DataLbl);
            this.Controls.Add(this.TimeStampLbl);
            this.Controls.Add(this.NextNodeLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.LastNodeLbl);
            this.Name = "Row";
            this.Size = new System.Drawing.Size(1018, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LastNodeLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label NextNodeLbl;
        private System.Windows.Forms.Label TimeStampLbl;
        private System.Windows.Forms.Label DataLbl;
    }
}
