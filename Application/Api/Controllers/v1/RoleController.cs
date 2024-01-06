using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Role;
using Dto.Response.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
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
            var role = _mapper.Map<Role>(request);
            var newRole = await _roleService.AddAsync(role);
            await _unitOfWork.CommitTransactionAsync();
            return Created(string.Empty, newRole);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(_mapper.Map<IList<RoleGetAllResponse>>(roles));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoleUpdateRequest request)
        {
            var role = _mapper.Map<Role>(request);
            await _roleService.UpdateAsync(role);
            await _unitOfWork.CommitTransactionAsync();
            return NoContent();
        }
    }
}
