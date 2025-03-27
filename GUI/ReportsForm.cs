using System.Data;
using System.Diagnostics;
using DataAccess;
using FastReport;
using FastReport.Export.PdfSimple;

namespace GUI
{
    public partial class ReportsForm : Style
    {
        private readonly PiezaRepository _repo;
        public ReportsForm()
        {
            InitializeComponent();
            ButtonStyle(btngetall);
            _repo = new PiezaRepository();
        }

        private async void btngetall_Click(object sender, EventArgs e)
        {
            DataTable dt = await ObtenerPiezas();
            MostrarReporte(dt, @"Reports\ReporteBajoStock.frx");
        }
        private void MostrarReporte(DataTable dt, string rutaFrx)
        {
            dt.TableName = "dtPiezas2";

            using (Report report = new Report())
            {
                report.RegisterData(dt, "dtPiezas2");
                report.Load(rutaFrx);  // Cargar el archivo de FastReport que diseñaste
                report.Prepare();
                string archivoPdf = "ReporteGenerado.pdf";
                report.Export(new PDFSimpleExport(), archivoPdf);

                // Abrir el PDF generado con el visor predeterminado
                Process.Start(new ProcessStartInfo(archivoPdf) { UseShellExecute = true });
            }
        }

        private async Task<DataTable> ObtenerPiezas()
        {
            var dtCompleto = await _repo.GetAllPiezasAsync();

            DataRow[] filasFiltradas = dtCompleto.Select();

            DataTable dtFiltrado = dtCompleto.Clone();
            foreach (DataRow row in filasFiltradas)
                dtFiltrado.ImportRow(row);

            return dtFiltrado;
        }
    }
}

