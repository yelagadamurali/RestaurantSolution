using Models;
using Models.DTO.CustomerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository
{
    /// <summary>
    /// declare interface methods
    /// </summary>
    public interface ICustomerRepository
    {
        Task<List<GetCustomerDTO>> GetAll();
        Task AddCustomer(AddCustomerDTO customer);
        Task UpdateCustomer(UpdateCustomerDTO customer);
        Task DeleteCustomer(int id);
        Task<GetCustomerDTO> GetById(int id); 
    }
}
