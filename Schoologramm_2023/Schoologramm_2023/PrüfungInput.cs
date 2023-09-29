using System.Data.SQLite;

namespace Schoologramm_2023
{
    class PrüfungInput
    {
        private string _prüfungsfach;
        private string _prüfungsstoff;
        private string _prüfungsdatum;

        private const string DatenbankPath = "C:\\Users\\pasca\\OneDrive\\Dokumente\\GitHub\\LA_ILA2_1301\\Schoologramm_2023\\Schoologramm_2023\\_data\\Daten.sqlite";

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
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={DatenbankPath}; Version=3;"))
            {
                connection.Open();

                string insertDataQuery = "INSERT INTO PrüfungsDaten (Datum, Fach, Stoff) VALUES (@prüfungsfach, @prüfungsstoff, @prüfungsdatum)";

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
