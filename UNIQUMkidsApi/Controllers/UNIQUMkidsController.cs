using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UNIQUMkidsCore;
using System.Net;
using System.Text.Json;
namespace UNIQUMkidsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UNIQUMkidsController : ControllerBase
    {
        private readonly ILogger<UNIQUMkidsController> _logger;

        public UNIQUMkidsController(ILogger<UNIQUMkidsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("parent")]
        public ActionResult<IEnumerable<Parent>> GetParents()
        {
            var parents = GetDataFromDB.GetParent();

            if (parents == null)
                return NoContent();

            return Ok(parents);
        }

        [HttpGet("parent/{id}")]
        public Parent GetParents(int id)
        {
            try
            {
                return GetDataFromDB.GetParent().Find(x => x.id_Parent == id);
            }
            catch (Exception ex)
            {
                return new Parent();
            }
        }
        [HttpGet("child/{id_Parent}")]
        public Child GetChilds(int id)
        {
            try
            {
                return GetDataFromDB.GetChild().Find(x => x.id_Parent == id);
            }
            catch (Exception ex)
            {
                return new Child();
            }
        }

    }
}
