using UnityEngine;
using System.Collections;

public class SpearmanMechanics : TribeMechanics {
	public SpearmanStats spearmanStats;

	protected override void Update() {
		base.Update ();

	}

	public void defend(bool defendDown) {
		if (checkCanDefend()) {
			spearmanStats.setIsDefending(defendDown);
		}
	}

	private bool checkCanDefend() {
		return getIsRunning ();
	}

}
