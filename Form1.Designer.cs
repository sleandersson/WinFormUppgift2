namespace WinFormUppgift2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNamn = new System.Windows.Forms.TextBox();
            this.tbPnr = new System.Windows.Forms.TextBox();
            this.tbDistrikt = new System.Windows.Forms.TextBox();
            this.tbAntal = new System.Windows.Forms.TextBox();
            this.rtbResultat = new System.Windows.Forms.RichTextBox();
            this.btnRegistrera = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Staffan Leandersson, Sleandersson@yahoo.se, L0002B, Uppgift 2\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 105);
            this.label2.TabIndex = 1;
            this.label2.Text = "Namn:\r\n\r\nPersonnummer:\r\n\r\nDistrikt:\r\n\r\nAntal sålda artiklar:";
            // 
            // tbNamn
            // 
            this.tbNamn.Location = new System.Drawing.Point(126, 39);
            this.tbNamn.Name = "tbNamn";
            this.tbNamn.Size = new System.Drawing.Size(221, 23);
            this.tbNamn.TabIndex = 2;
            // 
            // tbPnr
            // 
            this.tbPnr.Location = new System.Drawing.Point(126, 68);
            this.tbPnr.Name = "tbPnr";
            this.tbPnr.Size = new System.Drawing.Size(221, 23);
            this.tbPnr.TabIndex = 3;
            // 
            // tbDistrikt
            // 
            this.tbDistrikt.Location = new System.Drawing.Point(126, 97);
            this.tbDistrikt.Name = "tbDistrikt";
            this.tbDistrikt.Size = new System.Drawing.Size(221, 23);
            this.tbDistrikt.TabIndex = 4;
            // 
            // tbAntal
            // 
            this.tbAntal.Location = new System.Drawing.Point(126, 126);
            this.tbAntal.Name = "tbAntal";
            this.tbAntal.Size = new System.Drawing.Size(221, 23);
            this.tbAntal.TabIndex = 5;
            // 
            // rtbResultat
            // 
            this.rtbResultat.Location = new System.Drawing.Point(353, 39);
            this.rtbResultat.Name = "rtbResultat";
            this.rtbResultat.ReadOnly = true;
            this.rtbResultat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbResultat.Size = new System.Drawing.Size(460, 228);
            this.rtbResultat.TabIndex = 6;
            this.rtbResultat.Text = "";
            // 
            // btnRegistrera
            // 
            this.btnRegistrera.Location = new System.Drawing.Point(241, 173);
            this.btnRegistrera.Name = "btnRegistrera";
            this.btnRegistrera.Size = new System.Drawing.Size(106, 44);
            this.btnRegistrera.TabIndex = 6;
            this.btnRegistrera.Text = "Registrera";
            this.btnRegistrera.UseVisualStyleBackColor = true;
            this.btnRegistrera.Click += new System.EventHandler(this.btnRegistrera_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(17, 173);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(106, 44);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "Ångra";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(17, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 44);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Avsluta";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVisa
            // 
            this.btnVisa.Location = new System.Drawing.Point(241, 223);
            this.btnVisa.Name = "btnVisa";
            this.btnVisa.Size = new System.Drawing.Size(106, 44);
            this.btnVisa.TabIndex = 9;
            this.btnVisa.Text = "Visa försäljning";
            this.btnVisa.UseVisualStyleBackColor = true;
            this.btnVisa.Click += new System.EventHandler(this.btnVisa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(825, 274);
            this.Controls.Add(this.btnVisa);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnRegistrera);
            this.Controls.Add(this.rtbResultat);
            this.Controls.Add(this.tbAntal);
            this.Controls.Add(this.tbDistrikt);
            this.Controls.Add(this.tbPnr);
            this.Controls.Add(this.tbNamn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Uppgift 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbNamn;
        private TextBox tbPnr;
        private TextBox tbDistrikt;
        private TextBox tbAntal;
        private RichTextBox rtbResultat;
        private Button btnRegistrera;
        private Button btnUndo;
        private Button btnClose;
        private Button btnVisa;
    }
}