using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Role;
using Dto.Response.Role;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/[controller]s")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleService = roleService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RoleAddRequest request)
        {
            try
            {
                var role = _mapper.Map<Role>(request);
                var newRole = await _roleService.AddAsync(role);
                await _unitOfWork.CommitTransactionAsync();
                return Created(string.Empty, newRole);
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
            var roles = await _roleService.GetAllAsync();
            return Ok(_mapper.Map<IList<RoleGetAllResponse>>(roles));
        }
    }
}
