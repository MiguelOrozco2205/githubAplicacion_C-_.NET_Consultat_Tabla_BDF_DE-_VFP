using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Newtonsoft.Json;

namespace DevolverFormatoJSON
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         //muestra el JSON GENERADO EN UNA TABLA GRIDVIEW
         string fileJSON = File.ReadAllText(@"C:\Users\Miguel Angel\source\repos\DevolverFormatoJSON\JSON2.json");
         DataTable dt = (DataTable)JsonConvert.DeserializeObject(fileJSON, typeof(DataTable));
         GridView1.DataSource = dt;
         GridView1.DataBind();
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                //RUTA DE LA TABLA DBF
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = @"Provider=vfpoledb;Data Source=C:\Users\Miguel Angel\source\repos\DevolverFormatoJSON\DBExamen;Collating Sequence=machine;";
                //ABRIR CONEXION OleBD
                con.Open();

                //REALIZA UNA CONSULTA  DE LA TABLA 
                OleDbCommand ocmd = con.CreateCommand();
                ocmd.CommandText = @"SELECT * FROM tiposgtofilt";
                //EL DataTable CAPTURARA LOS DATOS DEVUELTOS
                DataTable dt = new DataTable();
                dt.Load(ocmd.ExecuteReader());
                //CERRAMOS LA CONEXION
                con.Close();
                //MOSTRAMOS EN EL GridView2 LA TABLA-DBF
                GridView2.DataSource = dt;
                GridView2.DataBind();


                //CONVIERTE Y GUARDA UN FORMATO JSON 
                File.WriteAllText(@"C:\Users\Miguel Angel\source\repos\DevolverFormatoJSON\JSON2.json", "[" + JsonConvert.SerializeObject(dt, Formatting.Indented) + "]");
                Response.Write("<script>alert('SE CREO LA CONEXION Y UN ARCHIVO JSON CON EXITO!!') </script>");

            }
            catch (OleDbException exp)
            {
                Response.Write("<script>alert('Ocurrio Un Error!!') </script>" + exp);
                //MessageBox.Show("Error: " + exp.Message);
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            //crea un nuevo egisgro y lo guarda en un formato JSON
            /*
            Cliente cliente = new Cliente
            {
                Tgt_Clave = txtTgt_Clave.Text,
                Tgt_desc = txtTgt_desc.Text,
                Rgd_tipo = txtRgd_tipo.Text,
                Rgd_clave = txtRgd_clave.Text,
                Rgd_desc = txtRgd_desc.Text
            };

            txtTgt_Clave.Text = "";
            txtTgt_desc.Text = "";
            txtRgd_tipo.Text = "";
            txtRgd_clave.Text = "";
            txtRgd_desc.Text = "";

            if (Session["ARCHIVOJSON"].ToString() == string.Empty)
                Session["ARCHIVOJSON"] = JsonConvert.SerializeObject(cliente);
            else
                Session["ARCHIVOJSON"] = Session["ARCHIVOJSON"].ToString() + "," + JsonConvert.SerializeObject(cliente);
            ltbCliente.Items.Add("Tgt_Clave" + cliente.Tgt_Clave + "Tgt_desc" + cliente.Tgt_desc + "Rgd_tipo" + cliente.Rgd_tipo + "Rgd_clave" +  cliente.Rgd_clave + "Rgd_desc" + cliente.Rgd_desc);
            */
        }

        protected void BtnJSON_Click(object sender, EventArgs e)
        {
            /*
            File.WriteAllText(@"C:\Users\Miguel Angel\Desktop\json\JSON.json", "[" + Session["ARCHIVOJSON"].ToString() + "]");
            Response.Write("<script>alert('JSON Listo!!') </script>");
            */
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            
        }
    }
}