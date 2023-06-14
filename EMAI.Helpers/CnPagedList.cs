using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Helpers;

public class CnPagedList<T>
{

    //https://github.com/CypressNorth/.NET-CNPagedList/blob/master/CNPagedList.cs
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list">The full list of items you would like to paginate</param>
    /// <param name="pageNumber">(optional) The current pageNumber number</param>
    /// <param name="pageSize">(optional) The size of the pageNumber</param>
    public CnPagedList(IQueryable<T> list, int? pageNumber = null, int? pageSize = null)
    {
        _list = list;
        _pageNumber = pageNumber;
        _pageSize = pageSize;
    }

    private readonly IQueryable<T> _list;

    /// <summary>
    /// The paginated result
    /// </summary>
    public IQueryable<T> Page
    {
        get
        {
            if (_list == null) return null;
            return _list.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }

    private readonly int? _pageNumber;

    /// <summary>
    ///  The current pageNumber.
    /// </summary>
    public int PageNumber => _pageNumber ?? 1;

    private int? _pageSize;

    /// <summary>
    /// The size of the pageNumber.
    /// </summary>
    public int PageSize
    {
        get
        {
            if (!_pageSize.HasValue)
            {
                return _list?.Count() ?? 0;
            }
            else
            {
                return _pageSize.Value;
            }
        }
    }

    /// <summary>
    /// The total number of items in the original list of items.
    /// </summary>
    public int Total => _list?.Count() ?? 0;


}
