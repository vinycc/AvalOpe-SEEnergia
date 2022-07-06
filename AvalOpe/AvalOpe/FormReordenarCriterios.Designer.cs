namespace AvalOpe
{
    partial class FormReordenarCriterios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReordenarCriterios));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btDescer = new System.Windows.Forms.Button();
            this.btSubir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Prioridade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criterio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Novo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prioridade,
            this.Criterio,
            this.Peso,
            this.Id,
            this.Desvio,
            this.Novo});
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btAdicionar
            // 
            resources.ApplyResources(this.btAdicionar, "btAdicionar");
            this.btAdicionar.Image = global::AvalOpe.Properties.Resources.add;
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // btExcluir
            // 
            resources.ApplyResources(this.btExcluir, "btExcluir");
            this.btExcluir.Image = global::AvalOpe.Properties.Resources.delete2;
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btSalvar
            // 
            resources.ApplyResources(this.btSalvar, "btSalvar");
            this.btSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btSalvar.Image = global::AvalOpe.Properties.Resources.disc;
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btDescer
            // 
            resources.ApplyResources(this.btDescer, "btDescer");
            this.btDescer.Image = global::AvalOpe.Properties.Resources.arrow_down;
            this.btDescer.Name = "btDescer";
            this.btDescer.UseVisualStyleBackColor = true;
            this.btDescer.Click += new System.EventHandler(this.btDescer_Click);
            // 
            // btSubir
            // 
            resources.ApplyResources(this.btSubir, "btSubir");
            this.btSubir.Image = global::AvalOpe.Properties.Resources.arrow_up;
            this.btSubir.Name = "btSubir";
            this.btSubir.UseVisualStyleBackColor = true;
            this.btSubir.Click += new System.EventHandler(this.btSubir_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btSubir, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btExcluir, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btAdicionar, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btDescer, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btSalvar, 0, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // Prioridade
            // 
            this.Prioridade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.Prioridade, "Prioridade");
            this.Prioridade.Name = "Prioridade";
            this.Prioridade.ReadOnly = true;
            // 
            // Criterio
            // 
            this.Criterio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Criterio, "Criterio");
            this.Criterio.Name = "Criterio";
            this.Criterio.ReadOnly = true;
            // 
            // Peso
            // 
            this.Peso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.Peso, "Peso");
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            // 
            // Id
            // 
            resources.ApplyResources(this.Id, "Id");
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Desvio
            // 
            resources.ApplyResources(this.Desvio, "Desvio");
            this.Desvio.Name = "Desvio";
            this.Desvio.ReadOnly = true;
            // 
            // Novo
            // 
            resources.ApplyResources(this.Novo, "Novo");
            this.Novo.Name = "Novo";
            this.Novo.ReadOnly = true;
            // 
            // FormReordenarCriterios
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormReordenarCriterios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btSubir;
        private System.Windows.Forms.Button btDescer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prioridade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criterio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Novo;
    }
}