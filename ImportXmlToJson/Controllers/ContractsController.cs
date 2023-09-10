using ImportXmlToJson.Domain;
using ImportXmlToJson.Models;
using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImportXmlToJson.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImportXmlToJson.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ContractsRepository contractsRepository;

        public ContractsController(ContractsRepository contractsRepository)
        {
            this.contractsRepository = contractsRepository;
        }

        public IActionResult Index()
        {
            var model = contractsRepository.GetContract();
            return View(model);
        }
        public IActionResult ContractEdit(int? id)
        {
            Contract model = id == null ? new Contract() : contractsRepository.GetContractById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult ContractEdit(Contract model)
        {
            if (ModelState.IsValid)
            {
                contractsRepository.SaveContract(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ContractDelete(int? id)
        {
            contractsRepository.DeleteContract(new Contract() { Id = id });
            return RedirectToAction("Index");
        }

        public async Task<List<Contract>> ImportExcel(IFormFile file)
        {
            var list = new List<Contract>();
            using (var stream = new MemoryStream())
            {
                if (file == null)
                {
                    return list;
                }
                await file.CopyToAsync(stream);
                using (var packeg = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = packeg.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 1; row <= rowcount ; row++)
                    {
                        list.Add(new Contract(){
                            Shifr_Contract = Convert.ToInt32(worksheet.Cells[row, 1].Value.ToString().Trim()),
                            Name_Contract = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Seller = worksheet.Cells[row, 3].Value.ToString().Trim()
                        });
                    }
                }
            }
            foreach (var item in list)
            {
                contractsRepository.SaveContract(item);
            }
            return list;
        }

        public IActionResult Imports()
        {
            return View();
        }
    }
}
