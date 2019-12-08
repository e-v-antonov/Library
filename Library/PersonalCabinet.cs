using CheckLoginPassword;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Library
{
    public partial class PersonalCabinet : Form
    {
        private SqlTableDependency<User> userDependency = new SqlTableDependency<User>(RegistryData.DBconstr);
        private SqlCommand commandCheckUniqueLoginUser = new SqlCommand("", RegistryData.DBConnectionString);
        private SqlCommand commandCheckUniquePasswordUser = new SqlCommand("", RegistryData.DBConnectionString);
        private DBStoredProcedure storedProcedure = new DBStoredProcedure();
        private int uniqueLogin = 0;
        private int uniquePassword = 0;
        private DBTables dbTablesForCheck = new DBTables();

        public PersonalCabinet()
        {
            InitializeComponent();
        }

        private void PersonalCabinet_Load(object sender, EventArgs e)   //загрузка формы
        {
            Thread threadPersonalData = new Thread(PersonalDataFill);
            threadPersonalData.Start();
        }

        private void PersonalDataFill() //загрузка данных
        {
            Action action = () =>
            {
                DBTables dbTables = new DBTables();

                dbTables.DTPersonalCabinet.Clear();
                userDependency.OnChanged += UserDependency_Changed;
                userDependency.Start();
                dbTables.DTPersonalCabinetFill();

                tbSurname.Text = dbTables.DTPersonalCabinet.Rows[0]["Surname_User"].ToString();
                tbName.Text = dbTables.DTPersonalCabinet.Rows[0]["Name_User"].ToString();
                tbPatronymic.Text = dbTables.DTPersonalCabinet.Rows[0]["Patronymic_User"].ToString();
                tbLogin.Text = dbTables.DTPersonalCabinet.Rows[0]["Column1"].ToString();
                tbPassword.Text = dbTables.DTPersonalCabinet.Rows[0]["Column2"].ToString();
                tbRepeatPassword.Text = tbPassword.Text;
            };
            Invoke(action);
        }

        private void UserDependency_Changed(object sender, RecordChangedEventArgs<User> e)  //автоматическое обновление данных
        {
            if (e.ChangeType != ChangeType.None)
            {
                PersonalDataFill();
            }
        }

        private bool CheckUniqueLogin() //проверка логина на уникальность
        {
            commandCheckUniqueLoginUser.CommandText = "select count(*) from [dbo].[User] where CONVERT([nvarchar] (16), DECRYPTBYKEY([Login_User])) = '" + 
                tbLogin.Text + "' and [ID_User] <> " + AuthorizationForm.UserID.ToString();

            try     
            {
                RegistryData.DBConnectionString.Open();
                dbTablesForCheck.CommandOpenKey.ExecuteNonQuery();
                uniqueLogin = Convert.ToInt32(commandCheckUniqueLoginUser.ExecuteScalar().ToString());
                dbTablesForCheck.CommandCloseKey.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RegistryData.DBConnectionString.Close();
            }

            if (uniqueLogin == 0)
                return true;
            else
            {
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + MessageUser.NoUniqueLogin;
                return false;
            }
        }

        private bool CheckUniquePassword()  //проверка пароля на уникальность
        {
            commandCheckUniquePasswordUser.CommandText = "select count(*) from [dbo].[User] where CONVERT([nvarchar] (16), DECRYPTBYKEY([Password_User])) = '" +
                tbPassword.Text + "' and [ID_User] <> " + AuthorizationForm.UserID.ToString();

            try
            {
                RegistryData.DBConnectionString.Open();
                dbTablesForCheck.CommandOpenKey.ExecuteNonQuery();
                uniquePassword = Convert.ToInt32(commandCheckUniquePasswordUser.ExecuteScalar().ToString());
                dbTablesForCheck.CommandCloseKey.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), MessageUser.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RegistryData.DBConnectionString.Close();
            }

            if (uniquePassword == 0)
                return true;
            else
            {
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + MessageUser.NoUniquePassword;
                return false;                
            }
        }

        private void btnApply_Click(object sender, EventArgs e) //применение изменений
        {
            switch (MessageBox.Show(MessageUser.ApplyChange, MessageUser.TitleLibrary, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    if ((tbLogin.TextLength >= 8) && (tbPassword.TextLength >= 8) && (tbPassword.Text == tbRepeatPassword.Text) &&
                        (CheckUniqueLogin() == true) && (CheckUniquePassword() == true) &&
                        (CheckClass.CheckPasswordUpperLatin(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerLatin(tbPassword.Text) == true) &&
                        (CheckClass.CheckPasswordUpperCyrill(tbPassword.Text) == true) && (CheckClass.CheckPasswordLowerCyrill(tbPassword.Text) == true) &&
                        (CheckClass.CheckPasswordNumber(tbPassword.Text) == true) && (CheckClass.CheckPasswordSymbol(tbPassword.Text) == true) &&
                        (CheckClass.CheckLoginCyrill(tbLogin.Text) == true))
                    {
                        storedProcedure.SPUserUpdate(AuthorizationForm.UserID, tbSurname.Text, tbName.Text, tbPatronymic.Text, tbLogin.Text, tbPassword.Text, AuthorizationForm.userRole);
                        AuthorizationForm.LoginUser = tbLogin.Text;
                        MessageBox.Show(MessageUser.GoodChange, MessageUser.TitleLibrary, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + MessageUser.CorrectLoginPassword;

                    PersonalDataFill();
                    break;

                case DialogResult.No:
                    Close();
                    break;
            }
        }

        private void btnError_Click(object sender, EventArgs e) //кнопка ошибки
        {
            MessageBox.Show(RegistryData.ErrorMessage, MessageUser.TitleError);
        }

        private void btnExit_Click(object sender, EventArgs e)  //кнопка выхода
        {
            Close();
        }
    }
}
