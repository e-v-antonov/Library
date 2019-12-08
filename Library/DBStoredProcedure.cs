using System;
using System.Data.SqlClient;

namespace Library
{
    class DBStoredProcedure
    {
        IniFiles iniFiles = new IniFiles();
        private SqlCommand storedProcedure = new SqlCommand("", RegistryData.DBConnectionString);  //добавить подключение к БД

        private void ConfigurationProcedure(string nameProcedure)   //задание названия процедуры
        {
            storedProcedure.CommandText = nameProcedure;
            storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public void SPRegistrationCardReaderInsert(string surnameReader, string nameReader, string patronymicReader, string birthdayReader, 
            string passportSeriesReader, string passportNumberReader, string whoGivePassportReader, string whenGivePassportReader, string townReader, 
            string streetReader, Int32 buildingReader, Int32 apartmentReader, string homePhoneReader, string mobilePhoneReader, string emailReader, 
            string registrationDateReader)  //добавление регистрационной карточки
        {
            ConfigurationProcedure("Registration_Card_Reader_Insert");

            storedProcedure.Parameters.AddWithValue("@Surname_Reader", surnameReader);
            storedProcedure.Parameters.AddWithValue("@Name_Reader", nameReader);
            storedProcedure.Parameters.AddWithValue("@Patronymic_Reader", patronymicReader);
            storedProcedure.Parameters.AddWithValue("@Birthday_Reader", birthdayReader);
            storedProcedure.Parameters.AddWithValue("@Passport_Series_Reader", passportSeriesReader);
            storedProcedure.Parameters.AddWithValue("@Passport_Number_Reader", passportNumberReader);
            storedProcedure.Parameters.AddWithValue("@Who_Give_Passport_Reader", whoGivePassportReader);
            storedProcedure.Parameters.AddWithValue("@When_Give_Passport_Reader", whenGivePassportReader);
            storedProcedure.Parameters.AddWithValue("@Town_Reader", townReader);
            storedProcedure.Parameters.AddWithValue("@Street_Reader", streetReader);
            storedProcedure.Parameters.AddWithValue("@Building_Reader", buildingReader);
            storedProcedure.Parameters.AddWithValue("@Apartment_Reader", apartmentReader);
            storedProcedure.Parameters.AddWithValue("@Home_Phone_Reader", homePhoneReader);
            storedProcedure.Parameters.AddWithValue("@Mobile_Phone_Reader", mobilePhoneReader);
            storedProcedure.Parameters.AddWithValue("@Email_Reader", emailReader);
            storedProcedure.Parameters.AddWithValue("@Registration_Date_Reader", registrationDateReader);

            ExecuteStoredProcedure("Insert record - Registration_Card_Reader");
        }

        public void SPRegistrationCardReaderUpdate(Int32 idRegistrationCardReader, string surnameReader, string nameReader, string patronymicReader, 
            string birthdayReader, string passportSeriesReader, string passportNumberReader, string whoGivePassportReader, string whenGivePassportReader, 
            string townReader, string streetReader, Int32 buildingReader, Int32 apartmentReader, string homePhoneReader, string mobilePhoneReader, 
            string emailReader)  //обновление регистрационной карточки
        {
            ConfigurationProcedure("Registration_Card_Reader_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Registration_Card_Reader", idRegistrationCardReader);
            storedProcedure.Parameters.AddWithValue("@Surname_Reader", surnameReader);
            storedProcedure.Parameters.AddWithValue("@Name_Reader", nameReader);
            storedProcedure.Parameters.AddWithValue("@Patronymic_Reader", patronymicReader);
            storedProcedure.Parameters.AddWithValue("@Birthday_Reader", birthdayReader);
            storedProcedure.Parameters.AddWithValue("@Passport_Series_Reader", passportSeriesReader);
            storedProcedure.Parameters.AddWithValue("@Passport_Number_Reader", passportNumberReader);
            storedProcedure.Parameters.AddWithValue("@Who_Give_Passport_Reader", whoGivePassportReader);
            storedProcedure.Parameters.AddWithValue("@When_Give_Passport_Reader", whenGivePassportReader);
            storedProcedure.Parameters.AddWithValue("@Town_Reader", townReader);
            storedProcedure.Parameters.AddWithValue("@Street_Reader", streetReader);
            storedProcedure.Parameters.AddWithValue("@Building_Reader", buildingReader);
            storedProcedure.Parameters.AddWithValue("@Apartment_Reader", apartmentReader);
            storedProcedure.Parameters.AddWithValue("@Home_Phone_Reader", homePhoneReader);
            storedProcedure.Parameters.AddWithValue("@Mobile_Phone_Reader", mobilePhoneReader);
            storedProcedure.Parameters.AddWithValue("@Email_Reader", emailReader);

            ExecuteStoredProcedure("Update record - Registration_Card_Reader");
        }

        public void SPRegistrationCardReaderDelete(Int32 idRegistrationCardReader)  //удаление регистрационной карточки
        {
            ConfigurationProcedure("Registration_Card_Reader_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Registration_Card_Reader", idRegistrationCardReader);

            ExecuteStoredProcedure("Delete record - Registration_Card_Reader");
        }

        public void SPRegistrationCardReaderLogicalDeletee(Int32 idRegistrationCardReader)  //логическое удаление регистрационной карточки
        {
            ConfigurationProcedure("Registration_Card_Reader_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Registration_Card_Reader", idRegistrationCardReader);

            ExecuteStoredProcedure("Logical Delete record - Registration_Card_Reader");
        }

        public void SPWriterBookInsert(string surnameWriter, string nameWriter, string patronymicWriter)    //добавление автора
        {
            ConfigurationProcedure("Writer_Book_Insert");

            storedProcedure.Parameters.AddWithValue("@Surname_Writer", surnameWriter);
            storedProcedure.Parameters.AddWithValue("@Name_Writer", nameWriter);
            storedProcedure.Parameters.AddWithValue("@Patronymic_Writer ", patronymicWriter);

            ExecuteStoredProcedure("Insert record - Writer_Book");
        }

        public void SPWriterBookUpdate(Int32 idWriter, string surnameWriter, string nameWriter, string patronymicWriter)    //обновление автора
        {
            ConfigurationProcedure("Writer_Book_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Writer", idWriter);
            storedProcedure.Parameters.AddWithValue("@Surname_Writer", surnameWriter);
            storedProcedure.Parameters.AddWithValue("@Name_Writer", nameWriter);
            storedProcedure.Parameters.AddWithValue("@Patronymic_Writer ", patronymicWriter);

            ExecuteStoredProcedure("Update record - Writer_Book");
        }

        public void SPWriterBookDelete(Int32 idWriter)  //удаление автора
        {
            ConfigurationProcedure("Writer_Book_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Writer", idWriter);

            ExecuteStoredProcedure("Delete record - Writer_Book");
        }

        public void SPWriterBookLogicalDeletee(Int32 idWriter)  //логическое удаление автора
        {
            ConfigurationProcedure("Writer_Book_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Writer", idWriter);

            ExecuteStoredProcedure("Logical Delete record - Writer_Book");
        }

        public void SPGenreBookInsert(string genre) //добавление жанра
        {
            ConfigurationProcedure("Genre_Book_Insert");

            storedProcedure.Parameters.AddWithValue("@Genre", genre);

            ExecuteStoredProcedure("Insert record - Genre_Book");
        }

        public void SPGenreBookUpdate(Int32 idGenre, string genre)  //обновление жанра
        {
            ConfigurationProcedure("Genre_Book_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Genre_Book", idGenre);
            storedProcedure.Parameters.AddWithValue("@Genre", genre);

            ExecuteStoredProcedure("Update record - Genre_Book");
        }

        public void SPGenreBookDelete(Int32 idGenre)    //удаление жанра
        {
            ConfigurationProcedure("Genre_Book_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Genre_Book", idGenre);

            ExecuteStoredProcedure("Delete record - Genre_Book");
        }

        public void SPGenreBookLogicalDelete(Int32 idGenre) //логическое удаление жанра
        {
            ConfigurationProcedure("Genre_Book_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Genre_Book", idGenre);

            ExecuteStoredProcedure("Logical Delete record - Genre_Book");
        }

        public void SPPublishingBookInsert(string publishing)   //добавление издательства
        {
            ConfigurationProcedure("Publishing_Book_Insert");

            storedProcedure.Parameters.AddWithValue("@Publishing", publishing);

            ExecuteStoredProcedure("Insert record - Publishing_Book");
        }

        public void SPPublishingBookUpdate(Int32 idPublishing, string publishing)   //обновление издательства
        {
            ConfigurationProcedure("Publishing_Book_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Publishing_Book", idPublishing);
            storedProcedure.Parameters.AddWithValue("@Publishing", publishing);

            ExecuteStoredProcedure("Update record - Publishing_Book");
        }

        public void SPPublishingBookDelete(Int32 idPublishing)  //удаление издательства
        {
            ConfigurationProcedure("Publishing_Book_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Publishing_Book", idPublishing);

            ExecuteStoredProcedure("Delete record - Publishing_Book");
        }

        public void SPPublishingBookLogicalDelete(Int32 idPublishing)   //логическое удаление издательства
        {
            ConfigurationProcedure("Publishing_Book_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Publishing_Book", idPublishing);

            ExecuteStoredProcedure("Logical Delete record - Publishing_Book");
        }

        public void SPBookInsert(string bookTitle, Int32 publicationDate, Int32 numberPages, string ISBNBook, Int32 costBook, Int32 totalNumberCopiesBook, 
            string dateAcceptanceBook, Int32 writerID, Int32 genreBookID, Int32 publishingBookID)  //добавление книги
        {
            ConfigurationProcedure("Book_Insert");

            storedProcedure.Parameters.AddWithValue("@Book_Title", bookTitle);
            storedProcedure.Parameters.AddWithValue("@Publication_Date", publicationDate);
            storedProcedure.Parameters.AddWithValue("@Number_Pages", numberPages);
            storedProcedure.Parameters.AddWithValue("@ISBN_Book", ISBNBook);
            storedProcedure.Parameters.AddWithValue("@Cost_Book", costBook);
            storedProcedure.Parameters.AddWithValue("@Total_Number_Copies_Book", totalNumberCopiesBook);
            storedProcedure.Parameters.AddWithValue("@Date_Acceptance_Book", dateAcceptanceBook);
            storedProcedure.Parameters.AddWithValue("@Writer_ID", writerID);
            storedProcedure.Parameters.AddWithValue("@Genre_Book_ID", genreBookID);
            storedProcedure.Parameters.AddWithValue("@Publishing_Book_ID", publishingBookID);

            ExecuteStoredProcedure("Insert record - Book");
        }

        public void SPBookUpdate(Int32 idBook, string bookTitle, Int32 publicationDate, Int32 numberPages, string ISBNBook, Int32 costBook, 
            Int32 totalNumberCopiesBook, string dateAcceptanceBook, Int32 writerID, Int32 genreBookID, Int32 publishingBookID)    //обновление книги
        {
            ConfigurationProcedure("Book_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Book", idBook);
            storedProcedure.Parameters.AddWithValue("@Book_Title", bookTitle);
            storedProcedure.Parameters.AddWithValue("@Publication_Date", publicationDate);
            storedProcedure.Parameters.AddWithValue("@Number_Pages", numberPages);
            storedProcedure.Parameters.AddWithValue("@ISBN_Book", ISBNBook);
            storedProcedure.Parameters.AddWithValue("@Cost_Book", costBook);
            storedProcedure.Parameters.AddWithValue("@Total_Number_Copies_Book", totalNumberCopiesBook);
            storedProcedure.Parameters.AddWithValue("@Date_Acceptance_Book", dateAcceptanceBook);
            storedProcedure.Parameters.AddWithValue("@Available_Number_Copies_Book ", totalNumberCopiesBook);
            storedProcedure.Parameters.AddWithValue("@Writer_ID", writerID);
            storedProcedure.Parameters.AddWithValue("@Genre_Book_ID", genreBookID);
            storedProcedure.Parameters.AddWithValue("@Publishing_Book_ID", publishingBookID);

            ExecuteStoredProcedure("Update record - Book");
        }

        public void SPBookDelete(Int32 idBook)  //удаление книги
        {
            ConfigurationProcedure("Book_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Book", idBook);

            ExecuteStoredProcedure("Delete record - Book");
        }

        public void SPBookLogicalDelete(Int32 idBook)   //логическое удаление книги
        {
            ConfigurationProcedure("Book_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Book", idBook);

            ExecuteStoredProcedure("Logical Delete record - Book");
        }

        public void SPFormularReaderInsert(string dateIssueBook, Int32 numberDaysIssueBook, Int32 registrationCardReaderID, Int32 bookID)    //добавление формуляра
        {
            ConfigurationProcedure("Formular_Reader_Insert");

            storedProcedure.Parameters.AddWithValue("@Date_Issue_Book", dateIssueBook);
            storedProcedure.Parameters.AddWithValue("@Number_Days_Issue_Book", numberDaysIssueBook);
            storedProcedure.Parameters.AddWithValue("@Registration_Card_Reader_ID", registrationCardReaderID);
            storedProcedure.Parameters.AddWithValue("@Book_ID", bookID);

            ExecuteStoredProcedure("Insert record - Formular_Reader");
        }

        public void SPFormularReaderUpdate(Int32 idFormularReader, string dateIssueBook, Int32 numberDaysIssueBook, Int32 bookReturned, Int32 registrationCardReaderID, Int32 bookID)    //обновление формуляра
        {
            ConfigurationProcedure("Formular_Reader_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Formular_Reader", idFormularReader);
            storedProcedure.Parameters.AddWithValue("@Date_Issue_Book", dateIssueBook);
            storedProcedure.Parameters.AddWithValue("@Number_Days_Issue_Book", numberDaysIssueBook);
            storedProcedure.Parameters.AddWithValue("@Book_Returned", bookReturned);
            storedProcedure.Parameters.AddWithValue("@Registration_Card_Reader_ID", registrationCardReaderID);
            storedProcedure.Parameters.AddWithValue("@Book_ID", bookID);

            ExecuteStoredProcedure("Update record - Formular_Reader");
        }

        public void SPFormularReaderDelete(Int32 idFormularReader)  //удаление формуляра
        {
            ConfigurationProcedure("Formular_Reader_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Formular_Reader", idFormularReader);

            ExecuteStoredProcedure("Delete record - Formular_Reader");
        }

        public void SPFormularReaderLogicalDelete(Int32 idFormularReader)   //логическое удаление формуляра
        {
            ConfigurationProcedure("Formular_Reader_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Formular_Reader", idFormularReader);

            ExecuteStoredProcedure("Logical Delete record - Formular_Reader");
        }

        public void SPRoleUserInsert(string roleName, UInt32 administratorUser, UInt32 guestUser, UInt32 directorUser, UInt32 bibliographerUser, UInt32 librarianUser)  //добавление роли
        {
            ConfigurationProcedure("Role_User_Insert");

            storedProcedure.Parameters.AddWithValue("@Role_Name", roleName);
            storedProcedure.Parameters.AddWithValue("@Administrator_User", administratorUser);
            storedProcedure.Parameters.AddWithValue("@Guest_User", guestUser);
            storedProcedure.Parameters.AddWithValue("@Director_User", directorUser);
            storedProcedure.Parameters.AddWithValue("@Bibliographer_User", bibliographerUser);
            storedProcedure.Parameters.AddWithValue("@Librarian_User", librarianUser);

            ExecuteStoredProcedure("Insert record - Role_User");
        }

        public void SPRoleUserUpdate(Int32 idRoleUser, string roleName, UInt32 administratorUser, UInt32 guestUser, UInt32 directorUser, UInt32 bibliographerUser, 
            UInt32 librarianUser)    //обновление роли
        {
            ConfigurationProcedure("Role_User_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Role_User", idRoleUser);
            storedProcedure.Parameters.AddWithValue("@Role_Name", roleName);
            storedProcedure.Parameters.AddWithValue("@Administrator_User", administratorUser);
            storedProcedure.Parameters.AddWithValue("@Guest_User", guestUser);
            storedProcedure.Parameters.AddWithValue("@Director_User", directorUser);
            storedProcedure.Parameters.AddWithValue("@Bibliographer_User", bibliographerUser);
            storedProcedure.Parameters.AddWithValue("@Librarian_User", librarianUser);

            ExecuteStoredProcedure("Update record - Role_User");
        }

        public void SRoleUserDelete(Int32 idRoleUser)   //удаление роли
        {
            ConfigurationProcedure("Role_User_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Role_User", idRoleUser);

            ExecuteStoredProcedure("Delete record - Role_User");
        }

        public void SRoleUserLogicalDelete(Int32 idRoleUser)    //логическое удаление роли
        {
            ConfigurationProcedure("Role_User_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_Role_User", idRoleUser);

            ExecuteStoredProcedure("Logical Delete record - Role_User");
        }

        public void SPUserInsert(string surnameUser, string nameUser, string patronymicUser, string loginUser, string passwordUser, Int32 roleUserID)   //добавление пользователя
        {
            ConfigurationProcedure("User_Insert");

            storedProcedure.Parameters.AddWithValue("@Surname_User", surnameUser);
            storedProcedure.Parameters.AddWithValue("@Name_User ", nameUser);
            storedProcedure.Parameters.AddWithValue("@Patronymic_User", patronymicUser);
            storedProcedure.Parameters.AddWithValue("@Login_User", loginUser);
            storedProcedure.Parameters.AddWithValue("@Password_User", passwordUser);
            storedProcedure.Parameters.AddWithValue("@Role_User_ID", roleUserID);

            ExecuteStoredProcedure("Insert record - User");
        }

        public void SPUserUpdate(Int32 idUser, string surnameUser, string nameUser, string patronymicUser, string loginUser, string passwordUser, Int32 roleUserID) //обновление пользователя
        {
            ConfigurationProcedure("User_Update");

            storedProcedure.Parameters.AddWithValue("@ID_User", idUser);
            storedProcedure.Parameters.AddWithValue("@Surname_User", surnameUser);
            storedProcedure.Parameters.AddWithValue("@Name_User ", nameUser);
            storedProcedure.Parameters.AddWithValue("@Patronymic_User", patronymicUser);
            storedProcedure.Parameters.AddWithValue("@Login_User", loginUser);
            storedProcedure.Parameters.AddWithValue("@Password_User", passwordUser);
            storedProcedure.Parameters.AddWithValue("@Role_User_ID", roleUserID);

            ExecuteStoredProcedure("Update record - User");
        }

        public void SPUserDelete(Int32 idUser)  //удаление пользователя
        {
            ConfigurationProcedure("User_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_User", idUser);

            ExecuteStoredProcedure("Delete record - User");
        }

        public void SPUserLogicalDelete(Int32 idUser)   //логическое удаление пользователя
        {
            ConfigurationProcedure("User_Logical_Delete");

            storedProcedure.Parameters.AddWithValue("@ID_User", idUser);

            ExecuteStoredProcedure("Logical Delete record - User");
        }

        public void SPFormularReturnBookUpdate(Int32 idFormularReader)   //логическое удаление пользователя
        {
            ConfigurationProcedure("Formular_Return_Book_Update");

            storedProcedure.Parameters.AddWithValue("@ID_Formular_Reader", idFormularReader);

            ExecuteStoredProcedure("Update record - Formular_Reader");
        }

        private void ExecuteStoredProcedure(string operation)   //выполнение процедуры
        {
            try
            {
                RegistryData.DBConnectionString.Open();
                RegistryData.DBConnectionString.InfoMessage += MessageInformation;
                storedProcedure.ExecuteNonQuery();
                storedProcedure.Parameters.Clear();
                iniFiles.Write(operation, AuthorizationForm.LoginUser + " " + DateTime.Now.ToString(), "Operation");
            }
            catch (SqlException ex)
            {
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + ex.Message;
                iniFiles.Write(ex.Message, AuthorizationForm.LoginUser + " " + DateTime.Now.ToString(), "Errors");
            }
            finally
            {
                RegistryData.DBConnectionString.Close();
            }
        }

        private void MessageInformation(object sender, SqlInfoMessageEventArgs e)   //информационное сообщение от SQL
        {
            RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + " " + e.Message;
            iniFiles.Write(e.Message, AuthorizationForm.LoginUser + " " + DateTime.Now.ToString(), "Errors");
        }
    }
}
