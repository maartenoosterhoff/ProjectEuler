namespace ProjectEuler {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtSolution = new System.Windows.Forms.TextBox();
            this.cmbProblems = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtSolution
            // 
            this.txtSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSolution.Location = new System.Drawing.Point(0, 24);
            this.txtSolution.Multiline = true;
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.Size = new System.Drawing.Size(654, 485);
            this.txtSolution.TabIndex = 0;
            // 
            // cmbProblems
            // 
            this.cmbProblems.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbProblems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProblems.FormattingEnabled = true;
            this.cmbProblems.Location = new System.Drawing.Point(0, 0);
            this.cmbProblems.Name = "cmbProblems";
            this.cmbProblems.Size = new System.Drawing.Size(654, 24);
            this.cmbProblems.TabIndex = 1;
            this.cmbProblems.SelectedIndexChanged += new System.EventHandler(this.cmbProblems_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 509);
            this.Controls.Add(this.txtSolution);
            this.Controls.Add(this.cmbProblems);
            this.Name = "MainForm";
            this.Text = "Project Euler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSolution;
        private System.Windows.Forms.ComboBox cmbProblems;
    }
}

