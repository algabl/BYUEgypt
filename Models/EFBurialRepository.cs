using System.Linq.Expressions;

namespace BYUEgypt.Models;

public class EFBurialRepository : IBurialRepository
{
    private fagelgamous_databaseContext Context { get; set; }
    public EFBurialRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }

    public IQueryable<Burialmain> Burials => Context.Burialmains;
    public void DeleteRecord(Burialmain burial)
    {
        Context.Remove(burial);
        Context.SaveChanges();
    }

    public IQueryable<Burialmain> GenerateQuery(Dictionary<string, string> dict, int pageSize = 5, int pageNum = 1)
    {
        var queryable = Context.Burialmains.AsQueryable();
   
        foreach (var kvp in dict)
        {
            // queryable = queryable.Where(x => x.Property == x.Value);

            var property = typeof(Burialmain).GetProperty(kvp.Key);
            if (property != null)
            {
                var parameter = Expression.Parameter(typeof(Burialmain), "bm");
                var left = Expression.Property(parameter, kvp.Key);
                var right = Expression.Constant(kvp.Value);
                var predicate = Expression.Equal(left, right);
                var lambda = Expression.Lambda<Func<Burialmain, bool>>(predicate, parameter);
                
                queryable = queryable.Where(lambda);
            }

            // Add the dynamically generated Where clause to the query
            
        }

        queryable = queryable
            .OrderBy(bm => bm.Id)
            .Skip((pageNum - 1) * pageSize);
        
        return queryable;
    }

    public string Whatever()
    {
        return "Hello world";
    }
}