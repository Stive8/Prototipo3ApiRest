namespace Cliente
{
    partial class GUIListarMedidor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnListarMedidor = new System.Windows.Forms.Button();
            this.btnActivo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltrarPredio = new System.Windows.Forms.TextBox();
            this.btnFiltrarPredio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnListarMedidor
            // 
            this.btnListarMedidor.Location = new System.Drawing.Point(505, 271);
            this.btnListarMedidor.Name = "btnListarMedidor";
            this.btnListarMedidor.Size = new System.Drawing.Size(91, 35);
            this.btnListarMedidor.TabIndex = 1;
            this.btnListarMedidor.Text = "Listar";
            this.btnListarMedidor.UseVisualStyleBackColor = true;
            this.btnListarMedidor.Click += new System.EventHandler(this.btnListarMedidor_Click);
            // 
            // btnActivo
            // 
            this.btnActivo.AutoSize = true;
            this.btnActivo.Location = new System.Drawing.Point(72, 280);
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(55, 17);
            this.btnActivo.TabIndex = 3;
            this.btnActivo.TabStop = true;
            this.btnActivo.Text = "Activo";
            this.btnActivo.UseVisualStyleBackColor = true;
            this.btnActivo.Click += new System.EventHandler(this.btnActivo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtrar Por Predio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Digite El Id Del Predio";
            // 
            // txtFiltrarPredio
            // 
            this.txtFiltrarPredio.Location = new System.Drawing.Point(291, 279);
            this.txtFiltrarPredio.Name = "txtFiltrarPredio";
            this.txtFiltrarPredio.Size = new System.Drawing.Size(100, 20);
            this.txtFiltrarPredio.TabIndex = 6;
            // 
            // btnFiltrarPredio
            // 
            this.btnFiltrarPredio.Location = new System.Drawing.Point(306, 307);
            this.btnFiltrarPredio.Name = "btnFiltrarPredio";
            this.btnFiltrarPredio.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarPredio.TabIndex = 7;
            this.btnFiltrarPredio.Text = "Filtrar";
            this.btnFiltrarPredio.UseVisualStyleBackColor = true;
            this.btnFiltrarPredio.Click += new System.EventHandler(this.btnFiltrarPredio_Click);
            // 
            // GUIListarMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 342);
            this.Controls.Add(this.btnFiltrarPredio);
            this.Controls.Add(this.txtFiltrarPredio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnActivo);
            this.Controls.Add(this.btnListarMedidor);
            this.Controls.Add(this.dataGridView1);
            this.Name = "GUIListarMedidor";
            this.Text = "Listar Medidor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnListarMedidor;
        private System.Windows.Forms.RadioButton btnActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltrarPredio;
        private System.Windows.Forms.Button btnFiltrarPredio;
    }
}