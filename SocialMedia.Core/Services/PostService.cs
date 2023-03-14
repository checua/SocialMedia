using SocialMedia.Core.Interfaces;
using SocialMedial.Core.Etities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{

    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;


        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.PostRepository.GetAll();
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if(post.Description.Contains("Sexo"))
            {
                throw new Exception("Content not alowed");
            }

            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
           await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}
