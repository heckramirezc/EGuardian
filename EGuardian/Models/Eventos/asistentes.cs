using System;
namespace EGuardian.Models.Eventos
{
    public class asistentes
    {
        public string nombre { get; set; }
        public string puesto { get; set; }
        public string rol { get; set; }
        public string Rol
        {
            get
            {
                return rol.ToUpper();
            }
        }
    }
}
