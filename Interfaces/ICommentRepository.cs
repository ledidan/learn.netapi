
using Models;

namespace Interfaces {
    
    public interface ICommentRepository {
        Task<List<Comment>> GetAllCommentsAsync();

        Task<Comment?> GetCommentAsyncById(int id);

        Task<Comment?> CreateAsync(Comment comment);

        Task<Comment?> UpdateAsync(int id, Comment comment);
        Task<Comment?> DeleteAsync(int id);
    }
}