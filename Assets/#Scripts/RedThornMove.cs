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
    float[] moveY;
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
        a = new bool[Thorn.Length];
        moveY = new float[Thorn.Length];
        for (int i = 0; i < Wall.Length; i++)
            Wall[i] = GameObject.Find("RWall").transform.Find("red_wall (" + i + ")").gameObject;

        for (int i = 0; i < Thorn.Length; i++)
        {
            Thorn[i] = GameObject.Find("RThorns").transform.Find("red_thorn (" + i + ")").gameObject;
            a[i] = true;
            moveY[i] = Thorn[i].transform.localPosition.y;
        }

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
        if (RedMove.RedStart == true)
            return;
        if (RedMove.RedDieOrClear == false)
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
       
    }

   
    void ReverseMove()//Reverse모드인지 아닌지 구별하기 위한 함수
    {
        if (RedMove.RedEndPortalLook == true || RedMove.RedReversePortalLook==true)//Reverse포탈이 보이고 && End 포탈이 보이면 return;
                                             //사실상 이런 상황이 없을 것으로 맵이 만들어질 것임.
        {

            return;
        }
        if (RedMove.RedReversePortalLook == false)//Reverse포탈이 보이지 않는다면
        {
            Move();

            //return;



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
                case 35:
                    {
                        if (ReversePotal.Count == 1 && check == false)
                        {
                            List<int> TThornNum = new List<int>();
                         
                            List<int> TWallNum = new List<int>();
                     

                            TThornNum.Insert(0, 11);
                            TThornNum.Insert(1, 12);
                            TThornNum.Insert(2, 13);
                            TThornNum.Insert(3, 10);





                            TWallNum.Insert(0, 16);
                            TWallNum.Insert(1, 17);
                            TWallNum.Insert(2, 18);
                            
                         

                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            for (int i = 0; i < TWallNum.Count; i++)
                                Wall[TWallNum[i]].SetActive(true);//19
                        }
                        break;
                    }
                case 37:
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
                case 38:
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
                case 39:
                    {
                        ThornMoveX(0.7f, 19);
                        ThornMoveX(0.7f, 21);

                        ThornMoveY(0.7f, 19);
                        ThornMoveY(0.7f, 21);

                        ThornMoveX(0.7f, 22);
                        ThornMoveX(0.7f, 23);

                        ThornMoveY(0.7f, 22);
                        ThornMoveY(0.7f, 23);
                        if (Wall[33].transform.localPosition.y > -4f && check == false)
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 24);
                            TThornNum.Insert(1, 25);
                            TThornNum.Insert(2, 26);
                            TThornNum.Insert(3, 27);

                            FThornNum.Insert(0, 2);
                            FThornNum.Insert(1, 3);
                            FThornNum.Insert(2, 17);
                            FThornNum.Insert(3, 18);

                            FWallNum.Insert(0, 35);
                            FWallNum.Insert(1, 36);
                            FWallNum.Insert(2, 37);

                            TWallNum.Insert(0, 38);
                            TWallNum.Insert(1, 39);
                            TWallNum.Insert(2, 40);
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
                case 40:
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
                case 41:
                    {
                        ThornMoveX(-0.7f, 19);
                        ThornMoveX(-0.7f, 21);

                        ThornMoveY(-0.7f, 19);
                        ThornMoveY(-0.7f, 21);

                        ThornMoveX(-0.7f, 22);
                        ThornMoveX(-0.7f, 23);

                        ThornMoveY(-0.7f, 22);
                        ThornMoveY(-0.7f, 23);
                        if (ReversePotal.Count == 1 && check == false)
                        {
                            List<int> TThornNum = new List<int>();//true할 thorn
                            List<int> FThornNum = new List<int>();//false할 thorn
                            List<int> TWallNum = new List<int>();//true할 wall
                            List<int> FWallNum = new List<int>();//false할 wall
                            TThornNum.Insert(0, 24);//index,thornnumber
                            TThornNum.Insert(1, 25);
                            TThornNum.Insert(2, 26);
                            TThornNum.Insert(3, 27);

                            FThornNum.Insert(0, 0);
                            FThornNum.Insert(1, 1);
                            FThornNum.Insert(2, 13);
                            FThornNum.Insert(3, 14);

                            FWallNum.Insert(0, 16);
                            FWallNum.Insert(1, 17);
                            FWallNum.Insert(2, 18);

                            TWallNum.Insert(0, 35);
                            TWallNum.Insert(1, 36);
                            TWallNum.Insert(2, 37);
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
                case 21:
                    ThornMoveX(1.0f, 0);
                    ThornMoveX(1.0f, 1);
                    ThornMoveX(1.0f, 2);
                    ThornMoveX(1.0f, 3);
                    ThornMoveX(1.0f, 4);
                    ThornMoveX(1.0f, 5);
                    ThornMoveX(1.0f, 6);
                    ThornMoveX(1.0f, 7);
                    ThornMoveX(1.0f, 8);
                    ThornMoveX(1.0f, 26);
                    ThornMoveX(1.0f, 27);
                    ThornMoveX(1.0f, 81);
                    ThornMoveX(1.0f, 82);
                    ThornMoveX(1.0f, 83);
                    ThornMoveX(1.0f, 84);
                    ThornMoveX(1.0f, 85);
                    ThornMoveX(1.0f, 86);
                    if (Wall[0].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        TThornNum.Insert(0, 10);
                        TThornNum.Insert(1, 11);
                        TThornNum.Insert(2, 12);
                        TThornNum.Insert(3, 13);
                        TThornNum.Insert(4, 14);

                        FThornNum.Insert(0, 15);
                        FThornNum.Insert(1, 16);
                        FThornNum.Insert(2, 17);
                        FThornNum.Insert(3, 18);
                        FThornNum.Insert(4, 19);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);

                    }
                    if (Wall[4].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 22);
                        TThornNum.Insert(1, 24);


                        FThornNum.Insert(0, 20);
                        FThornNum.Insert(1, 25);
                        FThornNum.Insert(2, 77);
                        FThornNum.Insert(3, 78);
                        FThornNum.Insert(4, 79);
                        FThornNum.Insert(5, 80);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[11].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        FThornNum.Insert(0, 24);

                        TThornNum.Insert(0, 25);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[14].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 23);

                        FThornNum.Insert(0, 21);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[30].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 44);

                        FThornNum.Insert(0, 28);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[31].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 45);

                        FThornNum.Insert(0, 29);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[32].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 46);

                        FThornNum.Insert(0, 30);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[33].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 47);

                        FThornNum.Insert(0, 31);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[34].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 48);

                        FThornNum.Insert(0, 32);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[35].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 49);

                        FThornNum.Insert(0, 33);
                        ThornMoveX(1.0f, 37);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[36].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 50);

                        FThornNum.Insert(0, 34);
                        FThornNum.Insert(0, 35);
                        FThornNum.Insert(0, 36);

                        ThornMoveX(1.0f, 38);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[82].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 39);
                    }
                    if (Thorn[81].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 40);
                    }
                    if (Thorn[39].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 41);
                    }
                    if (Thorn[40].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 42);
                    }
                    if (Thorn[41].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 43);
                    }
                    break;
                case 42:
                    ThornMoveX(1.0f, 0);
                    ThornMoveX(1.0f, 1);
                    ThornMoveX(1.0f, 2);
                    ThornMoveX(1.0f, 3);
                    ThornMoveX(1.0f, 4);
                    ThornMoveX(1.0f, 5);
                    ThornMoveX(1.0f, 6);
                    ThornMoveX(1.0f, 7);
                    ThornMoveX(1.0f, 8);
                    ThornMoveX(1.0f, 26);
                    ThornMoveX(1.0f, 27);
                    ThornMoveX(1.0f, 81);
                    ThornMoveX(1.0f, 82);
                    ThornMoveX(1.0f, 83);
                    ThornMoveX(1.0f, 84);
                    ThornMoveX(1.0f, 85);
                    ThornMoveX(1.0f, 86);
                    if (Wall[0].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        TThornNum.Insert(0, 10);
                        TThornNum.Insert(1, 11);
                        TThornNum.Insert(2, 12);
                        TThornNum.Insert(3, 13);
                        TThornNum.Insert(4, 14);

                        FThornNum.Insert(0, 15);
                        FThornNum.Insert(1, 16);
                        FThornNum.Insert(2, 17);
                        FThornNum.Insert(3, 18);
                        FThornNum.Insert(4, 19);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);

                    }
                    if (Wall[4].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 22);
                        TThornNum.Insert(1, 24);


                        FThornNum.Insert(0, 20);
                        FThornNum.Insert(1, 25);
                        FThornNum.Insert(2, 77);
                        FThornNum.Insert(3, 78);
                        FThornNum.Insert(4, 79);
                        FThornNum.Insert(5, 80);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[11].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        FThornNum.Insert(0, 24);

                        TThornNum.Insert(0, 25);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[14].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 23);

                        FThornNum.Insert(0, 21);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[30].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 44);

                        FThornNum.Insert(0, 28);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[31].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 45);

                        FThornNum.Insert(0, 29);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[32].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();


                        FThornNum.Insert(0, 30);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[34].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 48);

                        FThornNum.Insert(0, 32);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[35].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 49);

                        FThornNum.Insert(0, 33);
                        ThornMoveX(1.0f, 37);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[36].transform.localPosition.y >= 1)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        TThornNum.Insert(0, 50);

                        FThornNum.Insert(0, 34);
                        FThornNum.Insert(0, 35);
                        FThornNum.Insert(0, 36);

                        ThornMoveX(1.0f, 38);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Thorn[82].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 39);
                    }
                    if (Thorn[81].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 40);
                    }
                    if (Thorn[39].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 41);
                    }
                    if (Thorn[40].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 42);
                    }
                    if (Thorn[41].transform.localPosition.y >= 1)
                    {
                        ThornMoveX(1.0f, 43);
                    }
                    break;
                case 43:
                    if (Wall[10].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        FThornNum.Insert(0, 57);
                        FThornNum.Insert(1, 58);
                        FThornNum.Insert(2, 59);
                        FThornNum.Insert(3, 104);
                        FThornNum.Insert(4, 105);
                        FThornNum.Insert(5, 106);

                        TThornNum.Insert(0, 6);
                        TThornNum.Insert(1, 7);
                        TThornNum.Insert(2, 8);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    if (Wall[17].transform.localPosition.y >= 2.5)
                    {
                        
                        
                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 17);
                        FWallNum.Insert(1, 18);
                        FWallNum.Insert(2, 19);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);
                       
                    }
                    if (Wall[23].transform.localPosition.y >= 1)
                    {
                      
                       
                        List<int> FThornNum = new List<int>();
                        FThornNum.Insert(0, 70);
                        FThornNum.Insert(1, 71);
                        FThornNum.Insert(2, 72);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);

                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 79);
                        FWallNum.Insert(1, 80);
                        FWallNum.Insert(2, 81);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);

                    }
                    if (Wall[32].transform.localPosition.y >= 2.5)
                    {


                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 88);
                        FWallNum.Insert(1, 89);
                        FWallNum.Insert(2, 90);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);

                    }
                    if (Wall[49].transform.localPosition.y >= 0)
                    {
                      
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        
                        FThornNum.Insert(0, 96);
                        FThornNum.Insert(1, 97);
                        FThornNum.Insert(2, 98);
                        FThornNum.Insert(0, 99);
                        FThornNum.Insert(1, 100);
                        FThornNum.Insert(2, 101);


                        TThornNum.Insert(0, 113);
                        TThornNum.Insert(1, 114);
                        

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    if (Wall[53].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        FThornNum.Insert(0, 113);
                        FThornNum.Insert(1, 114);
                       


                        TThornNum.Insert(0, 0);
                        


                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    break;

                case 44:
                    if (Wall[10].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        FThornNum.Insert(0, 57);
                        FThornNum.Insert(1, 58);
                        FThornNum.Insert(2, 59);
                        FThornNum.Insert(3, 104);
                        FThornNum.Insert(4, 105);
                        FThornNum.Insert(5, 106);

                        TThornNum.Insert(0, 6);
                        TThornNum.Insert(1, 7);
                        TThornNum.Insert(2, 8);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    if (Wall[17].transform.localPosition.y >= 2.5)
                    {


                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 17);
                        FWallNum.Insert(1, 18);
                        FWallNum.Insert(2, 19);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);

                    }
                    if (Wall[23].transform.localPosition.y >= 1)
                    {

                        List<int> FThornNum = new List<int>();
                        FThornNum.Insert(0, 70);
                        FThornNum.Insert(1, 71);
                        FThornNum.Insert(2, 72);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);

                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 79);
                        FWallNum.Insert(1, 80);
                        FWallNum.Insert(2, 81);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);

                    }
                    if (Wall[32].transform.localPosition.y >= 2.5)
                    {


                        List<int> FWallNum = new List<int>();

                        FWallNum.Insert(0, 88);
                        FWallNum.Insert(1, 89);
                        FWallNum.Insert(2, 90);
                        for (int i = 0; i < FWallNum.Count; i++)
                            Wall[FWallNum[i]].SetActive(false);

                    }
                    if (Wall[49].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        FThornNum.Insert(0, 96);
                        FThornNum.Insert(1, 97);
                        FThornNum.Insert(2, 98);
                        FThornNum.Insert(0, 99);
                        FThornNum.Insert(1, 100);
                        FThornNum.Insert(2, 101);


                        TThornNum.Insert(0, 113);
                        TThornNum.Insert(1, 114);


                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    if (Wall[53].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();

                        FThornNum.Insert(0, 113);
                        FThornNum.Insert(1, 114);



                        TThornNum.Insert(0, 0);



                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);//57,58,59,104,105,106
                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);//6,7,8
                    }
                    break;
                case 45:
                    {

                        if (Thorn[5].transform.localPosition.y >=1 && ReversePotal.Count == 1)
                            Thorn[5].SetActive(true);
                        if (Thorn[6].transform.localPosition.y >= 1 && ReversePotal.Count == 1)
                            Thorn[6].SetActive(true);
                        if (Wall[0].transform.localPosition.y >= 0 && ReversePotal.Count == 1)
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 7);
                            TThornNum.Insert(1, 8);
                            TThornNum.Insert(2, 9);
                            TThornNum.Insert(3, 10);

                            FThornNum.Insert(0, 0);
                            FThornNum.Insert(1, 1);
                            FThornNum.Insert(2, 2);
                            FThornNum.Insert(3, 3);

                            FWallNum.Insert(0, 5);
                            FWallNum.Insert(1, 6);
                            FWallNum.Insert(2, 7);

                            TWallNum.Insert(0, 8);
                            TWallNum.Insert(1, 9);
                            TWallNum.Insert(2, 10);
                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                            for (int i = 0; i < FWallNum.Count; i++)
                                Wall[FWallNum[i]].SetActive(false);//6,15,16


                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            for (int i = 0; i < TWallNum.Count; i++)
                                Wall[TWallNum[i]].SetActive(true);//19,20,21
                           
                        }
                      
                        if (Wall[14].transform.localPosition.y >= 0&& ReversePotal.Count == 1)//벽 15번이 0에 위치할때 실행
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 16);
                            TThornNum.Insert(1, 17);
                            TThornNum.Insert(2, 18);
                            TThornNum.Insert(3, 19);

                            FThornNum.Insert(0,11);
                            FThornNum.Insert(1, 12);
                            FThornNum.Insert(2, 13);
                            FThornNum.Insert(3, 14);

                            FWallNum.Insert(0, 19);
                            FWallNum.Insert(1, 20);
                            FWallNum.Insert(2, 21);

                            TWallNum.Insert(0, 13);
                            TWallNum.Insert(1, 12);
                            TWallNum.Insert(2, 11);
                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                            for (int i = 0; i < FWallNum.Count; i++)
                                Wall[FWallNum[i]].SetActive(false);//6,15,16


                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            for (int i = 0; i < TWallNum.Count; i++)
                                Wall[TWallNum[i]].SetActive(true);//19,20,21
                           
                        }
                        if (Thorn[37].transform.localPosition.y >= 0.5 && ReversePotal.Count == 1)
                        {
                            Thorn[37].SetActive(true);
                        }
                        if (Wall[30].transform.localPosition.y >= 0 && TextManager.gamecoin >= 3 && ReversePotal.Count == 1)
                        {
                            
                            List<int> FThornNum = new List<int>();
                           
                            List<int> FWallNum = new List<int>();
                            

                            FThornNum.Insert(0, 30);
                            FThornNum.Insert(1, 31);
                            FThornNum.Insert(2, 32);
                            FThornNum.Insert(3, 33);

                            FWallNum.Insert(0, 38);
                            FWallNum.Insert(1, 39);
                            FWallNum.Insert(2, 40);

                            
                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                            for (int i = 0; i < FWallNum.Count; i++)
                                Wall[FWallNum[i]].SetActive(false);//6,15,16


                           
                        }
                        if (Thorn[35].transform.localPosition.y >= -0.5&& ReversePotal.Count == 1)
                        {
                            Thorn[35].SetActive(true);
                            Thorn[34].SetActive(false);
                            ThornMoveY(3f, 35);
                        }
                        if (TextManager.gamecoin >= 4 && Potal[0].transform.localPosition.y >= -1)
                        {
                            Potal[0].SetActive(true);
                        }
                        if (ReversePotal.Count == 0&&check==false)
                        {
                            Potal[0].SetActive(false);
                            ReversePotal.Insert(0, GameObject.Find("RedReversePortal").transform.Find("RedReverse (" + 1 + ")").gameObject);

                            ReversePotal2 = ReversePotal;
                            ReversePotal[0].SetActive(true);
                            check = true;
                        }
                            break;
                    }
            

            }
          
        }
       

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
    void ThornMoveY(float speed, int ThornNum)
    {



        if (a[ThornNum] == true)
        {
            Thorn[ThornNum].transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
            if (Thorn[ThornNum].transform.localPosition.y > (moveY[ThornNum] + 2.0f))
            {
               
                a[ThornNum] = false;
            }

        }
        else if (a[ThornNum] == false)
        {
            Thorn[ThornNum].transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
            
            if (Thorn[ThornNum].transform.localPosition.y < (moveY[ThornNum] - 2f))
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
            {
                Thorn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                moveY[i] += 3f * Time.deltaTime;
            }
            for (int i = 0; i < Wall.Length; i++)
                Wall[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Potal.Length; i++)
                Potal[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < EndPotal.Length; i++)
                EndPotal[i].Translate(0, 3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < ReversePotal.Count; i++)
            {
                ReversePotal[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                if (PlayerPrefs.GetInt("CurStage", 0) == 45)
                {
                    GameObject.Find("RedReversePortal").transform.Find("RedReverse (" + 1 + ")").gameObject.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                }
            }
            for (int i = 0; i < coinn.Length; i++)
                coinn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
        }
        else if(RedReverse == true)//RedReverse모드인 경우
        {


            for (int i = 0; i < Thorn.Length; i++)
            {
                Thorn[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
                moveY[i] -= 3f * Time.deltaTime;
            }
            for (int i = 0; i < Wall.Length; i++)
                Wall[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < Potal.Length; i++)
                Potal[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < EndPotal.Length; i++)
                EndPotal[i].Translate(0, -3f * Time.deltaTime, 0, Space.World);

            for (int i = 0; i < ReversePotal.Count; i++)
            {
                ReversePotal[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
                
            }
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
