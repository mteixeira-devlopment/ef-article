using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFArticle.DataAccess;
using EFArticle.Dtos;
using EFArticle.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFArticle.Controllers
{
    [ApiController]
    [Route("ef-article")]
    public class EfArticleController : ControllerBase
    {
        private readonly EfArticleDbContext _efArticleDbContext;

        public EfArticleController(EfArticleDbContext efArticleDbContext)
        {
            _efArticleDbContext = efArticleDbContext;
        }
        
        [HttpGet]
        [Route("linq-query_sintax-sample")]
        public IEnumerable<Guid> LinqQuerySintaxSample()
        {
            var query =
                from pe in _efArticleDbContext.Persons
                where pe.Name == "Jonh"
                select pe.Id;

            var result = query.ToList();

            return result;
        }

        [HttpGet]
        [Route("linq-method_sintax-sample")]
        public IEnumerable<Guid> LinqMethodSintaxSample()
        {
            var query = _efArticleDbContext.Persons
                .Where(pe => pe.Name == "Jonh")
                .Select(pe => pe.Id);

            var result = query.ToList();

            return result;
        }

        [HttpPost]
        [Route("person")]
        public IActionResult CreatePerson(NewPersonDto model)
        {
            var document = new Document(model.UniqueIdentifierRegister, model.DriveLicence);
            var person = new Person(model.Name, document);

            person.AddAddress(model.City, model.Street, model.Number);

            _efArticleDbContext.Add(person);
            _efArticleDbContext.SaveChanges();

            return Ok();
        }
    }
}
