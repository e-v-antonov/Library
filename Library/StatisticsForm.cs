using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Library
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void ChartIssueBooksFill()  //Статистика по выданным книгам
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTStatisticsBookReturned.Clear();
                dbTables.DTStatisticsBookReturnedFill();

                chrtStatistics.Series.Clear();
                chrtStatistics.Titles.Clear();
                chrtStatistics.Titles.Add("Статистика по выданным книгам");
                chrtStatistics.Series.Add(new Series("IssueBooks")
                {
                    ChartType = SeriesChartType.Pie
                });

                int i = 0;

                while (i < dbTables.DTStatisticsBookReturned.Rows.Count)
                {
                    string x1 = dbTables.DTStatisticsBookReturned.Rows[i][1].ToString();
                    double y1 = Convert.ToDouble(dbTables.DTStatisticsBookReturned.Rows[i][1].ToString());
                    chrtStatistics.Series["IssueBooks"].Points.AddXY(x1, y1);                    
                    i++;
                }

                chrtStatistics.Series["IssueBooks"].Points[0].LegendText = "Кол-во неовзвращенных книг";
                chrtStatistics.Series["IssueBooks"].Points[1].LegendText = "Кол-во возвращенных книг";
            };
            Invoke(action);
        }

        private void ChartAgeReaderFill()   //Статистика возраста читателей
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTStatisticsAgeReader.Clear();
                dbTables.DTStatisticsAgeReaderFill();

                chrtStatistics.Series.Clear();
                chrtStatistics.Titles.Clear();
                chrtStatistics.Titles.Add("Статистика возраста читателей");
                chrtStatistics.Series.Add(new Series("AgeReader")
                {
                    ChartType = SeriesChartType.Column
                });

                int i = 0;

                while (i < dbTables.DTStatisticsAgeReader.Rows.Count)
                {
                    var x1 = dbTables.DTStatisticsAgeReader.Rows[i][0].ToString();
                    var y1 = dbTables.DTStatisticsAgeReader.Rows[i][1].ToString();
                    chrtStatistics.Series["AgeReader"].Points.AddXY(x1, y1);
                    i++;
                }

                chrtStatistics.Series["AgeReader"].IsVisibleInLegend = false;
                Axis axisX = new Axis();
                Axis axisY = new Axis();
                axisX.Title = "Возраст";
                axisY.Title = "Кол-во читателей";
                chrtStatistics.ChartAreas[0].AxisX = axisX;
                chrtStatistics.ChartAreas[0].AxisY = axisY;
            };
            Invoke(action);
        }

        private void ChartPublicationDateFill() //Время издания книг
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTStatisticsPublicationDate.Clear();
                dbTables.DTStatisticsPublicationDateFill();

                chrtStatistics.Series.Clear();
                chrtStatistics.Titles.Clear();
                chrtStatistics.Titles.Add("Время издания книг");
                chrtStatistics.Series.Add(new Series("PublicationDate")
                {
                    ChartType = SeriesChartType.Column
                });

                int i = 0;

                while (i < dbTables.DTStatisticsPublicationDate.Rows.Count)
                {
                    var x1 = dbTables.DTStatisticsPublicationDate.Rows[i][0].ToString();
                    var y1 = dbTables.DTStatisticsPublicationDate.Rows[i][1].ToString();
                    chrtStatistics.Series["PublicationDate"].Points.AddXY(x1, y1);
                    i++;
                }

                chrtStatistics.Series["PublicationDate"].IsVisibleInLegend = false;
                Axis axisX = new Axis();
                Axis axisY = new Axis();
                axisX.Title = "Год издания";
                axisY.Title = "Кол-во книг";
                chrtStatistics.ChartAreas[0].AxisX = axisX;
                chrtStatistics.ChartAreas[0].AxisY = axisY;
            };
            Invoke(action);
        }

        private void ChartWriterBookFill()  //Статистика по авторам книг
        {
            DBTables dbTables = new DBTables();

            Action action = () =>
            {
                dbTables.DTStatisticsWriterBook.Clear();
                dbTables.DTStatisticsWriterBookFill();

                chrtStatistics.Series.Clear();
                chrtStatistics.Titles.Clear();
                chrtStatistics.Titles.Add("Статистика по авторам книг");
                chrtStatistics.Series.Add(new Series("WriterBook")
                {
                    ChartType = SeriesChartType.Pie
                });

                int i = 0;

                while (i < dbTables.DTStatisticsWriterBook.Rows.Count)
                {
                    string x1 = dbTables.DTStatisticsWriterBook.Rows[i][0].ToString();
                    double y1 = Convert.ToDouble(dbTables.DTStatisticsWriterBook.Rows[i][1].ToString());
                    chrtStatistics.Series["WriterBook"].Points.AddXY(y1.ToString(), y1);

                    chrtStatistics.Series["WriterBook"].Points[i].LegendText = x1;

                    i++;
                }
            };
            Invoke(action);
        }

        private void rbIssueBooks_CheckedChanged(object sender, EventArgs e)    //показ статистики по выданным книгам
        {
            Thread threadStatisticsIssueBooks = new Thread(ChartIssueBooksFill);
            threadStatisticsIssueBooks.Start();
        }

        private void rbAgeReader_CheckedChanged(object sender, EventArgs e) //показ статистики по возрасту читателей
        {
            Thread threadStatisticsAgeReader = new Thread(ChartAgeReaderFill);
            threadStatisticsAgeReader.Start();
        }

        private void rbPublicationDate_CheckedChanged(object sender, EventArgs e)   //показ статистики по году издания книги
        {
            Thread threadStatisticsPublicationDate = new Thread(ChartPublicationDateFill);
            threadStatisticsPublicationDate.Start();
        }

        private void rbWriterBook_CheckedChanged(object sender, EventArgs e)    //показ статистики по авторам книг
        {
            Thread threadStatisticsWriterBook = new Thread(ChartWriterBookFill);
            threadStatisticsWriterBook.Start();
        }
    }
}
