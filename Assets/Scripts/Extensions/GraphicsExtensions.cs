using UnityEngine;

public static class GraphicsExtensions {
	public static string HexString(this Color aColor) {
		return HexString((Color32)aColor, false);
	}
	public static string HexString(this Color aColor, 
			bool includeAlpha) {
		return HexString((Color32)aColor, includeAlpha);
	}
	public static string HexString(this Color32 aColor, bool includeAlpha) {
		string rs = aColor.r.ToString("X2");
		string gs = aColor.g.ToString("X2");
		string bs = aColor.b.ToString("X2");
		string a_s = aColor.a.ToString("X2");
		while(rs.Length < 2) rs= "0" + rs;
		while(gs.Length < 2) gs= "0" + gs;
		while(bs.Length < 2) bs= "0" + bs;
		while(a_s.Length < 2) a_s= "0" + a_s;
		if(includeAlpha) return "#"+ rs + gs + bs + a_s;
		return "#"+ rs + gs + bs;
	}
}
