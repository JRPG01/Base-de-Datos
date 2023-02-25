using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibrosProyecto
{
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
            Cargar();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            

        }
        private void Cargar()
        {
            dgvDatos.DataSource = new DAOLibro().ObtenerTodos();
        }

        private void tsmAdd_Click(object sender, EventArgs e)
        {
            frmAgregar addlib= new frmAgregar(1,0);
            addlib.ShowDialog();
            if (addlib.Agregado>0)
            {
                Cargar();
            }
        }

        private void tsmModif_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                int idPro = int.Parse(dgvDatos.SelectedRows[0].Cells["id"].Value.ToString());
                frmAgregar frm = new frmAgregar(2, idPro);
                frm.ShowDialog();
                if (frm.Modif)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una columna para continar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmElim_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                int idPro = int.Parse(dgvDatos.SelectedRows[0].Cells["id"].Value.ToString());
                DialogResult dialog = MessageBox.Show("Estas a punto de eliminar el libro " + dgvDatos.SelectedRows[0].Cells["NombreCorto"].Value.ToString()+" ¿Desea continuar?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (DialogResult.Yes== dialog)
                {
                    bool eli=new DAOLibro().eliminar(idPro);

                    if (eli)
                    {
                        MessageBox.Show("Eliminado correctamente");
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("A ocurrido un error");
                    }
                }

            }
            else
            {
                MessageBox.Show("Seleccione una columna para continar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreasControl frm= new frmAreasControl();
            frm.ShowDialog();
        }
    }
}
