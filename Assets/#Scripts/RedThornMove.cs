using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedThornMove : MonoBehaviour
{
    //장애물들을 하나의 Object로 보고나서 짠 코드


    public GameObject[] Thorn;
    public GameObject[] Wall;
    public Transform[] Potal;
    public Transform[] EndPotal;
    public List<GameObject> ReversePotal;//Transform -> GameObject로 바꿔줌
    public GameObject[] coinn;
    public static bool RedReverse;
    //Reverse방향으로 가는지 즉, ReversePortal을 탔는지
    //Red, Blue 두개로 만들어야 함. 아직 하나만 구현(Red만 구현)
    public GameObject blueSideObject;
    public GameObject redSideObject;
    float moveX, moveY;
    bool a;
    void Awake()
    {
        RedMove.RedEndPortalLook = false;//End포탈이 보이지 않는 상태 초기화
        BlueMove.BlueEndPortalLook = false;

        RedMove.RedReversePortalLook = false;//ReversePortal이 보이지 않는 상태 초기화
        BlueMove.BlueReversePortalLook = false;

        RedReverse = false; // Reverse모드가 아닌 상태 초기화
        //foreach (var ii in ReversePotal)
        //{
        //    reverseportalnum++;
        //}
        RedMove.Redrev += redreev;
        for (int i = 0; i < Wall.Length; i++)
            Wall[i] = GameObject.Find("RWall").transform.Find("red_wall (" + i + ")").gameObject;

        for (int i = 0; i < Thorn.Length; i++)
            Thorn[i] = GameObject.Find("RThorns").transform.Find("red_thorn (" + i + ")").gameObject;

        for (int i=0; i<coinn.Length;i++)
            coinn[i] = GameObject.Find("RCoins").transform.Find("rcoin ("+i+")").gameObject;
        
        


        // for(int i=0;i< ReversePotal.Count;i++)
    }

    // Update is called once per frame
    void Update()
    {
        if (RedMove.RedDieOrClear == false)
            return;

        if (RedMove.RedStart == true)
            return;
        if (RedMove.AllAlive == false && RedMove.RedDieOrClear == true && BlueMove.BlueDieOrClear == true)
        {
            return;
        }
        if (RedMove.RedAlive == false || RedMove.AllAlive == false)
        {
            return;
        }
        ReverseMove();
        RedReversePortalisLooked();
        RedPotalisLooked();
        //ThornMoveX(1, 1);
        //ThornMoveY(1, 0);
    }

    void redreev(int i)
    {
        Destroy(ReversePotal[0]);
        ReversePotal.RemoveAt(0);
    }

    void ReverseMove()//Reverse모드인지 아닌지 구별하기 위한 함수
    {
        
        if (RedMove.RedReversePortalLook == false)//Reverse포탈이 보이지 않는다면
        {
            Move();
            
            //return;
        }
        else//Reverse포탈이 보인다면 리턴
            return;
        
    }

    void ThornMoveX(float speed,  int ThornNum)//0.5f가 적당한 속도
    {
        moveX = Thorn[ThornNum].transform.localPosition.x;
        
            if (a == true)
            {
                Thorn[ThornNum].transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x < -2.1f)
                {
                    a = false;
                }

            }
            else
            {
                Thorn[ThornNum].transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x > -0.75f)
                {
                    a = true;
                }
            }
        
    }
    void ThornMoveY(float speed,  int ThornNum)
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
        
        if (RedMove.RedEndPortalLook == true)//Reverse포탈이 보이고 && End 포탈이 보이면 return;
                                             //사실상 이런 상황이 없을 것으로 맵이 만들어질 것임.
        {
            
            return;
        }
        switch (PlayerPrefs.GetInt("CurStage", 0))
        {
            case 6:
                {
                    ThornMoveX(0.5f,  0);
                    ThornMoveX(1f,  1);
                    break;
                }
            case 7:
                {
                    ThornMoveX(0.5f,  0);
                    ThornMoveX(1f,  1);
                    ThornMoveY(0.7f,  2);

                    ThornMoveX(0.5f,  3);
                    ThornMoveX(0.5f,  4);
                    ThornMoveY(1f,  3);
                    ThornMoveY(1f,  4);
                    break;
                }
            case 8:
                {
                    ThornMoveX(0.5f, 5);
                    ThornMoveX(0.5f, 6);
                    break;
                }


        }
        if (RedReverse == false)//RedReverse모드가 아닌 경우
        {
            
            for (int i = 0; i < Thorn.Length; i++)
                Thorn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

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
        else if(RedReverse == true)//RedReverse모드인 경우
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
                coinn[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);

        }
        
    }

    void RedPotalisLooked()//화면은 움직이지 않고 슬라임이 움직일 EndPortal의 y좌표값 입력
    {
        if (EndPotal.Length > 0)
        {
            if (EndPotal[0].localPosition.y >= -4.5f && EndPotal[0].localPosition.y <= -4f)
            {
                //BlueMove.BlueEndPortalLook = true;
                RedMove.RedEndPortalLook = true;
                //Debug.Log("potal");
            }
            else if (EndPotal[0].localPosition.y <= 2f && EndPotal[0].localPosition.y >= 1.5f)
            {
                RedMove.RedEndPortalLook = true;
            }
        }
    }

    void RedReversePortalisLooked()//화면은 움직이지 않고 슬라임이 움직일 ReversePortal의 y좌표값 입력
    {
        for (int i = 0; i < ReversePotal.Count; i++)//&& ReversePotal[].localPosition.y <= -4f
        {
            if ((ReversePotal[i].transform.localPosition.y >= -4.5f && ReversePotal[i].transform.localPosition.y <= -4f)
                || (ReversePotal[i].transform.localPosition.y <= 3.3f && ReversePotal[i].transform.localPosition.y >= 2.8f))
            {
               
                RedMove.RedReversePortalLook = true;
               
            }
           
        }
    }

    void onDestroy()
    {
        RedMove.Redrev -= redreev;
    }

}
