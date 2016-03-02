using UnityEngine;

public static class TransformExtensions {
	public static Transform SetX(this Transform pTransform, float pValue) {
		Vector3 lPosition = pTransform.position;
		lPosition.x = pValue;
		pTransform.position = lPosition;
		return pTransform;
	 }
 
	public static Transform SetY(this Transform pTransform, float pValue) {
		Vector3 lPosition = pTransform.position;
		lPosition.y = pValue;
		pTransform.position = lPosition;
		return pTransform;
	}
 
	public static Transform SetZ(this Transform pTransform, float pValue) {
		Vector3 lPosition = pTransform.position;
		lPosition.z = pValue;
		pTransform.position = lPosition;
		return pTransform;
	}
 
	public static Transform SetXYZ(this Transform pTransform, float pValueX, float pValueY, float pValueZ) {
		Vector3 lPosition = pTransform.position;
		lPosition.x = pValueX;
		lPosition.y = pValueY;
		lPosition.z = pValueZ;
		pTransform.position = lPosition;
		return pTransform;
	}

	public static void LookAt2D(this Transform transform, Vector2 target) {
		transform.LookAt2D(new Vector3(target.x, target.y, 0));
	}

	public static Quaternion LookAt2DRotate(Transform transform, Vector3 target) {
		var dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public static void LookAt2D(this Transform transform, Vector3 target) {
		transform.rotation = LookAt2DRotate(transform, target);
	}
}
