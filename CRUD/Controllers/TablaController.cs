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
                    return Redirect("~/tabla/");
                }
                
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel1 model = new TablaViewModel1();
            using (CRUDEntities db = new CRUDEntities())
            {
                var oTabla = db.tabla.Find(Id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.Fecha_Nacimiento = oTabla.fecha_nacimiento;
                model.Id = oTabla.id;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaViewModel1 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities db = new CRUDEntities())
                    {
                        var oTabla = db.tabla.Find(model.Id);
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        oTabla.nombre = model.Nombre;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/tabla/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                
                var oTabla = db.tabla.Find(Id);
                db.tabla.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/tabla/");
        }
    }
}