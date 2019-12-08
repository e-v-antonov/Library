namespace Library
{
    partial class PersonalCabinet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalCabinet));
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPatronymic = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbRepetPassword = new System.Windows.Forms.Label();
            this.pnCancel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.gbPersonalData = new System.Windows.Forms.GroupBox();
            this.tbPatronymic = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.gbAccountDetails = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbRepeatPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.pnCancel.SuspendLayout();
            this.gbPersonalData.SuspendLayout();
            this.gbAccountDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSurname
            // 
            resources.ApplyResources(this.lbSurname, "lbSurname");
            this.lbSurname.Name = "lbSurname";
            // 
            // lbName
            // 
            resources.ApplyResources(this.lbName, "lbName");
            this.lbName.Name = "lbName";
            // 
            // lbPatronymic
            // 
            resources.ApplyResources(this.lbPatronymic, "lbPatronymic");
            this.lbPatronymic.Name = "lbPatronymic";
            // 
            // lbLogin
            // 
            resources.ApplyResources(this.lbLogin, "lbLogin");
            this.lbLogin.Name = "lbLogin";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // lbRepetPassword
            // 
            resources.ApplyResources(this.lbRepetPassword, "lbRepetPassword");
            this.lbRepetPassword.Name = "lbRepetPassword";
            // 
            // pnCancel
            // 
            this.pnCancel.Controls.Add(this.btnExit);
            this.pnCancel.Controls.Add(this.btnError);
            resources.ApplyResources(this.pnCancel, "pnCancel");
            this.pnCancel.Name = "pnCancel";
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnError
            // 
            resources.ApplyResources(this.btnError, "btnError");
            this.btnError.Name = "btnError";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // gbPersonalData
            // 
            this.gbPersonalData.Controls.Add(this.tbPatronymic);
            this.gbPersonalData.Controls.Add(this.lbPatronymic);
            this.gbPersonalData.Controls.Add(this.tbName);
            this.gbPersonalData.Controls.Add(this.lbName);
            this.gbPersonalData.Controls.Add(this.tbSurname);
            this.gbPersonalData.Controls.Add(this.lbSurname);
            resources.ApplyResources(this.gbPersonalData, "gbPersonalData");
            this.gbPersonalData.Name = "gbPersonalData";
            this.gbPersonalData.TabStop = false;
            // 
            // tbPatronymic
            // 
            resources.ApplyResources(this.tbPatronymic, "tbPatronymic");
            this.tbPatronymic.Name = "tbPatronymic";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // tbSurname
            // 
            resources.ApplyResources(this.tbSurname, "tbSurname");
            this.tbSurname.Name = "tbSurname";
            // 
            // gbAccountDetails
            // 
            this.gbAccountDetails.Controls.Add(this.btnApply);
            this.gbAccountDetails.Controls.Add(this.tbRepeatPassword);
            this.gbAccountDetails.Controls.Add(this.lbRepetPassword);
            this.gbAccountDetails.Controls.Add(this.tbPassword);
            this.gbAccountDetails.Controls.Add(this.lbPassword);
            this.gbAccountDetails.Controls.Add(this.tbLogin);
            this.gbAccountDetails.Controls.Add(this.lbLogin);
            resources.ApplyResources(this.gbAccountDetails, "gbAccountDetails");
            this.gbAccountDetails.Name = "gbAccountDetails";
            this.gbAccountDetails.TabStop = false;
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbRepeatPassword
            // 
            resources.ApplyResources(this.tbRepeatPassword, "tbRepeatPassword");
            this.tbRepeatPassword.Name = "tbRepeatPassword";
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            // 
            // tbLogin
            // 
            resources.ApplyResources(this.tbLogin, "tbLogin");
            this.tbLogin.Name = "tbLogin";
            // 
            // PersonalCabinet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbAccountDetails);
            this.Controls.Add(this.gbPersonalData);
            this.Controls.Add(this.pnCancel);
            this.Name = "PersonalCabinet";
            this.Load += new System.EventHandler(this.PersonalCabinet_Load);
            this.pnCancel.ResumeLayout(false);
            this.gbPersonalData.ResumeLayout(false);
            this.gbPersonalData.PerformLayout();
            this.gbAccountDetails.ResumeLayout(false);
            this.gbAccountDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPatronymic;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbRepetPassword;
        private System.Windows.Forms.Panel pnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.GroupBox gbPersonalData;
        private System.Windows.Forms.GroupBox gbAccountDetails;
        private System.Windows.Forms.TextBox tbPatronymic;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.TextBox tbRepeatPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btnApply;
    }
}