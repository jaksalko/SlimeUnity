using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MenuButton : MonoBehaviour {

    public Button[] StageButton;
    public Button storeButton;
    public Button optionButton;
    public Button optionExitButton;
    int ClearStage;
    string str;
    public static int CurStage;
    public GameObject optionUI;
    public GameObject ExitUI;
    public Button exityes;
    public Button exitno;

    public GameObject storeUI;

    private void Awake()
    {
        



        StageButton[0] = GetComponent<Button>();
        for (int i = 1; i < StageButton.Length; i++)
            StageButton[i] = GameObject.Find("Stage" + i).GetComponent<Button>();


        StageButton[1].interactable = true;
        for (int i = 2; i < StageButton.Length; i++)
        {

            if (PlayerPrefs.GetInt("ClearStage", 0) >= i)
            {
                Debug.Log("여기여기" + PlayerPrefs.GetInt("ClearStage", 0));
                StageButton[i].interactable = true;
            }
            else
            {
                StageButton[i].interactable = false;
            }
        }
    }
    public void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape) && ExitUI.active == false)
            {
                ExitUI.SetActive(true);
            }
        }
    }
    public void storeButtonClick() {
        storeUI.SetActive(true);
    }
    public void storeExitClick()
    {
        storeUI.SetActive(false);
    }
    public void optionExitClick() {
        optionUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void optionButtonClick() {
        optionUI.SetActive(true);
    }
<<<<<<< HEAD
    public void gameStartButton()
    {
        // HEAD
        Debug.Log(ClearStage);
        str = EventSystem.current.currentSelectedGameObject.name;
        str = str.Replace("Stage", "");
        CurStage = Convert.ToInt32(str);
        PlayerPrefs.SetInt("CurStage", CurStage);
        AutoFade.LoadLevel("Stage" + CurStage.ToString(), 1, 1, Color.black);
        //
        RedMove.DieCheck = 0;
        Debug.Log("ClearStage = " + ClearStage);

=======
    public void gameStartButton() {

        Debug.Log(ClearStage);
           str = EventSystem.current.currentSelectedGameObject.name;
           str = str.Replace("Stage", "");
           CurStage = Convert.ToInt32(str);
           PlayerPrefs.SetInt("CurStage", CurStage);
           AutoFade.LoadLevel("Stage" + CurStage.ToString(), 1, 1, Color.black);

        Debug.Log("ClearStage = " + ClearStage);
        if (PlayerPrefs.GetInt("ClearStage", 0) == 0)
            AutoFade.LoadLevel("Stage0", 1, 1, Color.black);
        else
        {
            str = EventSystem.current.currentSelectedGameObject.name;
            str = str.Replace("Stage", "");
            CurStage = Convert.ToInt32(str);
            PlayerPrefs.SetInt("CurStage", CurStage);
            AutoFade.LoadLevel("Stage" + CurStage.ToString(), 1, 1, Color.black);

            RedMove.DieCheck = 0;
        }
>>>>>>> e792a331e90343fc07170766366faaed8757bb1d
    }
    public void ExitYesClick() {
        Application.Quit();
    }
    public void ExitNoClick() {
        ExitUI.SetActive(false);
    }
    public void deletepref()
    {
        PlayerPrefs.DeleteAll();
    }

}
