using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EndingScene : MonoBehaviour
{

    public GameObject red;
    public GameObject blue;
    Animator blueAnimator;
    bool check;
    // Use this for initialization
    void Awake ()
    {
        check = false;
        blueAnimator = blue.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (blue.transform.localPosition.y == -800)
        {
            blueAnimator.Play("bluehappy1");
        }
       
    }
}
