namespace AvalOpe.FormAvaliacaoCriterioDist
{
    partial class FormAvaliarCriterioTempoFila
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAvaliarCriterioTempoFila));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInadequado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRazoavel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdequado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.trackInadequado = new System.Windows.Forms.TrackBar();
            this.trackRazoavel = new System.Windows.Forms.TrackBar();
            this.trackAdequado = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAvaliacao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackInadequado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRazoavel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAdequado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInadequado);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRazoavel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAdequado);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtInadequado
            // 
            resources.ApplyResources(this.txtInadequado, "txtInadequado");
            this.txtInadequado.Name = "txtInadequado";
            this.txtInadequado.TextChanged += new System.EventHandler(this.txtAdequado_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtRazoavel
            // 
            resources.ApplyResources(this.txtRazoavel, "txtRazoavel");
            this.txtRazoavel.Name = "txtRazoavel";
            this.txtRazoavel.TextChanged += new System.EventHandler(this.txtAdequado_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtAdequado
            // 
            resources.ApplyResources(this.txtAdequado, "txtAdequado");
            this.txtAdequado.Name = "txtAdequado";
            this.txtAdequado.TextChanged += new System.EventHandler(this.txtAdequado_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.trackInadequado);
            this.groupBox2.Controls.Add(this.trackRazoavel);
            this.groupBox2.Controls.Add(this.trackAdequado);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
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
            // trackInadequado
            // 
            resources.ApplyResources(this.trackInadequado, "trackInadequado");
            this.trackInadequado.Maximum = 1;
            this.trackInadequado.Name = "trackInadequado";
            this.trackInadequado.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackInadequado.Scroll += new System.EventHandler(this.trackInadequado_Scroll);
            // 
            // trackRazoavel
            // 
            resources.ApplyResources(this.trackRazoavel, "trackRazoavel");
            this.trackRazoavel.Maximum = 1;
            this.trackRazoavel.Name = "trackRazoavel";
            this.trackRazoavel.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackRazoavel.Scroll += new System.EventHandler(this.trackRazoavel_Scroll);
            // 
            // trackAdequado
            // 
            resources.ApplyResources(this.trackAdequado, "trackAdequado");
            this.trackAdequado.Maximum = 1;
            this.trackAdequado.Name = "trackAdequado";
            this.trackAdequado.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackAdequado.Scroll += new System.EventHandler(this.trackAdequado_Scroll);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
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
            this.txtPeso.TextChanged += new System.EventHandler(this.txtAdequado_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
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
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // FormAvaliarCriterioTempoFila
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtAvaliacao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.label13);
            this.Name = "FormAvaliarCriterioTempoFila";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackInadequado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackRazoavel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAdequado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInadequado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRazoavel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdequado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAvaliacao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar trackInadequado;
        private System.Windows.Forms.TrackBar trackRazoavel;
        private System.Windows.Forms.TrackBar trackAdequado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}