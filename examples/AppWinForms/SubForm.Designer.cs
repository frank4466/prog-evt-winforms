namespace AppWinForms
{
    partial class SubForm
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
            this.validateBtn = new System.Windows.Forms.Button();
            this.inputLbl = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // validateBtn
            // 
            this.validateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.validateBtn.Location = new System.Drawing.Point(105, 113);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(75, 23);
            this.validateBtn.TabIndex = 0;
            this.validateBtn.Text = "Valider";
            this.validateBtn.UseVisualStyleBackColor = true;
            // 
            // inputLbl
            // 
            this.inputLbl.AutoSize = true;
            this.inputLbl.Location = new System.Drawing.Point(81, 51);
            this.inputLbl.Name = "inputLbl";
            this.inputLbl.Size = new System.Drawing.Size(33, 13);
            this.inputLbl.TabIndex = 1;
            this.inputLbl.Text = "Label";
            this.inputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(84, 67);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(116, 20);
            this.inputBox.TabIndex = 2;
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 148);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.inputLbl);
            this.Controls.Add(this.validateBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubForm";
            this.Text = "SubForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.Label inputLbl;
        private System.Windows.Forms.TextBox inputBox;
    }
}