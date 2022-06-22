using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tp.API.Logic;
using Tp.EntityFramework.Entities;
using Tp.MVC.First.Models;

namespace Tp.MVC.First.Controllers
{
    public class DigimonController : Controller
    {
        // GET: PublicAPI

        DigimonLogic logic = new DigimonLogic();
        public async Task<ActionResult> Index()
        {
            List<Digimon> digimon = await logic.GetDigimon();

            List<DigimonView> digimonsView = digimon.Select(d => new DigimonView()
            {
                Name = d.Name,
                Lvl = d.Level,
                Pic = d.Img

            }).ToList();

            return View(digimonsView);
        }
    }
}