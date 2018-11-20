using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logo : MonoBehaviour {

    public TextMeshProUGUI Text;
    int i;
    // Use this for initialization
    void Start ()
    {
        i = 0;

        
    }

    void ttext()
    {
        switch (i)
        {
            case 0:
                {
                    Text.text = "2 ";
                    i++;
                    break;
                }
            case 10:
                {
                    Text.text += "D ";
                    i++;
                    break;
                }
            case 20:
                {
                    Text.text += "B ";
                    i++;
                    break;
                }
            case 30:
                {
                    Text.text += "F";
                    i++;
                    break;
                }
            case 100:
                {
                    AutoFade.LoadLevel("StartScene", 1, 1, Color.black);
                    break;
                }
            default:
                {
                    i++;
                    break;
                }
        }
    }

	// Update is called once per frame
	void Update ()
    {

        Invoke("ttext", 1f);




    }
}
