using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedThornMove : MonoBehaviour
{
    //장애물들을 하나의 Object로 보고나서 짠 코드


    public GameObject[] Thorn;
    public GameObject[] Wall;
    public GameObject[] Potal;
    public Transform[] EndPotal;
    public GameObject[] ReversePotalArr;
    public List<GameObject> ReversePotal;
    public static List<GameObject> ReversePotal2;
    public GameObject[] coinn;
    public static bool RedReverse;
    //Reverse방향으로 가는지 즉, ReversePortal을 탔는지
    //Red, Blue 두개로 만들어야 함. 아직 하나만 구현(Red만 구현)
    public GameObject blueSideObject;
    public GameObject redSideObject;
    float moveX, moveY;
    int temp;
    bool[] a;
    bool check ;
    void Awake()
    {
        
        temp = 0;
        check = false;
        RedMove.RedEndPortalLook = false;//End포탈이 보이지 않는 상태 초기화
        BlueMove.BlueEndPortalLook = false;

        RedMove.RedReversePortalLook = false;//ReversePortal이 보이지 않는 상태 초기화
        BlueMove.BlueReversePortalLook = false;

        RedReverse = false; // Reverse모드가 아닌 상태 초기화
        //foreach (var ii in ReversePotal)
        //{
        //    reverseportalnum++;
        //}
        for (int i = 0; i < Wall.Length; i++)
            Wall[i] = GameObject.Find("RWall").transform.Find("red_wall (" + i + ")").gameObject;

        for (int i = 0; i < Thorn.Length; i++)
            Thorn[i] = GameObject.Find("RThorns").transform.Find("red_thorn (" + i + ")").gameObject;

        a = new bool[Thorn.Length];

        for (int i=0; i<coinn.Length;i++)
            coinn[i] = GameObject.Find("RCoins").transform.Find("rcoin ("+i+")").gameObject;
        if (PlayerPrefs.GetInt("CurStage",0)>30)
        {
            for (int i = 0; i < ReversePotalArr.Length; i++)
            {
                ReversePotalArr[i] = GameObject.Find("RedReversePortal").transform.Find("RedReverse (" + i + ")").gameObject;

            }
            for (int i = 0; i < ReversePotalArr.Length; i++)
            {
                ReversePotal.Insert(i, ReversePotalArr[i]);
            }
            ReversePotal2 = ReversePotal;
        }

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

   
    void ReverseMove()//Reverse모드인지 아닌지 구별하기 위한 함수
    {
        if (RedMove.RedEndPortalLook == true)//Reverse포탈이 보이고 && End 포탈이 보이면 return;
                                             //사실상 이런 상황이 없을 것으로 맵이 만들어질 것임.
        {

            return;
        }
        if (RedMove.RedReversePortalLook == false)//Reverse포탈이 보이지 않는다면
        {
            Move();
            
            //return;
        }
        
        
        switch (PlayerPrefs.GetInt("CurStage", 0))
        {
            case 6:
                {
                    ThornMoveX(0.5f, 0);
                    ThornMoveX(1f, 1);
                    break;
                }
            case 7:
                {
                    ThornMoveX(0.5f, 0);
                    ThornMoveX(1f, 1);
                    ThornMoveY(0.7f, 2);

                    ThornMoveX(0.5f, 3);
                    ThornMoveX(0.5f, 4);
                    ThornMoveY(1f, 3);
                    ThornMoveY(1f, 4);
                    break;
                }
            case 8:
                {
                    ThornMoveX(0.5f, 5);
                    ThornMoveX(0.5f, 6);
                    break;
                }
            case 36:
                {
                    ThornMoveX(1.5f, 17);
                    ThornMoveX(1f, 18);
                    ThornMoveX(0.5f, 19);
                    if (ReversePotal.Count == 0 && check == false)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        List<int> TWallNum = new List<int>();
                        List<int> FWallNum = new List<int>();
                        TThornNum.Insert(0, 11);
                        TThornNum.Insert(1, 12);
                        TThornNum.Insert(2, 13);
                        TThornNum.Insert(3, 14);

                        FThornNum.Insert(0, 0);
                        FThornNum.Insert(1, 1);
                        FThornNum.Insert(2, 16);
                        FThornNum.Insert(3, 15);

                        FWallNum.Insert(0, 18);
                        FWallNum.Insert(1, 17);
                        FWallNum.Insert(2, 16);

                        TWallNum.Insert(0, 19);
                        TWallNum.Insert(1, 20);
                        TWallNum.Insert(2, 21);
                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);//6,15,16


                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                        for (int i = 0; i < TWallNum.Count; i++)
                            Wall[TWallNum[i]].SetActive(true);//19,20,21
                        check = true;
                    }
                    break;
                }
            case 37:
                {
                    
                    if (ReversePotal.Count % 2 == 1 && check == true)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        
                        TThornNum.Insert(0, 2);
                        TThornNum.Insert(1, 3);
                        

                        FThornNum.Insert(0, 0);
                        FThornNum.Insert(1, 1);
                        if (ReversePotal.Count < 4)
                        {
                            TThornNum.Insert(2, 5);
                        }
                        if (ReversePotal.Count < 3)
                        {
                            FThornNum.Insert(2, 4);
                        }


                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                       


                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                        
                        check = false;
                    }

                    if (ReversePotal.Count % 2 == 0 && check == false)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 0);
                        TThornNum.Insert(1, 1);


                        FThornNum.Insert(0, 2);
                        FThornNum.Insert(1, 3);

                        if (ReversePotal.Count < 4)
                        {
                            FThornNum.Insert(2, 5);
                        }
                        if (ReversePotal.Count < 3)
                        {
                            TThornNum.Insert(2, 4);
                        }

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                      

                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                     
                        check = true;
                    }
                    break;
                }
            case 38:
                {
                    ThornMoveX(0.7f, 19);
                    ThornMoveX(0.7f, 21);

                    ThornMoveY(0.7f, 19);
                    ThornMoveY(0.7f, 21);

                    ThornMoveX(0.7f, 22);
                    ThornMoveX(0.7f, 23);

                    ThornMoveY(0.7f, 22);
                    ThornMoveY(0.7f, 23);
                    break;
                }

        }
        return;

    }

    void ThornMoveX(float speed,  int ThornNum)//0.5f가 적당한 속도
    {

       
        if (a[ThornNum] == true)
            {
                Thorn[ThornNum].transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x < -2.1f)
                {
                a[ThornNum] = false;
                }

            }
            else
            {
                Thorn[ThornNum].transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.x > -0.75f)
                {
                a[ThornNum] = true;
                }
            }
        
    }
    void ThornMoveY(float speed,  int ThornNum)
    {
        
        moveY = Thorn[ThornNum].transform.localPosition.y;
        
            if (a[ThornNum] == true)
            {
                Thorn[ThornNum].transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.y > moveY + 1.2f)
                {
                a[ThornNum] = false;
                }

            }
            else
            {
                Thorn[ThornNum].transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
                if (Thorn[ThornNum].transform.localPosition.y < moveY - 1.2f)
                {
                a[ThornNum] = true;
                }
            }
        
    }
    void Move()
    {
        
        if (RedReverse == false)//RedReverse모드가 아닌 경우
        {
            
            for (int i = 0; i < Thorn.Length; i++)
                Thorn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Wall.Length; i++)
                Wall[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Potal.Length; i++)
                Potal[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

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
                Potal[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);

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
            if (EndPotal[0].localPosition.y >= -4f && EndPotal[0].localPosition.y <= -3.5f)
            {
                //BlueMove.BlueEndPortalLook = true;
                RedMove.RedEndPortalLook = true;
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



}
