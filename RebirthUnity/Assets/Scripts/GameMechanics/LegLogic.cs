using UnityEngine;
using System.Collections;

public class LegLogic : MonoBehaviour {
	public SpriteMechanics mechanics;
	public string selfTag;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag != selfTag) {
			mechanics.setInAir(false);
		}
	}
}
