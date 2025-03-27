using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Clase para observar cambios en la base de datos
    /// </summary>
    internal class DatabaseWatcher
    {
        /// <summary>
        /// FileSystemWatcher para detectar cambios en la base de datos
        /// </summary>
        private FileSystemWatcher _watcher;
        public event EventHandler? DatabaseChanged;

        public DatabaseWatcher(string databasePath)
        {
            /// ✅ Evita que el FileSystemWatcher se quede bloqueado por un archivo de base de datos
            _watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(databasePath) ?? string.Empty,
                Filter = Path.GetFileName(databasePath),
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
            };

            _watcher.Changed += async (s, e) => await OnDatabaseChanged();
            _watcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// Dispara el evento DatabaseChanged después de un retraso de 500 ms
        /// </summary>
        /// <returns></returns>
        private async Task OnDatabaseChanged()
        {
            // ✅ Evita múltiples disparos de eventos innecesarios
            await Task.Delay(500);
            DatabaseChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Libera los recursos del FileSystemWatcher
        /// </summary>
        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}
