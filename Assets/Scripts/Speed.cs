using UnityEngine;

public class Speed : MonoBehaviour {
	Vector3 prevPos;
	public Vector3 speed;

	void OnEnable() {
		prevPos = transform.position;
	}

	void Update() {
		speed = (transform.position - prevPos) / Time.deltaTime;
		prevPos = transform.position;
	}
}
