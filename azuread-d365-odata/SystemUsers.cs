using System;
using Newtonsoft.Json;

namespace D365_AzureAD_ODataQuery
{
	// auto-generated from: https://app.quicktype.io/?l=csharp using raw OData JSON response
	public class SystemUsers
	{
		[JsonProperty("value")]
		public SystemUser[] Users { get; set; }
	}

	public class SystemUser
	{
		[JsonProperty("address1_addressid")]
		public Guid Address1Addressid { get; set; }

		[JsonProperty("address1_addresstypecode")]
		public long Address1Addresstypecode { get; set; }

		[JsonProperty("address1_city")]
		public string Address1City { get; set; }

		[JsonProperty("address1_composite")]
		public string Address1Composite { get; set; }

		[JsonProperty("address1_country")]
		public string Address1Country { get; set; }

		[JsonProperty("address1_county")]
		public object Address1County { get; set; }

		[JsonProperty("address1_fax")]
		public object Address1Fax { get; set; }

		[JsonProperty("address1_latitude")]
		public object Address1Latitude { get; set; }

		[JsonProperty("address1_line1")]
		public string Address1Line1 { get; set; }

		[JsonProperty("address1_line2")]
		public object Address1Line2 { get; set; }

		[JsonProperty("address1_line3")]
		public object Address1Line3 { get; set; }

		[JsonProperty("address1_longitude")]
		public object Address1Longitude { get; set; }

		[JsonProperty("address1_name")]
		public object Address1Name { get; set; }

		[JsonProperty("address1_postalcode")]
		public long Address1Postalcode { get; set; }

		[JsonProperty("address1_postofficebox")]
		public object Address1Postofficebox { get; set; }

		[JsonProperty("address1_shippingmethodcode")]
		public long Address1Shippingmethodcode { get; set; }

		[JsonProperty("address1_stateorprovince")]
		public string Address1Stateorprovince { get; set; }

		[JsonProperty("address1_telephone1")]
		public object Address1Telephone1 { get; set; }

		[JsonProperty("address1_telephone2")]
		public object Address1Telephone2 { get; set; }

		[JsonProperty("address1_telephone3")]
		public object Address1Telephone3 { get; set; }

		[JsonProperty("address1_upszone")]
		public object Address1Upszone { get; set; }

		[JsonProperty("address1_utcoffset")]
		public object Address1Utcoffset { get; set; }

		[JsonProperty("address2_addressid")]
		public Guid Address2Addressid { get; set; }

		[JsonProperty("address2_addresstypecode")]
		public long Address2Addresstypecode { get; set; }

		[JsonProperty("address2_city")]
		public object Address2City { get; set; }

		[JsonProperty("address2_composite")]
		public object Address2Composite { get; set; }

		[JsonProperty("address2_country")]
		public object Address2Country { get; set; }

		[JsonProperty("address2_county")]
		public object Address2County { get; set; }

		[JsonProperty("address2_fax")]
		public object Address2Fax { get; set; }

		[JsonProperty("address2_latitude")]
		public object Address2Latitude { get; set; }

		[JsonProperty("address2_line1")]
		public object Address2Line1 { get; set; }

		[JsonProperty("address2_line2")]
		public object Address2Line2 { get; set; }

		[JsonProperty("address2_line3")]
		public object Address2Line3 { get; set; }

		[JsonProperty("address2_longitude")]
		public object Address2Longitude { get; set; }

		[JsonProperty("address2_name")]
		public object Address2Name { get; set; }

		[JsonProperty("address2_postalcode")]
		public object Address2Postalcode { get; set; }

		[JsonProperty("address2_postofficebox")]
		public object Address2Postofficebox { get; set; }

		[JsonProperty("address2_shippingmethodcode")]
		public long Address2Shippingmethodcode { get; set; }

		[JsonProperty("address2_stateorprovince")]
		public object Address2Stateorprovince { get; set; }

		[JsonProperty("address2_telephone1")]
		public object Address2Telephone1 { get; set; }

		[JsonProperty("address2_telephone2")]
		public object Address2Telephone2 { get; set; }

		[JsonProperty("address2_telephone3")]
		public object Address2Telephone3 { get; set; }

		[JsonProperty("address2_utcoffset")]
		public object Address2Utcoffset { get; set; }

		[JsonProperty("employeeid")]
		public string Employeeid { get; set; }

		[JsonProperty("firstname")]
		public string Firstname { get; set; }

		[JsonProperty("fullname")]
		public string Fullname { get; set; }

		[JsonProperty("homephone")]
		public object Homephone { get; set; }

		[JsonProperty("isdisabled")]
		public bool Isdisabled { get; set; }

		[JsonProperty("jobtitle")]
		public object Jobtitle { get; set; }

		[JsonProperty("lastname")]
		public string Lastname { get; set; }

		[JsonProperty("middlename")]
		public string Middlename { get; set; }

		[JsonProperty("mobilephone")]
		public string Mobilephone { get; set; }

		[JsonProperty("nickname")]
		public string Nickname { get; set; }

		[JsonProperty("personalemailaddress")]
		public string Personalemailaddress { get; set; }

		[JsonProperty("photourl")]
		public object Photourl { get; set; }

		[JsonProperty("preferredaddresscode")]
		public long Preferredaddresscode { get; set; }

		[JsonProperty("preferredemailcode")]
		public long Preferredemailcode { get; set; }

		[JsonProperty("preferredphonecode")]
		public long Preferredphonecode { get; set; }

		[JsonProperty("salutation")]
		public string Salutation { get; set; }

		[JsonProperty("skills")]
		public object Skills { get; set; }

		[JsonProperty("ssw_aboutmeaudiourl")]
		public object SswAboutmeaudiourl { get; set; }

		[JsonProperty("ssw_blogurl")]
		public Uri SswBlogurl { get; set; }

		[JsonProperty("ssw_chinaid")]
		public object SswChinaid { get; set; }

		[JsonProperty("ssw_datefinished")]
		public object SswDatefinished { get; set; }

		[JsonProperty("ssw_dateofbirth")]
		public DateTimeOffset SswDateofbirth { get; set; }

		[JsonProperty("ssw_datestarted")]
		public DateTimeOffset SswDatestarted { get; set; }

		[JsonProperty("ssw_defaultrate")]
		public long SswDefaultrate { get; set; }

		[JsonProperty("ssw_facebookurl")]
		public Uri SswFacebookurl { get; set; }

		[JsonProperty("ssw_githuburl")]
		public Uri SswGithuburl { get; set; }

		[JsonProperty("ssw_istimeproemp")]
		public bool SswIstimeproemp { get; set; }

		[JsonProperty("ssw_jobtitle")]
		public long SswJobtitle { get; set; }

		[JsonProperty("ssw_linkedinurl")]
		public Uri SswLinkedinurl { get; set; }

		[JsonProperty("ssw_note")]
		public string SswNote { get; set; }

		[JsonProperty("ssw_playlist")]
		public object SswPlaylist { get; set; }

		[JsonProperty("ssw_profilecategory")]
		public object SswProfilecategory { get; set; }

		[JsonProperty("ssw_publicprofileurl")]
		public Uri SswPublicprofileurl { get; set; }

		[JsonProperty("ssw_skypeusername")]
		public string SswSkypeusername { get; set; }

		[JsonProperty("ssw_smartphoneos")]
		public long SswSmartphoneos { get; set; }

		[JsonProperty("ssw_smartphonewifimacaddress")]
		public object SswSmartphonewifimacaddress { get; set; }

		[JsonProperty("ssw_timepropwd")]
		public object SswTimepropwd { get; set; }

		[JsonProperty("ssw_tshirtsize")]
		public long SswTshirtsize { get; set; }

		[JsonProperty("ssw_twitterusername")]
		public string SswTwitterusername { get; set; }

		[JsonProperty("ssw_youtubeplaylistid")]
		public string SswYoutubeplaylistid { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }
	}
}