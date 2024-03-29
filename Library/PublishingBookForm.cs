﻿using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Library
{
    public partial class PublishingBookForm : Form
    {
        private SqlTableDependency<Publishing_Book> publishingDependency = new SqlTableDependency<Publishing_Book>(RegistryData.DBconstr);
        private DBStoredProcedure storedProcedure = new DBStoredProcedure();

        public PublishingBookForm()
        {
            InitializeComponent();
        }

        private void UpdateEnable(bool valueUpdateEnable)   //изменение доступности кнопок
        {
            btnInsert.Enabled = valueUpdateEnable;
            btnUpdate.Enabled = valueUpdateEnable;
            btnDelete.Enabled = valueUpdateEnable;
        }

        private void PublishingBookForm_Load(object sender, EventArgs e)    //загрузка формы
        {
            Thread threadPublishing = new Thread(PublishingBookFill);
            threadPublishing.Start();
        }

        private void PublishingBookFill() //заполнение combo box данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTPublishing.Clear();
                dbTables.DTPublishingFill();
                publishingDependency.OnChanged += PublishingDependency_Changed;
                publishingDependency.Start();

                ltbPublishing.DataSource = dbTables.DTPublishing;
                ltbPublishing.ValueMember = "ID_Publishing_Book";
                ltbPublishing.DisplayMember = "Publishing";
            };
            Invoke(action);
        }

        private void PublishingDependency_Changed(object sender, RecordChangedEventArgs<Publishing_Book> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                PublishingBookFill();
            }
        }

        private void ltbPublishing_Click(object sender, EventArgs e)    //клик по записи в combo box
        {
            tbPublishing.Text = ltbPublishing.Text;
        }

        private void ltbPublishing_SelectedIndexChanged(object sender, EventArgs e)  //выбор записи в combo box
        {
            tbPublishing.Text = ltbPublishing.Text;
        }

        private void btnInsert_Click(object sender, EventArgs e)      //кнопка добавления записи
        {
            storedProcedure.SPPublishingBookInsert(tbPublishing.Text);
            tbPublishing.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)    //кнопка изменения записи
        {
            storedProcedure.SPPublishingBookUpdate(Convert.ToInt32(ltbPublishing.SelectedValue.ToString()), tbPublishing.Text);
            tbPublishing.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)    //кнопка удаления записи
        {
            switch (MessageBox.Show(MessageUser.QuestionDeletePublishing + " " + ltbPublishing.Text + "?", MessageUser.DeletePublishing, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    if (AuthorizationForm.userRole == 1)
                    {
                        storedProcedure.SPPublishingBookDelete(Convert.ToInt32(ltbPublishing.SelectedValue.ToString()));
                    }
                    else
                    {
                        storedProcedure.SPPublishingBookLogicalDelete(Convert.ToInt32(ltbPublishing.SelectedValue.ToString()));
                    }
                    break;
            }
        }

        private void btnError_Click(object sender, EventArgs e) //кнопка ошибки
        {
            MessageBox.Show(RegistryData.ErrorMessage, MessageUser.TitleError);
        }

        private void btnExit_Click(object sender, EventArgs e)   //кнопка закрытия окна
        {
            Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)   //введение текста в поле поиска
        {
            ltbPublishing.SelectedIndex = ltbPublishing.FindString(tbSearch.Text);
            ltbPublishing_Click(sender, e);
        }

        private void tbSearch_Leave(object sender, EventArgs e) //поле поиска больше не в фокусе
        {
            if (tbPublishing.Text == "")
                tbPublishing.Text = MessageUser.EnterPublishing;
        }

        private void tbSearch_Enter(object sender, EventArgs e) //поле поиска стало активным
        {
            if (tbPublishing.Text == MessageUser.EnterPublishing)
                tbPublishing.Clear();
        }

        private void tbSearch_Click(object sender, EventArgs e) //клик по полю поиска
        {
            tbSearch.Clear();
        }

        private void PublishingBookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            publishingDependency.Stop();
            publishingDependency.OnChanged += null;
        }
    }

    public class Publishing_Book
    {
        public int ID_Publishing_Book { get; set; }
        public string Publishing { get; set; }
        public int Publishing_Book_Logical_Delete { get; set; }
    }
}
