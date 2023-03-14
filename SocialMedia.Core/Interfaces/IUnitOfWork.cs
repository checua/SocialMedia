using SocialMedial.Core.Etities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> PostRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        void SaveChanges();
        void SaveChangesAsync();
    }
}
