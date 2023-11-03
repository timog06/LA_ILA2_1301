using System.Data.SQLite;
using System.IO;

namespace Schoologramm_2023
{
    public class DatabaseManager
    {
        public string _databasePath;
        public string _databaseArchivePath;

        public DatabaseManager(string databasePath, string databaseArchivePath)
        {
            _databasePath = databasePath;
            _databaseArchivePath = databaseArchivePath;
        }

        public void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
            {
                CreateDatabase(_databasePath);
            }
        }
        public void InitializeDatabaseArchvive()
        {
            if (!File.Exists(_databaseArchivePath))
            {
                CreateDataBaseArchive(_databaseArchivePath);
            }
        }
        
        private void CreateDatabase(string databasePath)
        {
            SQLiteConnection.CreateFile(databasePath);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath}; Version=3;"))
            {
                connection.Open();
                string createTableQuery = @"
                    PRAGMA foreign_keys = off;
                    BEGIN TRANSACTION;

                    -- Tabelle: HausaufgabenDaten
                    CREATE TABLE IF NOT EXISTS HausaufgabenDaten (
                        Datum      TEXT,
                        Fach       TEXT,
                        Auftrag    TEXT,
                        ID         INTEGER PRIMARY KEY AUTOINCREMENT
                    );

                    -- Tabelle: PrüfungsDaten
                    CREATE TABLE IF NOT EXISTS PrüfungsDaten (
                        Datum       TEXT,
                        Fach        TEXT,
                        Stoff       TEXT,
                        ID          INTEGER PRIMARY KEY AUTOINCREMENT
                    );

                    COMMIT TRANSACTION;
                    PRAGMA foreign_keys = on;
                ";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateDataBaseArchive(string _databaseArchivePath)
        {
            SQLiteConnection.CreateFile(_databaseArchivePath);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={_databaseArchivePath}; Version=3;"))
            {
                connection.Open();
                string createTableQuery = @"
                    PRAGMA foreign_keys = off;
                    BEGIN TRANSACTION;

                    -- Tabelle: HausaufgabenDaten
                    CREATE TABLE IF NOT EXISTS HausaufgabenDaten (
                        Datum      TEXT,
                        Fach       TEXT,
                        Auftrag    TEXT,
                        ID          INTEGER PRIMARY KEY AUTOINCREMENT
                    );

                    -- Tabelle: PrüfungsDaten
                    CREATE TABLE IF NOT EXISTS PrüfungsDaten (
                        Datum       TEXT,
                        Fach        TEXT,
                        Stoff       TEXT,
                        ID          INTEGER PRIMARY KEY AUTOINCREMENT
                    );

                    COMMIT TRANSACTION;
                    PRAGMA foreign_keys = on;
                ";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
