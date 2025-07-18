using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej15.Domain;
using Dsw2025Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2025Ej15.Data.Repositories;

public class EfRepository : IRepository
{
    private readonly Dsw2025Ej15Context _context;
    public EfRepository(Dsw2025Ej15Context context)
    {
        _context = context;
    }

    public async Task<T> Add<T>(T entity) where T : EntityBase
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<T> Delete<T>(Guid id) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public async Task<T?> First<T>(Expression<Func<T, bool>> predicate) where T : EntityBase
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate); // Set es análogo al GetList
    }

    public async Task<List<T>?> GetAll<T>() where T : EntityBase
    {
        return await _context.Set<T>().ToListAsync(); // Set es análogo al GetList
    }

    public async Task<T> GetById<T>(Guid id) where T : EntityBase
    {
        throw new NotImplementedException();
    }

    public Task<T> Update<T>(T entity) where T : EntityBase
    {
        throw new NotImplementedException();
    }
}
