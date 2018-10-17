﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMove : MonoBehaviour
{
    public delegate void reverR(int i);
    public static event reverR Redrev;

    private PopupCoinTextManager popuptextmanager;
    private TextManager textmanager;
    public static bool RedEndPortalLook;
    public static bool RedReversePortalLook;
    public bool check;
    //public int a = 0;
    public float tempx = 0;
    public float tempy = 0;
    public Vector3 posRed;
    public Vector3 posBlue;
    public GameObject popup;
    public GameObject resume;
    public GameObject nextStage;
    public GameObject redMan;
    public GameObject blueMan;
    private GameObject RedHidePortal;
    public AudioSource RedSound;
    Animator redManAnimator;
    public static bool RedAlive;
    public static bool AllAlive;
    public int ReverseCount;//리버스 포탈이 0과짝수면 아래쪽 / 홀수면 위쪽에서 나타나는 것을 구분
    public int ClearStage;
    public int CurStage;
    private MenuButton menuButton;
    public static bool RedDieOrClear;//false = Die , true = Clear
    public static bool RedStart;
    public static int DieCheck;



    // Use this for initialization
    void Awake()
    {

        Debug.Log("Awake");
        ReverseCount = 0;
        RedStart = true;
        RedAlive = true;
        AllAlive = true;
        DieCheck = 0;
        RedDieOrClear = true;
        popup.gameObject.SetActive(true);
        popuptextmanager = GameObject.Find("PopupTotalText").GetComponent<PopupCoinTextManager>();
        popuptextmanager = GameObject.Find("PopupCoinText").GetComponent<PopupCoinTextManager>();
        popup.gameObject.SetActive(false);
        textmanager = GameObject.Find("CoinText").GetComponent<TextManager>();
        RedHidePortal = GameObject.Find("RedPortalObject");
        ButtonManager.Red += reds;
        redManAnimator = redMan.GetComponent<Animator>();
        ButtonManager.RedWallCheck = true;//왼쪽 벽
        ButtonManager.BlueWallCheck = false;//오른쪽 벽

    }

    // Update is called once per frame
    void Update()
    {


        if (RedStart == true)
        {
            if (this.transform.localPosition.y > 3)
                this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            else
                RedStart = false;
        }

        if (RedDieOrClear == false || BlueMove.BlueDieOrClear == false)//가시에 찔렸을 시
        {
            RedDieOrClear = false;
            BlueMove.BlueDieOrClear = false;
            redManAnimator.Play("RedSlimeDie");
            if (DieCheck == 0)
                popuptextmanager.OnGameOverIn();
            else
                return;
            popup.gameObject.SetActive(true);
            resume.gameObject.SetActive(false);
            nextStage.gameObject.SetActive(false);

            CurStage = PlayerPrefs.GetInt("CurStage");

            //if (ClearStage < CurStage)
            //{
            //    ClearStage = CurStage;
            //}

            PlayerPrefs.Save();

            Debug.Log("GameOver");
            //popup.gameObject.SetActive(true);
            //resume.gameObject.SetActive(false);

            redManAnimator.Play("RedSlimeDie");
            AllAlive = false;
            DieCheck++;

        }

        if (RedMove.AllAlive == false && RedDieOrClear == true && BlueMove.BlueDieOrClear == true)//클리어 시
        {
            Debug.Log("클리어 했음");
            //redManAnimator.Play("RedSlimeDie");
            //만일 클리어 하면
            CurStage = PlayerPrefs.GetInt("CurStage");
            ClearStage = PlayerPrefs.GetInt("ClearStage", 0);       //클리어한 가장 마지막 스테이지 저장
            if (ClearStage < CurStage && RedDieOrClear == true && BlueMove.BlueDieOrClear == true)
            {
                ClearStage = CurStage;
            }
            PlayerPrefs.SetInt("ClearStage", ClearStage);
            PlayerPrefs.Save();
            if (DieCheck == 0)
            {
                Debug.Log("레드 슬라임 다이체크");
                popuptextmanager.OnGameOverIn();
                DieCheck++;
            }
            else
            {
                if (RedThornMove.RedReverse == false)
                    this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
                else
                    this.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                return;
            }
            popup.gameObject.SetActive(true);
            resume.gameObject.SetActive(false);
            nextStage.gameObject.SetActive(true);
        }


        if (RedAlive == false || RedMove.AllAlive == false)//둘중에 하나가 false 상태면 움직x
        {
            return;
        }
        if (RedMove.RedEndPortalLook == true)//포탈이 화면에 보이면 슬라임이 떨어짐

        {

            {

                Handheld.Vibrate(); // 진동 메소드

                Handheld.Vibrate();

                if (RedThornMove.RedReverse == false)
                    this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
                else
                    this.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
            }

            if (RedMove.RedReversePortalLook == true)//포탈이 화면에 보이면 슬라임이 떨어짐
            {
                if (RedThornMove.RedReverse == false)
                {
                    this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
                    // RedMove.RedReversePortalLook = false;
                }
                else
                {
                    this.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                    //RedMove.RedReversePortalLook = false;
                }
            }





        }
    }

    void reds()
    {
        RedSound.Play();
    }

    void OnCollisionEnter(Collision coll)
    {


        redManAnimator.Play("RedSlimeMove");
        //gameObject.GetComponent<Animator>().Play("Die");
        if (coll.gameObject.tag == "Enemy")
        {
            popuptextmanager.totalcoinPlus();
            Debug.Log("가시에 찔림");
            RedDieOrClear = false;
            redManAnimator.Play("RedSlimeDie");
            RedAlive = false;

            if (BlueMove.BlueAlive == true)
            {
                return;
            }

            //만일 클리어 하면

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {

            textmanager.getCoin();
            Debug.Log("coin++");
            other.gameObject.SetActive(false);//방금 트리거가 발생한 코인을 숨기기

        }
        if (other.gameObject.tag == "RedPortal" && this.tag.ToString() == "RedMan")
        {

            posRed = redMan.transform.position;
            posBlue = blueMan.transform.position;
            tempx = posRed.x;
            tempy = posRed.y;
            redMan.transform.position = new Vector3(posBlue.x, posBlue.y, 0);
            blueMan.transform.position = new Vector3(tempx, tempy, 0);

            if (ButtonManager.BlueWallCheck == true && ButtonManager.RedWallCheck == true)
            {
                ButtonManager.RedWallCheck = true;
                ButtonManager.BlueWallCheck = true;
            }
            else if (ButtonManager.BlueWallCheck == false && ButtonManager.RedWallCheck == true)
            {
                ButtonManager.RedWallCheck = false;
                ButtonManager.BlueWallCheck = true;
                redMan.transform.Rotate(new Vector3(180, 0, 0));
                blueMan.transform.Rotate(new Vector3(180, 0, 0));
            }
            else if (ButtonManager.BlueWallCheck == true && ButtonManager.RedWallCheck == false)
            {
                ButtonManager.RedWallCheck = true;
                ButtonManager.BlueWallCheck = false;
                redMan.transform.Rotate(new Vector3(180, 0, 0));
                blueMan.transform.Rotate(new Vector3(180, 0, 0));
            }
            else
            {
                ButtonManager.RedWallCheck = false;
                ButtonManager.BlueWallCheck = false;
            }





        }
        if (other.gameObject.tag == "RedReversePortal" && this.tag.ToString() == "RedMan")
        {

            Debug.Log("reverse   Redreversecount = " + ReverseCount);
            if (ReverseCount % 2 == 0)//리버스 포탈이 아래쪽에 있을 때
                RedThornMove.RedReverse = true;
            else//리버스 포탈이 위쪽에 있을 때
                RedThornMove.RedReverse = false;

            RedMove.RedReversePortalLook = false; // Reverse포탈에 닿으면 다시 false로 바꿔줌
                                                  //바꿔주지 않으면 계속 보이는 상태로인해
                                                  //RedThornMove 스크립트의 ReverseMove()에서
                                                  //정상 작동을 하지 않음.

            RedHidePortal.SetActive(false);
            Redrev(0); // RedThornMove에 있는 redreev() 메소드를 호출
            this.transform.Rotate(new Vector3(180, 0, 180));
            ReverseCount++;
        }
        if (other.gameObject.tag == "EndPortal")
        {
            Debug.Log("레드슬라임 앤드포탈 만남");
            popuptextmanager.totalcoinPlus();
            RedAlive = false;
            RedDieOrClear = true;
            redManAnimator.Play("RedSlimeDie");
            Debug.Log("Red Clear Game");



            //만일 클리어 하면
            CurStage = PlayerPrefs.GetInt("CurStage");
            ClearStage = PlayerPrefs.GetInt("ClearStage", 0);       //클리어한 가장 마지막 스테이지 저장
            if (ClearStage < CurStage)
            {
                ClearStage = CurStage;
            }
            PlayerPrefs.SetInt("ClearStage", ClearStage);
            PlayerPrefs.Save();
            if (BlueMove.BlueAlive == true)
                return;




        }
    }
    void OnDestroy()
    {
        ButtonManager.Red -= reds;

    }
}

