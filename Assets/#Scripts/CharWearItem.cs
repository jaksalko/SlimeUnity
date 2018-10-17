using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWearItem : MonoBehaviour {
    public GameObject redhat;
    public GameObject bluehat;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "DefaultRedToggle (UnityEngine.UI.Toggle)")
        {
            Debug.Log(PlayerPrefs.GetString("RedWear", "DefaultRedToggle"));
            redhat.GetComponent<SpriteRenderer>().sprite = null;
        }    
        else if(PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "SantaRedToggle (UnityEngine.UI.Toggle)")
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "CrownRedToggle (UnityEngine.UI.Toggle)")
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;


        if (PlayerPrefs.GetString("BlueWear", "DefaultBlueToggle") == "DefaultBlueToggle (UnityEngine.UI.Toggle)")
        {
            Debug.Log(PlayerPrefs.GetString("BlueWear", "DefaultBlueToggle"));
            bluehat.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "SantaBlueToggle (UnityEngine.UI.Toggle)")
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "CrownBlueToggle (UnityEngine.UI.Toggle)")
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;
    }
        // Update is called once per frame
        void Update () {
		
	}
}
