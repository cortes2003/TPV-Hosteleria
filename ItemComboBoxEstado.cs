using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TPV_Hosteleria
{
    internal class ItemComboBoxEstado
    {
        public String TipoEstado { get; set; }
        public String ColorCirculo {  get; set; }
        public String TextoComboBox => $"{TipoEstado} {ColorCirculo}";
    }
}
