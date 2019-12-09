namespace Library
{
    partial class FeedbackForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackForm));
            this.gbRatingApplication = new System.Windows.Forms.GroupBox();
            this.rbFive = new System.Windows.Forms.RadioButton();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.rbThree = new System.Windows.Forms.RadioButton();
            this.rbTwo = new System.Windows.Forms.RadioButton();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.lbDescriptionRating = new System.Windows.Forms.Label();
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.pnFoot = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAttachment = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbRatingApplication.SuspendLayout();
            this.gbComment.SuspendLayout();
            this.gbEmail.SuspendLayout();
            this.pnFoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRatingApplication
            // 
            this.gbRatingApplication.Controls.Add(this.rbFive);
            this.gbRatingApplication.Controls.Add(this.rbFour);
            this.gbRatingApplication.Controls.Add(this.rbThree);
            this.gbRatingApplication.Controls.Add(this.rbTwo);
            this.gbRatingApplication.Controls.Add(this.rbOne);
            this.gbRatingApplication.Controls.Add(this.lbDescriptionRating);
            resources.ApplyResources(this.gbRatingApplication, "gbRatingApplication");
            this.gbRatingApplication.Name = "gbRatingApplication";
            this.gbRatingApplication.TabStop = false;
            // 
            // rbFive
            // 
            resources.ApplyResources(this.rbFive, "rbFive");
            this.rbFive.Checked = true;
            this.rbFive.Name = "rbFive";
            this.rbFive.TabStop = true;
            this.rbFive.UseVisualStyleBackColor = true;
            this.rbFive.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // rbFour
            // 
            resources.ApplyResources(this.rbFour, "rbFour");
            this.rbFour.Name = "rbFour";
            this.rbFour.UseVisualStyleBackColor = true;
            this.rbFour.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // rbThree
            // 
            resources.ApplyResources(this.rbThree, "rbThree");
            this.rbThree.Name = "rbThree";
            this.rbThree.UseVisualStyleBackColor = true;
            this.rbThree.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // rbTwo
            // 
            resources.ApplyResources(this.rbTwo, "rbTwo");
            this.rbTwo.Name = "rbTwo";
            this.rbTwo.UseVisualStyleBackColor = true;
            this.rbTwo.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // rbOne
            // 
            resources.ApplyResources(this.rbOne, "rbOne");
            this.rbOne.Name = "rbOne";
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.CheckedChanged += new System.EventHandler(this.rbOne_CheckedChanged);
            // 
            // lbDescriptionRating
            // 
            resources.ApplyResources(this.lbDescriptionRating, "lbDescriptionRating");
            this.lbDescriptionRating.Name = "lbDescriptionRating";
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.rtbComment);
            this.gbComment.Controls.Add(this.label1);
            resources.ApplyResources(this.gbComment, "gbComment");
            this.gbComment.Name = "gbComment";
            this.gbComment.TabStop = false;
            // 
            // rtbComment
            // 
            resources.ApplyResources(this.rtbComment, "rtbComment");
            this.rtbComment.Name = "rtbComment";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.tbEmail);
            this.gbEmail.Controls.Add(this.lbEmail);
            resources.ApplyResources(this.gbEmail, "gbEmail");
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.TabStop = false;
            // 
            // tbEmail
            // 
            resources.ApplyResources(this.tbEmail, "tbEmail");
            this.tbEmail.Name = "tbEmail";
            // 
            // lbEmail
            // 
            resources.ApplyResources(this.lbEmail, "lbEmail");
            this.lbEmail.Name = "lbEmail";
            // 
            // pnFoot
            // 
            this.pnFoot.Controls.Add(this.btnSend);
            this.pnFoot.Controls.Add(this.btnAttachment);
            resources.ApplyResources(this.pnFoot, "pnFoot");
            this.pnFoot.Name = "pnFoot";
            // 
            // btnSend
            // 
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAttachment
            // 
            resources.ApplyResources(this.btnAttachment, "btnAttachment");
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // FeedbackForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnFoot);
            this.Controls.Add(this.gbComment);
            this.Controls.Add(this.gbRatingApplication);
            this.Controls.Add(this.gbEmail);
            this.Name = "FeedbackForm";
            this.gbRatingApplication.ResumeLayout(false);
            this.gbRatingApplication.PerformLayout();
            this.gbComment.ResumeLayout(false);
            this.gbEmail.ResumeLayout(false);
            this.gbEmail.PerformLayout();
            this.pnFoot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRatingApplication;
        private System.Windows.Forms.RadioButton rbFive;
        private System.Windows.Forms.RadioButton rbFour;
        private System.Windows.Forms.RadioButton rbThree;
        private System.Windows.Forms.RadioButton rbTwo;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.Label lbDescriptionRating;
        private System.Windows.Forms.GroupBox gbComment;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Panel pnFoot;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAttachment;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}