using System;
using System.Collections.Generic;
using System.Text;


namespace ListViewExercise.Models
{
    class Search
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Llegada { get; set; }
        public DateTime Salida { get; set; }
        public string Completo
        {
            get
            {
                return String.Format("{0} {1}", Llegada.ToString("MMM d, yyyy"), Salida.ToString("MMM d, yyyy"));
            }
        }

    }
}
