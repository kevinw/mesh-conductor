using UnityEngine;

public static class VectorExtensions {
	public static Vector2 xy(this Vector3 v3) {
		return new Vector2(v3.x, v3.y);
	}

	public static Vector3 xyz(this Vector2 v2, float z = 0.0f) {
		return new Vector3(v2.x, v2.y, z);
	}

	public static Vector3 Mean(Vector3[] positions) {
		if (positions.Length == 0)
			return Vector3.zero;

		float x = 0f;
		float y = 0f;
		float z = 0f;

		foreach (Vector3 pos in positions) {
			x += pos.x;
			y += pos.y;
			z += pos.z;
		}

		return new Vector3(x / positions.Length, y / positions.Length, z / positions.Length);
	}

	// Determine the signed angle between two vectors, with normal 'n' as the rotation axis.
	public static float AngleSigned(this Vector3 v1, Vector3 v2, Vector3 normal) {
		return Mathf.Atan2(
			Vector3.Dot(normal, Vector3.Cross(v1, v2)),
			Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}
}
