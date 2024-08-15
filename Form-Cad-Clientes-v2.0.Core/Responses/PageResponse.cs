namespace Formulario.Core.Responses;

public class PageResponse<TData> : Response<TData>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }

    public PageResponse()
    {
    }

    public PageResponse(bool isSuccess, TData? data, int pageNumber, int pageSize, int totalPages, int totalItems, string? errorMessage = null, int statusCode = 200)
        : base(isSuccess, data, errorMessage, statusCode)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = totalPages;
        TotalItems = totalItems;
    }
}