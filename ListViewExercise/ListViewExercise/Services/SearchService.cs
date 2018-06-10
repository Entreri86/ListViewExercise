using ListViewExercise.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ListViewExercise.Services
{
    class SearchService
    {
        private List<Search> searches = new List<Search>
        {
            new Search
            {
                Id = 1,
                Location = "Huesca",
                Llegada = new DateTime(2018, 2, 10),
                Salida = new DateTime (2018, 2, 15)
            },
            new Search
            {
                Id = 2,
                Location = "Grecia",
                Llegada = new DateTime(2018, 7, 17),
                Salida = new DateTime(2018, 7, 22)
            }
        };

        public IEnumerable <Search> GetRecentSearches (string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))//Si el filtro esta vacio devolvemos la lista vacia. 
            {
                return searches;
            }
            //Comparamos con la lambda expression si filtrando por los caracteres iniciales si coinciden, en ese caso devolvemos la vista filtrada 
            return searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch (int searchId)
        {
            //Borramos de la lista (se auto-actualiza la vista) el numero segun filtrado de Id
            searches.Remove(searches.Single(s => s.Id == searchId));
        }

    }
}
