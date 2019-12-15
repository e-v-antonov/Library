using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckLoginPassword;

namespace Library
{
    public partial class FeedbackForm : Form
    {
        private string rating = "5";
        private string constraintEmail = @"^.+@.+\..+$";

        public FeedbackForm()
        {
            InitializeComponent();
        }

        private void btnAttachment_Click(object sender, EventArgs e)    //прикрепление файла
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            SendMail.file.Add(openFileDialog.FileName);
        }

        private void btnSend_Click(object sender, EventArgs e)  //отправка сообщения
        {
            if (!Regex.IsMatch(tbEmail.Text, constraintEmail, RegexOptions.None))
            {
                MessageBox.Show(MessageUser.ErrorEmail, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SendMail sendMail = new SendMail(rtbComment.Text, tbEmail.Text, rating);
                sendMail.MySendMail();
                Close();
            }
        }

        private void rbOne_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                rating = radioButton.Text;
            }
        }
    }
}
