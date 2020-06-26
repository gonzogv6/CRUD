using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<TablaViewModel> lst;
            using (CRUDEntities db = new CRUDEntities())
            {
                 lst = (from d in db.tabla
                           select new TablaViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,                               
                               Correo = d.correo
                           }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel1 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities db = new CRUDEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        oTabla.nombre = model.Nombre;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }
                }
                return Redirect("Tabla/");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}