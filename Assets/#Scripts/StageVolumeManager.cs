using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageVolumeManager : MonoBehaviour
{
    private AudioSource audiosrc;
    //public static float musicVolume;
    public Slider StageBGMSlider;

    // Use this for initialization
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        StageBGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1);

    }

    // Update is called once per frame
    void Update()
    {

        audiosrc.volume = StageBGMSlider.value;
    }

    public void SetStageBGMVolume(float vol)
    {
        Debug.Log(vol.ToString());

        StageBGMSlider.value = vol;
        PlayerPrefs.SetFloat("BGMVolume", vol);

    }

}
