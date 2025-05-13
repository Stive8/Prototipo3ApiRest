using System;

namespace Cliente
{
    partial class Listar
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnEstratoBajo = new System.Windows.Forms.RadioButton();
            this.btnEstratoAlto = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(587, 232);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(478, 280);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(85, 39);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnEstratoBajo
            // 
            this.btnEstratoBajo.AutoSize = true;
            this.btnEstratoBajo.Location = new System.Drawing.Point(27, 291);
            this.btnEstratoBajo.Name = "btnEstratoBajo";
            this.btnEstratoBajo.Size = new System.Drawing.Size(85, 17);
            this.btnEstratoBajo.TabIndex = 6;
            this.btnEstratoBajo.TabStop = true;
            this.btnEstratoBajo.Text = "Estrato 1,2,3";
            this.btnEstratoBajo.UseVisualStyleBackColor = true;
            this.btnEstratoBajo.Click += new System.EventHandler(this.btnEstratoBajo_CheckedChanged);
            // 
            // btnEstratoAlto
            // 
            this.btnEstratoAlto.AutoSize = true;
            this.btnEstratoAlto.Location = new System.Drawing.Point(128, 291);
            this.btnEstratoAlto.Name = "btnEstratoAlto";
            this.btnEstratoAlto.Size = new System.Drawing.Size(85, 17);
            this.btnEstratoAlto.TabIndex = 7;
            this.btnEstratoAlto.TabStop = true;
            this.btnEstratoAlto.Text = "Estrato 4,5,6";
            this.btnEstratoAlto.UseVisualStyleBackColor = true;
            this.btnEstratoAlto.Click += new System.EventHandler(this.btnEstratoAlto_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filtrar Estratos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filtrar Estratos Por rango";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "MIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "MAX";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(297, 288);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(36, 20);
            this.txtMin.TabIndex = 12;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(379, 288);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(36, 20);
            this.txtMax.TabIndex = 13;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(308, 316);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 14;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // Listar
            // 
            this.ClientSize = new System.Drawing.Size(611, 351);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEstratoAlto);
            this.Controls.Add(this.btnEstratoBajo);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dataGridView2);
            this.Name = "Listar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn propietario;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn estrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subsidio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoVivienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorFactura;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.RadioButton btnEstratoBajo;
        private System.Windows.Forms.RadioButton btnEstratoAlto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnFiltrar;
    }
}