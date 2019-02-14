using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using PattientVaccinationApp.ActionFilters;
using PattientVaccinationApp.Core.Model;
using PattientVaccinationApp.CustomValidators;
using PattientVaccinationApp.Models;
using PattientVaccinationApp.Service.Patient;

namespace PattientVaccinationApp.Controllers
{
    [LogAction]
    public class PatientController : Controller
    {
        #region Fields

        private readonly IPatientService _patientService;

        #endregion

        #region Constructor

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        #endregion

        #region Methods

        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var patients =
                Mapper.Map<IEnumerable<Patient>, List<PatientDto>>(_patientService.GetAll());
             
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(x => x.FirstName.Contains(searchString) ||
                                               (x.MiddleName!=null && x.MiddleName.Contains(searchString)) ||
                                               x.LastName.Contains(searchString) ||
                                               x.SNILS.Contains(searchString)).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(patients.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PatientDto patient = Mapper.Map<Patient, PatientDto>(_patientService.Get((int)id));

            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,SNILS")] PatientDto patientDto)
        {
            if (!SNILSChecksum.VerifySnils(patientDto.SNILS))
            {
                ModelState.AddModelError("SNILS", "Не правильный формат СНИЛСА!");
            }

            if (ModelState.IsValid)
            {
                Patient patient = Mapper.Map<PatientDto, Patient>(patientDto);
                _patientService.Insert(patient);
                return RedirectToAction("Index");
            }

            return View(patientDto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PatientDto patient = Mapper.Map<Patient, PatientDto>(_patientService.Get((int)id));
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,DateOfBirth,Gender,SNILS")] PatientDto patientDto)
        {
            if (!SNILSChecksum.VerifySnils(patientDto.SNILS))
            {
                ModelState.AddModelError("SNILS", "Не правильный формат СНИЛСА!");
            }

            if (ModelState.IsValid)
            {
                Patient patient = Mapper.Map<PatientDto, Patient>(patientDto);
                _patientService.Update(patient);
                return RedirectToAction("Index");
            }
            return View(patientDto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientDto patient = Mapper.Map<Patient, PatientDto>(_patientService.Get((int)id));
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = _patientService.Get(id);
            _patientService.Delete(patient);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
