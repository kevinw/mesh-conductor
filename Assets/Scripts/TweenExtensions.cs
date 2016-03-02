using UnityEngine;

public static class TweenExtensions {
	public static Color Tween(this Color color, Color otherColor, float val) {
		Color diff = color - otherColor;
		return color + diff * val;
	}
}
