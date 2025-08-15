using System.Linq.Expressions;
using CrastuArrustutu.Shared.Dtos;

namespace CrastuArrustutu.Shared.ReadModel;

public interface IQueries<T> where T : DtoBase
{
	Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
	Task<PagedResult<T>> GetByFilterAsync(Expression<Func<T, bool>>? query, int page, int pageSize, CancellationToken cancellationToken);
}