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
using CapaNegocio;

namespace ProyectoProductoMascota
{
    public partial class FormMascotas : Form
    {
        //DataTable dataMascotas = new DataTable();

        Mascota NuevaMasc;
        Mascota MascExistente;
        NegMascota objNegMascota = new NegMascota();
        bool nuevo = true;
        int fila;

        public FormMascotas()
        {
            InitializeComponent();
            CrearDGV();
            LlenarDGV();
            #region CtorViejo
            // dgv_Mascotas.DataSource = dataMascotas;
            //#region Columnas de DGV
            ////Se crean las columnas del DataGridView
            //dataMascotas.Columns.Add("Codigo");
            //dataMascotas.Columns.Add("Nombre");
            //dataMascotas.Columns.Add("Tipo");
            //dataMascotas.Columns.Add("Sexo");
            //dataMascotas.Columns.Add("Edad");
            //dataMascotas.Columns.Add("Peso");
            //dataMascotas.Columns.Add("Ultimo Control");
            //dataMascotas.Columns.Add("Vacunada");
            //dataMascotas.Columns.Add("Castrada");
            //#endregion
            #endregion
        }

        private void CrearDGV()
        {
            dgv_Mascotas.Columns.Add("0","Código");
            dgv_Mascotas.Columns.Add("1", "Nombre");
            dgv_Mascotas.Columns.Add("2", "Edad");
            dgv_Mascotas.Columns.Add("3", "Tipo");
            dgv_Mascotas.Columns.Add("4", "Sexo");
            dgv_Mascotas.Columns.Add("5", "Peso");
            dgv_Mascotas.Columns.Add("6", "Ultimo Control");
            dgv_Mascotas.Columns.Add("7", "Vacunada");
            dgv_Mascotas.Columns.Add("8", "Castrada");

            dgv_Mascotas.Columns[0].Width = 100;
            dgv_Mascotas.Columns[1].Width = 100;
            dgv_Mascotas.Columns[2].Width = 100;
            dgv_Mascotas.Columns[3].Width = 100;
            dgv_Mascotas.Columns[4].Width = 100;
            dgv_Mascotas.Columns[5].Width = 100;
            dgv_Mascotas.Columns[6].Width = 100;
            dgv_Mascotas.Columns[7].Width = 100;
            dgv_Mascotas.Columns[8].Width = 100;
        }

        private void LlenarDGV()
        {
            dgv_Mascotas.Rows.Clear();

            DataSet ds = new DataSet();
            ds = objNegMascota.listadoMascotas("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //Lo que quieres mostrar esta en dr[0].ToString(), dr[1].ToString(),etc...
                    dgv_Mascotas.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                }
            }
            else
                MessageBox.Show("No hay Mascotas cargadas en el sistema");
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            #region PrgViejo
            //Creamos un objeto Nueva masocta de la clase Mascotas con sus atributos
            //Mascota NuevaMascota = new Mascota(int.Parse(txt_Codigo.Text), cmb_Tipo.Text, int.Parse(txt_Edad.Text));

            //Asignacion del valor a las propiedades del objeto NuevaMascota
            //NuevaMascota.NombreMascota = txt_Nombre.Text;
            //NuevaMascota.Sexo = cmb_Sexo.Text;
            //NuevaMascota.Peso = int.Parse(txt_Peso.Text);
            //NuevaMascota.UltimoControl = dateTimePicker1.Value;
            //NuevaMascota.Vacunada = radiobtn_SiVacuna.Checked;
            //NuevaMascota.Castrada = radiobtn_SiCastrada.Checked;

            //Carga de mascotas al DataGridView
            //dataMascotas.Rows.Add();
            //int i = dataMascotas.Rows.Count - 1;

            //dataMascotas.Rows[i]["Codigo"] = NuevaMascota.Codigo;
            //dataMascotas.Rows[i]["Nombre"] = NuevaMascota.NombreMascota;
            //dataMascotas.Rows[i]["Tipo"] = NuevaMascota.Tipo;
            //dataMascotas.Rows[i]["Sexo"] = NuevaMascota.Sexo;
            //dataMascotas.Rows[i]["Edad"] = NuevaMascota.Edad;
            //dataMascotas.Rows[i]["Peso"] = NuevaMascota.Peso;
            //dataMascotas.Rows[i]["Ultimo Control"] = NuevaMascota.UltimoControl.ToShortDateString();
            //dataMascotas.Rows[i]["Vacunada"] = NuevaMascota.Vacunada;
            //dataMascotas.Rows[i]["Castrada"] = NuevaMascota.Castrada;

            //limpiarPantalla();
            #endregion

            int nGrabados = -1;

            Mascota NuevaMascota = new Mascota(int.Parse(txt_Codigo.Text), cmb_Tipo.Text, int.Parse(txt_Edad.Text));

            nGrabados = objNegMascota.abmMascotas("Alta", NuevaMascota);

            if (nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar la mascota en el sistema");
            }
            else
            {
                NuevaMascota.NombreMascota = txt_Nombre.Text;
                NuevaMascota.Sexo = cmb_Sexo.Text;
                NuevaMascota.Peso = int.Parse(txt_Peso.Text);
                NuevaMascota.UltimoControl = dateTimePicker1.Value;
                NuevaMascota.Vacunada = radiobtn_SiVacuna.Checked;
                NuevaMascota.Castrada = radiobtn_SiCastrada.Checked;

                LlenarDGV();
                Limpiar();
            }


        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            #region PrgViejo
            dgv_Mascotas.Rows.Remove(dgv_Mascotas.CurrentRow);
            #endregion
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            #region PrgViejo
            txt_Codigo.Text = string.Empty;
            txt_Nombre.Text = string.Empty;
            txt_Edad.Text = string.Empty;
            cmb_Tipo.Text = string.Empty;
            cmb_Sexo.Text = string.Empty;
            txt_Peso.Text = string.Empty;
            radiobtn_SiVacuna.Checked = false;
            radiobtn_NoVacuna.Checked = false;
            radiobtn_SiCastrada.Checked = false;
            radiobtn_NoCastrada.Checked = false;
            #endregion
        }

        private void dgvMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MascExistente = new Mascota();

            DataSet ds = new DataSet();

            ds = objNegMascota.listadoMascotas(MascExistente.Codigo.ToString()); //Busco un codigo en particular
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBox(ds);
            }
        }

        private void Ds_a_TxtBox(DataSet ds)
        {
            
        }
    }
}
