using Logistica.Model;
using Logistica.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistica.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LogisticsController : ControllerBase
    {
        private readonly ILogisticRepository _logisticRepository;

        public LogisticsController(ILogisticRepository logisticRepository)
        {
            _logisticRepository = logisticRepository;
        }
        // GET: v1/<LogisticsController>
        /// <summary>
        /// Obtiene todos los registros de logistica
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var logistic = _logisticRepository.GetLogistic();
            return new OkObjectResult(logistic);
        }

        // GET v1/<LogisticsController>/5
        /// <summary>
        /// Obtiene un registro, se debe enviar un Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var logistic = _logisticRepository.GetLogisticById(id);
            return new OkObjectResult(logistic);
        }

        // POST v1/<LogisticsController>
        /// <summary>
        /// Crea un nuevo registro en logistica, se debe enviar la informacion del esquema
        /// </summary>
        /// <param name="logistic"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public IActionResult Post([FromBody] Logistic logistic)
        {
            using (var scope = new TransactionScope())
            {
                _logisticRepository.InsertLogistic(logistic);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = logistic.Id }, logistic);
            }
        }

        // PUT v1/<LogisticsController>/5
        /// <summary>
        /// Se actualiza un registro de losgistica, se debe enviar la estructura del esquema
        /// </summary>
        /// <param name="id"></param>
        /// <param name="logistic"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Logistic logistic)
        {
            if (logistic != null)
            {
                using (var scope = new TransactionScope())
                {
                    _logisticRepository.UpdateLogistic(logistic);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE v1/<LogisticsController>/5
        /// <summary>
        /// Se elimiena un registro de logistica, se debe enviar un Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _logisticRepository.DeleteLogistic(id);
            return new OkResult();
        }
    }
}
