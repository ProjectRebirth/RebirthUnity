using UnityEngine;
using System.Collections;

public class SpearmanMechanics : TribeMechanics {
	private bool isDefending;

	protected override void Update() {
		base.Update ();

	}


	public void defend(bool defendPushed) {
		isDefending = false;
		if (checkCanDefend ()) {
			isDefending = defendPushed;
		}
	}

	/**
	 *Add any conditions that allow the sprite to defend themselves here
	 */ 
	public bool checkCanDefend() {
		return !getIsRunning();
	}

	public bool getIsDefending() {
		return isDefending;
	}

	
}
