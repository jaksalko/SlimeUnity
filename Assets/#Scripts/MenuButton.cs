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
<<<<<<< HEAD
    public GameObject ExitUI;
    public Button exityes;
    public Button exitno;
=======
>>>>>>> 4fff2abca66371f49672c1fb9319df7db7e82fbc
    public GameObject storeUI;

    private void Awake()
    {

        ClearStage = PlayerPrefs.GetInt("ClearStage", 0);       //클리어한 가장 마지막 스테이지 저장

        StageButton[0] = GetComponent<Button>();
        for (int i = 1; i < StageButton.Length; i++)
            StageButton[i] = GameObject.Find("Stage" + i).GetComponent<Button>();


        for (int i = 1; i < StageButton.Length; i++) {
            if (ClearStage + 1 >= i)
            {
                StageButton[i].interactable = true;
            }
            else {
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
    public void gameStartButton() {
        Debug.Log(ClearStage);
        if (ClearStage == 0)
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
