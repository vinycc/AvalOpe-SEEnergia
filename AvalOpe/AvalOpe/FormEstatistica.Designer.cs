namespace AvalOpe
{
    partial class FormEstatistica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstatistica));
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.wineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentagem = new Sample.DataGridViewProgressColumn();
            this.dataGridViewProgressColumn1 = new Sample.DataGridViewProgressColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataInicial = new System.Windows.Forms.DateTimePicker();
            this.btEnviar = new System.Windows.Forms.Button();
            this.criterio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.regional = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.operador = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dataGridView
            // 
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wineColumn,
            this.Porcentagem});
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // wineColumn
            // 
            this.wineColumn.DataPropertyName = "Criterio";
            resources.ApplyResources(this.wineColumn, "wineColumn");
            this.wineColumn.Name = "wineColumn";
            this.wineColumn.ReadOnly = true;
            this.wineColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Porcentagem
            // 
            this.Porcentagem.DataPropertyName = "Porcentagem";
            resources.ApplyResources(this.Porcentagem, "Porcentagem");
            this.Porcentagem.Name = "Porcentagem";
            this.Porcentagem.ReadOnly = true;
            this.Porcentagem.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Porcentagem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.DataPropertyName = "Porcentagem";
            resources.ApplyResources(this.dataGridViewProgressColumn1, "dataGridViewProgressColumn1");
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.dataInicial);
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Controls.Add(this.criterio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dataFinal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.regional);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.operador);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // dataInicial
            // 
            resources.ApplyResources(this.dataInicial, "dataInicial");
            this.dataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataInicial.MaxDate = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.dataInicial.MinDate = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            this.dataInicial.Name = "dataInicial";
            this.dataInicial.Value = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.dataInicial.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // btEnviar
            // 
            resources.ApplyResources(this.btEnviar, "btEnviar");
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // criterio
            // 
            resources.ApplyResources(this.criterio, "criterio");
            this.criterio.FormattingEnabled = true;
            this.criterio.Name = "criterio";
            this.criterio.SelectedIndexChanged += new System.EventHandler(this.criterio_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // dataFinal
            // 
            resources.ApplyResources(this.dataFinal, "dataFinal");
            this.dataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataFinal.MaxDate = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.dataFinal.MinDate = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            this.dataFinal.Name = "dataFinal";
            this.dataFinal.Value = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.dataFinal.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // regional
            // 
            resources.ApplyResources(this.regional, "regional");
            this.regional.FormattingEnabled = true;
            this.regional.Name = "regional";
            this.regional.SelectedIndexChanged += new System.EventHandler(this.regional_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // operador
            // 
            resources.ApplyResources(this.operador, "operador");
            this.operador.FormattingEnabled = true;
            this.operador.Name = "operador";
            this.operador.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // FormEstatistica
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormEstatistica";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label9;
        private Sample.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn wineColumn;
        private Sample.DataGridViewProgressColumn Porcentagem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox operador;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox criterio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dataFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox regional;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.DateTimePicker dataInicial;
    }
}