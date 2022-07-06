namespace AvalOpe
{
    partial class FormAdicionarManobra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdicionarManobra));
            this.comboAcao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempo = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btAdicionarLista = new System.Windows.Forms.Button();
            this.comboObjeto = new System.Windows.Forms.ComboBox();
            this.txtIdObjeto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboAcao
            // 
            resources.ApplyResources(this.comboAcao, "comboAcao");
            this.comboAcao.FormattingEnabled = true;
            this.comboAcao.Name = "comboAcao";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btAdicionar
            // 
            resources.ApplyResources(this.btAdicionar, "btAdicionar");
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // btCancelar
            // 
            resources.ApplyResources(this.btCancelar, "btCancelar");
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtTempo
            // 
            resources.ApplyResources(this.txtTempo, "txtTempo");
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btAdicionarLista
            // 
            resources.ApplyResources(this.btAdicionarLista, "btAdicionarLista");
            this.btAdicionarLista.Name = "btAdicionarLista";
            this.btAdicionarLista.UseVisualStyleBackColor = true;
            this.btAdicionarLista.Click += new System.EventHandler(this.btAdicionarLista_Click);
            // 
            // comboObjeto
            // 
            resources.ApplyResources(this.comboObjeto, "comboObjeto");
            this.comboObjeto.FormattingEnabled = true;
            this.comboObjeto.Name = "comboObjeto";
            // 
            // txtIdObjeto
            // 
            resources.ApplyResources(this.txtIdObjeto, "txtIdObjeto");
            this.txtIdObjeto.Name = "txtIdObjeto";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // FormAdicionarManobra
            // 
            this.AcceptButton = this.btAdicionar;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdObjeto);
            this.Controls.Add(this.comboObjeto);
            this.Controls.Add(this.btAdicionarLista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboAcao);
            this.Name = "FormAdicionarManobra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAcao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAdicionar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtTempo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btAdicionarLista;
        private System.Windows.Forms.ComboBox comboObjeto;
        private System.Windows.Forms.TextBox txtIdObjeto;
        private System.Windows.Forms.Label label4;
    }
}