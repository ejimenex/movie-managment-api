using MovieApi.Common.Pagination;

namespace MovieApi.BussinesLogic.Abstract
{

    public interface IPaginator<TDto, TFilter>
    {
        PagedData<TDto> GetPaged(TFilter filter);
    }
}

