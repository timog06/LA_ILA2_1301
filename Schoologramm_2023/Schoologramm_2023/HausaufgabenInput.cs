using System.Windows.Controls;
using System.Data.SQLite;

namespace Schoologramm_2023
{
    class HausaufgabenInput
    {
        private string _fach;
        private string _auftrag;
        private string _fälligkeit;

        private string ConnectionString = new DatabaseManager(@".\Daten.sqlite", @".\DatenArchiv.sqlite")._databasePath;

        public bool Check { get; private set; }

        public HausaufgabenInput(string fach, string auftrag, string fälligkeit)
        {
            _fach = fach;
            _auftrag = auftrag;
            _fälligkeit = fälligkeit;

        }
        public void HausaufgabenUeberpruefung()
        {
            if (_fach != "" && _auftrag != "" && _fälligkeit != "")
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

                string insertDataQuery = "INSERT INTO HausaufgabenDaten (Datum, Fach, Auftrag) VALUES (@fälligkeit, @fach, @auftrag)";

                using (SQLiteCommand command = new SQLiteCommand(insertDataQuery, connection))
                {
                    command.Parameters.AddWithValue("@fälligkeit", _fälligkeit);
                    command.Parameters.AddWithValue("@fach", _fach);
                    command.Parameters.AddWithValue("@auftrag", _auftrag);

                    command.ExecuteNonQuery();
                }
            }

        }
    }

}
