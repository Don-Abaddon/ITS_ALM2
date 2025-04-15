using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using Domain;
using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;

namespace GUI
{
    public partial class ReportsForm : Style
    {
        private Inventory _inventory;
        public ReportsForm()
        {
            InitializeComponent();
            ButtonStyle(btngetall);
            _inventory = new Inventory();

        }

        private async void btngetall_Click(object sender, EventArgs e)
        {
            DataTable dt = await _inventory.ObtenerPiezas();
            dataGridView1.DataSource = dt;
            MostrarReporte(dt, @"Reports\ReporteBajoStock.frx");
        }
        /// <summary>
        /// Muestra el reporte en un archivo PDF 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rutaFrx"></param>
        private void MostrarReporte(DataTable dt, string rutaFrx)
        {
            dt.TableName = "dtPiezas2";

            using (Report report = new Report())
            {
                report.RegisterData(dt, dt.TableName);
                report.Load(rutaFrx);  // Cargar el archivo de FastReport que diseñaste
                report.Prepare();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar reporte como…";
                    sfd.FileName = $"ReporteGenerado_{DateTime.Now:yyyy-MM-dd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Exportar al archivo elegido
                        report.Export(new PDFSimpleExport(), sfd.FileName);

                        // Abrir el PDF con el visor predeterminado
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        private  async void btnResumen_Click(object sender, EventArgs e)
        {
            DataTable dt = await _inventory.ObtenerResumenPorCategoria();
            dataGridView1.DataSource = dt;
            MostrarReporteBajo(dt, @"Reports\ReporteCategoria.frx"); ;
        }

        private void MostrarReporteBajo(DataTable dt, string rutaFrx)
        {
            dt.TableName = "dtPiezas2";

            using (Report report = new Report())
            {
                report.RegisterData(dt, dt.TableName);
                report.Load(rutaFrx);  // Cargar el archivo de FastReport que diseñaste
                report.Prepare();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar reporte como…";
                    sfd.FileName = $"ReporteCategoria_{DateTime.Now:yyyy-MM-dd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Exportar al archivo elegido
                        report.Export(new PDFSimpleExport(), sfd.FileName);

                        // Abrir el PDF con el visor predeterminado
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
        }
    }
}


