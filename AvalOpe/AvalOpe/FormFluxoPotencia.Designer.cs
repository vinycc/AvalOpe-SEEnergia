namespace AvalOpe
{
    partial class FormFluxoPotencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFluxoPotencia));
            this.btExecutarFluxo = new System.Windows.Forms.Button();
            this.btVisualizarFluxo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboRede = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucDiagrama = new AvalOpe.ucDiagramaUnifilar();
            this.txtFluxo = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btExecutarFluxo
            // 
            resources.ApplyResources(this.btExecutarFluxo, "btExecutarFluxo");
            this.btExecutarFluxo.Name = "btExecutarFluxo";
            this.btExecutarFluxo.UseVisualStyleBackColor = true;
            this.btExecutarFluxo.Click += new System.EventHandler(this.btExecutarFluxo_Click);
            // 
            // btVisualizarFluxo
            // 
            resources.ApplyResources(this.btVisualizarFluxo, "btVisualizarFluxo");
            this.btVisualizarFluxo.Name = "btVisualizarFluxo";
            this.btVisualizarFluxo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.comboRede, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btVisualizarFluxo, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btExecutarFluxo, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // comboRede
            // 
            resources.ApplyResources(this.comboRede, "comboRede");
            this.comboRede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRede.FormattingEnabled = true;
            this.comboRede.Items.AddRange(new object[] {
            resources.GetString("comboRede.Items"),
            resources.GetString("comboRede.Items1"),
            resources.GetString("comboRede.Items2")});
            this.comboRede.Name = "comboRede";
            this.comboRede.SelectedIndexChanged += new System.EventHandler(this.comboRede_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.ucDiagrama);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.txtFluxo);
            // 
            // ucDiagrama
            // 
            resources.ApplyResources(this.ucDiagrama, "ucDiagrama");
            this.ucDiagrama.Name = "ucDiagrama";
            // 
            // txtFluxo
            // 
            resources.ApplyResources(this.txtFluxo, "txtFluxo");
            this.txtFluxo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFluxo.Name = "txtFluxo";
            // 
            // FormFluxoPotencia
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormFluxoPotencia";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btExecutarFluxo;
        private System.Windows.Forms.Button btVisualizarFluxo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboRede;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ucDiagramaUnifilar ucDiagrama;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox txtFluxo;
    }
}