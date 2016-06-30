namespace Estacionamento.View
{
    partial class Form1
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Estacionamento_DAL_ContextDataSet = new Estacionamento.DAL._Estacionamento_DAL_ContextDataSet();
            this.estacionamentoDALContextDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._Estacionamento_DAL_ContextDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionamentoDALContextDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ClientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Estacionamento.View.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(555, 490);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Estacionamento_DAL_ContextDataSet
            // 
            this._Estacionamento_DAL_ContextDataSet.DataSetName = "_Estacionamento_DAL_ContextDataSet";
            this._Estacionamento_DAL_ContextDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estacionamentoDALContextDataSetBindingSource
            // 
            this.estacionamentoDALContextDataSetBindingSource.DataSource = this._Estacionamento_DAL_ContextDataSet;
            this.estacionamentoDALContextDataSetBindingSource.Position = 0;
            // 
            // ClientesBindingSource
            // 
            this.ClientesBindingSource.DataMember = "Clientes";
            this.ClientesBindingSource.DataSource = this._Estacionamento_DAL_ContextDataSet;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 490);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Estacionamento_DAL_ContextDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estacionamentoDALContextDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ClientesBindingSource;
        private DAL._Estacionamento_DAL_ContextDataSet _Estacionamento_DAL_ContextDataSet;
        private System.Windows.Forms.BindingSource estacionamentoDALContextDataSetBindingSource;
    }
}