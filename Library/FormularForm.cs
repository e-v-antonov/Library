﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;


namespace Library
{
    public partial class FormularForm : Form
    {
        private SqlTableDependency<Formular_Reader> formularDependency = new SqlTableDependency<Formular_Reader>(RegistryData.DBconstr);
        private SqlTableDependency<Registration_Card_Reader> regCardDependency = new SqlTableDependency<Registration_Card_Reader>(RegistryData.DBconstr);
        private SqlTableDependency<Book> bookDependency = new SqlTableDependency<Book>(RegistryData.DBconstr);
        private DBStoredProcedure storedProcedure = new DBStoredProcedure();
        private SqlCommand commandSearchBook = new SqlCommand("", RegistryData.DBConnectionString);
        private DateTime dateIssue;
        private string issueBook = "";
        private string filterBook = "";

        public FormularForm()
        {
            InitializeComponent();
        }

        private void UpdateEnable(bool valueUpdateEnable)   //изменение доступности кнопок
        {
            btnInsert.Enabled = valueUpdateEnable;
            btnUpdate.Enabled = valueUpdateEnable;
            btnDelete.Enabled = valueUpdateEnable;
        }

        private void FormularForm_Load(object sender, EventArgs e)  //загрузка формы
        {
            Thread threadFormuar = new Thread(FormularFill);
            Thread threadReader = new Thread(ReaderFill);
            Thread threadBook = new Thread(BookFill); 

            threadFormuar.Start();
            threadReader.Start();
            threadBook.Start();
        }

        private void FormularFill() //заполнение data grid view данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                try
                {
                    dbTables.DTFormular.Clear();
                    dbTables.DTFormularFill();
                    formularDependency.OnChanged += FormularDependency_Changed;
                    formularDependency.Start();

                    filterBook = dbTables.QRFormular;

                    dgvFormular.DataSource = dbTables.DTFormular;
                    dgvFormular.Columns[0].Visible = false;
                    dgvFormular.Columns[1].Visible = false;
                    dgvFormular.Columns[2].HeaderText = MessageUser.ReaderFormular;
                    dgvFormular.Columns[3].HeaderText = MessageUser.PassportFormular;
                    dgvFormular.Columns[4].Visible = false;
                    dgvFormular.Columns[5].HeaderText = MessageUser.BookFormular;
                    dgvFormular.Columns[6].HeaderText = MessageUser.DateIssueBook;
                    dgvFormular.Columns[7].HeaderText = MessageUser.NumberDaysIssue;
                    dgvFormular.Columns[8].HeaderText = MessageUser.DateReturnedBook;
                    dgvFormular.Columns[9].HeaderText = MessageUser.BookReturned;
                    dgvFormular.ClearSelection();
                }
                catch
                {
                    MessageBox.Show(MessageUser.ErrorLoadingData, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Invoke(action);
        }

        private void FormularDependency_Changed(object sender, RecordChangedEventArgs<Formular_Reader> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                FormularFill();
            }
        }

        private void ReaderFill()    //заполнение combo box данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                try
                {
                    dbTables.DTRegistrationCard.Clear();
                    dbTables.DTReaderForComboBoxFill();
                    regCardDependency.OnChanged += RegCardDependency_Changed;
                    regCardDependency.Start();

                    cbReader.DataSource = dbTables.DTRegistrationCard;
                    cbReader.ValueMember = "ID_Registration_Card_Reader";
                    cbReader.DisplayMember = "Reader";
                    cbReader.SelectedValue = -1;
                }
                catch
                {
                    MessageBox.Show(MessageUser.ErrorLoadingData, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Invoke(action);
        }

        private void BookFill()  //заполнение combo box данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                try
                {
                    dbTables.DTBook.Clear();
                    dbTables.DTBookForComboBoxFill();
                    bookDependency.OnChanged += BookDependency_Changed;
                    bookDependency.Start();

                    cbBook.DataSource = dbTables.DTBook;
                    cbBook.ValueMember = "ID_Book";
                    cbBook.DisplayMember = "Book_Title";
                    cbBook.SelectedValue = -1;
                }
                catch
                {
                    MessageBox.Show(MessageUser.ErrorLoadingData, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            Invoke(action);
        }

        private void RegCardDependency_Changed(object sender, RecordChangedEventArgs<Registration_Card_Reader> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                ReaderFill();
            }
        }

        private void BookDependency_Changed(object sender, RecordChangedEventArgs<Book> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                BookFill();
            }
        }

        private void dgvFormular_CellClick(object sender, DataGridViewCellEventArgs e)  //клик по полю data grid view
        {
            dtpDateIssue.Value = Convert.ToDateTime(dgvFormular.CurrentRow.Cells[6].Value.ToString());
            nudNumberDays.Value = Convert.ToInt32(dgvFormular.CurrentRow.Cells[7].Value.ToString());
            tbDateReturn.Text = dgvFormular.CurrentRow.Cells[8].Value.ToString();
            if (dgvFormular.CurrentRow.Cells[9].Value.ToString() == "1")
                chbBookReturned.Checked = true;
            else
                chbBookReturned.Checked = false;
            cbReader.SelectedValue = dgvFormular.CurrentRow.Cells[1].Value.ToString();
            cbBook.SelectedValue = dgvFormular.CurrentRow.Cells[4].Value.ToString();
        }

        private void dtpDateIssue_ValueChanged(object sender, EventArgs e)  //изменение значения в date time picker
        {
            dateIssue = dtpDateIssue.Value;
            tbDateReturn.Text = dateIssue.AddDays(Convert.ToDouble(nudNumberDays.Value)).ToString("dd.MM.yyyy");
        }

        private void nudNumberDays_ValueChanged(object sender, EventArgs e) //изменение значения numeric up down
        {
            dtpDateIssue_ValueChanged(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)    //кнопка добавления записи
        {
            try
            {
                issueBook = dtpDateIssue.Value.ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show(MessageUser.WrongFormatDate, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (chbBookReturned.Checked == true)
                MessageBox.Show(MessageUser.BookNotReturned, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                storedProcedure.SPFormularReaderInsert(issueBook, Convert.ToInt32(nudNumberDays.Value), Convert.ToInt32(cbReader.SelectedValue.ToString()), Convert.ToInt32(cbBook.SelectedValue.ToString()));

            FormularFill();
            dtpDateIssue.Value = DateTime.Now;
            nudNumberDays.Value = 1;
            cbReader.SelectedValue = -1;
            cbBook.SelectedValue = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)      //кнопка изменения записи
        {
            try
            {
                issueBook = dtpDateIssue.Value.ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show(MessageUser.WrongFormatDate, MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int returnedBook = 0;
            if (chbBookReturned.Checked == true)
                returnedBook = 1;
            else
                returnedBook = 0;
                

            storedProcedure.SPFormularReaderUpdate(Convert.ToInt32(dgvFormular.CurrentRow.Cells[0].Value.ToString()), issueBook, Convert.ToInt32(nudNumberDays.Value), returnedBook, Convert.ToInt32(cbReader.SelectedValue.ToString()), Convert.ToInt32(cbBook.SelectedValue.ToString()));

            FormularFill();
            dtpDateIssue.Value = DateTime.Now;
            nudNumberDays.Value = 1;
            cbReader.SelectedValue = -1;
            cbBook.SelectedValue = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)       //кнопка удаления записи
        {
            switch (MessageBox.Show(MessageUser.QuestionDeleteFormular + " " + cbReader.Text + "?", MessageUser.DeleteEntryFormular, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    if (AuthorizationForm.userRole == 1)
                    {
                        storedProcedure.SPFormularReaderDelete(Convert.ToInt32(dgvFormular.CurrentRow.Cells[0].Value.ToString()));
                    }
                    else
                    {
                        storedProcedure.SPFormularReaderLogicalDelete(Convert.ToInt32(dgvFormular.CurrentRow.Cells[0].Value.ToString()));
                    }
                    FormularFill();
                    dtpDateIssue.Value = DateTime.Now;
                    nudNumberDays.Value = 1;
                    cbReader.SelectedValue = -1;
                    cbBook.SelectedValue = -1;
                    break;
            }
        }

        private void tbSearch_Click(object sender, EventArgs e) //клик по полю поиска
        {
            tbSearch.Clear();
        }

        private void tbSearch_Enter(object sender, EventArgs e) //поле поиска стало активным
        {
            if (tbSearch.Text == "" + tbSearch.Text + MessageUser.EnterDetailsBook)
                tbSearch.Clear();
        }

        private void tbSearch_Leave(object sender, EventArgs e) //поле поиска больше не в фокусе
        {
            if (tbSearch.Text == "")
                tbSearch.Text = "" + tbSearch.Text + MessageUser.EnterDetailsBook;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)   //введение текста в поле поиска
        {
            chbFiltration_CheckedChanged(sender, e);
        }

        private void chbFiltration_CheckedChanged(object sender, EventArgs e)   //изменение check box
        {
            switch (chbFiltration.CheckState)
            {
                case (CheckState.Checked):  //фильтрация
                    DataTable data = new DataTable("Book");
                    commandSearchBook.Notification = null;
                    commandSearchBook.CommandText = filterBook + " and [Date_Issue_Book] like '%" + tbSearch.Text
                        + "%' or [Number_Days_Issue_Book] like '%" + tbSearch.Text + "%' or [Date_Return_Book] like '%" + tbSearch.Text
                        + "%' or [Book_Returned] like '%" + tbSearch.Text + "%' or [dbo].[Book].[Book_Title] like '%" + tbSearch.Text
                        + "%' or [dbo].[Registration_Card_Reader].[Surname_Reader] like '%" + tbSearch.Text
                        + "%' or [dbo].[Registration_Card_Reader].[Name_Reader] like '%" + tbSearch.Text
                        + "%' or [dbo].[Registration_Card_Reader].[Patronymic_Reader] like '%" + tbSearch.Text
                        + "%' or CONVERT([nvarchar] (4), DECRYPTBYKEY([dbo].[Registration_Card_Reader].[Passport_Series_Reader])) like '%"
                        + tbSearch.Text + "%' or CONVERT([nvarchar] (6), DECRYPTBYKEY([dbo].[Registration_Card_Reader].[Passport_Number_Reader])) like '%"
                        + tbSearch.Text + "%'";

                    RegistryData.DBConnectionString.Open();
                    DBTables dbTables = new DBTables();
                    dbTables.CommandOpenKey.ExecuteNonQuery();
                    data.Load(commandSearchBook.ExecuteReader());
                    dbTables.CommandCloseKey.ExecuteNonQuery();
                    RegistryData.DBConnectionString.Close();

                    dgvFormular.DataSource = data;
                    dgvFormular.Columns[0].Visible = false;
                    dgvFormular.Columns[1].Visible = false;
                    dgvFormular.Columns[2].HeaderText = MessageUser.ReaderFormular;
                    dgvFormular.Columns[3].HeaderText = MessageUser.PassportFormular;
                    dgvFormular.Columns[4].Visible = false;
                    dgvFormular.Columns[5].HeaderText = MessageUser.BookFormular;
                    dgvFormular.Columns[6].HeaderText = MessageUser.DateIssueBook;
                    dgvFormular.Columns[7].HeaderText = MessageUser.NumberDaysIssue;
                    dgvFormular.Columns[8].HeaderText = MessageUser.DateReturnedBook;
                    dgvFormular.Columns[9].HeaderText = MessageUser.BookReturned;
                    dgvFormular.ClearSelection();
                    break;

                case (CheckState.Unchecked):    //поиск
                    FormularFill();

                    for (int i = 0; i < dgvFormular.RowCount; i++)
                    {
                        for (int j = 0; j < dgvFormular.ColumnCount; j++)
                        {
                            if (dgvFormular.Rows[i].Cells[j].Value != null)
                                if (dgvFormular.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                                {
                                    dgvFormular.Rows[i].Selected = true;
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        private void btnUpdateReader_Click(object sender, EventArgs e)  //открытие справочника регистрационные карточки
        {
            RegistrationCardForm registrationCardForm = new RegistrationCardForm();
            registrationCardForm.Show(this);
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)    //открытие справочника книги
        {
            BookForm bookForm = new BookForm();
            bookForm.Show(this);
        }

        private void btnError_Click(object sender, EventArgs e) //кнопка ошибки
        {
            MessageBox.Show(RegistryData.ErrorMessage, "Ошибки в результате работы информационной системы");
        }

        private void btnExit_Click(object sender, EventArgs e)  //кнопка закрыть
        {
            Close();
        }

        private void cbReader_DropDown(object sender, EventArgs e)  //открытие списка combo box
        {
            ReaderFill();
        }

        private void cbBook_DropDown(object sender, EventArgs e)    //открытие списка combo box
        {
            BookFill();
        }

        private void dgvFormular_Click(object sender, EventArgs e)  //клик по полю data grid view
        {
            //FormularFill();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)   //принудительное обновление данных на форме
        {
            FormularFill();
            ReaderFill();
            BookFill();
        }

        private void FormularForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

    public class Formular_Reader
    {
        public int ID_Formular_Reader { get; set; }
        public DateTime Date_Issue_Book { get; set; }
        public int Number_Days_Issue_Book { get; set; }
        public DateTime Date_Return_Book { get; set; }
        public int Book_Returned { get; set; }
        public int Registration_Card_Reader_ID { get; set; }
        public int Book_ID { get; set; }
        public int Formular_Reader_Logical_Delete { get; set; }
    }   
}
