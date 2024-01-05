using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Customer;
using Dto.Response.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerService = customerService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CustomerAddRequest request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request);
                var newCustomer = await _customerService.AddAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                return Created(string.Empty, newCustomer);                
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<IList<CustomerGetAllResponse>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerGetByIdResponse>(customer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerUpdateRequest request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request);
                var updatedCustomer = await _customerService.UpdateAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                var customer = await _customerService.GetByIdAsync(id);
                await _customerService.RemoveAsync(customer);
                await _unitOfWork.CommitTransactionAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }
    }
}
