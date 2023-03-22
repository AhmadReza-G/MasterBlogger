using MB.Application.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg;
public interface ICommentRepository
{
    void Create(Comment entity);
    Comment Get(long id);
    List<CommentViewModel> GetList();
    void SaveChanges();
}
