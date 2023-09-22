using System.Windows.Controls;

namespace Schoologramm_2023
{
    class HausaufgabenInput
    {
        private string _fach;
        private string _auftrag;
        private string _fälligkeit;

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

                //Übergabe in die Datenbank
            }
        }
    }

}
