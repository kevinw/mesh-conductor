using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Rotater : MonoBehaviour {
	public float speed = 100.0f;
	public float x = 1.0f;
	public float y = 0.0f;
	public float z = 1.0f;

	void Update() {
		var delta = Time.deltaTime * speed;
		transform.Rotate(x * delta, y * delta, z * delta);
	}
}
