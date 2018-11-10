using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMove : MonoBehaviour
{
    public GameObject popup;
    private PopupCoinTextManager popuptextmanager;
    private TextManager textmanager;
    public static bool BlueEndPortalLook;//End 포탈이 정해진 위치에 도달했는지?
    public static bool BlueReversePortalLook;//Reverse 포탈이 정해진 위치에 도달했는지?
    public float tempx = 0;
    public float tempy = 0;
    public Vector3 posRed;
    public Vector3 posBlue;
    public GameObject redMan;
    public GameObject blueMan;
    private GameObject BlueHidePortal;//Reverse 포탈과 충돌시 Blue의 장애물 중 Portal을 없애기 위함 
    public int ReverseCount;
    public static bool BlueAlive;
    Animator blueManAnimator;
   // private BlueThornMove blue;
    public AudioSource BlueSound;
    public AudioSource BlueCoinSound;
    public int ClearStage;
    private MenuButton menuButton;
    int CurStage;
    public static bool BlueDieOrClear;//false = Die , true = Clear
    public static bool BlueStart;

    // Use this for initialization
    void Awake()
    {

        Debug.Log("블루무브 awake");
        BlueStart = true;
        BlueDieOrClear = true;
        BlueAlive = true;
        ReverseCount = 0;
        popup.gameObject.SetActive(true);
        popuptextmanager = GameObject.Find("PopupTotalText").GetComponent<PopupCoinTextManager>();
        popuptextmanager = GameObject.Find("PopupCoinText").GetComponent<PopupCoinTextManager>();
        popup.gameObject.SetActive(false);
        textmanager = GameObject.Find("CoinText").GetComponent<TextManager>();
        ButtonManager.Blue += blues;
        blueManAnimator = blueMan.GetComponent<Animator>();
        BlueHidePortal = GameObject.Find("BluePortalObject");
        //BlueHidePortal초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueStart == true)
        {
            if (this.transform.localPosition.y > 3)
                this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            else
                BlueStart = false;
        }
        if (RedMove.RedDieOrClear == false || BlueDieOrClear == false)
        {
            RedMove.RedDieOrClear = false;
            BlueDieOrClear = false;
            blueManAnimator.Play("BlueSlimeDie");
            return;
        }
        if (RedMove.DieCheck != 0)
        {
            Debug.Log("블루 슬라임 다이체크");
            if (BlueThornMove.BlueReverse == false)
                this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            else
                this.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
            return;
        }

        if (BlueAlive == false || RedMove.AllAlive == false)
        {
            Debug.Log("블루 멈춤");
            return;
        }
        if (BlueMove.BlueEndPortalLook == true)//포탈이 화면에 보이면 슬라임이 떨어짐
        {
            if (BlueThornMove.BlueReverse == false)
                this.transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            else
                this.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
        }

        if (BlueMove.BlueReversePortalLook == true)//포탈이 화면에 보이면 슬라임이 떨어짐
        {
            if (BlueThornMove.BlueReverse == false)
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

    void blues()
    {
        BlueSound.Play();
    }

    void OnCollisionEnter(Collision coll)
    {

        blueManAnimator.Play("BlueSlimeMove");
        if (coll.gameObject.tag == "Enemy" )
        {
            popuptextmanager.totalcoinPlus();
            blueManAnimator.Play("BlueSlimeDie");
            BlueMove.BlueDieOrClear = false;
            BlueAlive = false;
            if (RedMove.RedAlive == true)
            {
                return;
            }
            
            
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            BlueCoinSound.Play();
            textmanager.getCoin();
            Debug.Log("coin++");
            other.gameObject.SetActive(false);//방금 트리거가 발생한 코인을 숨기기

        }
        if (other.gameObject.tag == "BluePortal" && this.tag.ToString() == "BlueMan")
        {
            if (PlayerPrefs.GetInt("Vibrate", 0) != 0)
            {
                Handheld.Vibrate(); // 진동 메소드
                Debug.Log("Vibrate");
            }
            other.gameObject.SetActive(false);
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
            }//둘다 왼쪽벽
            else if (ButtonManager.BlueWallCheck == false && ButtonManager.RedWallCheck == true)
            {
                ButtonManager.RedWallCheck = false;
                ButtonManager.BlueWallCheck = true;
                redMan.transform.Rotate(new Vector3(180, 0, 0));
                blueMan.transform.Rotate(new Vector3(180, 0, 0));
            }// Red = 왼쪽 Blue = 오른쪽
            else if (ButtonManager.BlueWallCheck == true && ButtonManager.RedWallCheck == false)
            {
                ButtonManager.RedWallCheck = true;
                ButtonManager.BlueWallCheck = false;
                redMan.transform.Rotate(new Vector3(180, 0, 0));
                blueMan.transform.Rotate(new Vector3(180, 0, 0));
            }// Red = 오른쪽 Blue = 왼쪽
            else
            {
                ButtonManager.RedWallCheck = false;
                ButtonManager.BlueWallCheck = false;
            }// Red = 오른쪽 Blue = 오른쪽
            Debug.Log("Blueportal");




        }
        if (other.gameObject.tag == "RedReversePortal" && this.tag.ToString() == "BlueMan")
        {
            popuptextmanager.totalcoinPlus();
            blueManAnimator.Play("BlueSlimeDie");
            BlueMove.BlueDieOrClear = false;
            BlueAlive = false;
            if (RedMove.RedAlive == true)
            {
                return;
            }
        }
        if (other.gameObject.tag == "RedEndPortal")
        {
            popuptextmanager.totalcoinPlus();
            blueManAnimator.Play("BlueSlimeDie");
            BlueMove.BlueDieOrClear = false;
            BlueAlive = false;
            if (RedMove.RedAlive == true)
            {
                return;
            }
        }
            if (other.gameObject.tag == "BlueReversePortal" && this.tag.ToString() == "BlueMan")
        {
            Debug.Log("reverse Bluereversecount = " + ReverseCount);
            if (ReverseCount % 2 == 0)//리버스 포탈이 아래쪽에 있을 때
                BlueThornMove.BlueReverse = true;
            else//리버스 포탈이 위쪽에 있을 때
                BlueThornMove.BlueReverse = false;

            BlueMove.BlueReversePortalLook = false; // Reverse포탈에 닿으면 다시 false로 바꿔줌



            Debug.Log(this.ToString());
            Debug.Log("들어옴블루" + BlueThornMove.ReversePotal2.Count);
            Destroy(BlueThornMove.ReversePotal2[0]);
            BlueThornMove.ReversePotal2.RemoveAt(0);



















            this.transform.Rotate(new Vector3(180, 0, 180));
            ReverseCount++;


        }//ReversePortal을 만나고 그것이 BlueMan일 경우
        if (other.gameObject.tag == "BlueEndPortal")
        {
            Debug.Log("블루슬라임 앤드포탈 만남");
            BlueAlive = false;
            BlueMove.BlueDieOrClear = true;
            


            
            if (RedMove.RedAlive == true)
                return;
            RedMove.AllAlive = false;
            Debug.Log("Blue Clear Game");


        }
        if (other.gameObject.tag == "EndPortal")
        {
            Debug.Log("블루슬라임 앤드포탈 만남");
            BlueAlive = false;
            BlueMove.BlueDieOrClear = true;




            if (RedMove.RedAlive == true)
                return;
            RedMove.AllAlive = false;
            Debug.Log("Blue Clear Game");


        }
    }
    void OnDestroy()
    {
        ButtonManager.Blue -= blues;
    }
}
