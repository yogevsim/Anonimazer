namespace User
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ip_box = new System.Windows.Forms.TextBox();
            this.port_box = new System.Windows.Forms.TextBox();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.send_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tickmark = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.browseFile_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip_box
            // 
            this.ip_box.Location = new System.Drawing.Point(92, 157);
            this.ip_box.Name = "ip_box";
            this.ip_box.Size = new System.Drawing.Size(223, 20);
            this.ip_box.TabIndex = 1;
            // 
            // port_box
            // 
            this.port_box.Location = new System.Drawing.Point(92, 230);
            this.port_box.Name = "port_box";
            this.port_box.Size = new System.Drawing.Size(223, 20);
            this.port_box.TabIndex = 2;
            // 
            // msg_box
            // 
            this.msg_box.Location = new System.Drawing.Point(92, 306);
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(223, 20);
            this.msg_box.TabIndex = 3;
            this.msg_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.msg_box_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "PORT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "MESSAGE:";
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(163, 379);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 7;
            this.send_btn.Text = "SEND";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.EnabledChanged += new System.EventHandler(this.send_btn_EnabledChanged);
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 8;
            // 
            // tickmark
            // 
            this.tickmark.Image = global::User.Properties.Resources.whatsapp_double_ticks_small;
            this.tickmark.Location = new System.Drawing.Point(244, 380);
            this.tickmark.Name = "tickmark";
            this.tickmark.Size = new System.Drawing.Size(21, 18);
            this.tickmark.TabIndex = 10;
            this.tickmark.Visible = false;
            this.tickmark.VisibleChanged += new System.EventHandler(this.tickmark_VisibleChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(238, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.label1.Image = global::User.Properties.Resources.JawBreaker;
            this.label1.Location = new System.Drawing.Point(87, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 88);
            this.label1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tickTimer
            // 
            this.tickTimer.Interval = 10000;
            this.tickTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // browseFile_btn
            // 
            this.browseFile_btn.Location = new System.Drawing.Point(321, 304);
            this.browseFile_btn.Name = "browseFile_btn";
            this.browseFile_btn.Size = new System.Drawing.Size(75, 23);
            this.browseFile_btn.TabIndex = 11;
            this.browseFile_btn.Text = "Browse";
            this.browseFile_btn.UseVisualStyleBackColor = true;
            this.browseFile_btn.Click += new System.EventHandler(this.browseFile_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 480);
            this.Controls.Add(this.browseFile_btn);
            this.Controls.Add(this.tickmark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.msg_box);
            this.Controls.Add(this.port_box);
            this.Controls.Add(this.ip_box);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Jaw Breaker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip_box;
        private System.Windows.Forms.TextBox port_box;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tickmark;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.Button browseFile_btn;
    }
}

