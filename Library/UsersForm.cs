using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using CheckLoginPassword;

namespace Library
{
    public partial class UsersForm : Form
    {
        private SqlTableDependency<User> userDependency = new SqlTableDependency<User>(RegistryData.DBconstr);
        private SqlTableDependency<Role_User> roleUserDependency = new SqlTableDependency<Role_User>(RegistryData.DBconstr);
        private DBStoredProcedure storedProcedure = new DBStoredProcedure();
        private SqlCommand commandSearchUser = new SqlCommand("", RegistryData.DBConnectionString);
        private string filterUser = "";
        private bool uniquePassword = false;
        private bool uniqueLogin = false;

        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e) //загрузка формы
        {
            Thread threadUser = new Thread(UserFill);
            Thread threadRoleUser = new Thread(RoleUserFill);
            threadUser.Start();
            threadRoleUser.Start();
        }

        private void UserFill() //заполнение data grid view данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTUsers.Clear();
                dbTables.DTUsersFill();
                userDependency.OnChanged += UserDependency_Changed;
                userDependency.Start();

                filterUser = dbTables.QRUsers;

                dgvUsers.DataSource = dbTables.DTUsers;
                dgvUsers.Columns[0].Visible = false;
                dgvUsers.Columns[1].HeaderText = MessageUser.Surname;
                dgvUsers.Columns[2].HeaderText = MessageUser.Name;
                dgvUsers.Columns[3].HeaderText = MessageUser.Patronymic;
                dgvUsers.Columns[4].HeaderText = MessageUser.Login;
                dgvUsers.Columns[5].HeaderText = MessageUser.Password;
                dgvUsers.Columns[6].Visible = false;
                dgvUsers.Columns[7].HeaderText = MessageUser.Post;
                dgvUsers.ClearSelection();
            };
            Invoke(action);
        }

        private void UserDependency_Changed(object sender, RecordChangedEventArgs<User> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                UserFill();
            }
        }

        private void RoleUserFill() //заполнение combo box данными из базы данных
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTRoleUser.Clear();
                dbTables.DTRoleUserForComboBox();
                roleUserDependency.OnChanged += RoleUserDependency_Changed;
                roleUserDependency.Start();

                cbRole.DataSource = dbTables.DTRoleUser;
                cbRole.ValueMember = "ID_Role_User";
                cbRole.DisplayMember = "Role_Name";
            };
            Invoke(action);
        }

        private void RoleUserDependency_Changed(object sender, RecordChangedEventArgs<Role_User> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                RoleUserFill();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)  //клик по полю data grid view
        {
            tbSurname.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            tbName.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            tbPatronymic.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            tbLogin.Text = dgvUsers.CurrentRow.Cells[4].Value.ToString();
            tbPassword.Text = dgvUsers.CurrentRow.Cells[5].Value.ToString();
            cbRole.SelectedValue = dgvUsers.CurrentRow.Cells[6].Value.ToString();
        }

        private bool CheckUniqueLogin(Button button)    //проверка уникальности логина
        {
            int currentRow = 0;

            if (button.Name == "btnUpdate") //если это апдейт
                currentRow = dgvUsers.CurrentCell.RowIndex;
            else
                currentRow = -1;

            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                if (i == currentRow)    //если равняется номеру строки
                    continue;   //пропускаем
                else  //иначе
                    if ((tbLogin.Text) == (dgvUsers.Rows[i].Cells[4].Value.ToString())) //если логин равняется 
                    {
                        uniqueLogin = false;
                        return uniqueLogin;
                    }
                else
                    uniqueLogin = true;
            }

            return uniqueLogin;
        }

        private bool CheckUniquePassword(Button button) //проверка уникальности пароля
        {
            int currentRow = 0;

            if (button.Name == "btnUpdate")
                currentRow = dgvUsers.CurrentCell.RowIndex;
            else
                currentRow = -1;

            for (int i = 0; i < dgvUsers.RowCount; i++)
            {
                if (i == currentRow)
                    continue;
                else
                    if ((tbPassword.Text) == (dgvUsers.Rows[i].Cells[5].Value.ToString()))
                    {
                        uniquePassword = false;
                        return uniquePassword;
                    }
                    else
                        uniquePassword = true;
            }

            return uniquePassword;
        }

        private void btnInsert_Click(object sender, EventArgs e)    //кнопка добавления записи
        {
            var nameButton = sender as Button;

            if ((tbLogin.TextLength >= 8) && (tbPassword.TextLength >= 8) && (CheckUniqueLogin(nameButton) == true) && 
                (CheckUniquePassword(nameButton) == true) && (tbPassword.Text == tbRepeatPassword.Text) && 
                (CheckClass.CheckPasswordUpperLatin(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerLatin(tbPassword.Text) == true) && 
                (CheckClass.CheckPasswordUpperCyrill(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerCyrill(tbPassword.Text) == true) && 
                (CheckClass.CheckPasswordNumber(tbPassword.Text) == true) && (CheckClass.CheckPasswordSymbol(tbPassword.Text) == true) && 
                (CheckClass.CheckLoginCyrill(tbLogin.Text) == false))
                    storedProcedure.SPUserInsert(tbSurname.Text, tbName.Text, tbPatronymic.Text, tbLogin.Text, tbPassword.Text, Convert.ToInt32(cbRole.SelectedValue.ToString()));
            else
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + MessageUser.CorrectLoginPassword;

            UserFill();
        }

        private void btnUpdate_Click(object sender, EventArgs e)    //кнопка изменения записи
        {
            var nameButton = sender as Button;

            if ((tbLogin.TextLength >= 8) && (tbPassword.TextLength >= 8) && (CheckUniqueLogin(nameButton) == true) && 
                (CheckUniquePassword(nameButton) == true) && (tbPassword.Text == tbRepeatPassword.Text) &&
                (CheckClass.CheckPasswordUpperLatin(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerLatin(tbPassword.Text) == true) &&
                (CheckClass.CheckPasswordUpperCyrill(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerCyrill(tbPassword.Text) == true) &&
                (CheckClass.CheckPasswordNumber(tbPassword.Text) == true) && (CheckClass.CheckPasswordSymbol(tbPassword.Text) == true) &&
                (CheckClass.CheckLoginCyrill(tbLogin.Text) == false))
                    storedProcedure.SPUserUpdate(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString()), tbSurname.Text, tbName.Text, tbPatronymic.Text, tbLogin.Text, tbPassword.Text, Convert.ToInt32(cbRole.SelectedValue.ToString()));
            else
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + MessageUser.CorrectLoginPassword;

            UserFill();
        }

        private void btnDelete_Click(object sender, EventArgs e)    //кнопка удаления записи
        {
            switch (MessageBox.Show(MessageUser.QuestionDeleteUser + " " + tbSurname.Text + " " + tbName.Text + " " + tbPatronymic.Text + "?", MessageUser.DeleteUser, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    storedProcedure.SPUserDelete(Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value.ToString()));
                    dgvUsers.ClearSelection();
                    tbSurname.Clear();
                    tbName.Clear();
                    tbPatronymic.Clear();
                    tbPassword.Clear();
                    tbLogin.Clear();
                    tbRepeatPassword.Clear();
                    cbRole.SelectedValue = -1;
                    UserFill();
                    break;
            }
        }

        private void tbSearch_Click(object sender, EventArgs e) //клик по полю поиска
        {
            tbSearch.Clear();
        }

        private void tbSearch_Leave(object sender, EventArgs e) //поле поиска больше не в фокусе
        {
            if (tbSearch.Text == "")
                tbSearch.Text = MessageUser.EnterDataUser;
        }

        private void tbSearch_Enter(object sender, EventArgs e) //клик по полю поиска
        {
            if (tbSearch.Text == MessageUser.EnterDataUser)
                tbSearch.Clear();
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
                    DataTable data = new DataTable("User");
                    commandSearchUser.CommandText = filterUser + " and [Surname_User] like '%" + tbSearch.Text + "%' or [Name_User] like '%" + 
                        tbSearch.Text + "%' or [Patronymic_User] like '%" + tbSearch.Text + "%' or [Login_User] like '%" + tbSearch.Text + 
                        "%' or [Password_User] like '%" + tbSearch.Text + "%' or [Role_Name] like '%" + tbSearch.Text + "%'";
                    RegistryData.DBConnectionString.Open();
                    DBTables dbTables = new DBTables();
                    dbTables.CommandOpenKey.ExecuteNonQuery();
                    data.Load(commandSearchUser.ExecuteReader());
                    dbTables.CommandCloseKey.ExecuteNonQuery();
                    RegistryData.DBConnectionString.Close();

                    dgvUsers.DataSource = data;
                    dgvUsers.Columns[0].Visible = false;
                    dgvUsers.Columns[1].HeaderText = MessageUser.Surname;
                    dgvUsers.Columns[2].HeaderText = MessageUser.Name;
                    dgvUsers.Columns[3].HeaderText = MessageUser.Patronymic;
                    dgvUsers.Columns[4].HeaderText = MessageUser.Login;
                    dgvUsers.Columns[5].HeaderText = MessageUser.Password;
                    dgvUsers.Columns[6].Visible = false;
                    dgvUsers.Columns[7].HeaderText = MessageUser.Post;
                    dgvUsers.ClearSelection();
                    break;

                case (CheckState.Unchecked):    //поиск
                    UserFill();

                    for (int i = 0; i < dgvUsers.RowCount; i++)
                    {
                        for (int j = 0; j < dgvUsers.ColumnCount; j++)
                        {
                            if (dgvUsers.Rows[i].Cells[j].Value != null)
                                if (dgvUsers.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                                {
                                    dgvUsers.Rows[i].Selected = true;
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        private void btnError_Click(object sender, EventArgs e) //кнопка ошибок
        {
            MessageBox.Show(RegistryData.ErrorMessage, MessageUser.TitleError);
        }

        private void btnExit_Click(object sender, EventArgs e)  //кнопка закрыть
        {
            Close();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)   //принудительное обновление данных на форме
        {
            UserFill();
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userDependency.Stop();
            roleUserDependency.Stop();
            userDependency.OnChanged += null;
            roleUserDependency.OnChanged += null;
        }
    }

    public class User
    {
        public int ID_User { get; set; }
        public string Surname_User { get; set; }
        public string Name_User { get; set; }
        public string Patronymic_User { get; set; }
        public string Login_User { get; set; }
        public string Password_User { get; set; }
        public int Role_User_ID { get; set; }
        public int User_Logical_Delete { get; set; }
    }

    public class Role_User
    {
        public int ID_Role_User { get; set; }
        public string Role_Name { get; set; }
        public int Administrator_User { get; set; }
        public int Guest_User { get; set; }
        public int Director_User { get; set; }
        public int Bibliographer_User { get; set; }
        public int Librarian_User { get; set; }
        public int Role_User_Logical_Delete { get; set; }
    }
}
