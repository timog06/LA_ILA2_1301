namespace Schoologramm_2023
{
    class PrüfungInput
    {
        private string _prüfungsfach;
        private string _prüfungsstoff;
        private string _prüfungsdatum;

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

                //Übergabe in die Datenbank
            }
        }
    }
}
