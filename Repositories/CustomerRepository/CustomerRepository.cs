using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO.CustomerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repositories.CustomerRepository
{
    /// <summary>
    /// implements interface methods
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// dependency injection to the DbContext
        /// </summary>
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// implement Add Operation
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task AddCustomer(AddCustomerDTO customer)
        {
            try
            {
                var cust = new Customer();
                cust.Name = customer.Name;
                cust.PhoneNumber = customer.PhoneNumber;
                cust.PaymentType = customer.PaymentType;
                cust.CreatedDate = customer.CreatedDate;
                cust.CreatedBy = customer.CreatedBy;

                await _context.Customers.AddAsync(cust);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// implement Delete Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCustomer(int id)
        {
            try
            {
                var result = await _context.Customers.FirstOrDefaultAsync(x => x.PKCostomerId == id && x.IsActive);
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDelete = true;
                    result.ModifiedDate = DateTime.Now;
                    result.Modifiedby = 1;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// implement Getall Operation
        /// </summary>
        /// <returns></returns>
        public async Task<List<GetCustomerDTO>> GetAll()
        {
            try
            {
                var result =await _context.Customers.Include(x => x.FoodItems).Where(x => x.IsActive && !x.IsDelete).Select(
              x => new GetCustomerDTO
              {
                  PKCostomerId = x.PKCostomerId,
                  Name = x.Name,
                  PhoneNumber = x.PhoneNumber,
                  PaymentType = x.PaymentType,
                  CreatedDate = x.CreatedDate,
                  CreatedBy = x.CreatedBy
              }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// implement GetbyId Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetCustomerDTO> GetById(int id)
        {
            try
            {
                var result = await _context.Customers.Where(x => x.PKCostomerId == id && x.IsActive && !x.IsDelete).Include(x => x.FoodItems).Select(
               x => new GetCustomerDTO
               {
                   PKCostomerId = x.PKCostomerId,
                   Name = x.Name,
                   PhoneNumber = x.PhoneNumber,
                   PaymentType = x.PaymentType,
                   CreatedDate = x.CreatedDate,
                   CreatedBy = x.CreatedBy
               }).FirstOrDefaultAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        /// <summary>
        /// implement Update Operation
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task UpdateCustomer(UpdateCustomerDTO customer)
        {
            try
            {
                var result = await _context.Customers.FirstOrDefaultAsync(x => x.PKCostomerId == customer.CostomerId);
               if (result != null)
                {
                    result.PKCostomerId = customer.CostomerId;
                    result.Name = customer.Name;
                    result.PhoneNumber = customer.PhoneNumber;
                    result.PaymentType = customer.PaymentType;
                    result.CreatedDate = customer.CreatedDate;
                    result.CreatedBy = customer.CreatedBy;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
