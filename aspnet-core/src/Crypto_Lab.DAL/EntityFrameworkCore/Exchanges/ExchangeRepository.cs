using System.Data;
using Crypto_Lab.Common.Models.Exchanges;
using Microsoft.EntityFrameworkCore;

namespace Crypto_Lab.DAL.EntityFrameworkCore.Symbols;

public class ExchangeRepository
{
    private readonly CryptoDbContext _context;

    public ExchangeRepository(CryptoDbContext context)
    {
        _context = context;
    }

    public Task<List<Exchange>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> InsertAsync(Exchange item)
    {
        using var tran = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);

        try
        {
            if (!await IsExist(item))
            {
                _context.Exchanges.Add(item);
                _context.SaveChanges();
                await tran.CommitAsync();
            }
        }
        catch (Exception)
        {
            await tran.RollbackAsync();
            return false;
        }

        return true;
    }

    private async Task<bool> IsExist(Exchange item)
    {
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        return await _context.Exchanges
                            .Where(x => x.Name == item.Name
                                     || x.Slug == item.Slug)
                            .AnyAsync();
    }
}
