using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DOTs;
using SocialMedia.Core.Interfaces;
using SocialMedial.Core.Etities;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var post = _postService.GetPosts();
            var postDtos = _mapper.Map<IEnumerable<PostDto>>(post);

            //var postDto = post.Select(x => new PostDto
            //{
            //    PostId = x.PostId,
            //    UserId = x.UserId,
            //    Date = x.Date,
            //    Description = x.Description,
            //    Image = x.Image
            //});
            var response = new ApiResponse<IEnumerable<PostDto>>(postDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPos(int id)
        {
            var post = await _postService.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var post = _mapper.Map<Post>(postDto);
            //Aquí se pudiera validar la información
            await _postService.InsertPost(post);
            postDto = _mapper.Map<PostDto>(post);


            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id,PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
