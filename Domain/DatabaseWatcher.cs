using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class DatabaseWatcher
    {
        private FileSystemWatcher _watcher;
        public event EventHandler? DatabaseChanged;

        public DatabaseWatcher(string databasePath)
        {
            _watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(databasePath) ?? string.Empty,
                Filter = Path.GetFileName(databasePath),
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
            };

            _watcher.Changed += async (s, e) => await OnDatabaseChanged();
            _watcher.EnableRaisingEvents = true;
        }

        private async Task OnDatabaseChanged()
        {
            // ✅ Evita múltiples disparos de eventos innecesarios
            await Task.Delay(500);
            DatabaseChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            _watcher.Dispose();
        }
    }
}
