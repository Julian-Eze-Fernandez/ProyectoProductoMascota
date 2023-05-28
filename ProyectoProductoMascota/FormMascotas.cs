using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace ProyectoProductoMascota
{
    public partial class FormMascotas : Form
    {
        DataTable dataMascotas = new DataTable();
        
        public FormMascotas()
        {
            InitializeComponent();
            dgv_Mascotas.DataSource = dataMascotas;

            #region Columnas de DGV
            //Se crean las columnas del DataGridView
            dataMascotas.Columns.Add("Codigo");
            dataMascotas.Columns.Add("Nombre");
            dataMascotas.Columns.Add("Tipo");
            dataMascotas.Columns.Add("Sexo");
            dataMascotas.Columns.Add("Edad");
            dataMascotas.Columns.Add("Peso");
            dataMascotas.Columns.Add("Ultimo Control");
            dataMascotas.Columns.Add("Vacunada");
            dataMascotas.Columns.Add("Castrada");
            #endregion

        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {    
            //Creamos un objeto Nueva masocta de la clase Mascotas con sus atributos
            Mascota NuevaMascota = new Mascota(int.Parse(txt_Codigo.Text), cmb_Tipo.Text,int.Parse(txt_Edad.Text));

            //Asignacion del valor a las propiedades del objeto NuevaMascota
            NuevaMascota.Codigo = int.Parse(txt_Codigo.Text);
            NuevaMascota.NombreMascota = txt_Nombre.Text;
            NuevaMascota.Edad = int.Parse(txt_Edad.Text);
            NuevaMascota.Tipo = cmb_Tipo.Text;
            NuevaMascota.Sexo = cmb_Sexo.Text;
            NuevaMascota.Peso = int.Parse(txt_Peso.Text);
            NuevaMascota.UltimoControl = dateTimePicker1.Value;
            NuevaMascota.Vacunada = radiobtn_SiVacuna.Checked;
            NuevaMascota.Castrada = radiobtn_SiCastrada.Checked;

            //Carga de mascotas al DataGridView
            dataMascotas.Rows.Add();
            int i = dataMascotas.Rows.Count - 1;

            dataMascotas.Rows[i]["Codigo"] = NuevaMascota.Codigo;
            dataMascotas.Rows[i]["Nombre"] = NuevaMascota.NombreMascota;
            dataMascotas.Rows[i]["Tipo"] = NuevaMascota.Tipo;
            dataMascotas.Rows[i]["Sexo"] = NuevaMascota.Sexo;
            dataMascotas.Rows[i]["Edad"] = NuevaMascota.Edad;
            dataMascotas.Rows[i]["Peso"] = NuevaMascota.Peso;
            dataMascotas.Rows[i]["Ultimo Control"] = NuevaMascota.UltimoControl;
            dataMascotas.Rows[i]["Vacunada"] = NuevaMascota.Vacunada;
            dataMascotas.Rows[i]["Castrada"] = NuevaMascota.Castrada;

            limpiarPantalla();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            dgv_Mascotas.Rows.Remove(dgv_Mascotas.CurrentRow);
        }

        public void limpiarPantalla()
        {
            txt_Codigo.Text = "";
            txt_Nombre.Text = "";
            txt_Edad.Text = "";
            cmb_Tipo.Text = "";
            cmb_Sexo.Text = "";
            txt_Peso.Text = "";
            radiobtn_SiVacuna.Checked = false;
            radiobtn_NoVacuna.Checked = false;
            radiobtn_SiCastrada.Checked = false;
            radiobtn_NoCastrada.Checked = false;
        }
    }
}
