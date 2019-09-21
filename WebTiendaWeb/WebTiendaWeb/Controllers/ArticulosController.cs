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
    public class ArticulosController : Controller
    {
       
        string RutaConex = @"Data Source = DESKTOP-2VNKGS9\SQLEXPRESS; Database = Tienda; User Id = sa; Password = Passw0rd;";
        // GET: Catalogo de Articulos NO usamos Clase ArticuloModel para esta Accion
        [HttpGet]
        public ActionResult Index()
        {
            DataTable vDT = new DataTable();
            using (SqlConnection sqlConex = new SqlConnection(RutaConex))
            {
                sqlConex.Open();
                string cadSQL = "Select * From Articulos";
                SqlDataAdapter vDA = new SqlDataAdapter(cadSQL,sqlConex);
                vDA.Fill(vDT);
                sqlConex.Close();
            }  

            return View(vDT);
        }

 
        // GET: Articulos/Create
        public ActionResult Create()
        {
            return View(new ArticuloModel());
        }

        // POST: Articulos/Create
        [HttpPost]
        public ActionResult Create(ArticuloModel articuloModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }








        // GET: Articulos/Edit/ Falta Programar
        public ActionResult Edit(int id)
        {
            return View();
        }

      
        // GET: Articulos/Delete/ Falta Programar
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
