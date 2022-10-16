using Blog.Data;
using BlogFundamentosAspNet.Extensions;
using BlogFundamentosAspNet.Models;
using BlogFundamentosAspNet.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogFundamentosAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("v1/createcategory")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCategoryViewModel categoryViewModel, [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)//verifica o model state do view model
                return BadRequest(ModelState.GetErrors());

            try
            {
                var category = new Category 
                {
                    Id = 0,
                    Name = categoryViewModel.Name,
                    Slug = categoryViewModel.Slug.ToLower()
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500,"Não foi possível incluir a categoria! ");
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/categories")] //importante para não quebrar a aplicação.
        public async Task<IActionResult> GetAsync(
            [FromServices]BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.AsNoTracking().ToListAsync();
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("Falha interna no servidor"));
            }
        }
        

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]int id, [FromServices] BlogDataContext context)
        {
            try
            {


                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada"));

                }
                return Ok(category);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }



        [HttpPut("v1/updatecategory/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (category == default)
                {
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada"));
                }

                category.Name = model.Name;
                category.Slug = model.Slug;


                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possível alterar a categoria! ");
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/deletecategory/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (category == default)
                {
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada"));
                }



                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possível deletar a categoria! "));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }
    }
}
