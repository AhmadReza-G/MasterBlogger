using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Infrastructure;
public interface IUnitOfWork
{
    void BeginTran();
    void CommitTran();
    void Rollback();
}
