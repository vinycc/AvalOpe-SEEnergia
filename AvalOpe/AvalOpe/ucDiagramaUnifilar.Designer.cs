namespace AvalOpe
{
    partial class ucDiagramaUnifilar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDiagramaUnifilar));
            this.gViewer1 = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLegenda = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            resources.ApplyResources(this.gViewer1, "gViewer1");
            this.gViewer1.AsyncLayout = false;
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.gViewer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lblLegenda, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // lblLegenda
            // 
            resources.ApplyResources(this.lblLegenda, "lblLegenda");
            this.lblLegenda.Name = "lblLegenda";
            // 
            // ucDiagramaUnifilar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucDiagramaUnifilar";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLegenda;
    }
}
