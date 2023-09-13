using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Infraestructure.Repositories;

public class Pagination<TEntity>
{
    public int Offset { get; set; }
    public int TotalPages { get; set; }
    public List<TEntity> List { get; set; }
    public int TotalItems { get; set; }
}
