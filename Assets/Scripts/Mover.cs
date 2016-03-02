using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Mover : MonoBehaviour {
	public Vector3 oscillate;
	public float speed = 1.0f;
	public float offset;

	Vector3 originalPos;
	Timer timer;

	float LocalTime { get { return timer ? timer.localTime : Time.time; } }

	void Start() {
		originalPos = transform.position;
		timer = GetComponent<Timer>();
	}

	void Update() {
		transform.position = originalPos + oscillate * Mathf.Sin(LocalTime * speed + offset);
	}
}
