using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace LibrosProyecto
{
    public partial class frmAreasControl : Form
    {
        public frmAreasControl()
        {
            InitializeComponent();
            Cargar();
        }
        public void Cargar()
        {
            dataGridView1.DataSource = new DAOArea().ObtenerTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbAddMod.Text = "Modificar";
            btnAgregar.Text = "Modificar";
            dataGridView1.Enabled = false;
            if (dataGridView1.SelectedRows.Count>0)
            {
                int idPro = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                Area area= new DAOArea().ObtenerUno(idPro);
                txtNombre.Text = area.Nombre.ToString();
                txtUbi.Text= area.Ubicacion.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idPro = int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                DialogResult dialog = MessageBox.Show("Estas a punto de eliminar el area de "+ dataGridView1.SelectedRows[0].Cells["Nombre"].Value.ToString() + " y todos los libros relacionados a esta area ¿Deseas continuar?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (DialogResult.Yes== dialog)
                {
                    bool res = new DAOArea().eliminar(idPro);
                    if (res)
                    {
                        MessageBox.Show("Eliminado exitosa mente");
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("A ocurrido un problema");
                    }
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gbAddMod.Text == "Modificar")
            {
                Area area = new Area();
                area.Nombre=txtNombre.Text;
                area.Ubicacion = txtUbi.Text;
                area.id= int.Parse(dataGridView1.SelectedRows[0].Cells["id"].Value.ToString());
                if (new DAOArea().editar(area))
                {
                    MessageBox.Show("Modificado con exito");
                    Cargar();
                }
                else
                {
                    MessageBox.Show("A ocurrido un error");
                }
                gbAddMod.Text = "Agregar";
                btnAgregar.Text = "Agregar";
                txtNombre.Text = "";
                txtUbi.Text = "";
                dataGridView1.Enabled = true;
            }
            else
            {
                Area area = new Area();
                area.Nombre = txtNombre.Text;
                area.Ubicacion = txtUbi.Text;
                if (new DAOArea().agregar(area)>0)
                {
                    MessageBox.Show("Agregado con exito");
                    Cargar();
                }
                else
                {
                    MessageBox.Show("A ocurrido un error");
                }
                txtNombre.Text = "";
                txtUbi.Text = "";
            }
        }
    }
}
