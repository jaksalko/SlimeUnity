﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    private void Awake()
    {
        Screen.SetResolution(1080, 1920, true);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0)) {
            AutoFade.LoadLevel("Menu", 1, 1, Color.black);
        }		

	}
}
