using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly MasterBloggerContext _context;

    public CommentRepository(MasterBloggerContext context)
    {
        _context = context;
    }

}
