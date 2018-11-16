using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2 : MonoBehaviour
{
    public GameObject[] Red;
    public GameObject[] Blue;
    public Vector3[] redposition;
    public Vector3[] blueposition;
    // Use this for initialization
    void Awake ()
    {
        for (int i = 0; i < Red.Length; i++)
        {
            Red[i] = GameObject.Find("RedRain").transform.Find("RedHeart (" + i + ")").gameObject;
            redposition[i] = Red[i].transform.localPosition;
        }
        for (int i = 0; i < Blue.Length; i++)
        {
            Blue[i] = GameObject.Find("BlueRain").transform.Find("BlueHeart (" + i + ")").gameObject;
            blueposition[i] = Blue[i].transform.localPosition;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < Red.Length; i++)
            {
                Red[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            if (Red[i].transform.localPosition.y < -2f)
            {
                Red[i].transform.localPosition = new Vector3(redposition[i].x, 35f, redposition[i].z);
            }
            }
        for (int i = 0; i < Blue.Length; i++)
        {
            Blue[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            if (Blue[i].transform.localPosition.y < -5f)
            {
                Blue[i].transform.localPosition = new Vector3(blueposition[i].x, 4f, blueposition[i].z);
            }
        }

        
    }
}
