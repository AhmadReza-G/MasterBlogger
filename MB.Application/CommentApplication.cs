using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application;
public class CommentApplication : ICommentApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommentRepository _commentRepository;

    public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(AddComment command)
    {
        _unitOfWork.BeginTran();
        var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
        _commentRepository.Create(comment);
        _unitOfWork.CommitTran();
    }

    public void Cancel(long id)
    {
        _unitOfWork.BeginTran();
        var comment = _commentRepository.GetBy(id);
        comment.Cancel();
        //_commentRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }

    public void Confirm(long id)
    {
        _unitOfWork.BeginTran();
        var comment = _commentRepository.GetBy(id);
        comment.Confirm();
        //_commentRepository.SaveChanges();
        _unitOfWork.CommitTran();
    }

    public List<CommentViewModel> GetList()
    {
        return _commentRepository.GetList();
    }
}
