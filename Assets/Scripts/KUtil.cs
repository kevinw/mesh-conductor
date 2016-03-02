using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class KUtil {
	public static string decimalRegex = @"(?:^|(?<=\s))[0-9]*\.?[0-9](?=\s|$)";

	public static void SetActiveLater(this MonoBehaviour obj, bool active, float delay) {
		obj.StartCoroutine(SetActiveLaterHelper(obj, active, delay));
	}

	public static IEnumerator SetActiveLaterHelper(MonoBehaviour obj, bool active, float delay) {
		yield return new WaitForSeconds(delay);
		obj.gameObject.SetActive(active);
	}

	public static T randomPick<T>(T[] array) {
		return array[UnityEngine.Random.Range (0, array.Length - 1)];
	}

	public static GameObject InstantiatePrefab(GameObject prefab) {
#if UNITY_EDITOR
		if (Application.isEditor)
			return PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		else
#endif
			return GameObject.Instantiate(prefab) as GameObject;
	}

	public static Stack<T> Clone<T>(this Stack<T> stack) {
		var temp = new List<T>(stack.ToArray());
		temp.Reverse();

		return new Stack<T>(temp);
	}

	public static bool AlmostEquals(this float a, float b, float epsilon = float.NaN) {
		if (float.IsNaN(epsilon))
			return Mathf.Approximately(a, b);

		return Mathf.Abs(a - b) < epsilon;
	}

	public static void SetImageWithAspectRatio(Image image, Sprite sprite) {
		image.sprite = sprite;

		var asf = image.GetComponent<AspectRatioFitter>();
		asf.aspectRatio = sprite.textureRect.width  / sprite.textureRect.height;
	}

	public static Sprite SpriteFromTexture(Texture2D tex) {
		var rect = new Rect(0, 0, tex.width, tex.height);
		var pivot = new Vector2(0.5f, 0.5f);
		const float pixelsToUnits = 100f;
		return Sprite.Create(tex, rect, pivot, pixelsToUnits);
	}

	public static GameObject CreateFadePanel(bool visible) {
		// create a panel covering the whole canvas
		var canvas = Object.FindObjectOfType<Canvas>();
		var panel = new GameObject("Fade Panel");

		var image = panel.AddComponent<Image>();
		image.color = Color.black;
		image.gameObject.GetOrAddComponent<CanvasGroup>().alpha =
			visible ? 1.0f : 0.0f;

		var rt = image.rectTransform;
		rt.anchorMin = Vector2.zero;
		rt.anchorMax = Vector2.one;

		panel.transform.SetParent(canvas.transform, false);

		return panel;
	}

	public static System.Action Once(System.Action action) {
		bool done = false;
		return () => {
			if (!done) {
				done = true;
				action();
			}
		};
	}

}
