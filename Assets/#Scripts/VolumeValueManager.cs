using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueManager : MonoBehaviour {
    private AudioSource audiosrc;
    //public static float musicVolume;
    public Slider BGMSlider;
    public Slider SoundSlider;
    public GameObject soundbtn;
    public GameObject bgmbtn;
    public GameObject vibratebtn;
   

	// Use this for initialization
	void Start () {
        Debug.Log("start volumemanager : BGM :" + PlayerPrefs.GetFloat("BGMVolume", 1f)+ "Global: " + PlayerPrefs.GetFloat("GlobalVolume", 1f));
        audiosrc = GetComponent<AudioSource>();
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        SoundSlider.value = PlayerPrefs.GetFloat("GlobalVolume", 1f);
        
        if (BGMSlider.value == 0)
        {
            bgmbtn.GetComponent<Image>().sprite = Resources.Load("#Images/BGMSilent", typeof(Sprite)) as Sprite;

        }

        else
        {
            bgmbtn.GetComponent<Image>().sprite = Resources.Load("#Images/BGM", typeof(Sprite)) as Sprite;

        }
        if (SoundSlider.value == 0)
        {
            soundbtn.GetComponent<Image>().sprite = Resources.Load("#Images/Silentimg", typeof(Sprite)) as Sprite;

        }

        else
        {
            soundbtn.GetComponent<Image>().sprite = Resources.Load("#Images/OptionButton", typeof(Sprite)) as Sprite;

        }
        if (PlayerPrefs.GetInt("Vibrate", 0) == 0)
        {
            vibratebtn.GetComponent<Image>().sprite = Resources.Load("#Images/VibrateOff", typeof(Sprite)) as Sprite;
           
        }
        else
        {
           vibratebtn.GetComponent<Image>().sprite = Resources.Load("#Images/VibrateButton", typeof(Sprite)) as Sprite;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("start volumemanager : BGM :" + PlayerPrefs.GetFloat("BGMVolume", 1) + "Global: " + PlayerPrefs.GetFloat("GlobalVolume", 1));
        AudioListener.volume = SoundSlider.value;
        audiosrc.volume = BGMSlider.value;
	}

    public void SetBGMVolume(float vol)
    {
        if (BGMSlider.value == 0)
        {
            bgmbtn.GetComponent<Image>().sprite = Resources.Load("#Images/BGMSilent", typeof(Sprite)) as Sprite;
           
        }

        else
        {
            bgmbtn.GetComponent<Image>().sprite = Resources.Load("#Images/BGM", typeof(Sprite)) as Sprite;
            
        }
        Debug.Log(vol.ToString());
      
        BGMSlider.value = vol;
        PlayerPrefs.SetFloat("BGMVolume", vol);
        PlayerPrefs.Save();
        
    }
    public void SetGlobalVolume(float vol)
    {
        if (SoundSlider.value == 0)
        {
            soundbtn.GetComponent<Image>().sprite = Resources.Load("#Images/Silentimg", typeof(Sprite)) as Sprite;
           
        }

        else
        {
            soundbtn.GetComponent<Image>().sprite = Resources.Load("#Images/OptionButton", typeof(Sprite)) as Sprite;
           
        }
        Debug.Log(vol.ToString());

        SoundSlider.value = vol;
        PlayerPrefs.SetFloat("GlobalVolume", vol);
        PlayerPrefs.Save();
    }

    public void setBGMButtonClick() {
        if (BGMSlider.value == 0)
        {
           
            BGMSlider.value = 1;
        }
            
        else
        {
           
            BGMSlider.value = 0;
        }
            

        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }
    public void setSoundButtonClick() {
        if (SoundSlider.value == 0)
        {
            
            SoundSlider.value = 1;
        }

        else
        {
            
            SoundSlider.value = 0;
        }
           


        PlayerPrefs.SetFloat("GlobalVolume", SoundSlider.value);
    }
    public void setVibrateButtonClick() {
        if (PlayerPrefs.GetInt("Vibrate", 0) == 0)
        {
            PlayerPrefs.SetInt("Vibrate", 1);//Vibrate On
            vibratebtn.GetComponent<Image>().sprite = Resources.Load("#Images/VibrateButton", typeof(Sprite)) as Sprite;
        }
        else {
            PlayerPrefs.SetInt("Vibrate", 0);//Vibrate Off
            vibratebtn.GetComponent<Image>().sprite = Resources.Load("#Images/VibrateOff", typeof(Sprite)) as Sprite;
        }

    }
}
