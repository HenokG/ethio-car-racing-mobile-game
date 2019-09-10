using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Share : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "1612954558995442";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	// The link attached to this post.
	string Link = "http://www.roha.com/";
	
	// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
	string Picture = "https://support.content.office.net/en-us/media/098de964-5e9e-48b9-91f7-7f49fa592e16.jpg";
	
	// The name of the link attachment.
	string Name = "Ethio Car Racing";
	
	// The caption of the link (appears beneath the link name).
	string Description = "WOOOW!!! I Just Scored "+Utililty.highScore+" On Ethio Car Racing With Total Coins Of "+Utililty.currentCoins;
	
	// The description of the link (appears beneath the link caption).
	string Caption = "Download and enjoy Ethio Car racing, a free and fun game for android platform.";

	public void ShareScoreOnFB(){
		Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+FACEBOOK_APP_ID+ "&link="+
		                    Link+ "&picture="+Picture+ "&name="+ReplaceSpace(Name)+ "&caption="+
		                    ReplaceSpace(Caption)+ "&description="+ReplaceSpace(Description)+
		                    "&redirect_uri=https://facebook.com/");
	}
	
	string ReplaceSpace (string val) {
		return val.Replace(" ", "%20");
	}
}