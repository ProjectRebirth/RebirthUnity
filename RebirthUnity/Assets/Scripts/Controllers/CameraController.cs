using UnityEngine;
using System.Collections;


/**
 * Logic for the camera will go here. At the moment
 * you can move the camera a little offset from the player and zoom in
 * and out using the scaling variable.
 */ 
public class CameraController : MonoBehaviour {
	public Transform followPlayer;//The character that we want to follow
	public float offsetX;//How far left or right from the character we want the camera
	public float offsetY;//How far up or down from the character we want the camera to be
	public float scaling;//How zoomed in we want the camera to be

	/*
	 * Updates to follow the player on the screen
	 */
	void Update() {
		float x = followPlayer.localPosition.x;
		float y = followPlayer.localPosition.y;
		float z = transform.localPosition.z;

		Vector3 newPosition = new Vector3 (x + offsetX, y + offsetY, z);
		this.transform.localPosition = newPosition;

	}
}
