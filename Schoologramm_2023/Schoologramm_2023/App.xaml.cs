using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Schoologramm_2023
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string databasePath = @".\Daten.sqlite";
            string databaseArchivePath = @".\DatenArchiv.sqlite";
            var dbManager = new DatabaseManager(databasePath, databaseArchivePath);
            dbManager.InitializeDatabase();
            dbManager.InitializeDatabaseArchvive();
        }
    }
}
