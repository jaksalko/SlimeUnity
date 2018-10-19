using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueThornMove : MonoBehaviour
{

    public GameObject[] Thorn;
    public GameObject[] Wall;
    public Transform[] Potal;
    public Transform[] EndPotal;
    public List<GameObject> ReversePotal;
    public GameObject[] coinn;
    public static bool BlueReverse;
    public GameObject blueSideObject;
    public GameObject redSideObject;
    bool a;
    float moveX, moveY;
    void Awake()
    {
        a = true;
        RedMove.RedEndPortalLook = false;
        BlueMove.BlueEndPortalLook = false;

        RedMove.RedReversePortalLook = false;
        BlueMove.BlueReversePortalLook = false;

        BlueReverse = false;

        BlueMove.Bluerev += bluereev;

        for (int i = 0; i < Wall.Length; i++)
            Wall[i] = GameObject.Find("BWall").transform.Find("blue_wall (" + i + ")").gameObject;

        for (int i = 0; i < Thorn.Length; i++)
            Thorn[i] = GameObject.Find("BThorns").transform.Find("blue_thorn (" + i + ")").gameObject;

        for (int i = 0; i < coinn.Length; i++)
            coinn[i] = GameObject.Find("BCoins").transform.Find("bcoin (" + i + ")").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueMove.BlueStart == true)
            return;
        if (BlueMove.BlueDieOrClear == false)
            return;
        if (RedMove.AllAlive == false && RedMove.RedDieOrClear == true && BlueMove.BlueDieOrClear == true)
        {
            return;
        }
        if (BlueMove.BlueAlive == false || RedMove.AllAlive == false)
        {
            return;
        }
        ReverseMove();
        BlueReversePortalisLooked();
        BluePotalisLooked();
    }

    void bluereev(int i)
    {
        Destroy(ReversePotal[i]);
        ReversePotal.RemoveAt(i);
    }

    void ReverseMove()
    {

        if (BlueMove.BlueReversePortalLook == false)
        {
            Move();
            //Debug.Log("redreverse");
            //return;
        }
        else
            return;

    }
    void ThornMoveX(float speed, int ThornNum)//0.5f가 적당한 속도
    {
        moveX = Thorn[ThornNum].transform.localPosition.x;
        
            if (a == true)
            {
                Thorn[ThornNum].transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x < 0.75f)
                {
                    a = false;
                }

            }
            else
            {
                Thorn[ThornNum].transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x > 2.1f)
                {
                    a = true;
                }
            }
        
    }
    void ThornMoveY(float speed, int ThornNum)
    {
        moveY = Thorn[ThornNum].transform.localPosition.y;
       
            if (a == true)
            {
                Thorn[ThornNum].transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.y > moveY + 1.2f)
                {
                    a = false;
                }

            }
            else
            {
                Thorn[ThornNum].transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.y < moveY - 1.2f)
                {
                    a = true;
                }
            }
        
    }
    void Move()
    {
        Debug.Log(PlayerPrefs.GetInt("CurStage", 0)+"stage");
        if (BlueMove.BlueEndPortalLook == true)
        {
            
            return;
        }
        switch (PlayerPrefs.GetInt("CurStage", 0))
        {
            case 6:
                {
                    ThornMoveY(0.5f,  0);
                    ThornMoveY(1f,  1);
                    break;
                }
            case 7:
                {
                    ThornMoveY(0.5f,  0);
                    ThornMoveY(1f,  1);
                    ThornMoveX(0.5f,  2);
                    ThornMoveX(0.5f,  3);
                    ThornMoveY(0.5f,  2);
                    ThornMoveY(0.5f,  3);

                    break;
                }
            case 8:
                {
                    ThornMoveX(0.5f, 4);
                    break;
                }

                
        }
        
        if (BlueReverse == false)
        {

            
            for (int i = 0; i < Thorn.Length; i++)
            {
                Thorn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                
            }
            for (int i = 0; i < Wall.Length; i++)
                Wall[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Potal.Length; i++)
                Potal[i].Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < EndPotal.Length; i++)
                EndPotal[i].Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < ReversePotal.Count; i++)
                ReversePotal[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < coinn.Length; i++)
                coinn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
        }
        else if (BlueReverse == true)//RedReverse모드인 경우
        {


            for (int i = 0; i < Thorn.Length; i++)
                Thorn[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);


            for (int i = 0; i < Wall.Length; i++)
                Wall[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Potal.Length; i++)
                Potal[i].Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < EndPotal.Length; i++)
                EndPotal[i].Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < ReversePotal.Count; i++)
                ReversePotal[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
            for (int i = 0; i < coinn.Length; i++)
                coinn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
        }

    }

    void BluePotalisLooked()//화면은 움직이지 않고 슬라임이 움직일 EndPortal의 y좌표값 입력
    {
        if (EndPotal.Length > 0)
            if (EndPotal[0].localPosition.y >= -4.5f && EndPotal[0].localPosition.y <= -4f)
            {
                //BlueMove.BlueEndPortalLook = true;
                BlueMove.BlueEndPortalLook = true;
                //Debug.Log("potal");
            }
            else if (EndPotal[0].localPosition.y <= 1.5f && EndPotal[0].localPosition.y >= 1f)
            {
                BlueMove.BlueEndPortalLook = true;
            }
    }

    void BlueReversePortalisLooked()//화면은 움직이지 않고 슬라임이 움직일 ReversePortal의 y좌표값 입력
    {
        for (int i = 0; i < ReversePotal.Count; i++)//&& ReversePotal[].localPosition.y <= -4f
        {
            if ((ReversePotal[i].transform.localPosition.y >= -4.5f && ReversePotal[i].transform.localPosition.y <= -4f)
                || (ReversePotal[i].transform.localPosition.y <= 3.3f && ReversePotal[i].transform.localPosition.y >= 2.8f))
            {

                BlueMove.BlueReversePortalLook = true;

            }

        }
    }
    void onDestroy()
    {
        BlueMove.Bluerev -= bluereev;
    }
}
