using UnityEngine;

public class AnimateTexture : MonoBehaviour {
	Material material;

	public Vector2 offset;
	public string textureName = "_MainTex";
	public Vector2 uvAnimationRate = Vector2.one;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		offset += uvAnimationRate * Time.deltaTime;
		material.SetTextureOffset(textureName, offset);
	}
}
