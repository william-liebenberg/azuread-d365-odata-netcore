using System;
using System.Collections.Specialized;
using System.Text;

namespace D365_AzureAD_ODataQuery
{
	public static class UriExtensions
	{
		public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
		{
			var stringBuilder = new StringBuilder();
			var str = "?";
			for (var index = 0; index < parameters.Count; ++index)
			{
				stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
				str = "&";
			}
			return new Uri(uri + stringBuilder.ToString());
		}
	}
}