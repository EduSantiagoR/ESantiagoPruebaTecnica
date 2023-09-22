using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Result result = BL.Disco.GetAll();
            ML.Disco disco = new ML.Disco();
            disco.Discos = result.Objects;
            return View(disco);
        }
        public ActionResult Form() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if(disco.IdDisco == 0) //Add
            {
                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Agregado de manera éxitosa.";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar.";
                    return PartialView("Modal");
                }
            }
            else
            {
                return View();
            }
        }
    }
}