namespace AvalOpe.FormAvaliacaoCriterioDist
{
    partial class FormAvaliarCriterioSequenciaChaveamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAvaliarCriterioSequenciaChaveamento));
            this.txtAvaliacao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.trackAcaoCorreta = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAcaoCorreta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAvaliacao
            // 
            resources.ApplyResources(this.txtAvaliacao, "txtAvaliacao");
            this.txtAvaliacao.Name = "txtAvaliacao";
            this.txtAvaliacao.ReadOnly = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtNota
            // 
            resources.ApplyResources(this.txtNota, "txtNota");
            this.txtNota.Name = "txtNota";
            this.txtNota.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtPeso
            // 
            resources.ApplyResources(this.txtPeso, "txtPeso");
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.TextChanged += new System.EventHandler(this.txtPeso_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // btCancelar
            // 
            resources.ApplyResources(this.btCancelar, "btCancelar");
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            resources.ApplyResources(this.btSalvar, "btSalvar");
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.trackAcaoCorreta);
            this.groupBox2.Controls.Add(this.label8);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // trackAcaoCorreta
            // 
            resources.ApplyResources(this.trackAcaoCorreta, "trackAcaoCorreta");
            this.trackAcaoCorreta.Maximum = 1;
            this.trackAcaoCorreta.Name = "trackAcaoCorreta";
            this.trackAcaoCorreta.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackAcaoCorreta.Scroll += new System.EventHandler(this.trackAdequado_Scroll);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtObservacao
            // 
            resources.ApplyResources(this.txtObservacao, "txtObservacao");
            this.txtObservacao.Name = "txtObservacao";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // FormAvaliarCriterioSequenciaChaveamento
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.txtAvaliacao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label13);
            this.Name = "FormAvaliarCriterioSequenciaChaveamento";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackAcaoCorreta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAvaliacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar trackAcaoCorreta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label2;
    }
}