using System;

namespace Entidad.Dto.Comun
{
    public class ResultDataTable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public Object data { get; set; }
        public string error { get; set; }
    }
}
