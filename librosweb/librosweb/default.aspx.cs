using LibrosWeb.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace librosweb
{
    public partial class librosweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Libro libro= new Libro();
            libro.isbn= txtISBN.Text;
            libro.titulo= txtTitulo.Text;
            libro.edicion=int.Parse(txtEdi.Text);
            libro.anio_publicacion= txtAnio.Text;
            libro.nombre_autores=txtAutores.Text;
            libro.pais_publicacion= txtPais.Text;
            libro.carrera= lbCarr.SelectedValue.ToString();
            libro.materia= txtMateria.Text;
            libro.sinopsis=txtSinop.Text;
            Libro respuesta = new Libro();
            respuesta.Guardar(libro);
            if (respuesta.Agregado>0)
            {
                lblMensaje.Text = "Agregado";
                Response.Redirect("default.aspx");
            }
            else
            {
                lblMensaje.Text = "Error";
            }
        }
    }
}