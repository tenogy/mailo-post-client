namespace MailoPost.Models.Response;

public interface IBaseCollectionResponse<TItem> : IBaseResponse where TItem : class
{
	public int TotalCount { get; set; }
	public int TotalPages { get; set; }
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public IEnumerable<TItem>? Collection { get; set; }
}
