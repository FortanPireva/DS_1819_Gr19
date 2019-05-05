namespace DSProject
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
            this.txtPlaintexti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnkripto = new System.Windows.Forms.Button();
            this.btnDekripto = new System.Windows.Forms.Button();
            this.txtCiphertexti = new System.Windows.Forms.TextBox();
            this.txtTextiDekriptuar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPlaintexti
            // 
            this.txtPlaintexti.Location = new System.Drawing.Point(147, 95);
            this.txtPlaintexti.Name = "txtPlaintexti";
            this.txtPlaintexti.Size = new System.Drawing.Size(801, 22);
            this.txtPlaintexti.TabIndex = 0;
            this.txtPlaintexti.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shkruaj mesazhin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnEnkripto
            // 
            this.btnEnkripto.Location = new System.Drawing.Point(873, 210);
            this.btnEnkripto.Name = "btnEnkripto";
            this.btnEnkripto.Size = new System.Drawing.Size(75, 23);
            this.btnEnkripto.TabIndex = 2;
            this.btnEnkripto.Text = "Enkripto";
            this.btnEnkripto.UseVisualStyleBackColor = true;
            this.btnEnkripto.Click += new System.EventHandler(this.btnEnkripto_Click);
            // 
            // btnDekripto
            // 
            this.btnDekripto.Location = new System.Drawing.Point(873, 334);
            this.btnDekripto.Name = "btnDekripto";
            this.btnDekripto.Size = new System.Drawing.Size(75, 23);
            this.btnDekripto.TabIndex = 6;
            this.btnDekripto.Text = "Dekripto";
            this.btnDekripto.UseVisualStyleBackColor = true;
            this.btnDekripto.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCiphertexti
            // 
            this.txtCiphertexti.Location = new System.Drawing.Point(147, 277);
            this.txtCiphertexti.Name = "txtCiphertexti";
            this.txtCiphertexti.Size = new System.Drawing.Size(801, 22);
            this.txtCiphertexti.TabIndex = 7;
            this.txtCiphertexti.TextChanged += new System.EventHandler(this.plainTextBox2_TextChanged);
            // 
            // txtTextiDekriptuar
            // 
            this.txtTextiDekriptuar.Location = new System.Drawing.Point(147, 388);
            this.txtTextiDekriptuar.Name = "txtTextiDekriptuar";
            this.txtTextiDekriptuar.Size = new System.Drawing.Size(794, 22);
            this.txtTextiDekriptuar.TabIndex = 8;
            this.txtTextiDekriptuar.TextChanged += new System.EventHandler(this.txtTextiDekriptuar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ciphertexti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Plaintexti";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTextiDekriptuar);
            this.Controls.Add(this.txtCiphertexti);
            this.Controls.Add(this.btnDekripto);
            this.Controls.Add(this.btnEnkripto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPlaintexti);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlaintexti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnkripto;
        private System.Windows.Forms.Button btnDekripto;
        private System.Windows.Forms.TextBox txtCiphertexti;
        private System.Windows.Forms.TextBox txtTextiDekriptuar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}