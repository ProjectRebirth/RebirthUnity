using UnityEngine;
using System.Collections;

public class SpearmanMechanics : TribeMechanics {

	protected override void Update() {
		base.Update ();

	}

	public void defend(bool defendDown) {
		SpearmanStats spearmanStats = (SpearmanStats)baseStats;
		if (checkCanDefend ()) {
			spearmanStats.setIsDefending (defendDown);
		} else {
			spearmanStats.setIsDefending(false);
		}
	}

	private bool checkCanDefend() {
		return !getIsRunning ();
	}

	protected override void isDeadCleanup() {
		base.isDeadCleanup ();
		if (baseStats.getIsDead ()) {
			foreach (Transform child in transform) {
				Destroy (child.gameObject);
			}
		}
	}
}
