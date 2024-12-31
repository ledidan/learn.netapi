

using DTOs.Comment;
using Models;

namespace Mapper.CommentMapper
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Description = commentModel.Description,
                CreatedAt = commentModel.CreatedAt,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentFromCreateDTO(this CreateCommentDTO commentModel, int stockId)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Description = commentModel.Description,
                StockId = stockId
            };
        }
        
        public static Comment ToCommentFromUpdateDTO(this UpdateCommentDTO commentModel)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Description = commentModel.Description,
            };
        }

    }
}