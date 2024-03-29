﻿using System;
using System.Data;
using System.Data.SqlClient;
using TableDependency.SqlClient;

namespace Library
{
    class DBTables
    {
        public SqlCommand command = new SqlCommand("", RegistryData.DBConnectionString);
        public DataTable DTGenre = new DataTable("Genre");
        public DataTable DTPublishing = new DataTable("Publishing");
        public DataTable DTWriterBook = new DataTable("Writer_Book");
        public DataTable DTBook = new DataTable("Book");
        public DataTable DTRegistrationCard = new DataTable("Registration_Card_Reader");
        public DataTable DTFormular = new DataTable("Formular_Reader");
        public DataTable DTUsers = new DataTable("User");
        public DataTable DTRoleUser = new DataTable("Role_User");
        public DataTable DTListBookForAct= new DataTable("List_Book_For_Act");
        public DataTable DTInvenoryBook = new DataTable("Inventory_Book");
        public DataTable DTSummaryBook = new DataTable("Summary_Book");
        public DataTable DTPersonalCabinet = new DataTable("Personal Cabinet");
        public DataTable DTStatisticsBookReturned = new DataTable("StatisticsBookReturned");
        public DataTable DTStatisticsAgeReader = new DataTable("StatisticsAgeReader");
        public DataTable DTStatisticsPublicationDate = new DataTable("StatisticsPublicationDate");
        public DataTable DTStatisticsWriterBook = new DataTable("StatisticsWriterBook");
        public string QRGenre = "select [ID_Genre_Book], [Genre] from [dbo].[Genre_Book] where [Genre_Book_Logical_Delete] = 0";
        public string QRPublishing = "select [ID_Publishing_Book],[Publishing] from [dbo].[Publishing_Book] where [Publishing_Book_Logical_Delete] = 0";
        public string QRWriterBook = "select [ID_Writer], [Surname_Writer], [Name_Writer], [Patronymic_Writer]  from [dbo].[Writer_Book] where [Writer_Book_Logical_Delete] = 0";
        public string QRBook = "select [ID_Book], [Book_Title], [Writer_ID], [Surname_Writer] + ' ' + [Name_Writer] + ' ' + [Patronymic_Writer] as \"FIO_Writer\", " +
            "[Genre_Book_ID], [Genre], [Publishing_Book_ID], [Publishing], [Publication_Date], [Number_Pages], [ISBN_Book], [Cost_Book], " +
            "[Total_Number_Copies_Book], [Available_Number_Copies_Book], CONVERT([varchar] (10), [Date_Acceptance_Book], 104) from [dbo].[Book] " +
            "inner join [dbo].[Writer_Book] on [dbo].[Book].[Writer_ID] = [dbo].[Writer_Book].[ID_Writer] inner join [dbo].[Genre_Book] on " +
            "[dbo].[Book].[Genre_Book_ID] = [dbo].[Genre_Book].[ID_Genre_Book] inner join [dbo].[Publishing_Book] on" +
            " [dbo].[Book].[Publishing_Book_ID] = [dbo].[Publishing_Book].[ID_Publishing_Book] where [Book_Logical_Delete] = 0 and " +
            "[Genre_Book_Logical_Delete] = 0 and [Publishing_Book_Logical_Delete] = 0 and [Writer_Book_Logical_Delete] = 0";
        private string QRWriterForComboBox = "select [ID_Writer], [Surname_Writer] + ' ' + [Name_Writer] + ' ' + [Patronymic_Writer] as \"FIO_Writer\" from [dbo].[Writer_Book] where [Writer_Book_Logical_Delete] = 0";
        public string QRRegistrationCard = "select [ID_Registration_Card_Reader], [Surname_Reader], [Name_Reader], [Patronymic_Reader], " +
            "CONVERT([varchar] (10), [Birthday_Reader], 104), CONVERT([nvarchar] (4), DECRYPTBYKEY([Passport_Series_Reader])), " +
            "CONVERT([nvarchar] (6), DECRYPTBYKEY([Passport_Number_Reader])), [Who_Give_Passport_Reader], CONVERT([varchar] (10), " +
            "[When_Give_Passport_Reader], 104), [Town_Reader], CONVERT([nvarchar] (50), DECRYPTBYKEY([Street_Reader])), [Building_Reader]," +
            "[Apartment_Reader], CONVERT([nvarchar] (15), DECRYPTBYKEY([Home_Phone_Reader])), CONVERT([nvarchar] (15), " +
            "DECRYPTBYKEY([Mobile_Phone_Reader])), CONVERT([nvarchar] (129), DECRYPTBYKEY([Email_Reader])), [Book_On_Hand_Reader], CONVERT([varchar] (10), [Registration_Date_Reader], 104) from " +
            "[dbo].[Registration_Card_Reader] where [Registration_Card_Reader_Logical_Delete] = 0";
        public string QRFormular = "select[ID_Formular_Reader], [ID_Registration_Card_Reader], [Surname_Reader] + ' ' + [Name_Reader] + ' ' + " +
            "[Patronymic_Reader], CONVERT([nvarchar] (4), DECRYPTBYKEY([Passport_Series_Reader])) + ' ' + CONVERT([nvarchar] (6), " +
            "DECRYPTBYKEY([Passport_Number_Reader])), [ID_Book], [Book_Title], CONVERT([varchar] (10), [Date_Issue_Book], 104), " +
            "[Number_Days_Issue_Book], CONVERT([varchar] (10), [Date_Return_Book], 104), [Book_Returned] from [dbo].[Formular_Reader] " +
            "inner join [dbo].[Registration_Card_Reader] on [dbo].[Formular_Reader].[Registration_Card_Reader_ID] = " +
            "[dbo].[Registration_Card_Reader].[ID_Registration_Card_Reader] inner join [dbo].[Book] on [dbo].[Formular_Reader].[Book_ID] = " +
            "[dbo].[Book].[ID_Book] where [Formular_Reader_Logical_Delete] = 0 and [Registration_Card_Reader_Logical_Delete] = 0 and " +
            "[Book_Logical_Delete] = 0";
        public SqlCommand CommandOpenKey = new SqlCommand("Open_Symmetric_Key", RegistryData.DBConnectionString);
        public SqlCommand CommandCloseKey = new SqlCommand("Close_Symmetric_Key", RegistryData.DBConnectionString);
        private string QRBookForComboBox = "select [ID_Book], [Book_Title] from [dbo].[Book] where [Book_Logical_Delete] = 0";
        private string QRReaderForComboBox = "select [ID_Registration_Card_Reader], [Surname_Reader] + ' ' + [Name_Reader] + ' ' + " +
            "[Patronymic_Reader] + ', ' +  CONVERT([nvarchar] (4), DECRYPTBYKEY([Passport_Series_Reader])) + ' ' + CONVERT([nvarchar] (6), " +
            "DECRYPTBYKEY([Passport_Number_Reader])) as \"Reader\" from [dbo].[Registration_Card_Reader] where [Registration_Card_Reader_Logical_Delete] = 0";
        public string QRUsers = "select [ID_User], [Surname_User], [Name_User], [Patronymic_User], CONVERT([nvarchar] (16), " +
            "DECRYPTBYKEY([Login_User])), CONVERT([nvarchar] (16), DECRYPTBYKEY([Password_User])), [ID_Role_User], [Role_Name] from [dbo].[User] inner join " +
            "[dbo].[Role_User] on [Role_User_ID] = [ID_Role_User] where [User_Logical_Delete] = 0 and [Role_User_Logical_Delete] = 0";
        private string QRRoleUserForComboBox = "select [ID_Role_User], [Role_Name] from [dbo].[Role_User] where [Role_User_Logical_Delete] = 0";
        private string QRListBookForAct = "select [Инвентарный номер], [Название книги] + ', ' + [Автор], [Стоимость экземпляра книги, руб.], [Кол-во экземпляров], " +
                    "[Сумма стоимости книг, руб.] from [dbo].[Summary_Book]";
        private string QRInventoryBook = "select [Номер записи], CONVERT(varchar (10), [Дата записи], 104), [Автор], [Название книги], " +
            "[ISBN номер], [Жанр], [Год издания], [Издательство], [Кол-во страниц] from [dbo].[Inventory_Book]";
        private string QRSummaryBook = "select CONVERT([varchar] (10), [Дата записи], 104), [Инвентарный номер], [Название книги], [Автор]," +
            " [Жанр], [Издательство], [Год издания], [Кол-во страниц], [Кол-во экземпляров], [Стоимость экземпляра книги, руб.]," +
            " [Сумма стоимости книг, руб.] from [dbo].[Summary_Book]";
        private string QRPersonalCabinet = "select [Surname_User], [Name_User], [Patronymic_User], CONVERT([nvarchar] (16), " +
            "DECRYPTBYKEY([Login_User])), CONVERT([nvarchar] (16), DECRYPTBYKEY([Password_User])) from [dbo].[User] " +
            "where CONVERT([nvarchar] (16), DECRYPTBYKEY([Login_User])) = '" + AuthorizationForm.LoginUser + "'";
        private string QRStatisticsBookReturned = "select [Book_Returned], count(*) as [Count_Book] from [dbo].[Formular_Reader] where " +
            "[Formular_Reader_Logical_Delete] = 0 group by [Book_Returned]";
        private string QRStatisticsAgeReader = "select case when MONTH(GETDATE()) >= MONTH([Birthday_Reader]) AND DAY(GETDATE()) >= " +
            "DAY([Birthday_Reader]) then YEAR(GETDATE()) - YEAR([Birthday_Reader]) else (YEAR(GETDATE()) - YEAR([Birthday_Reader]) - 1) end " +
            "as [Age], count(*) from [dbo].[Registration_Card_Reader] where [Registration_Card_Reader_Logical_Delete] = 0 " +
            "group by case when MONTH(GETDATE()) >= MONTH([Birthday_Reader]) AND DAY(GETDATE()) >= DAY([Birthday_Reader]) " +
            "then YEAR(GETDATE()) - YEAR([Birthday_Reader]) else (YEAR(GETDATE()) - YEAR([Birthday_Reader]) - 1) end";
        private string QRStatisticsPublicationDate = "select [Publication_Date], count(*) from [dbo].[Book] " +
            "where [Book_Logical_Delete] = 0 group by [Publication_Date]";
        private string QRStatisticsWriterBook = "select [Писатель], count(*) from [dbo].[Books_List] group by [Писатель]";
        public SqlDependency dependency = new SqlDependency();
 

        private void DataTableFill(DataTable table, string query)   //выгрузка таблицы
        {
            try
            {
                table.Clear();
                command.Notification = null;
                command.CommandText = query;
               // dependency.AddCommandDependency(command);
                //SqlDependency.Start(RegistryData.DBConnectionString.ConnectionString);
                RegistryData.DBConnectionString.Open();
                CommandOpenKey.ExecuteNonQuery();
                table.Load(command.ExecuteReader());
                CommandCloseKey.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistryData.ErrorMessage += "\n" + DateTime.Now.ToLongDateString() + ex.Message;
            }
            finally
            {
                RegistryData.DBConnectionString.Close();
            }
        }

        public void DTGenreFill()   //таблица Жанры
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTGenre, QRGenre.Remove(55));
            else
                DataTableFill(DTGenre, QRGenre);
        }

        public void DTPublishingFill()  //таблица Издания
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTPublishing, QRPublishing.Remove(69));
            else
                DataTableFill(DTPublishing, QRPublishing);
        }

        public void DTWriterBookFill()  //таблица Писатели
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTWriterBook, QRWriterBook.Remove(98));
            else
                DataTableFill(DTWriterBook, QRWriterBook);
        }

        public void DTBookFill()    //таблица Книги
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTBook, QRBook.Remove(694));
            else
                DataTableFill(DTBook, QRBook);
        }

        public void DTWriterForComboBoxFill()   //таблица Писатели для ComboBox
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTWriterBook, QRWriterForComboBox.Remove(129));
            else
                DataTableFill(DTWriterBook, QRWriterForComboBox);
        }

        public void DTRegistrationCardFill()    //таблица Регистрационные карточки
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTRegistrationCard, QRRegistrationCard.Remove(766));
            else
                DataTableFill(DTRegistrationCard, QRRegistrationCard);
        }

        public void DTFormularFill()    //Таблица Формуляры
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTFormular, QRFormular.Remove(710));
            else
                DataTableFill(DTFormular, QRFormular);
        }

        public void DTBookForComboBoxFill() //таблица Книги для ComboBox
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTBook, QRBookForComboBox.Remove(48));
            else
                DataTableFill(DTBook, QRBookForComboBox);
        }

        public void DTReaderForComboBoxFill()   //таблица Читатели для ComboBox
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTRegistrationCard, QRReaderForComboBox.Remove(302));
            else
                DataTableFill(DTRegistrationCard, QRReaderForComboBox);
        }

        public void DTUsersFill()   //таблица Пользователи
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTUsers, QRUsers.Remove(287));
            else
                DataTableFill(DTUsers, QRUsers);
        }

        public void DTRoleUserForComboBox() //таблица Роли для ComboBox
        {
            if (AuthorizationForm.userRole == 1)
                DataTableFill(DTRoleUser, QRRoleUserForComboBox.Remove(57));
            else
                DataTableFill(DTRoleUser, QRRoleUserForComboBox);
        }

        public void DTListBookForActFill()  //таблица список книг для акта
        {
            DataTableFill(DTListBookForAct, QRListBookForAct);
        }

        public void DTInventoryBookFill()   //таблица для инвентарной книги
        {
            DataTableFill(DTInvenoryBook, QRInventoryBook);
        }

        public void DTSummaryBookfill() //таблица для книги суммарного учета
        {
            DataTableFill(DTSummaryBook, QRSummaryBook);
        }

        public void DTPersonalCabinetFill() //таблица для личного кабинета
        {
            DataTableFill(DTPersonalCabinet, QRPersonalCabinet);
        }

        public void DTStatisticsBookReturnedFill()  //таблица статистики выданных книг
        {
            DataTableFill(DTStatisticsBookReturned, QRStatisticsBookReturned);
        }

        public void DTStatisticsAgeReaderFill() //таблица статистики возраста читателей
        {
            DataTableFill(DTStatisticsAgeReader, QRStatisticsAgeReader);
        }

        public void DTStatisticsPublicationDateFill()   //таблица статистики года издания книг
        {
            DataTableFill(DTStatisticsPublicationDate, QRStatisticsPublicationDate);
        }

        public void DTStatisticsWriterBookFill()    //таблица статистики авторов книг//показ статистики по 
        {
            DataTableFill(DTStatisticsWriterBook, QRStatisticsWriterBook);
        }
    }
}
