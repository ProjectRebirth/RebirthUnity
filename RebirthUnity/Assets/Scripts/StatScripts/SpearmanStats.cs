using UnityEngine;
using System.Collections;

public class SpearmanStats : BaseStats {
	private bool isDefending;




	public override void takeDamage(float rawDamage) {
		if (!isDefending) {
			base.takeDamage(rawDamage);
		}
	}

	public bool getIsDefending() {
		return isDefending;
	}

	public void setIsDefending(bool isDefending) {
		this.isDefending = isDefending;
	}


}
