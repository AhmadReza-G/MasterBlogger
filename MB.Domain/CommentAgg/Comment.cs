using _01_Framework.Domain;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg;
public class Comment : DomainBase<long>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Message { get; private set; }
    public int Status { get; private set; } = Statuses.New;
    public long ArticleId { get; private set; }
    public Article Article { get; private set; }

    protected Comment() { }
    public Comment(string name, string email, string message, long articleId)
    {
        Name = name;
        Email = email;
        Message = message;
        ArticleId = articleId;
    }
    public void Confirm()
    {
        Status = Statuses.Confirmed;
    }
    public void Cancel()
    {
        Status = Statuses.Canceled;
    }
}
