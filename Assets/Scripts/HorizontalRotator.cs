using UnityEngine;
using System.Collections;

public class HorizontalRotator : MonoBehaviour {

	public float rotationSpeed;
	public int rotationAngle;

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, rotationAngle, 0) * Time.deltaTime * rotationSpeed);
	}
}
