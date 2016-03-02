using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MeshCopier : MonoBehaviour {
	public GameObject prefab;
	public HideFlags childHideFlags = HideFlags.DontSave;
	public Vector3 meshRotation = Vector3.zero;
	public uint count;
	public float radius;

	uint lastCount;
	float lastRadius;
	float calculatedRadius;
	GameObject lastPrefab;
	Vector3 lastMeshRotation;
	bool needsMeshUpdate;


	void DoInput() {
		var cam = Camera.main;
		var pos = Input.mousePosition;
		pos.z = cam.nearClipPlane;
		var viewpoint = cam.ScreenToViewportPoint(pos);
		meshRotation = viewpoint * 360f;
		//calculatedRadius = Mathf.Sin(Time.time) * radius;
		calculatedRadius = radius;
	}

	public float period = 3.0f;
	public float strength = 0.3f;
	public float periodSpeed = 1.0f;

	void Update() {
		DoInput();
		if (!Application.isPlaying &&
				lastCount == count &&
				lastRadius.AlmostEquals(calculatedRadius) &&
				lastPrefab == prefab && 
				meshRotation == lastMeshRotation)
			return;

		if (lastPrefab != prefab)
			needsMeshUpdate = true;

		lastCount = count;
		lastRadius = calculatedRadius;
		lastPrefab = prefab;
		lastMeshRotation = meshRotation;

		ReserveChildren(count);

		if (!prefab)
			return;

		var angle = 0f;
		for (int n = 0; n < count; ++n) {
			var direction = Quaternion.Euler(0, 0, angle);
			angle += 360f / count;
			var offset = Vector3.right * strength * Mathf.Sin(((float)n / count) * period * 2 * Mathf.PI + (Time.time * periodSpeed));
			var localPosition = Vector3.right * calculatedRadius + offset;
			localPosition = direction * localPosition;
			//var obj = (GameObject)Object.Instantiate(prefab, localPosition, direction);
			var obj = transform.GetChild(n).gameObject;
			obj.transform.position = localPosition;
			obj.transform.rotation = direction;
			obj.hideFlags = childHideFlags;
			obj.transform.Rotate(meshRotation);
		}
	}
	
	void ReserveChildren(uint count) {
		if (needsMeshUpdate) {
			gameObject.DestroyAllChildren();
			needsMeshUpdate = false;
		}

		if (transform.childCount < count)
			Debug.Log("Creating " + (count - transform.childCount) + " new children");
		else if (transform.childCount > count)
			Debug.Log("Destroying " + (transform.childCount - count) + " children");
		while (transform.childCount < count) {
			var obj = Object.Instantiate(prefab);
			obj.transform.SetParent(transform, false);
		}

		int failsafe = 100;

		while (transform.childCount > count && failsafe-- > 0) {
			var obj = transform.GetChild(transform.childCount - 1).gameObject;
			if (Application.isEditor)
				GameObject.DestroyImmediate(obj);
			else
				GameObject.Destroy(obj);
		}
	}
}
