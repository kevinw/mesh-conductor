using UnityEngine;
using System.Collections;

public class ModifyTransform : MonoBehaviour {

	public enum TransformType {
		Constant,
		Sine,
		Curve
	}

	Quaternion anchorRotation;
	public Vector3 rotationDelta;
	public TransformType rotationTransformType;

	Vector3 anchorPosition;
	public Vector3 positionDelta;
	public TransformType positionTransformType;
	public AnimationCurve positionCurve;

	void OnEnable() {
		anchorPosition = transform.localPosition;
		anchorRotation = transform.localRotation;
	}

	void Update () {
		if (rotationTransformType == TransformType.Constant)
			transform.Rotate(rotationDelta * Time.deltaTime);
		else if (rotationTransformType == TransformType.Sine)
			transform.localRotation = Quaternion.Euler(anchorRotation * (rotationDelta * Mathf.Sin(Time.time)));


		if (positionTransformType == TransformType.Constant)
			transform.localPosition += positionDelta * Time.deltaTime;
		else if (positionTransformType == TransformType.Sine)
			transform.localPosition = anchorPosition + positionDelta * Mathf.Sin(Time.time);
		else if (positionTransformType == TransformType.Curve)
			transform.localPosition = anchorPosition + positionDelta * positionCurve.Evaluate(Mathf.Repeat(Time.time, 1.0f));
	}
}
