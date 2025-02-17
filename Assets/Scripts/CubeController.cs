using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private InputHandler inputHanlder;

	void Start(){
		inputHanlder = new InputHandler ();
		RegistryCommandPattern.CUBEMONOBEHAVIOUR = this;
	}
	void Update () {

		if (inputHanlder.HandleInput() != null && RegistryCommandPattern.CURRENT_CUBE != null) {
				Command cmd = inputHanlder.HandleInput ();
				cmd.execute (RegistryCommandPattern.CURRENT_CUBE);
			}
	}
}
