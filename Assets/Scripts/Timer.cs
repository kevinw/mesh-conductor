using UnityEngine;

public class Timer : MonoBehaviour {
	public bool paused;
	public float localTime;

	void Update() {
		if (!paused)
			localTime += Time.deltaTime;
	}

	public void Pause() { paused = true; }
	public void Unpause() { paused = false; }
}
