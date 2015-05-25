using UnityEngine;
using System.Collections;

public class AdjustZAxis : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 position = transform.position;
		float z = position.x + position.y;
		position.z = z;
		transform.position = position;
	}

}
