using Modelos;
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

namespace LibrosProyecto
{
    

    public partial class frmAgregar : Form
    {
        public int Agregado = 0;
        public bool Modif = false;
        int op = 0;
        int lib = 0;
        public frmAgregar(int i, int id)
        {
            InitializeComponent();
            op = i;
            lib = id;
            cboArea.DataSource= new DAOArea().ObtenerTodos();
            cboArea.DisplayMember = "Nombre";
            cboArea.ValueMember = "id";

        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            //op 2 Modificar
            if (op == 2)
            {
                inventario libro = new DAOLibro().ObtenerUno(lib);
                txtNom.Text= libro.NombreCorto.ToString();
                txtDesc.Text= libro.Descripcion.ToString();
                txtObs.Text= libro.Observaciones.ToString();
                txtSer.Text= libro.Serie.ToString();
                txtCol.Text= libro.Color.ToString();
                dtpTime.Text= libro.FechaAdquision.ToString();
                cboTipAdq.SelectedText= libro.TipoAdquision.ToString();
                cboArea.SelectedValue = libro.AREAS_id;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //op 1 Agregar
            if (op == 1)
            {
                inventario inventario = new inventario();
                inventario.NombreCorto = txtNom.Text;
                inventario.Descripcion = txtDesc.Text;
                inventario.Serie= txtSer.Text;
                inventario.Observaciones= txtObs.Text;
                inventario.Color= txtCol.Text;
                inventario.TipoAdquision= cboTipAdq.Text;
                inventario.FechaAdquision= dtpTime.Text;
                inventario.AREAS_id = Int32.Parse(cboArea.SelectedValue.ToString()); ;
                int agregar = new DAOLibro().agregar(inventario);
                if (agregar>0)
                {
                    Agregado=agregar;
                    MessageBox.Show("Agregado con exito", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A surjido un problema", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else if(op == 2)
            {
                
                inventario inventario = new inventario();
                inventario.NombreCorto = txtNom.Text;
                inventario.id = lib;
                inventario.Descripcion = txtDesc.Text;
                inventario.Serie = txtSer.Text;
                inventario.Observaciones = txtObs.Text;
                inventario.Color = txtCol.Text;
                inventario.TipoAdquision = cboTipAdq.Text;
                inventario.FechaAdquision = dtpTime.Text;
                inventario.AREAS_id = Int32.Parse(cboArea.SelectedValue.ToString()); ;
                bool midif = new DAOLibro().editar(inventario);
                if (midif)
                {
                    Modif = midif;
                    MessageBox.Show("Modificado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A surjido un problema", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
