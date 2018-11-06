using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class MissionManager : MonoBehaviour {
    private MenuTextManager menutextmanager;
    public Button[] treasureButton;
    public Button[] missionButton;
    public TextMeshProUGUI clearmissionText;
    string str;
    int clearnum = 0;

    // Use this for initialization
    // PlayerPrefs "mission" + num -> nc or cn or cy  (nc: 깨지 못함 cn:깼는데 보상을 안받음 cy:깨고 보상도 받음)
    //nc : not clear    cn: clear but not take treasure      cy: clear and take treasure

    void Start ()
    {
        menutextmanager = GameObject.Find("TotalCoinText").GetComponent<MenuTextManager>();
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetString("mission0", "nc") == "nc" && PlayerPrefs.GetInt("ClearStage", 0) > 4)//mission0 이 안깬 상태고 클리어 스테이지가 5이상 이면
        {
            PlayerPrefs.SetString("mission0", "cn");//mission 0을 cn 상태로 바꿔줌
        }
        if (PlayerPrefs.GetString("mission2", "nc") == "nc" && PlayerPrefs.GetInt("ClearStage", 0) > 9)//mission2 이 안깬 상태고 클리어 스테이지가 10이상 이면
        {
            PlayerPrefs.SetString("mission2", "cn");//mission 0을 cn 상태로 바꿔줌
        }
        if (PlayerPrefs.GetString("mission4", "nc") == "nc" && PlayerPrefs.GetInt("ClearStage", 0) > 19)//mission4 이 안깬 상태고 클리어 스테이지가 20이상 이면
        {
            PlayerPrefs.SetString("mission4", "cn");//mission 0을 cn 상태로 바꿔줌
        }
        if (PlayerPrefs.GetString("mission6", "nc") == "nc" && PlayerPrefs.GetInt("ClearStage", 0) > 29)//mission6 이 안깬 상태고 클리어 스테이지가 30이상 이면
        {
            PlayerPrefs.SetString("mission6", "cn");//mission 0을 cn 상태로 바꿔줌
        }



        if (PlayerPrefs.GetString("mission1", "nc") == "nc" && PlayerPrefs.GetInt("TotalCoin", 0) > 99)//mission1 이 안깬 상태고 코인 갯수가 100개 이상이면
        {
            PlayerPrefs.SetString("mission1", "cn");//mission 1을 cn 상태로 바꿔줌
        }
        if (PlayerPrefs.GetString("mission3", "nc") == "nc" && PlayerPrefs.GetInt("TotalCoin", 0) > 999)//mission1 이 안깬 상태고 코인 갯수가 1000개 이상이면
        {
            PlayerPrefs.SetString("mission3", "cn");//mission 3을 cn 상태로 바꿔줌
        }
        if (PlayerPrefs.GetString("mission5", "nc") == "nc" && PlayerPrefs.GetInt("TotalCoin", 0) > 9999)//mission1 이 안깬 상태고 코인 갯수가 10000개 이상이면
        {
            PlayerPrefs.SetString("mission5", "cn");//mission 5을 cn 상태로 바꿔줌
        }




        for (int i = 0; i < treasureButton.Length; i++)//미션 상황에 따라 버튼의 이미지를 설정
        {

            if (PlayerPrefs.GetString("mission" + i.ToString(), "nc") == "nc")//깨지 못함
            {
                treasureButton[i].interactable = false;
                missionButton[i].interactable = true;
            }
            else if (PlayerPrefs.GetString("mission" + i.ToString(), "nc") == "cn")//깼는데 보상을 안받음
            {
                treasureButton[i].interactable = true;
                missionButton[i].interactable = true;
                clearnum++;
            }
            else if (PlayerPrefs.GetString("mission" + i.ToString(), "nc") == "cy")//깨고 보상도 받음
            {
                treasureButton[i].gameObject.SetActive(false);
                missionButton[i].interactable = false;
            }
            
        }
        clearmissionText.text = clearnum.ToString();
    }
	
    public void treasureButtonClick()//missionbutton 이 interactable = true 일때 (보상을 받지 않았을 때)
    {
        
        str = EventSystem.current.currentSelectedGameObject.name;
        str = str.Replace("missionbutton", "");
        int num = Convert.ToInt32(str);
        Debug.Log(num);
        if (PlayerPrefs.GetString("mission" + num.ToString(), "nc") == "cn")//보상을 받지 않았고, 미션을 깼다면
        {
            missionButton[num].interactable = false;// cy 상태로 바꿔줌
            treasureButton[num].gameObject.SetActive(false);
            clearnum--;
            clearmissionText.text = clearnum.ToString();
            switch (num)//미션 보상을 받은 상태로 하고 보상 지급
            {
                case 0:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0)+100);
                    PlayerPrefs.SetString("mission0", "cy");
                    MenuTextManager.totalcoin += 100;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 1:
                    //Debug.Log("미션전 " + PlayerPrefs.GetInt("TotalCoin", 0));
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 100);
                    PlayerPrefs.SetString("mission1", "cy");
                    MenuTextManager.totalcoin += 100;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    //Debug.Log("미션 후  " + PlayerPrefs.GetInt("TotalCoin", 0));
                    break;
                case 2:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 500);
                    PlayerPrefs.SetString("mission2", "cy");
                    MenuTextManager.totalcoin += 500;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 3:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 500);
                    PlayerPrefs.SetString("mission3", "cy");
                    MenuTextManager.totalcoin += 500;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 4:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 5000);
                    PlayerPrefs.SetString("mission4", "cy");
                    MenuTextManager.totalcoin += 5000;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 5:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 5000);
                    PlayerPrefs.SetString("mission5", "cy");
                    MenuTextManager.totalcoin += 5000;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 6:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 10000);
                    PlayerPrefs.SetString("mission6", "cy");
                    MenuTextManager.totalcoin += 10000;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 7:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 10000);
                    PlayerPrefs.SetString("mission7", "cy");
                    MenuTextManager.totalcoin += 10000;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;
                case 8:
                    PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin", 0) + 20000);
                    PlayerPrefs.SetString("mission8", "cy");
                    MenuTextManager.totalcoin += 20000;
                    menutextmanager.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("TotalCoin", 0).ToString();
                    break;

            }
            PlayerPrefs.Save();
        }
       
        
        
        
            

    }
}
