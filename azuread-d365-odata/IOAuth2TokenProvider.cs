using System.Threading;
using System.Threading.Tasks;

namespace D365_AzureAD_ODataQuery
{
	public interface IOAuth2TokenProvider<TToken>
	{
		Task<TToken> GetToken(CancellationToken cancellationToken);
	}
}