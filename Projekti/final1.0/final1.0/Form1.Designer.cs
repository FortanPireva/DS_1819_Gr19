namespace final1._0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.btnEnkripto = new System.Windows.Forms.Button();
            this.txtCiphertext = new System.Windows.Forms.TextBox();
            this.btnDekripto = new System.Windows.Forms.Button();
            this.txtTextiDekriptuar = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textQelsi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPlaintext.Location = new System.Drawing.Point(80, 42);
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.Size = new System.Drawing.Size(644, 26);
            this.txtPlaintext.TabIndex = 0;
            this.txtPlaintext.Text = "Message";
            this.txtPlaintext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnkripto
            // 
            this.btnEnkripto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnkripto.BackgroundImage")));
            this.btnEnkripto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEnkripto.Location = new System.Drawing.Point(659, 108);
            this.btnEnkripto.Name = "btnEnkripto";
            this.btnEnkripto.Size = new System.Drawing.Size(65, 62);
            this.btnEnkripto.TabIndex = 1;
            this.btnEnkripto.UseVisualStyleBackColor = true;
            this.btnEnkripto.Click += new System.EventHandler(this.btnEnkripto_Click);
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCiphertext.Location = new System.Drawing.Point(79, 211);
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.Size = new System.Drawing.Size(645, 26);
            this.txtCiphertext.TabIndex = 2;
            // 
            // btnDekripto
            // 
            this.btnDekripto.BackColor = System.Drawing.Color.DarkGray;
            this.btnDekripto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDekripto.BackgroundImage")));
            this.btnDekripto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDekripto.Location = new System.Drawing.Point(658, 277);
            this.btnDekripto.Name = "btnDekripto";
            this.btnDekripto.Size = new System.Drawing.Size(66, 62);
            this.btnDekripto.TabIndex = 3;
            this.btnDekripto.UseVisualStyleBackColor = false;
            this.btnDekripto.Click += new System.EventHandler(this.btnDekripto_Click);
            // 
            // txtTextiDekriptuar
            // 
            this.txtTextiDekriptuar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtTextiDekriptuar.Location = new System.Drawing.Point(79, 391);
            this.txtTextiDekriptuar.Name = "txtTextiDekriptuar";
            this.txtTextiDekriptuar.Size = new System.Drawing.Size(645, 26);
            this.txtTextiDekriptuar.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(79, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Shiko Celesin";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textQelsi
            // 
            this.textQelsi.Location = new System.Drawing.Point(274, 125);
            this.textQelsi.Name = "textQelsi";
            this.textQelsi.Size = new System.Drawing.Size(362, 26);
            this.textQelsi.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textQelsi);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtTextiDekriptuar);
            this.Controls.Add(this.btnDekripto);
            this.Controls.Add(this.txtCiphertext);
            this.Controls.Add(this.btnEnkripto);
            this.Controls.Add(this.txtPlaintext);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlaintext;
        private System.Windows.Forms.Button btnEnkripto;
        private System.Windows.Forms.TextBox txtCiphertext;
        private System.Windows.Forms.Button btnDekripto;
        private System.Windows.Forms.TextBox txtTextiDekriptuar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textQelsi;
    }
}

