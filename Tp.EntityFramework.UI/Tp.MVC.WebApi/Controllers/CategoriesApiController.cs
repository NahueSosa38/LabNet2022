using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Tp.EntityFramework.Entities;
using Tp.EntityFramework.Logic;
using Tp.MVC.WebApi.Models;

namespace Tp.MVC.WebApi.Controllers
{
    public class CategoriesApiController : ApiController
    {
        // GET: CategoriesApi

        public CategoriesLogic logic = new CategoriesLogic();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<CategoriesResponse> categoriesResponse;

                var categories = logic.GetAll();

                categoriesResponse = categories.Select(s => new CategoriesResponse
                {
                    Id = s.CategoryID,
                    Name = s.CategoryName,
                    Descripcion = s.Description


                }).ToList();

                return Ok (categoriesResponse);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]

        public IHttpActionResult Get(int id)
        {
            try
            {
                var categories = logic.GetAll();
                Categories mapeoCat = categories.Find(s => s.CategoryID == id);

                if (mapeoCat == null)
                {
                    return NotFound();
                }
                else
                {
                    CategoriesResponse categoriesResponse = new CategoriesResponse
                    {
                        Id = mapeoCat.CategoryID,
                        Name = mapeoCat.CategoryName,
                        Descripcion = mapeoCat.Description
                    };

                    return Ok(categoriesResponse);
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] CategoriesRequest CategoriesRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories CatToInsert = new Categories
                    {
                        CategoryID = CategoriesRequest.Id,
                        CategoryName = CategoriesRequest.Name,
                        Description = CategoriesRequest.Descripcion
                       
                    };

                    logic.Add(CatToInsert);
                    return Ok(CatToInsert);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] CategoriesRequest catRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool catExists = logic.GetAll().Exists(s => s.CategoryID == id);

                    if (catExists)
                    {
                        Categories updatedCat = new Categories
                        {
                            CategoryID = catRequest.Id,
                            CategoryName = catRequest.Name,
                            Description = catRequest.Descripcion
                        };

                        logic.Update(updatedCat);

                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var catToDelete = logic.GetAll().Find(s => s.CategoryID == id);
                if (catToDelete != null)
                {
                    logic.Delete(id);

                    return Ok(catToDelete);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
