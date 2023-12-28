namespace Crypto_Lab.DAL.EntityFrameworkCore.Symbols;

public class SymbolRepository
{
    private readonly CryptoDbContext _context;

    public SymbolRepository(CryptoDbContext context)
    {
        _context = context;
    }

    //public Task<List<Symbol>> GetListAsync()
    //{
    //    throw new NotImplementedException();
    //}

    //public async Task<bool> InsertAsync(Symbol item)
    //{
    //    using var tran = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);

    //    try
    //    {
    //        _context.Symbols.Add(item);
    //        _context.SaveChanges();
    //        await tran.CommitAsync();
    //    }
    //    catch (Exception)
    //    {
    //        await tran.RollbackAsync();
    //        return false;
    //    }

    //    return true;
    //}

    //public async Task<bool> InsertRangeAsync(List<Symbol> item)
    //{
    //    using var tran = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);

    //    try
    //    {
    //        _context.Symbols.AddRange(item);
    //        _context.SaveChanges();
    //        await tran.CommitAsync();
    //    }
    //    catch (Exception)
    //    {
    //        await tran.RollbackAsync();
    //        return false;
    //    }

    //    return true;
    //}
}
