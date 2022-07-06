namespace AvalOpe
{
    partial class FormAdicionarManobraParametro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdicionarManobraParametro));
            this.txtNome = new System.Windows.Forms.MaskedTextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOperador = new System.Windows.Forms.Label();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.MaskedTextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.comboOperador = new System.Windows.Forms.ComboBox();
            this.comboData = new System.Windows.Forms.DateTimePicker();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.btDistribuição = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            this.txtNome.ValidatingType = typeof(System.DateTime);
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.Name = "lblNome";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblOperador
            // 
            resources.ApplyResources(this.lblOperador, "lblOperador");
            this.lblOperador.Name = "lblOperador";
            // 
            // lblLocalizacao
            // 
            resources.ApplyResources(this.lblLocalizacao, "lblLocalizacao");
            this.lblLocalizacao.Name = "lblLocalizacao";
            // 
            // txtLocalizacao
            // 
            resources.ApplyResources(this.txtLocalizacao, "txtLocalizacao");
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.ValidatingType = typeof(System.DateTime);
            // 
            // lblData
            // 
            resources.ApplyResources(this.lblData, "lblData");
            this.lblData.Name = "lblData";
            // 
            // comboOperador
            // 
            this.comboOperador.FormattingEnabled = true;
            this.comboOperador.Items.AddRange(new object[] {
            resources.GetString("comboOperador.Items"),
            resources.GetString("comboOperador.Items1"),
            resources.GetString("comboOperador.Items2")});
            resources.ApplyResources(this.comboOperador, "comboOperador");
            this.comboOperador.Name = "comboOperador";
            // 
            // comboData
            // 
            this.comboData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.comboData, "comboData");
            this.comboData.Name = "comboData";
            // 
            // btAdicionar
            // 
            resources.ApplyResources(this.btAdicionar, "btAdicionar");
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionarLista_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btCancelar, "btCancelar");
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // panelBotoes
            // 
            this.panelBotoes.Controls.Add(this.button1);
            this.panelBotoes.Controls.Add(this.btDistribuição);
            resources.ApplyResources(this.panelBotoes, "panelBotoes");
            this.panelBotoes.Name = "panelBotoes";
            // 
            // btDistribuição
            // 
            resources.ApplyResources(this.btDistribuição, "btDistribuição");
            this.btDistribuição.Name = "btDistribuição";
            this.btDistribuição.UseVisualStyleBackColor = true;
            this.btDistribuição.Click += new System.EventHandler(this.btDistribuição_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAdicionarManobraParametro
            // 
            this.AcceptButton = this.btAdicionar;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBotoes);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.comboData);
            this.Controls.Add(this.comboOperador);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.lblOperador);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label5);
            this.Name = "FormAdicionarManobraParametro";
            this.panelBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.MaskedTextBox txtLocalizacao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ComboBox comboOperador;
        private System.Windows.Forms.DateTimePicker comboData;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Panel panelBotoes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btDistribuição;
    }
}