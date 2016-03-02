using UnityEngine;

public class AlbedoGlow : MonoBehaviour {
	public bool IsGlowing;
	public float speed = 0.1f;
	public float amount = 0.75f;

	float val;
	bool readAlbedo;
	Color originalColor;
	Color toColor;
	Material material;

	void Start() {
		material = GetComponent<Renderer>().material;
	}

	void Update() {
		val = Mathf.Clamp01(val + speed * (IsGlowing ? 1 : -1));

		if (!readAlbedo) {
			readAlbedo = true;
			originalColor = material.GetColor("_Color");
			toColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1.0f);
		}

		material.SetColor("_Color", Color.Lerp(originalColor, toColor, amount * val));
	}
}
