namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbState = new System.Windows.Forms.ComboBox();
            this.a = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.TextBox();
            this.d = new System.Windows.Forms.TextBox();
            this.ee = new System.Windows.Forms.TextBox();
            this.f = new System.Windows.Forms.TextBox();
            this.x0 = new System.Windows.Forms.Label();
            this.x1 = new System.Windows.Forms.Label();
            this.x2 = new System.Windows.Forms.Label();
            this.x3 = new System.Windows.Forms.Label();
            this.x4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.evaluateButton = new System.Windows.Forms.Button();
            this.RootOutput = new System.Windows.Forms.Label();
            this.RootCheck = new System.Windows.Forms.Label();
            this.clearSolution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solutions of  the";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "degree equation";
            // 
            // CbState
            // 
            this.CbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbState.FormattingEnabled = true;
            this.CbState.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CbState.Location = new System.Drawing.Point(285, 15);
            this.CbState.MaxDropDownItems = 4;
            this.CbState.Name = "CbState";
            this.CbState.Size = new System.Drawing.Size(41, 21);
            this.CbState.TabIndex = 2;
            this.CbState.SelectedIndexChanged += new System.EventHandler(this.CbState_SelectedIndexChanged);
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(75, 54);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(28, 20);
            this.a.TabIndex = 4;
            this.a.TextChanged += new System.EventHandler(this.a_TextChanged_1);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(155, 54);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(28, 20);
            this.b.TabIndex = 5;
            this.b.TextChanged += new System.EventHandler(this.b_TextChanged);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(242, 54);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(28, 20);
            this.c.TabIndex = 6;
            this.c.TextChanged += new System.EventHandler(this.c_TextChanged);
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(326, 54);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(28, 20);
            this.d.TabIndex = 7;
            this.d.TextChanged += new System.EventHandler(this.d_TextChanged);
            // 
            // ee
            // 
            this.ee.Location = new System.Drawing.Point(405, 54);
            this.ee.Name = "ee";
            this.ee.Size = new System.Drawing.Size(28, 20);
            this.ee.TabIndex = 8;
            this.ee.TextChanged += new System.EventHandler(this.e_TextChanged);
            // 
            // f
            // 
            this.f.Location = new System.Drawing.Point(476, 54);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(28, 20);
            this.f.TabIndex = 9;
            this.f.TextChanged += new System.EventHandler(this.f_TextChanged);
            // 
            // x0
            // 
            this.x0.AutoSize = true;
            this.x0.Location = new System.Drawing.Point(114, 57);
            this.x0.Name = "x0";
            this.x0.Size = new System.Drawing.Size(33, 13);
            this.x0.TabIndex = 10;
            this.x0.Text = "x^5 +";
            this.x0.Click += new System.EventHandler(this.label4_Click);
            // 
            // x1
            // 
            this.x1.AutoSize = true;
            this.x1.Location = new System.Drawing.Point(200, 57);
            this.x1.Name = "x1";
            this.x1.Size = new System.Drawing.Size(33, 13);
            this.x1.TabIndex = 11;
            this.x1.Text = "x^4 +";
            // 
            // x2
            // 
            this.x2.AutoSize = true;
            this.x2.Location = new System.Drawing.Point(287, 57);
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(33, 13);
            this.x2.TabIndex = 12;
            this.x2.Text = "x^3 +";
            // 
            // x3
            // 
            this.x3.AutoSize = true;
            this.x3.Location = new System.Drawing.Point(368, 57);
            this.x3.Name = "x3";
            this.x3.Size = new System.Drawing.Size(33, 13);
            this.x3.TabIndex = 13;
            this.x3.Text = "x^2 +";
            // 
            // x4
            // 
            this.x4.AutoSize = true;
            this.x4.Location = new System.Drawing.Point(449, 57);
            this.x4.Name = "x4";
            this.x4.Size = new System.Drawing.Size(21, 13);
            this.x4.TabIndex = 14;
            this.x4.Text = "x +";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "= 0";
            // 
            // evaluateButton
            // 
            this.evaluateButton.Location = new System.Drawing.Point(75, 104);
            this.evaluateButton.Name = "evaluateButton";
            this.evaluateButton.Size = new System.Drawing.Size(75, 23);
            this.evaluateButton.TabIndex = 16;
            this.evaluateButton.Text = "Evaluate";
            this.evaluateButton.UseVisualStyleBackColor = true;
            this.evaluateButton.Click += new System.EventHandler(this.evaluateButton_Click);
            // 
            // RootOutput
            // 
            this.RootOutput.AutoSize = true;
            this.RootOutput.Location = new System.Drawing.Point(426, 128);
            this.RootOutput.Name = "RootOutput";
            this.RootOutput.Size = new System.Drawing.Size(38, 13);
            this.RootOutput.TabIndex = 17;
            this.RootOutput.Text = "Roots:";
            this.RootOutput.Click += new System.EventHandler(this.RootOutput_Click);
            // 
            // RootCheck
            // 
            this.RootCheck.AutoSize = true;
            this.RootCheck.Location = new System.Drawing.Point(426, 233);
            this.RootCheck.Name = "RootCheck";
            this.RootCheck.Size = new System.Drawing.Size(67, 13);
            this.RootCheck.TabIndex = 18;
            this.RootCheck.Text = "Root Check:";
            // 
            // clearSolution
            // 
            this.clearSolution.Location = new System.Drawing.Point(13, 13);
            this.clearSolution.Name = "clearSolution";
            this.clearSolution.Size = new System.Drawing.Size(137, 23);
            this.clearSolution.TabIndex = 19;
            this.clearSolution.Text = "Clear Solution";
            this.clearSolution.UseVisualStyleBackColor = true;
            this.clearSolution.Click += new System.EventHandler(this.clearSolution_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 416);
            this.Controls.Add(this.clearSolution);
            this.Controls.Add(this.RootCheck);
            this.Controls.Add(this.RootOutput);
            this.Controls.Add(this.evaluateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.x4);
            this.Controls.Add(this.x3);
            this.Controls.Add(this.x2);
            this.Controls.Add(this.x1);
            this.Controls.Add(this.x0);
            this.Controls.Add(this.f);
            this.Controls.Add(this.ee);
            this.Controls.Add(this.d);
            this.Controls.Add(this.c);
            this.Controls.Add(this.b);
            this.Controls.Add(this.a);
            this.Controls.Add(this.CbState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CbState;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.TextBox d;
        private System.Windows.Forms.TextBox ee;
        private System.Windows.Forms.TextBox f;
        private System.Windows.Forms.Label x0;
        private System.Windows.Forms.Label x1;
        private System.Windows.Forms.Label x2;
        private System.Windows.Forms.Label x3;
        private System.Windows.Forms.Label x4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button evaluateButton;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.Label RootOutput;
        private System.Windows.Forms.Label RootCheck;
        private System.Windows.Forms.Button clearSolution;
    }
}

