using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao_dto_singleton.DTO
{
    class ClienteDTO
    {
        private int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private string ciudad;
        private string email;
        private string telefono;
        private string ocupacion;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
    }
}
