using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour {

    // Give us the texture so that we can scale proportianally the width according to the height variable below
    // We will grab it from the meshRenderer
    public float textureToMeshZ = 2f; // Use this to contrain texture to a certain size

    Vector3 prevScale = Vector3.one;
	Material materialCopy;

    float prevTextureToMeshZ = -1f;

    // Use this for initialization
    void Start () {
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMeshZ = textureToMeshZ;
        UpdateTiling();
    }

    void Update () {
        // If something has changed
        if (gameObject.transform.lossyScale != prevScale || !Mathf.Approximately(textureToMeshZ, prevTextureToMeshZ))
            UpdateTiling();

        // Maintain previous state variables
        prevScale = gameObject.transform.lossyScale;
        prevTextureToMeshZ = textureToMeshZ;
    }

    [ContextMenu("UpdateTiling")]
    void UpdateTiling() {
		var r = gameObject.GetComponent<Renderer>();
		if (r == null)
			return;

		var material = r.sharedMaterial;
		var texture = material.mainTexture;
		if (texture == null)
			return;

        // Figure out texture-to-mesh width based on user set texture-to-mesh height
		if (materialCopy == null) {
			materialCopy = new Material(r.sharedMaterial);
		}

		float textureToMeshX = ((float)texture.width / texture.height) * textureToMeshZ;
		materialCopy.mainTextureScale = new Vector2(gameObject.transform.lossyScale.x / textureToMeshX, gameObject.transform.lossyScale.y / textureToMeshZ);
		r.sharedMaterial = materialCopy;
    }
}
