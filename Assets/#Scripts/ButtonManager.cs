using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class ButtonManager : MonoBehaviour {

    public delegate void Sound();
    public static event Sound Red;
    public static event Sound Blue;

    //delegate는 다른 스크립트에 있는 메소드를 static을 사용하지 않고 사용할 수 있게 만든다.
    public static bool RedWallCheck;//Red의 벽위치
    public static bool BlueWallCheck;//Blue의 벽위치
    public GameObject popup;
    public GameObject option;
   
    public GameObject next;
    public GameObject red;
    public GameObject blue;
    
    public GameObject cointxt;
    public GameObject redbutton;
    public GameObject bluebutton;
    Animator redManAnimator;
    Animator blueManAnimator;
    bool check;
    string str;
    void Awake()
    {
       




        Application.targetFrameRate = 60;
        check = false;
       
        RedWallCheck = true;
        BlueWallCheck = false;
        Screen.SetResolution(1080, 1920, true);
        redManAnimator = red.GetComponent<Animator>();
        blueManAnimator = blue.GetComponent<Animator>();

        

    }
    void Start()
    {
        
    }
    void Update()
    {
        if (RedMove.AllAlive == false)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (RedWallCheck == false)
        {
            red.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
//           
        }
        else
        {
            red.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);

        }

        if (BlueWallCheck == false)
        {
            blue.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);

        }
        else
        {
            blue.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);

        }
    }



    public void LeftButtonClick()
    {
        if (RedMove.AllAlive == false)
            return;
        redManAnimator.Play("RedSlimeJump");
        if (RedWallCheck == true)
        {
            red.transform.Rotate(new Vector3(180, 0, 0));
           
            RedWallCheck = false;
          

        }
        else if (RedWallCheck == false)
        {
            red.transform.Rotate(new Vector3(180, 0, 0));
           
            RedWallCheck = true;
           
        }
        Red();
      
    }

    public void RightButtonClick()
    {
        if (RedMove.AllAlive == false)
            return;
        blueManAnimator.Play("BlueSlimeJump");
        if (BlueWallCheck == true)
        {
            blue.transform.Rotate(new Vector3(180, 0, 0));
           
            BlueWallCheck = false;
         
        }
        else
        {
            blue.transform.Rotate(new Vector3(180, 0, 0));
          
            BlueWallCheck = true;
          
        }
        Blue();
      
    }
    public void PauseButton()
    {
       
        popup.SetActive(true);
        next.SetActive(false);
        
        cointxt.SetActive(false);
        Time.timeScale = 0;
        

    }
    public void gomenuButton()
    {
        
        popup.SetActive(false);
        next.SetActive(true);
        
        cointxt.SetActive(true);
        if (RedMove.DieCheck > 0&&RedMove.clearSt==true)
        {
            if (PlayerPrefs.GetInt("ClearStage", 0) < PlayerPrefs.GetInt("CurStage", 0))
            {
                int ClearStage = PlayerPrefs.GetInt("CurStage", 0);


                PlayerPrefs.SetInt("ClearStage", ClearStage);
                PlayerPrefs.Save();

            }
        }
            AutoFade.LoadLevel("Menu", 1, 1, Color.black);

            if (PlayerPrefs.GetInt("CurStage", 0) == 0)
            {
                MenuButton.CurStage++;
                PlayerPrefs.SetInt("CurStage", MenuButton.CurStage);
                PlayerPrefs.Save();
            }
            check = true;
        
        Time.timeScale = 1;

    }
    public void ResumeButton()
    {
       
        popup.SetActive(false);
        next.SetActive(true);
        
        cointxt.SetActive(true);
        Time.timeScale = 1;

    }
    public void RestartButton()
    {
        int count = PlayerPrefs.GetInt("PlayCount", 0);
        count++;
        PlayerPrefs.SetInt("PlayCount", count);
        Debug.Log("PlayCount = " + PlayerPrefs.GetInt("PlayCount", 0));
        popup.SetActive(false);
        if (RedMove.DieCheck > 0 && RedMove.clearSt == true)
        {
            if (PlayerPrefs.GetInt("ClearStage", 0) < PlayerPrefs.GetInt("CurStage", 0))
            {
               int ClearStage = PlayerPrefs.GetInt("CurStage", 0);


                PlayerPrefs.SetInt("ClearStage", ClearStage);
                PlayerPrefs.Save();

            }
        }
        AutoFade.LoadLevel("Stage" + MenuButton.CurStage.ToString(), 1, 1, Color.black);
        
        Time.timeScale = 1;
    }
    public void NextStageButton()
    {

        int count = PlayerPrefs.GetInt("PlayCount", 0);
        count++;
        PlayerPrefs.SetInt("PlayCount", count);
        Debug.Log("PlayCount = " + PlayerPrefs.GetInt("PlayCount", 0));

        if (RedMove.DieCheck > 0 && RedMove.clearSt == true)
        {
            if (PlayerPrefs.GetInt("ClearStage", 0) < PlayerPrefs.GetInt("CurStage", 0))
            {
                int ClearStage = PlayerPrefs.GetInt("CurStage", 0);


                PlayerPrefs.SetInt("ClearStage", ClearStage);
                PlayerPrefs.Save();

            }
        }
           MenuButton.CurStage++;
            PlayerPrefs.SetInt("CurStage", MenuButton.CurStage);
            PlayerPrefs.Save();
            AutoFade.LoadLevel("Stage" + MenuButton.CurStage.ToString(), 1, 1, Color.black);
            check = true;
        


    }
    public void OptionButton()
    {
        option.SetActive(true);
        Time.timeScale = 0;
    }
    public void OptionExitButton()
    {
        option.SetActive(false);
        Time.timeScale = 1;
    }


}
