using UnityEngine;
using System.Collections;

public class LegLogic : MonoBehaviour {
	public SpriteMechanics mechanics;
	public string selfTag;
	private int colliderCount;


	void Update() {
		if (colliderCount > 0) {
			//mechanics.setInAir(false);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag != selfTag) {
			mechanics.setInAir(false);
			colliderCount += 1;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag != selfTag) {
			colliderCount -= 1;
		}
	}
}
