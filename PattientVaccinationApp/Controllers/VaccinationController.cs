using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PattientVaccinationApp.ActionFilters;
using PattientVaccinationApp.Core.Model;
using PattientVaccinationApp.Models;
using PattientVaccinationApp.Service.Vaccination;

namespace PattientVaccinationApp.Controllers
{
    [LogAction]
    public class VaccinationController : Controller
    {
        #region Fields

        private readonly IVaccinationService _vaccinationService;

        #endregion

        #region Constructor

        public VaccinationController(IVaccinationService vaccinationService)
        {
            _vaccinationService = vaccinationService;
        }

        #endregion

        #region Methods

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vaccine,IsVaccinationAllowed,ReleaseDate,PatientId")]
            VaccinationDto vaccinationDto)
        {
            if (ModelState.IsValid)
            {
                Vaccination vaccination = Mapper.Map<VaccinationDto, Vaccination>(vaccinationDto);
                _vaccinationService.Insert(vaccination);
                return RedirectToAction("Details", "Patient", new { id = vaccinationDto.PatientId });
            }

            return View(vaccinationDto);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VaccinationDto vaccination = Mapper.Map < Vaccination, VaccinationDto>(_vaccinationService.Get((int)id));
            if (vaccination == null)
            {
                return HttpNotFound();
            }
            return View(vaccination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vaccine,IsVaccinationAllowed,ReleaseDate,PatientId")] VaccinationDto vaccinationDto)
        {
            if (ModelState.IsValid)
            {
                Vaccination vaccination = Mapper.Map<VaccinationDto, Vaccination>(vaccinationDto);
                _vaccinationService.Update(vaccination);
                return RedirectToAction("Details", "Patient", new { id = vaccinationDto.PatientId });
            }

            return View(vaccinationDto);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PatientDto patient = Mapper.Map<Patient, PatientDto>(_patientService.Get((int)id));
            VaccinationDto vaccination = Mapper.Map < Vaccination, VaccinationDto> (_vaccinationService.Get((int)id));

            if (vaccination == null)
            {
                return HttpNotFound();
            }

            return View(vaccination);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccination vaccination = _vaccinationService.Get(id);
            _vaccinationService.Delete(vaccination);

            return RedirectToAction("Details", "Patient", new { id = vaccination.PatientId });
        }

        #endregion
    }
}