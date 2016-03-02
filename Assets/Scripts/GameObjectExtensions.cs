using UnityEngine;
using System.Collections.Generic;

public static class GameObjectExtensions {
	public static T GetOrAddComponent<T>(this GameObject obj)
		where T : Component
	{
		return obj.GetComponent<T>() ?? obj.AddComponent<T>();
	}

	public static void DestroyAllChildren(this GameObject obj) {
		if (obj.transform.childCount > 0) {
			var gameObjects = new List<GameObject>();
			foreach (Transform t in obj.transform)
				gameObjects.Add(t.gameObject);
			foreach (GameObject gobj in gameObjects)
#if UNITY_EDITOR
				if (Application.isEditor)
					Object.DestroyImmediate(gobj);
				else
#endif
				Object.Destroy (gobj);
		}
	}

	public static int GetNumParents(this GameObject obj) {
		var t = obj.transform;
		var numParents = 0;
		while (t.parent != null) {
			numParents++;
			t = t.parent;
		}
		return numParents;
	}

	public static LTDescr Fade(this CanvasGroup canvasGroup, bool fadeIn, float time = 0.10f) {
		float fromAlpha, toAlpha;
		if (fadeIn) {
			fromAlpha = 0f;
			toAlpha = 1f;
		} else {
			fromAlpha = 1f;
			toAlpha = 0f;
		}

		return LeanTween.value(canvasGroup.gameObject, canvasGroup.SetAlpha, fromAlpha, toAlpha, time);
	}

	public static void SetAlpha(this CanvasGroup canvasGroup, float alpha) {
		canvasGroup.alpha = alpha;
	}

}
