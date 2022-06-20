using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp.EntityFramework.Entities;
using Tp.EntityFramework.Logic;
using Tp.MVC.First.Models;

namespace Tp.MVC.First.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic Categories = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Tp.EntityFramework.Entities.Categories> listaCat = Categories.GetAll();

            List<CategoriesView> catView = listaCat.Select(s => new CategoriesView
            {
                Id = s.CategoryID,
                Name = s.CategoryName,
                Descripcion = s.Description

            }).ToList();

            return View(catView);
        }

        public ActionResult AgregarModificar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarModificar(CategoriesView categoriesView)
        {
            if (categoriesView.Id == 0)
            {
                try
                {
                    Categories categoriesEntity = new Categories
                    {
                        CategoryName = categoriesView.Name,

                        Description = categoriesView.Descripcion
                    };

                    Categories.Add(categoriesEntity);

                    return RedirectToAction("Index");
                }

                catch (FormatException formato)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = formato.Message,
                        mensajePerso = "Ingrese una ID correcta"
                    });
                }

                catch (OverflowException sobrecarga)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = sobrecarga.Message,
                        mensajePerso = "Hubo una sobrecarga en los datos ingresados"
                    });
                }

                catch (System.InvalidOperationException invalida)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        exceptionMessage = invalida.Message,
                        customMessage = "La operacion es invalida"
                    });
                }

                catch (Exception general)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = general.Message,
                        mensajePerso = "Ocurrió un error inesperado"
                    });
                }
            }
            else
            {
                try
                {
                    Categories categoriesEntity = new Categories

                    {
                        CategoryID = categoriesView.Id,
                        CategoryName = categoriesView.Name,
                        Description = categoriesView.Descripcion
                    };

                    Categories.Update(categoriesEntity);  


                    return RedirectToAction("Index");

                }
                catch (FormatException formato)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = formato.Message,
                        mensajePerso = "Ingrese el formato correcto"
                    });
                }

                catch (OverflowException sobrecarga)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = sobrecarga.Message,
                        mensajePerso = "Hubo una sobrecarga en los datos ingresados"
                    });
                }

                catch (System.InvalidOperationException invalida)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        exceptionMessage = invalida.Message,
                        customMessage = "La operacion es invalida"
                    });
                }

                catch (Exception general)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        mensajeExcepcion = general.Message,
                        mensajePerso = "Ocurrió un error inesperado"
                    });
                }
            }
        }

            public ActionResult Borrar(int id)
        {
            try
            {
                Categories.Delete(id);

                return RedirectToAction("Index", "Categories");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException datoAsociado)
            {
                return RedirectToAction("Index", "Error", new
                {
                    mensajeExcepcion = datoAsociado.Message,
                    mensajePerso = "No es posible eliminar un dato asociado"
                });
            }
        }    

    }
}