using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> companyList = _unitOfWork.CompanyRepository.GetAll().ToList();

            return View(companyList);
        }

        public IActionResult Upsert(int? id)
        {
            Company companyObj = new Company();
            
            if (id == null || id == 0)
            {
                return View(companyObj);
            }
            else
            {
                companyObj = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if(company.Id == 0)
            {
                _unitOfWork.CompanyRepository.Add(company);
            }
            else
            {
                _unitOfWork.CompanyRepository.Update(company);
            }
            _unitOfWork.Save();
            TempData["success"] = "Company added successfully";
            return RedirectToAction("Index");
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var companyToBeDeleted = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if(companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error deleting company" });
            }

            _unitOfWork.CompanyRepository.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            List<Company> companyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return Json(new { success = true, message = "Deleted company successfully." });
        }
        #endregion
    }
}
