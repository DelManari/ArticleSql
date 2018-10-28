namespace ArticleSql
{
    partial class RechForm
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
            this.txtprix = new System.Windows.Forms.TextBox();
            this.recherchbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpromo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtquan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtprix
            // 
            this.txtprix.Location = new System.Drawing.Point(68, 27);
            this.txtprix.Name = "txtprix";
            this.txtprix.Size = new System.Drawing.Size(100, 20);
            this.txtprix.TabIndex = 0;
            // 
            // recherchbtn
            // 
            this.recherchbtn.Location = new System.Drawing.Point(180, 154);
            this.recherchbtn.Name = "recherchbtn";
            this.recherchbtn.Size = new System.Drawing.Size(75, 23);
            this.recherchbtn.TabIndex = 3;
            this.recherchbtn.Text = "recherche";
            this.recherchbtn.UseVisualStyleBackColor = true;
            this.recherchbtn.Click += new System.EventHandler(this.recherchbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "prix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "promo";
            // 
            // txtpromo
            // 
            this.txtpromo.Location = new System.Drawing.Point(68, 70);
            this.txtpromo.Name = "txtpromo";
            this.txtpromo.Size = new System.Drawing.Size(100, 20);
            this.txtpromo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantite";
            // 
            // txtquan
            // 
            this.txtquan.Location = new System.Drawing.Point(68, 109);
            this.txtquan.Name = "txtquan";
            this.txtquan.Size = new System.Drawing.Size(100, 20);
            this.txtquan.TabIndex = 7;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtquan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpromo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recherchbtn);
            this.Controls.Add(this.txtprix);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtprix;
        private System.Windows.Forms.Button recherchbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpromo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtquan;
    }
}