using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gomenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goM()
    {
        AutoFade.LoadLevel("Menu", 1, 1, Color.white);
    }
}
