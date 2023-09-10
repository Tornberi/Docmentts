using Microsoft.AspNetCore.Mvc;
using ImportXmlToJson.Models;
using ImportXmlToJson.Domain;
using System.Text.Json;

namespace ImportXmlToJson.Controllers
{
    public class ImportsController : Controller
    {
        private readonly ImportsRepository importsRepository;

        public ImportsController(ImportsRepository importsRepository)
        {
            this.importsRepository = importsRepository;
        }

        public IActionResult Index()
        {
            var model = importsRepository.GetImports();
            return View(model);
        }

        public IActionResult ImportEdit(int? id)
        {
            Imports model = id == null ? new Imports() : importsRepository.GetImportsById(id);
            return View(model);
        }     
        [HttpPost]
        public IActionResult ImportsEdit(Imports model)
        {
            if (ModelState.IsValid)
            {
                importsRepository.SaveImports(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult JsonSerialization(Imports model)
        {
            var dataBase = importsRepository.GetImports();
            var json = JsonSerializer.Serialize(dataBase);
            return Ok(json);
        }

        [HttpPost]
        public IActionResult JsonSerializationByStage(string stage)
        {
            Imports model = stage == null ? new Imports() : importsRepository.GetImportsByStage(stage);
            var json = JsonSerializer.Serialize(model);
            return Ok(json);
        }
    }
}
