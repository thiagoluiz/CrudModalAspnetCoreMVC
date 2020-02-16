using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Persistence;
using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            PacienteDAL pd = new PacienteDAL();
            return View(pd.ListaPacientes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "IdPaciente,Nome,Idade,Peso,Altura")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                PacienteDAL pd = new PacienteDAL();
                pd.InserirPaciente(paciente);

                TempData["warning"] = "Mensagem de warning!!";
                TempData["success"] = "Mensagem de sucesso!!";
                TempData["info"] = "Mensagem de informação!!";
                TempData["error"] = "Mensagem de erro!!";
                return RedirectToAction("Index","Paciente");
            }


            return View(paciente);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Clientes.Find(id);
            PacienteDAL pd = new PacienteDAL();
            Paciente paciente = pd.getPaciente(id);


            if (paciente == null)
            {
                //return HttpNotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "IdPaciente,Nome,Idade,Peso,Altura")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                PacienteDAL pd = new PacienteDAL();
                pd.EditarPaciente(paciente);
                //db.Entry(cliente).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PacienteDAL pd = new PacienteDAL();
            Paciente paciente = pd.getPaciente(id);


            //Paciente paciente = new Paciente();
            //Cliente cliente = db.Clientes.Find(id);
            //if (cliente == null)
            //{
            //    return HttpNotFound();
            //}

            
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PacienteDAL pd = new PacienteDAL();
            pd.DeletarPaciente(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PacienteDAL pd = new PacienteDAL();
            Paciente paciente = pd.getPaciente(id);


            if (paciente == null)
            {
            //    return HttpNotFound();
            }
            return View(paciente);
        }

    }
}