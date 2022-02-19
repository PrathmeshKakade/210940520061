using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationExam.Models;

namespace WebApplicationExam.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductContainer1;Integrated Security=True;Connect Timeout=30;";
            sc.Open();
            SqlCommand cd = new SqlCommand();
            cd.Connection = sc;
            cd.CommandType = System.Data.CommandType.StoredProcedure;
            cd.CommandText = "select *from Products";
            SqlDataReader sdr = cd.ExecuteReader();
            List<product> productlist = new List<product>();
            while (sdr.Read())
            {
                product model = new product();
                model.ProductId = int.Parse(sdr["ProdctId"].ToString());
                model.ProductName = sdr["productname"].ToString();
                model.Rate = double.Parse(sdr["rate"].ToString());
                model.Description = sdr["description"].ToString();
                model.CategoryName = sdr["categoryname"].ToString();
                productlist.Add(model);
            }
            return View(productlist);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
          
           
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                
                SqlConnection cn1 = new SqlConnection();
                cn1.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductContainer1;Integrated Security=True;Connect Timeout=30;";
                cn1.Open();
                SqlCommand cmdget = new SqlCommand();
                cmdget.Connection = cn1;
                cmdget.CommandType = System.Data.CommandType.StoredProcedure;
                cmdget.CommandText = "update Products set ProductName=@productname,Description=@description,Rate=@rate,categoryname=@categoryname where ProductId=@productid";
                cmdget.Parameters.AddWithValue("@productid", SqlDbType.Int).Value = id;
                cmdget.Parameters.AddWithValue("@productname", SqlDbType.VarChar).Value = collection["ProductName"].ToString();
                cmdget.Parameters.AddWithValue("@description", SqlDbType.VarChar).Value = collection["Description"].ToString();
                cmdget.Parameters.AddWithValue("@rate", SqlDbType.Decimal).Value = collection["Rate"].ToString();
                cmdget.Parameters.AddWithValue("@categoryname", SqlDbType.VarChar).Value = collection["CategoryName"].ToString();


                cmdget.ExecuteNonQuery();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
