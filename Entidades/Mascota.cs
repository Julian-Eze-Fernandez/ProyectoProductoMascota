using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota
    {

        #region Atributos
        private int codigo;
        private string nombreMascota;
        private int edad;
        private string tipo;
        private string sexo;
        private decimal peso;
        private bool vacunada;
        private bool castrada;
        DateTime ultimoControl;
        #endregion

        #region Constructores
        public Mascota()
        {
        }

        public Mascota(int cod, string tip, int ed)
        {
            codigo = cod;
            tipo = tip;
            edad = ed;
        }
        #endregion

        #region Propiedades

        public int Codigo { get; set; }
        public string NombreMascota { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string Sexo { get; set; }
        public decimal Peso { get; set; }
        public DateTime UltimoControl { get; set; }
        public bool Vacunada { get; set; }
        public bool Castrada { get; set; }
        #endregion
    }
}
