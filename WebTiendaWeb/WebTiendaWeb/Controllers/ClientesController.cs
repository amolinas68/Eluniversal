using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;

using WebTiendaWeb.Models;

namespace WebTiendaWeb.Controllers
{
    public class ClientesController : Controller
    {
        string RutaConex = @"Data Source = DESKTOP-2VNKGS9\SQLEXPRESS; Database = Tienda; User Id = sa; Password = Passw0rd;";
        // GET: Catalogo de Clientes
        [HttpGet]
        public ActionResult Index()
        {
            DataTable vDT = new DataTable();
            using (SqlConnection sqlConex = new SqlConnection(RutaConex))
            {
                sqlConex.Open();
                string cadSQL = "Select * From Clientes";
                SqlDataAdapter vDA = new SqlDataAdapter(cadSQL, sqlConex);
                vDA.Fill(vDT);
                sqlConex.Close();
            }

            return View(vDT);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View(new ClientesModel());
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClientesModel clientes)
        {
            DataTable vDT = new DataTable();
            using (SqlConnection sqlConex = new SqlConnection(RutaConex))
            {
                sqlConex.Open();
                string cadSQL = "Insert Into Clientes Values (@IdCliente,@Nombre,@Email)";
                SqlCommand vComd = new SqlCommand(cadSQL, sqlConex);
                vComd.Parameters.AddWithValue("@IdCliente", clientes.IdCliente);
                vComd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                vComd.Parameters.AddWithValue("@Email", clientes.Email);
                vComd.ExecuteNonQuery();  
                sqlConex.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            ClientesModel clientesModel = new ClientesModel();
            DataTable vDT = new DataTable();
            using (SqlConnection sqlConex = new SqlConnection(RutaConex))
            {
                sqlConex.Open();
                string cadSQL = "Select * From Clientes Where IdCliente=@IdCliente";
                SqlDataAdapter vDA = new SqlDataAdapter(cadSQL, sqlConex);
                vDA.SelectCommand.Parameters.AddWithValue("@IdCliente", id);
                vDA.Fill(vDT);
            }
            if (vDT.Rows.Count == 1)
            {
                clientesModel.IdCliente = Convert.ToInt32(vDT.Rows[0]["IdCliente"].ToString());
                clientesModel.Nombre = vDT.Rows[0]["Nombre"].ToString();
                clientesModel.Email = vDT.Rows[0]["Email"].ToString();
                return View(clientesModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientesModel clientes)
        {
            using (SqlConnection sqlConex = new SqlConnection(RutaConex))
            {
                sqlConex.Open();
                string cadSQL = "Update Clientes Set Nombre=@Nombre," +
                                " Email=@Email " +
                                " Where IdCliente=@IdCliente";
                SqlCommand vComd = new SqlCommand(cadSQL, sqlConex);
                vComd.Parameters.AddWithValue("@IdCliente", clientes.IdCliente);
                vComd.Parameters.AddWithValue("@Nombre", clientes.Nombre);
                vComd.Parameters.AddWithValue("@Email", clientes.Email);
                vComd.ExecuteNonQuery();
                sqlConex.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
