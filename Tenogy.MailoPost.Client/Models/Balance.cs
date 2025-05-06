using System.Text.Json.Serialization;

namespace MailoPost.Models;

public class BalanceModel
{
	[JsonPropertyName("balance")]
	public decimal Balance { get; set; }

	[JsonPropertyName("tariff")]
	public BalanceTariffModel Tariff { get; set; } = new();
}

public sealed class BalanceTariffModel
{
	[JsonPropertyName("subscribers")]
	public BalanceTariffSubscribersModel Subscribers { get; set; } = new();

	[JsonPropertyName("credits")]
	public long Credits { get; set; }

	[JsonPropertyName("expires_at")]
	public long ExpiresAtTicks { get; set; }

	[JsonIgnore]
	public DateTime ExpiresAt => new DateTime(ExpiresAtTicks).Date;
}

public sealed class BalanceTariffSubscribersModel
{
	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("available")]
	public int Available { get; set; }
}
