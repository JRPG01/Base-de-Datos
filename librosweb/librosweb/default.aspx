<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="librosweb.librosweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="1284px">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="isbn" HeaderText="isbn" SortExpression="isbn" />
                <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                <asp:BoundField DataField="edicion" HeaderText="edicion" SortExpression="edicion" />
                <asp:BoundField DataField="anio_publicacion" HeaderText="anio_publicacion" SortExpression="anio_publicacion" />
                <asp:BoundField DataField="nombre_autores" HeaderText="nombre_autores" SortExpression="nombre_autores" />
                <asp:BoundField DataField="pais_publicacion" HeaderText="pais_publicacion" SortExpression="pais_publicacion" />
                <asp:BoundField DataField="sinopsis" HeaderText="sinopsis" SortExpression="sinopsis" />
                <asp:BoundField DataField="carrera" HeaderText="carrera" SortExpression="carrera" />
                <asp:BoundField DataField="materia" HeaderText="materia" SortExpression="materia" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=WIN-ODSO932OM24;Initial Catalog=librosweb;Persist Security Info=True;User ID=Admin;Password=SQL_Server@123" SelectCommand="SELECT * FROM [libros]"></asp:SqlDataSource>
        <br />
        <h2>Seccion para agregar</h2><br />
        <br />
        <div>
            ISBN del libro.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtISBN" runat="server" Width="246px"></asp:TextBox>
        </div>
        <p>
            Titulo.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTitulo" runat="server" Width="468px"></asp:TextBox>
        </p>
        <p>
            Numero de edicion.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEdi" runat="server" Width="230px" TextMode="Number"></asp:TextBox>
        </p>
        <p>
            Pais de publicacion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPais" runat="server" Width="361px"></asp:TextBox>
        </p>
        <p>
            Autores&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtAutores" runat="server" Width="475px"></asp:TextBox>
        </p>
        <p>
            Año de publicacion.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAnio" runat="server" TextMode="Number" Width="363px"></asp:TextBox>
        </p>
        <p>
            Sinopsis&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p>
            <asp:TextBox ID="txtSinop" runat="server" Height="124px" TextMode="MultiLine" Width="553px"></asp:TextBox>
        </p>
        <p>
            Carrera&nbsp;&nbsp;&nbsp;&nbsp; <asp:ListBox ID="lbCarr" runat="server">
                <asp:ListItem Selected="True">Sistemas Automotrices</asp:ListItem>
                <asp:ListItem>Ambiental</asp:ListItem>
                <asp:ListItem>Sistemas computacionales</asp:ListItem>
                <asp:ListItem>Industrial</asp:ListItem>
                <asp:ListItem>Electronica</asp:ListItem>
                <asp:ListItem>Gestion Empresarial</asp:ListItem>
            </asp:ListBox>
        </p>
        <p>
            Materia.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="526px" OnClick="btnAgregar_Click" />
        </p>
        <p>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
