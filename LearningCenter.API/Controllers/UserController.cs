using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningCenter.API.Handler.Query.Login;
using LearningCenter.API.Resources;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        
        public UserController(IUserDomain userDomain,IMapper mapper,IMediator mediator )
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _mediator = mediator;
        }
        // GET: api/User
        [HttpPost] 
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
               /// var user = _mapper.Map<UserResource, User>(userResource);
               // var result = await _userDomain.Login(user);
               // return Ok(result);

               var result= await _mediator.Send(loginRequest);

               return Ok(result);
        }   
        
        // GET: api/User
        [HttpPost]
        [AllowAnonymous]
        [Route("Signup")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Signup(UserResource userResource)
        {
            var user = _mapper.Map<UserResource,User>(userResource);
            var result = await _userDomain.Signup(user);
            return Ok();
        }
        
        // GET: api/User
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        

        // PUT: api/User/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        public void Delete(int id)
        {
        }
    }
}
