using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupCoinTextManager : MonoBehaviour {
    public TextMeshProUGUI popupGamecoinText;
    public TextMeshProUGUI popupTotalText;
    public static int temp;
    bool click;
    // Use this for initialization
    void Start()
    {
        click = false;
        popupTotalText.text = "" + temp;
        popupGamecoinText.text = "" + (TextManager.gamecoin);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click = true;
        }
    }
    public void OnGameOverIn()
    {

        Invoke("GameOver", 1);

    }
    public void GameOver()
    {
        Debug.Log("GameOver()1");
        //이부분에 게임 종료시 스코어 패널, 실행될 프로그램 입력 
        StartCoroutine(GameOverScoreView()); // 코루틴 
        click = false;
        CancelInvoke();
    }

    IEnumerator GameOverScoreView()
    {


        int t = temp;

        for (int i = 0; i <= TextManager.gamecoin; i++)
        {

            popupTotalText.text = "" + (t + i);
            popupGamecoinText.text = "" + (TextManager.gamecoin - i);

           
             

            if (click==true)
            {
                popupTotalText.text = "" + (t + TextManager.gamecoin);
                popupGamecoinText.text = "" + 0;
                t += TextManager.gamecoin;
                PlayerPrefs.SetInt("TotalCoin", t);
                break;
            }
            yield return new WaitForSeconds(.001f); //스코어 올라가는 시간 조절

        }
        if (click == false)
        {
            t += TextManager.gamecoin;
            PlayerPrefs.SetInt("TotalCoin", t);
            CancelInvoke();
        }
        
    }

    public void totalcoinPlus()//If die or clear
    {
        temp = MenuTextManager.totalcoin;
        MenuTextManager.totalcoin += TextManager.gamecoin;
        Debug.Log(MenuTextManager.totalcoin + "로 저장됨 토탈코인");
        PlayerPrefs.SetInt("TotalCoin", MenuTextManager.totalcoin);
        PlayerPrefs.Save();
    }


}