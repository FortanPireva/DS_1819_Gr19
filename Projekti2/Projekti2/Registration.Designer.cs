namespace Projekti2
{
    partial class Registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.emritxt = new System.Windows.Forms.TextBox();
            this.mbiemritxt = new System.Windows.Forms.TextBox();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.kpasswordtxt = new System.Windows.Forms.TextBox();
            this.titullitxt = new System.Windows.Forms.TextBox();
            this.rrogatxt = new System.Windows.Forms.TextBox();
            this.btnregjistro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(272, 34);
            this.label1.MaximumSize = new System.Drawing.Size(200, 200);
            this.label1.MinimumSize = new System.Drawing.Size(200, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formular Regjistrimi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mbiemri";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Titulli";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rroga";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Password-i";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Konfirmo Password-in";
            // 
            // emritxt
            // 
            this.emritxt.Location = new System.Drawing.Point(362, 113);
            this.emritxt.Name = "emritxt";
            this.emritxt.Size = new System.Drawing.Size(100, 22);
            this.emritxt.TabIndex = 8;
            // 
            // mbiemritxt
            // 
            this.mbiemritxt.Location = new System.Drawing.Point(362, 163);
            this.mbiemritxt.Name = "mbiemritxt";
            this.mbiemritxt.Size = new System.Drawing.Size(100, 22);
            this.mbiemritxt.TabIndex = 9;
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(362, 211);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(100, 22);
            this.emailtxt.TabIndex = 10;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(362, 244);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(100, 22);
            this.passwordtxt.TabIndex = 11;
            // 
            // kpasswordtxt
            // 
            this.kpasswordtxt.Location = new System.Drawing.Point(362, 275);
            this.kpasswordtxt.Name = "kpasswordtxt";
            this.kpasswordtxt.Size = new System.Drawing.Size(100, 22);
            this.kpasswordtxt.TabIndex = 12;
            this.kpasswordtxt.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // titullitxt
            // 
            this.titullitxt.Location = new System.Drawing.Point(362, 310);
            this.titullitxt.Name = "titullitxt";
            this.titullitxt.Size = new System.Drawing.Size(100, 22);
            this.titullitxt.TabIndex = 13;
            // 
            // rrogatxt
            // 
            this.rrogatxt.Location = new System.Drawing.Point(362, 358);
            this.rrogatxt.Name = "rrogatxt";
            this.rrogatxt.Size = new System.Drawing.Size(100, 22);
            this.rrogatxt.TabIndex = 14;
            // 
            // btnregjistro
            // 
            this.btnregjistro.Location = new System.Drawing.Point(349, 415);
            this.btnregjistro.Name = "btnregjistro";
            this.btnregjistro.Size = new System.Drawing.Size(138, 23);
            this.btnregjistro.TabIndex = 15;
            this.btnregjistro.Text = "Regjistrohu";
            this.btnregjistro.UseVisualStyleBackColor = true;
            this.btnregjistro.Click += new System.EventHandler(this.btnregjistro_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnregjistro);
            this.Controls.Add(this.rrogatxt);
            this.Controls.Add(this.titullitxt);
            this.Controls.Add(this.kpasswordtxt);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.mbiemritxt);
            this.Controls.Add(this.emritxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emritxt;
        private System.Windows.Forms.TextBox mbiemritxt;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.TextBox kpasswordtxt;
        private System.Windows.Forms.TextBox titullitxt;
        private System.Windows.Forms.TextBox rrogatxt;
        private System.Windows.Forms.Button btnregjistro;
    }
}