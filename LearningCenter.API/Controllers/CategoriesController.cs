using System.Net.Mime;
using System.Security;
using AutoMapper;
using LearningCenter.API.Filter;
using LearningCenter.API.Reponse;
using LearningCenter.API.Resources;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers;



[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryDomain _categoryDomain;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryDomain categoryDomain, IMapper mapper)
    {
        _categoryDomain = categoryDomain;
        _mapper = mapper;
    }

    // GET: api/Categories
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    //GET api/categories/byName?name
    [HttpGet("byName")]
    [Authorize("root,admin,employee,customer")]
    public async Task<IActionResult> Get(string name,int p )
    {
        try
        {
            //var value = 10 / p;
            //int newValue = "Diez"; "true" , "1" ,"verdadero"
            //Int16 i = p;

            var result = await _categoryDomain.getAll(name);
            return Ok(_mapper.Map<List<Category>, List<CategoryResource>>(result));
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
        finally
        {
            
        }
    }

    // GET: api/Categories/5
    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<IActionResult> Get(int id)
    {
        //Captura datos y la repuesta //Autorizacion
        //var result = new CategoryDomain().getCategoryById(id);
        try
        {
            if (id == 0)
            {
                return BadRequest("Id");
            }

            var result = await _categoryDomain.getCategoryById(id); ///intelisense
            /*var response = new CategoryResponse()
            {
                Success = true, Message = "Operacion realizada con esito", result

            };*/
            return Ok(_mapper.Map<Category, CategoryResource>(result));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }

    // POST: api/Categories
    [HttpPost]
    [Authorize("root,admin")]
    [ProducesResponseType(typeof(IActionResult), 201)]
    [ProducesResponseType(typeof(List<Category>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post([FromBody] CategoryResource categoryInput)
    {
        /* var category = new Category()
         {
             Name = categoryInput.Name,
             Description = categoryInput.Description
         };*/
        /*if (categoryInput.Name == "" || categoryInput.Name == null)
        {
            throw CheckoutException.Canceled;
        }*/

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error de formato");
            }

            var category = _mapper.Map<CategoryResource, Category>(categoryInput);

            var result = await _categoryDomain.createCategory(category);

            return StatusCode(StatusCodes.Status201Created, "category created");
        }
        catch (ArgumentException argumentException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, argumentException.Message);
        }
        catch (InvalidCastException invalidCastException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Error interno al castear");
        }
        catch (VerificationException verificationException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, verificationException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar , intente mas tarde");
        }
    }

    // PUT: api/Categories/5
    [HttpPut("{id}")]
    [Authorize("root,admin")]
    public async Task<IActionResult> Put(int id, [FromBody] Category category)
    {
        try
        {
            var result = await _categoryDomain.updateCategory(id, category);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _categoryDomain.deleteCategory(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }

    }
}