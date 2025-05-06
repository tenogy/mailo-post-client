namespace MailoPost.Models.Response;

public interface IBaseResponse
{
	bool Success { get; }
	IEnumerable<ErrorOfResponse>? Errors { get; set; }
}
