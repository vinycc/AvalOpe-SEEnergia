namespace AvalOpe
{
    partial class FormArvoreCriterios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArvoreCriterios));
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.radioAutomatico = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboContingencia = new System.Windows.Forms.ComboBox();
            this.btReordenarCriterios = new System.Windows.Forms.Button();
            this.lblAvaliacaoTitulo = new System.Windows.Forms.Label();
            this.lblAvaliacao = new System.Windows.Forms.Label();
            this.btCalcularAvaliacao = new System.Windows.Forms.Button();
            this.btGerarArvore = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ucArvore = new System.Windows.Forms.Integration.ElementHost();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboOperador
            // 
            this.comboOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Items.AddRange(new object[] {
            resources.GetString("comboOperador.Items"),
            resources.GetString("comboOperador.Items1"),
            resources.GetString("comboOperador.Items2"),
            resources.GetString("comboOperador.Items3"),
            resources.GetString("comboOperador.Items4")});
            resources.ApplyResources(this.comboOperador, "comboOperador");
            this.comboOperador.Name = "comboOperador";
            this.comboOperador.SelectedIndexChanged += new System.EventHandler(this.comboOperador_SelectedIndexChanged);
            // 
            // radioManual
            // 
            resources.ApplyResources(this.radioManual, "radioManual");
            this.radioManual.Name = "radioManual";
            this.radioManual.TabStop = true;
            this.radioManual.UseVisualStyleBackColor = true;
            this.radioManual.CheckedChanged += new System.EventHandler(this.radioManual_CheckedChanged);
            // 
            // radioAutomatico
            // 
            resources.ApplyResources(this.radioAutomatico, "radioAutomatico");
            this.radioAutomatico.Name = "radioAutomatico";
            this.radioAutomatico.TabStop = true;
            this.radioAutomatico.UseVisualStyleBackColor = true;
            this.radioAutomatico.CheckedChanged += new System.EventHandler(this.radioAutomatico_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboContingencia);
            this.panel1.Controls.Add(this.btReordenarCriterios);
            this.panel1.Controls.Add(this.lblAvaliacaoTitulo);
            this.panel1.Controls.Add(this.lblAvaliacao);
            this.panel1.Controls.Add(this.btCalcularAvaliacao);
            this.panel1.Controls.Add(this.btGerarArvore);
            this.panel1.Controls.Add(this.radioAutomatico);
            this.panel1.Controls.Add(this.comboOperador);
            this.panel1.Controls.Add(this.radioManual);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // comboContingencia
            // 
            this.comboContingencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboContingencia.FormattingEnabled = true;
            this.comboContingencia.Items.AddRange(new object[] {
            resources.GetString("comboContingencia.Items"),
            resources.GetString("comboContingencia.Items1"),
            resources.GetString("comboContingencia.Items2"),
            resources.GetString("comboContingencia.Items3"),
            resources.GetString("comboContingencia.Items4")});
            resources.ApplyResources(this.comboContingencia, "comboContingencia");
            this.comboContingencia.Name = "comboContingencia";
            this.comboContingencia.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btReordenarCriterios
            // 
            resources.ApplyResources(this.btReordenarCriterios, "btReordenarCriterios");
            this.btReordenarCriterios.Name = "btReordenarCriterios";
            this.btReordenarCriterios.UseVisualStyleBackColor = true;
            this.btReordenarCriterios.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAvaliacaoTitulo
            // 
            resources.ApplyResources(this.lblAvaliacaoTitulo, "lblAvaliacaoTitulo");
            this.lblAvaliacaoTitulo.Name = "lblAvaliacaoTitulo";
            // 
            // lblAvaliacao
            // 
            resources.ApplyResources(this.lblAvaliacao, "lblAvaliacao");
            this.lblAvaliacao.Name = "lblAvaliacao";
            // 
            // btCalcularAvaliacao
            // 
            resources.ApplyResources(this.btCalcularAvaliacao, "btCalcularAvaliacao");
            this.btCalcularAvaliacao.Name = "btCalcularAvaliacao";
            this.btCalcularAvaliacao.UseVisualStyleBackColor = true;
            this.btCalcularAvaliacao.Click += new System.EventHandler(this.btCalcularAvaliacao_Click);
            // 
            // btGerarArvore
            // 
            resources.ApplyResources(this.btGerarArvore, "btGerarArvore");
            this.btGerarArvore.Name = "btGerarArvore";
            this.btGerarArvore.UseVisualStyleBackColor = true;
            this.btGerarArvore.Click += new System.EventHandler(this.btGerarArvore_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.ucArvore, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // ucArvore
            // 
            resources.ApplyResources(this.ucArvore, "ucArvore");
            this.ucArvore.Name = "ucArvore";
            this.ucArvore.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.ucArvore_ChildChanged);
            this.ucArvore.Child = null;
            // 
            // FormArvoreCriterios
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormArvoreCriterios";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.RadioButton radioAutomatico;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btGerarArvore;
        private System.Windows.Forms.Button btCalcularAvaliacao;
        private System.Windows.Forms.Integration.ElementHost ucArvore;
        private System.Windows.Forms.Label lblAvaliacaoTitulo;
        private System.Windows.Forms.Label lblAvaliacao;
        private System.Windows.Forms.Button btReordenarCriterios;
        private System.Windows.Forms.ComboBox comboContingencia;
    }
}