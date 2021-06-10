using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BabaRh.Api.Controllers
{
    using BabaRh.AccessLayer.EntityFramework.AccessLayers;
    using BabaRh.AccessLayer.Models;

    public class QuizzesController : ApiController
    { 
        private readonly QuizzAccessLayer quizzAccessLayer = QuizzAccessLayer.Instance;
        private readonly ModuleAccessLayer moduleAccessLayer = ModuleAccessLayer.Instance;
        private readonly QuestionAccessLayer questionAccessLayer = QuestionAccessLayer.Instance;

        // GET api/quizzes
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = quizzAccessLayer.GetAll();

            return this.Ok(result);
        }

        // GET api/quizzes/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var result = quizzAccessLayer.Get(id);

            return this.Ok(result);
        }



        //[HttpPost]
        //public async Task<IHttpActionResult> Create([FromBody] Pizza pizza)
        //{
        //    if (!doughAccessLayer.Exists(pizza.Dough.Id))
        //    {
        //        return this.NotFound();
        //    }

        //    if (!ingredientAccessLayer.Exists(pizza.Ingredients.Select(i => i.Id).ToList()))
        //    {
        //        return this.NotFound();
        //    }

        //    var pizzaToAdd = new DataAccessLayer.Models.Pizza
        //    {
        //        Name = pizza.Name,
        //        DoughId = pizza.Dough.Id,
        //    };

        //    pizzaToAdd.IngredientPizzas = pizza.Ingredients.Select(ip => new DataAccessLayer.Models.IngredientPizza { IngredientId = ip.Id, Pizza = pizzaToAdd }).ToList();

        //    await pizzaAccessLayer.AddAsync(pizzaToAdd);
        //    return this.Ok("created");
        //}

        //[HttpPut]
        //public async Task<IHttpActionResult> Update(int id, [FromBody] Pizza pizza)
        //{
        //    if (!doughAccessLayer.Exists(pizza.Dough.Id))
        //    {
        //        return this.NotFound();
        //    }

        //    if (!ingredientAccessLayer.Exists(pizza.Ingredients.Select(i => i.Id).ToList()))
        //    {
        //        return this.NotFound();
        //    }

        //    var pizzaToUpdate = new DataAccessLayer.Models.Pizza
        //    {
        //        Id = pizza.Id,
        //        Name = pizza.Name,
        //        DoughId = pizza.Dough.Id,
        //        IngredientPizzas = pizza.Ingredients.Select(i => new DataAccessLayer.Models.IngredientPizza { IngredientId = i.Id, PizzaId = pizza.Id }).ToList()
        //    };

        //    await pizzaAccessLayer.UpdateAsync(pizzaToUpdate);

        //    return this.Ok("updated");
        //}

        //[HttpDelete]
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    var pizzaToDelete = pizzaAccessLayer.Get(id);

        //    if (pizzaToDelete == null)
        //    {
        //        return this.NotFound();
        //    }

        //    await pizzaAccessLayer.DeleteAsync(pizzaToDelete.Id);
        //    return this.Ok("Delete");
        //}
    }
}
