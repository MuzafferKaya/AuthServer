using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.User;
using Dto.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] UserAddRequest request)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                var newUser = await _userService.AddAsync(user);
                await _unitOfWork.CommitTransactionAsync();
                return Created(string.Empty, newUser);
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
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IList<UserGetAllResponse>>(users));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserUpdateRequest request)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                var updatedUser = await _userService.UpdateAsync(user);
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
