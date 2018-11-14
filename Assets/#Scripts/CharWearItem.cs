using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWearItem : MonoBehaviour {
    public GameObject redhat;
    public GameObject bluehat;

    // Use this for initialization
    void Start()
    {
        bluehat.transform.localScale = new Vector3(1f, 1f, 0);
        redhat.transform.localScale = new Vector3(1f, 1f, 0);
        if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "DefaultRedToggle (UnityEngine.UI.Toggle)")
        {
           redhat.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "SantaRedToggle (UnityEngine.UI.Toggle)")
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;

        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "CrownRedToggle (UnityEngine.UI.Toggle)")
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;

        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "StrawRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;

        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "BeretRedToggle (UnityEngine.UI.Toggle)")
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "CookRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;

        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "CatRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;

        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "ChickRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;

        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "RabbitRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.7f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;

        }
        else if (PlayerPrefs.GetString("RedWear", "DefaultRedToggle") == "FrogRedToggle (UnityEngine.UI.Toggle)")
        {
            redhat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            redhat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;

        }




        if (PlayerPrefs.GetString("BlueWear", "DefaultBlueToggle") == "DefaultBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "SantaBlueToggle (UnityEngine.UI.Toggle)")
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;

        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "CrownBlueToggle (UnityEngine.UI.Toggle)")
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;

        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "StrawBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultBlueToggle") == "BeretBlueToggle (UnityEngine.UI.Toggle)")
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "CookBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "CatBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "ChickBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "RabbitBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetString("BlueWear", "DefaultRedToggle") == "FrogBlueToggle (UnityEngine.UI.Toggle)")
        {
            bluehat.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            bluehat.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
