using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.CustomerDTO;
using Repositories.CustomerRepository;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// DI to ICustomerRepository
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customer)
        {
            _customerRepository= customer;
        }
        /// <summary>
        /// API for Getall Operation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GettAllCustomer")]
        public async Task<List<GetCustomerDTO>> GettAllCustomer()
        {
            try
            {
                var result = await _customerRepository.GetAll();
                return(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        /// <summary>
        /// API for Add Operation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(AddCustomerDTO item)
        {
            try
            {
                await _customerRepository.AddCustomer(item);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }
        /// <summary>
        /// API for Update Operation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO item)
        {
            try
            {
               await _customerRepository.UpdateCustomer(item);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// API for Delete Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
               await _customerRepository.DeleteCustomer(id);
                return Ok(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// API for GetbyId Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        public async Task<GetCustomerDTO> GetById(int id)
        {
            try
            {
             var result =  await _customerRepository.GetById(id);
                return(result);
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
