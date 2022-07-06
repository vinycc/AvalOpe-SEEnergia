namespace AvalOpe
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btDistribuição = new System.Windows.Forms.Button();
            this.btSubtransmissão = new System.Windows.Forms.Button();
            this.CmbTables = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // btDistribuição
            // 
            resources.ApplyResources(this.btDistribuição, "btDistribuição");
            this.btDistribuição.Name = "btDistribuição";
            this.btDistribuição.UseVisualStyleBackColor = true;
            this.btDistribuição.Click += new System.EventHandler(this.btDistribuição_Click);
            // 
            // btSubtransmissão
            // 
            resources.ApplyResources(this.btSubtransmissão, "btSubtransmissão");
            this.btSubtransmissão.Name = "btSubtransmissão";
            this.btSubtransmissão.UseVisualStyleBackColor = true;
            this.btSubtransmissão.Click += new System.EventHandler(this.btSubtransmissão_Click);
            // 
            // CmbTables
            // 
            this.CmbTables.FormattingEnabled = true;
            resources.ApplyResources(this.CmbTables, "CmbTables");
            this.CmbTables.Name = "CmbTables";
            // 
            // FormInicio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CmbTables);
            this.Controls.Add(this.btSubtransmissão);
            this.Controls.Add(this.btDistribuição);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInicio_FormClosed);
            this.Load += new System.EventHandler(this.FormInicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btDistribuição;
        private System.Windows.Forms.Button btSubtransmissão;
        private System.Windows.Forms.ComboBox CmbTables;
    }
}