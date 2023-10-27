using System.Data.SQLite;

namespace Schoologramm_2023
{
    class PrüfungInput
    {
        private string _prüfungsfach;
        private string _prüfungsstoff;
        private string _prüfungsdatum;

        private string ConnectionString = new DatabaseManager(@".\Daten.sqlite", @".\DatenArchiv.sqlite")._databasePath;

        public bool Check { get; private set; }

        public PrüfungInput(string prüfungsfach, string prüfungsstoff, string prüfungsdatum)
        {
            _prüfungsfach = prüfungsfach;
            _prüfungsstoff = prüfungsstoff;
            _prüfungsdatum = prüfungsdatum;
        }
        public void PrüfungsUeberpruefung()
        {
            if (_prüfungsfach != "" && _prüfungsstoff != "" && _prüfungsdatum != "")
            {
                Check = true;
                InsertIntoDatabase();
            }
        }

        private void InsertIntoDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
            {
                connection.Open();

                string insertDataQuery = "INSERT INTO PrüfungsDaten (Datum, Fach, Stoff) VALUES (@prüfungsdatum, @prüfungsfach, @prüfungsstoff)";

                using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@prüfungsdatum", _prüfungsdatum);
                    command.Parameters.AddWithValue("@prüfungsfach", _prüfungsfach);
                    command.Parameters.AddWithValue("@prüfungsstoff", _prüfungsstoff);

                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
