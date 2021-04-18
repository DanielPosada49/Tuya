using Facturar.Model;
using Facturas.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Facturas.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class invoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public invoicesController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // GET: v1/<invoicesController>
        /// <summary>
        /// Obtiene todas las facturas existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var invoice = _invoiceRepository.GetInvoices();
            return new OkObjectResult(invoice);
        }

        // GETBYID v1/<invoicesController>/5
        /// <summary>
        /// Obtiene una factura especifica, se debe agregar el id de la factura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var invoice = _invoiceRepository.GetInvoiceById(id);
            return new OkObjectResult(invoice);
        }

        // POST v1/<invoicesController>
        /// <summary>
        /// Crea una nueva factura, se deben enviar algunos datos en base de esquema
        /// </summary>
        /// <param name="invoice.Client"></param>
        /// <param name="invoice.Document"></param>
        /// <param name="invoice.ProductId"></param>
        /// <param name="invoice.Amount"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            using (var scope = new TransactionScope())
            {
                _invoiceRepository.InsertInvoice(invoice);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = invoice.Id }, invoice);
            }
        }

        // PUT v1/<invoicesController>/5
        /// <summary>
        /// Se actualiza una factura, se debe enviar el id de la factura
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Invoice invoice)
        {
            if (invoice != null)
            {
                using (var scope = new TransactionScope())
                {
                    _invoiceRepository.UpdateInvoice(invoice);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE v1/<invoicesController>/5
        /// <summary>
        /// Se elimina una factura, se debe enviar el id de la factura
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _invoiceRepository.DeleteInvoice(id);
            return new OkResult();
        }
    }
}
