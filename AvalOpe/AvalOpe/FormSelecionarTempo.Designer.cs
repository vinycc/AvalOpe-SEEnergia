namespace AvalOpe
{
    partial class FormSelecionarTempo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelecionarTempo));
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTempo
            // 
            resources.ApplyResources(this.txtTempo, "txtTempo");
            this.txtTempo.Name = "txtTempo";
            // 
            // btEnviar
            // 
            resources.ApplyResources(this.btEnviar, "btEnviar");
            this.btEnviar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCancelar
            // 
            resources.ApplyResources(this.btCancelar, "btCancelar");
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // FormSelecionarTempo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btEnviar);
            this.Controls.Add(this.txtTempo);
            this.Name = "FormSelecionarTempo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label5;
    }
}