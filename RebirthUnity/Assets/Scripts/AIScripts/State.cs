using UnityEngine;
using System.Collections;

//Not implemented
public abstract class State {

	public abstract void enterState ();

	public abstract void updateState ();

	public abstract void exitState();
}
