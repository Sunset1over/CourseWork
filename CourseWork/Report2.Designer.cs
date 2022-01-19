
namespace CourseWork
{
    partial class Report2
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BioadditiveBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CourseWorkDataSet = new CourseWork.CourseWorkDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BioadditiveTableAdapter = new CourseWork.CourseWorkDataSetTableAdapters.BioadditiveTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BioadditiveBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CourseWorkDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BioadditiveBindingSource
            // 
            this.BioadditiveBindingSource.DataMember = "Bioadditive";
            this.BioadditiveBindingSource.DataSource = this.CourseWorkDataSet;
            // 
            // CourseWorkDataSet
            // 
            this.CourseWorkDataSet.DataSetName = "CourseWorkDataSet";
            this.CourseWorkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BioadditiveBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CourseWork.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(638, 444);
            this.reportViewer1.TabIndex = 0;
            // 
            // BioadditiveTableAdapter
            // 
            this.BioadditiveTableAdapter.ClearBeforeFill = true;
            // 
            // Report2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 444);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report2";
            this.Load += new System.EventHandler(this.Report2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BioadditiveBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CourseWorkDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BioadditiveBindingSource;
        private CourseWorkDataSet CourseWorkDataSet;
        private CourseWorkDataSetTableAdapters.BioadditiveTableAdapter BioadditiveTableAdapter;
    }
}