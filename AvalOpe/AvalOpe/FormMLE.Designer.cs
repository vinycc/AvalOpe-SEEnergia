namespace AvalOpe
{
    partial class FormMLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMLE));
            this.btIndicadores = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExibirRedeOriginal = new System.Windows.Forms.Button();
            this.btExecutarFluxoPotencia = new System.Windows.Forms.Button();
            this.btReconfigurarRede = new System.Windows.Forms.Button();
            this.comboRede = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ucMatriz = new AvalOpe.ucMatriz();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btIndicadores
            // 
            resources.ApplyResources(this.btIndicadores, "btIndicadores");
            this.btIndicadores.Name = "btIndicadores";
            this.btIndicadores.UseVisualStyleBackColor = true;
            this.btIndicadores.Click += new System.EventHandler(this.btIndicadores_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExibirRedeOriginal);
            this.panel1.Controls.Add(this.btExecutarFluxoPotencia);
            this.panel1.Controls.Add(this.btReconfigurarRede);
            this.panel1.Controls.Add(this.comboRede);
            this.panel1.Controls.Add(this.btIndicadores);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btExibirRedeOriginal
            // 
            resources.ApplyResources(this.btExibirRedeOriginal, "btExibirRedeOriginal");
            this.btExibirRedeOriginal.Name = "btExibirRedeOriginal";
            this.btExibirRedeOriginal.UseVisualStyleBackColor = true;
            this.btExibirRedeOriginal.Click += new System.EventHandler(this.btExibirRedeOriginal_Click);
            // 
            // btExecutarFluxoPotencia
            // 
            resources.ApplyResources(this.btExecutarFluxoPotencia, "btExecutarFluxoPotencia");
            this.btExecutarFluxoPotencia.Name = "btExecutarFluxoPotencia";
            this.btExecutarFluxoPotencia.UseVisualStyleBackColor = true;
            this.btExecutarFluxoPotencia.Click += new System.EventHandler(this.btExecutarFluxoPotencia_Click);
            // 
            // btReconfigurarRede
            // 
            resources.ApplyResources(this.btReconfigurarRede, "btReconfigurarRede");
            this.btReconfigurarRede.Name = "btReconfigurarRede";
            this.btReconfigurarRede.UseVisualStyleBackColor = true;
            this.btReconfigurarRede.Click += new System.EventHandler(this.btReconfigurarRede_Click);
            // 
            // comboRede
            // 
            this.comboRede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRede.FormattingEnabled = true;
            this.comboRede.Items.AddRange(new object[] {
            resources.GetString("comboRede.Items"),
            resources.GetString("comboRede.Items1"),
            resources.GetString("comboRede.Items2"),
            resources.GetString("comboRede.Items3")});
            resources.ApplyResources(this.comboRede, "comboRede");
            this.comboRede.Name = "comboRede";
            this.comboRede.SelectedIndexChanged += new System.EventHandler(this.comboRede_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ucMatriz);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // ucMatriz
            // 
            resources.ApplyResources(this.ucMatriz, "ucMatriz");
            this.ucMatriz.Name = "ucMatriz";
            this.ucMatriz.Load += new System.EventHandler(this.ucMatriz_Load);
            // 
            // FormMLE
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormMLE";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btIndicadores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboRede;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private ucMatriz ucMatriz;
        private System.Windows.Forms.Button btExibirRedeOriginal;
        private System.Windows.Forms.Button btExecutarFluxoPotencia;
        private System.Windows.Forms.Button btReconfigurarRede;
    }
}