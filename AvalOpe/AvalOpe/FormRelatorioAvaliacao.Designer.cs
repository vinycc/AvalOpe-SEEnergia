namespace AvalOpe
{
    partial class FormRelatorioAvaliacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelatorioAvaliacao));
            this.lblDataAvaliacao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInstalacao = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAvaliacao = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblOperador = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.wineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentagem = new Sample.DataGridViewProgressColumn();
            this.dataGridViewProgressColumn1 = new Sample.DataGridViewProgressColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDataAvaliacao
            // 
            resources.ApplyResources(this.lblDataAvaliacao, "lblDataAvaliacao");
            this.lblDataAvaliacao.Name = "lblDataAvaliacao";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lblInstalacao
            // 
            resources.ApplyResources(this.lblInstalacao, "lblInstalacao");
            this.lblInstalacao.Name = "lblInstalacao";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // lblAvaliacao
            // 
            resources.ApplyResources(this.lblAvaliacao, "lblAvaliacao");
            this.lblAvaliacao.Name = "lblAvaliacao";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // lblOperador
            // 
            resources.ApplyResources(this.lblOperador, "lblOperador");
            this.lblOperador.Name = "lblOperador";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.lblAvaliacao);
            this.groupBox1.Controls.Add(this.lblDataAvaliacao);
            this.groupBox1.Controls.Add(this.lblOperador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblInstalacao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormRelatorioAvaliacao
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRelatorioAvaliacao";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAvaliacao;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblDataAvaliacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInstalacao;
        private System.Windows.Forms.Label label9;
        private Sample.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn wineColumn;
        private Sample.DataGridViewProgressColumn Porcentagem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}