namespace TurkishTyper
{
    partial class FormSettings
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
            this.buttonUpperCase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUpperCase = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLowerCase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLowerCase = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonUpperCase
            // 
            this.buttonUpperCase.Location = new System.Drawing.Point(255, 20);
            this.buttonUpperCase.Name = "buttonUpperCase";
            this.buttonUpperCase.Size = new System.Drawing.Size(75, 23);
            this.buttonUpperCase.TabIndex = 5;
            this.buttonUpperCase.Text = "Change";
            this.buttonUpperCase.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "UPPER Case";
            // 
            // textBoxUpperCase
            // 
            this.textBoxUpperCase.Location = new System.Drawing.Point(83, 22);
            this.textBoxUpperCase.Name = "textBoxUpperCase";
            this.textBoxUpperCase.ReadOnly = true;
            this.textBoxUpperCase.Size = new System.Drawing.Size(166, 20);
            this.textBoxUpperCase.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLowerCase);
            this.groupBox1.Controls.Add(this.textBoxUpperCase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxLowerCase);
            this.groupBox1.Controls.Add(this.buttonUpperCase);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 80);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shortcuts";
            // 
            // buttonLowerCase
            // 
            this.buttonLowerCase.Location = new System.Drawing.Point(255, 46);
            this.buttonLowerCase.Name = "buttonLowerCase";
            this.buttonLowerCase.Size = new System.Drawing.Size(75, 23);
            this.buttonLowerCase.TabIndex = 9;
            this.buttonLowerCase.Text = "Change";
            this.buttonLowerCase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "lower Case";
            // 
            // textBoxLowerCase
            // 
            this.textBoxLowerCase.Location = new System.Drawing.Point(83, 48);
            this.textBoxLowerCase.Name = "textBoxLowerCase";
            this.textBoxLowerCase.ReadOnly = true;
            this.textBoxLowerCase.Size = new System.Drawing.Size(166, 20);
            this.textBoxLowerCase.TabIndex = 7;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 101);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSettings";
            this.Text = "TurkishTyper Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUpperCase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUpperCase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonLowerCase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLowerCase;
    }
}

