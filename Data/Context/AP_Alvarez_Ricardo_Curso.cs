using System;
using System.Collections.Generic;

#nullable disable

namespace data.Context
{
    public partial class AP_Alvarez_Ricardo_Curso
    {
        public AP_Alvarez_Ricardo_Curso()
        {
            AP_Alvarez_Ricardo_Nota = new HashSet<AP_Alvarez_Ricardo_Nota>();
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool? obligatorio { get; set; }
        public bool? estado { get; set; }

        public virtual ICollection<AP_Alvarez_Ricardo_Nota> AP_Alvarez_Ricardo_Nota { get; set; }
    }
}
