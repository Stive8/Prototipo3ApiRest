﻿namespace Cliente
{
    partial class GUICrearMedidor
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
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtDiametro = new System.Windows.Forms.TextBox();
            this.txtIdPredio = new System.Windows.Forms.TextBox();
            this.btnCrearMedidor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diametro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID del predio";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(193, 28);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(88, 20);
            this.txtMarca.TabIndex = 4;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(194, 58);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(87, 20);
            this.txtSerial.TabIndex = 5;
            // 
            // txtDiametro
            // 
            this.txtDiametro.Location = new System.Drawing.Point(193, 93);
            this.txtDiametro.Name = "txtDiametro";
            this.txtDiametro.Size = new System.Drawing.Size(88, 20);
            this.txtDiametro.TabIndex = 6;
            // 
            // txtIdPredio
            // 
            this.txtIdPredio.Location = new System.Drawing.Point(194, 130);
            this.txtIdPredio.Name = "txtIdPredio";
            this.txtIdPredio.Size = new System.Drawing.Size(86, 20);
            this.txtIdPredio.TabIndex = 7;
            // 
            // btnCrearMedidor
            // 
            this.btnCrearMedidor.Location = new System.Drawing.Point(140, 165);
            this.btnCrearMedidor.Name = "btnCrearMedidor";
            this.btnCrearMedidor.Size = new System.Drawing.Size(89, 23);
            this.btnCrearMedidor.TabIndex = 8;
            this.btnCrearMedidor.Text = "Crear";
            this.btnCrearMedidor.UseVisualStyleBackColor = true;
            this.btnCrearMedidor.Click += new System.EventHandler(this.btnCrearMedidor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Modulo Crear Medidor";
            // 
            // GUICrearMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 211);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCrearMedidor);
            this.Controls.Add(this.txtIdPredio);
            this.Controls.Add(this.txtDiametro);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GUICrearMedidor";
            this.Text = "Crear Medidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.TextBox txtDiametro;
        private System.Windows.Forms.TextBox txtIdPredio;
        private System.Windows.Forms.Button btnCrearMedidor;
        private System.Windows.Forms.Label label5;
    }
}