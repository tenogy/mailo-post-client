namespace MailoPost.Models.RequestContent
{
	public interface IBaseCollectionContent : IBaseContent
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
