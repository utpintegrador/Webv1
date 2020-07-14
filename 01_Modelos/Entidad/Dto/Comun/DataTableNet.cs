using System.Collections.Generic;

namespace Entidad.Dto.Comun
{
    public class DataTableNet
    {
        public int Draw { get; set; }//indica el numero de veces que se esta dibujando la grilla
        public int? Start { get; set; }
        public int? Length { get; set; }
        public List<Order> Order { get; set; }
        public List<Columns> Columns { get; set; }
        //public Search Search { get; set; }

        //Campos calculados
        //public int NumberPage { get; set; }
        public string ColumnOrder { get; set; }
        public string OrderDirection { get; set; }

    }

    public class Columns
    {
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public Search Search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string Regex { get; set; }
    }

    public class Order
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }
}
