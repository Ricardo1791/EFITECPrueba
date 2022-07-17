using System;
using System.Collections.Generic;

#nullable disable

namespace data.Context
{
    public partial class AP_Alvarez_Ricardo_Alumno
    {
        public AP_Alvarez_Ricardo_Alumno()
        {
            AP_Alvarez_Ricardo_Nota = new HashSet<AP_Alvarez_Ricardo_Nota>();
        }

        public int id { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public bool? estado { get; set; }

        public virtual ICollection<AP_Alvarez_Ricardo_Nota> AP_Alvarez_Ricardo_Nota { get; set; }
    }
}
