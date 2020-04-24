using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Soportes
{
    class ValidacionDatos
    {
        private ValidationContext contexto;
        private List<ValidationResult> resultados;
        private bool validacion;
        private string mensaje;

        public ValidacionDatos(object instancia)
        {
            contexto = new ValidationContext(instancia);
            resultados = new List<ValidationResult>();
            validacion = Validator.TryValidateObject(instancia, contexto, resultados, true);
        }

        public bool Validar()
        {
            if(validacion == false)
            {
                foreach (ValidationResult item in resultados)
                {
                    mensaje += item.ErrorMessage + "\n";
                }
                System.Windows.Forms.MessageBox.Show(mensaje);
            }
            return validacion;
        }
    }
}
