using UnityEngine;
using System.Collections;
using Leap;

public class HandReader : MonoBehaviour {
	public HandController handController;

	void LateUpdate () {
		if (handController == null)
			return;

		foreach (HandModel handModel in handController.HandModels) {
			foreach (var finger in handModel.fingers) {
			}
		}
	}
}
