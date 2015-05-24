using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public Transform prefabComponent;
	public bool buildUp;
	public bool buildRight;

	public float incrementX;
	public float incrementY;

	public int size;

	// Use this for initialization
	void Start () {
		if (!buildUp) {
			incrementY *= -1;
		}
		if (!buildRight) {
			incrementX *= -1;
		}


	}
}
