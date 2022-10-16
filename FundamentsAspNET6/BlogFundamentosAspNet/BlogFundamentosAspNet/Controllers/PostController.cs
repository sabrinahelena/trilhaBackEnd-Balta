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
    public class PostController : ControllerBase
    {
        [HttpPost("v1/createpost")]
        public async Task<IActionResult> PostAsync([FromBody] EditorPostViewModel postViewModel, [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)//verifica o model state do view model
                return BadRequest(ModelState.GetErrors());

            try
            {
                var post = new Post
                {
                    Id = 0,
                    Title = postViewModel.Title,
                    Slug = postViewModel.Slug.ToLower(),
                    Summary = postViewModel.Summary,
                    Body = postViewModel.Body,
                    CreateDate = postViewModel.CreateDate,
                    LastUpdateDate = postViewModel.LastUpdateDate     
                };
                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();
                return Created($"v1/posts/{post.Id}", new ResultViewModel<Post>(post));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possível incluir o post! ");
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/posts")] //importante para não quebrar a aplicação.
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context)
        {
            try
            {
                var posts = await context.Posts.AsNoTracking().ToListAsync();
                return Ok(new ResultViewModel<List<Post>>(posts));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Post>>("Falha interna no servidor"));
            }
        }


        [HttpGet("v1/posts/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var post = await context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                {
                    return NotFound(new ResultViewModel<Post>("Post não encontrado"));

                }
                return Ok(post);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }



        [HttpPut("v1/updatepost/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorPostViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {
                var post = await context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (post == default)
                {
                    return NotFound(new ResultViewModel<Post>("Post não encontrado"));
                }

                post.Title = model.Title;
                post.Slug = model.Slug;
                post.Summary = model.Summary;
                post.Body = model.Body;
                post.LastUpdateDate = model.LastUpdateDate;
                post.CreateDate = model.CreateDate;


                context.Posts.Update(post);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Post>(post));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Não foi possível alterar o post! ");
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/deletepost/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var post = await context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (post == default)
                {
                    return NotFound(new ResultViewModel<Post>("Post não encontrado"));
                }

                context.Posts.Remove(post);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Post>(post));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Post>("Não foi possível deletar o post! "));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }
    }
}

