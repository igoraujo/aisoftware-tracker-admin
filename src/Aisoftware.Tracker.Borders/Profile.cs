using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class Profile
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

    public enum ProfileName
    {
        [Description("Administrador")]
        Administrator,
        [Description("Gerente")]
        Manager,
        [Description("Usuário")]
        User,
        [Description("Apenas Relatórios")]
        UserReport
    }
}
