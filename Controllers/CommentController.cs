using DTOs.Comment;
using Interfaces;
using Interfaces.IStock;
using Mapper.CommentMapper;
using Microsoft.AspNetCore.Mvc;

namespace CommentController
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IStockRepository _stockRepository;
        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsAsync()
        {

            var comments = await _commentRepository.GetAllCommentsAsync();
            var commentsDTO = comments.Select(s => s.ToCommentDTO());
            return Ok(commentsDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCommentAsyncById(int id)
        {
            var comment = await _commentRepository.GetCommentAsyncById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDTO());
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _stockRepository.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            };
            var commentModel = commentDTO.ToCommentFromCreateDTO(stockId);
            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetCommentAsyncById), new { id = commentModel }, commentModel.ToCommentDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCommentAsync([FromRoute] int id, [FromBody] UpdateCommentDTO updateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultComment = await _commentRepository.UpdateAsync(id, updateDTO.ToCommentFromUpdateDTO());

            if (resultComment == null)
            {
                NotFound("Comment not found");
            }

            return Ok(resultComment);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingComment = await _commentRepository.DeleteAsync(id);
            if (existingComment == null)
            {
                return NotFound("Comment does not exist");
            }
            return Ok(existingComment);
        }
    }
}