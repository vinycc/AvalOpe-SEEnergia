namespace AvalOpe
{
    partial class FormTeste1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeste1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.txtHorasManutencao = new System.Windows.Forms.TextBox();
            this.cbTensao = new System.Windows.Forms.ComboBox();
            this.cbConsumidorPrioritario = new System.Windows.Forms.ComboBox();
            this.cbFioPartido = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btEnviar);
            this.panel2.Controls.Add(this.txtHorasManutencao);
            this.panel2.Controls.Add(this.cbTensao);
            this.panel2.Controls.Add(this.cbConsumidorPrioritario);
            this.panel2.Controls.Add(this.cbFioPartido);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Name = "panel2";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btEnviar
            // 
            resources.ApplyResources(this.btEnviar, "btEnviar");
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // txtHorasManutencao
            // 
            resources.ApplyResources(this.txtHorasManutencao, "txtHorasManutencao");
            this.txtHorasManutencao.Name = "txtHorasManutencao";
            // 
            // cbTensao
            // 
            resources.ApplyResources(this.cbTensao, "cbTensao");
            this.cbTensao.FormattingEnabled = true;
            this.cbTensao.Items.AddRange(new object[] {
            resources.GetString("cbTensao.Items"),
            resources.GetString("cbTensao.Items1")});
            this.cbTensao.Name = "cbTensao";
            // 
            // cbConsumidorPrioritario
            // 
            resources.ApplyResources(this.cbConsumidorPrioritario, "cbConsumidorPrioritario");
            this.cbConsumidorPrioritario.FormattingEnabled = true;
            this.cbConsumidorPrioritario.Items.AddRange(new object[] {
            resources.GetString("cbConsumidorPrioritario.Items"),
            resources.GetString("cbConsumidorPrioritario.Items1")});
            this.cbConsumidorPrioritario.Name = "cbConsumidorPrioritario";
            // 
            // cbFioPartido
            // 
            resources.ApplyResources(this.cbFioPartido, "cbFioPartido");
            this.cbFioPartido.FormattingEnabled = true;
            this.cbFioPartido.Items.AddRange(new object[] {
            resources.GetString("cbFioPartido.Items"),
            resources.GetString("cbFioPartido.Items1")});
            this.cbFioPartido.Name = "cbFioPartido";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // FormTeste1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "FormTeste1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TextBox txtHorasManutencao;
        private System.Windows.Forms.ComboBox cbTensao;
        private System.Windows.Forms.ComboBox cbConsumidorPrioritario;
        private System.Windows.Forms.ComboBox cbFioPartido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}