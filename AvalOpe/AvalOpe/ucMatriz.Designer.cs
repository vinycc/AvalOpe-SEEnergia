namespace AvalOpe
{
    partial class ucMatriz
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMatriz));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.gViewer1 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.txtIndicadoresAuxiliar = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiagramaUnifilar = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabMatriz = new System.Windows.Forms.TabPage();
            this.txtTempo = new System.Windows.Forms.Label();
            this.txtMLE = new System.Windows.Forms.RichTextBox();
            this.tabIndicadores = new System.Windows.Forms.TabPage();
            this.txtIndicadores = new System.Windows.Forms.RichTextBox();
            this.tabFluxoPotencia = new System.Windows.Forms.TabPage();
            this.txtFluxoDePotencia = new System.Windows.Forms.RichTextBox();
            this.tabDiagramaGeo = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDiagramaUnifilar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabMatriz.SuspendLayout();
            this.tabIndicadores.SuspendLayout();
            this.tabFluxoPotencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel2.Controls.Add(this.txtIndicadoresAuxiliar);
            this.splitContainer1.Panel2Collapsed = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.elementHost1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.gViewer1, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // gViewer1
            // 
            this.gViewer1.AsyncLayout = false;
            resources.ApplyResources(this.gViewer1, "gViewer1");
            this.gViewer1.BackColor = System.Drawing.Color.Transparent;
            this.gViewer1.BackwardEnabled = true;
            this.gViewer1.ForwardEnabled = true;
            this.gViewer1.Graph = null;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomFraction = 0.5D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // txtIndicadoresAuxiliar
            // 
            this.txtIndicadoresAuxiliar.BackColor = System.Drawing.SystemColors.Window;
            this.txtIndicadoresAuxiliar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndicadoresAuxiliar.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txtIndicadoresAuxiliar, "txtIndicadoresAuxiliar");
            this.txtIndicadoresAuxiliar.Name = "txtIndicadoresAuxiliar";
            this.txtIndicadoresAuxiliar.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDiagramaUnifilar);
            this.tabControl1.Controls.Add(this.tabDiagramaGeo);
            this.tabControl1.Controls.Add(this.tabMatriz);
            this.tabControl1.Controls.Add(this.tabIndicadores);
            this.tabControl1.Controls.Add(this.tabFluxoPotencia);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabDiagramaUnifilar
            // 
            this.tabDiagramaUnifilar.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabDiagramaUnifilar, "tabDiagramaUnifilar");
            this.tabDiagramaUnifilar.Name = "tabDiagramaUnifilar";
            this.tabDiagramaUnifilar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabMatriz
            // 
            this.tabMatriz.Controls.Add(this.txtTempo);
            this.tabMatriz.Controls.Add(this.txtMLE);
            resources.ApplyResources(this.tabMatriz, "tabMatriz");
            this.tabMatriz.Name = "tabMatriz";
            this.tabMatriz.UseVisualStyleBackColor = true;
            // 
            // txtTempo
            // 
            resources.ApplyResources(this.txtTempo, "txtTempo");
            this.txtTempo.Name = "txtTempo";
            // 
            // txtMLE
            // 
            this.txtMLE.BackColor = System.Drawing.SystemColors.Window;
            this.txtMLE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMLE.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txtMLE, "txtMLE");
            this.txtMLE.Name = "txtMLE";
            this.txtMLE.ReadOnly = true;
            // 
            // tabIndicadores
            // 
            this.tabIndicadores.Controls.Add(this.txtIndicadores);
            resources.ApplyResources(this.tabIndicadores, "tabIndicadores");
            this.tabIndicadores.Name = "tabIndicadores";
            this.tabIndicadores.UseVisualStyleBackColor = true;
            // 
            // txtIndicadores
            // 
            this.txtIndicadores.BackColor = System.Drawing.SystemColors.Window;
            this.txtIndicadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndicadores.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txtIndicadores, "txtIndicadores");
            this.txtIndicadores.Name = "txtIndicadores";
            this.txtIndicadores.ReadOnly = true;
            // 
            // tabFluxoPotencia
            // 
            this.tabFluxoPotencia.Controls.Add(this.txtFluxoDePotencia);
            resources.ApplyResources(this.tabFluxoPotencia, "tabFluxoPotencia");
            this.tabFluxoPotencia.Name = "tabFluxoPotencia";
            this.tabFluxoPotencia.UseVisualStyleBackColor = true;
            // 
            // txtFluxoDePotencia
            // 
            this.txtFluxoDePotencia.BackColor = System.Drawing.SystemColors.Window;
            this.txtFluxoDePotencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFluxoDePotencia.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.txtFluxoDePotencia, "txtFluxoDePotencia");
            this.txtFluxoDePotencia.Name = "txtFluxoDePotencia";
            this.txtFluxoDePotencia.ReadOnly = true;
            // 
            // tabDiagramaGeo
            // 
            resources.ApplyResources(this.tabDiagramaGeo, "tabDiagramaGeo");
            this.tabDiagramaGeo.Name = "tabDiagramaGeo";
            this.tabDiagramaGeo.UseVisualStyleBackColor = true;
            // 
            // ucMatriz
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucMatriz";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDiagramaUnifilar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabMatriz.ResumeLayout(false);
            this.tabMatriz.PerformLayout();
            this.tabIndicadores.ResumeLayout(false);
            this.tabFluxoPotencia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDiagramaUnifilar;
        private System.Windows.Forms.TabPage tabMatriz;
        private System.Windows.Forms.TabPage tabIndicadores;
        private System.Windows.Forms.RichTextBox txtMLE;
        private System.Windows.Forms.Label txtTempo;
        private System.Windows.Forms.RichTextBox txtIndicadores;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtIndicadoresAuxiliar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.TabPage tabFluxoPotencia;
        private System.Windows.Forms.RichTextBox txtFluxoDePotencia;
        private System.Windows.Forms.TabPage tabDiagramaGeo;
    }
}
