namespace Library
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chrtStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbSelectDiagram = new System.Windows.Forms.GroupBox();
            this.rbWriterBook = new System.Windows.Forms.RadioButton();
            this.rbPublicationDate = new System.Windows.Forms.RadioButton();
            this.rbAgeReader = new System.Windows.Forms.RadioButton();
            this.rbIssueBooks = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chrtStatistics)).BeginInit();
            this.gbSelectDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // chrtStatistics
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtStatistics.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.chrtStatistics, "chrtStatistics");
            legend1.Name = "Legend1";
            this.chrtStatistics.Legends.Add(legend1);
            this.chrtStatistics.Name = "chrtStatistics";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Легенда диаграммы";
            this.chrtStatistics.Series.Add(series1);
            // 
            // gbSelectDiagram
            // 
            this.gbSelectDiagram.Controls.Add(this.rbWriterBook);
            this.gbSelectDiagram.Controls.Add(this.rbPublicationDate);
            this.gbSelectDiagram.Controls.Add(this.rbAgeReader);
            this.gbSelectDiagram.Controls.Add(this.rbIssueBooks);
            resources.ApplyResources(this.gbSelectDiagram, "gbSelectDiagram");
            this.gbSelectDiagram.Name = "gbSelectDiagram";
            this.gbSelectDiagram.TabStop = false;
            // 
            // rbWriterBook
            // 
            resources.ApplyResources(this.rbWriterBook, "rbWriterBook");
            this.rbWriterBook.Name = "rbWriterBook";
            this.rbWriterBook.TabStop = true;
            this.rbWriterBook.UseVisualStyleBackColor = true;
            this.rbWriterBook.CheckedChanged += new System.EventHandler(this.rbWriterBook_CheckedChanged);
            // 
            // rbPublicationDate
            // 
            resources.ApplyResources(this.rbPublicationDate, "rbPublicationDate");
            this.rbPublicationDate.Name = "rbPublicationDate";
            this.rbPublicationDate.TabStop = true;
            this.rbPublicationDate.UseVisualStyleBackColor = true;
            this.rbPublicationDate.CheckedChanged += new System.EventHandler(this.rbPublicationDate_CheckedChanged);
            // 
            // rbAgeReader
            // 
            resources.ApplyResources(this.rbAgeReader, "rbAgeReader");
            this.rbAgeReader.Name = "rbAgeReader";
            this.rbAgeReader.TabStop = true;
            this.rbAgeReader.UseVisualStyleBackColor = true;
            this.rbAgeReader.CheckedChanged += new System.EventHandler(this.rbAgeReader_CheckedChanged);
            // 
            // rbIssueBooks
            // 
            resources.ApplyResources(this.rbIssueBooks, "rbIssueBooks");
            this.rbIssueBooks.Name = "rbIssueBooks";
            this.rbIssueBooks.TabStop = true;
            this.rbIssueBooks.UseVisualStyleBackColor = true;
            this.rbIssueBooks.CheckedChanged += new System.EventHandler(this.rbIssueBooks_CheckedChanged);
            // 
            // StatisticsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chrtStatistics);
            this.Controls.Add(this.gbSelectDiagram);
            this.Name = "StatisticsForm";
            ((System.ComponentModel.ISupportInitialize)(this.chrtStatistics)).EndInit();
            this.gbSelectDiagram.ResumeLayout(false);
            this.gbSelectDiagram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chrtStatistics;
        private System.Windows.Forms.GroupBox gbSelectDiagram;
        private System.Windows.Forms.RadioButton rbWriterBook;
        private System.Windows.Forms.RadioButton rbPublicationDate;
        private System.Windows.Forms.RadioButton rbAgeReader;
        private System.Windows.Forms.RadioButton rbIssueBooks;
    }
}