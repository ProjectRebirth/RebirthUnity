using UnityEngine;
using System.Collections;

public class ObjectSpawnController : MonoBehaviour {
	public Transform prefabComponent;

	public bool buildUp;
	public bool buildRight;

	public int xLength;
	public int yLength;

	public float incrementX;
	public float incrementY;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < xLength; i++) {
			for (int j = 0; j < yLength; j++) {
				Instantiate(prefabComponent.gameObject, new Vector3(i * incrementX + transform.localPosition.x,
				                                                    j * incrementY + transform.localPosition.y, 0), new Quaternion());
			}
		}

	}
}
