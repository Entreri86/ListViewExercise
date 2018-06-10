using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ListViewExercise.Models
{
    /**
     * Derivamos la clase de grupo de busqueda de ObservableCollection para que al borrar alguna de las busquedas se auto-actualice la vista    
     **/

    class SearchGroup : ObservableCollection <Search>
    {
        public string Title { get; set; }

        public SearchGroup (string title, IEnumerable<Search> searches = null) : base (searches)
        {
            this.Title = title;
        }
    }
}
