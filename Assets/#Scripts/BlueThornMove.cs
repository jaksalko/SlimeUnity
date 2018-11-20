using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueThornMove : MonoBehaviour
{

    public GameObject[] Thorn;
    public GameObject[] Wall;
    public GameObject[] Potal;
    public Transform[] EndPotal;
    public GameObject[] ReversePotalArr;
    public List<GameObject> ReversePotal;
    public static List<GameObject> ReversePotal2;
    public GameObject[] coinn;
    public static bool BlueReverse;
    public GameObject blueSideObject;
    public GameObject redSideObject;
    public bool[] a;
    bool check;
    float[] moveY;
    void Awake()
    {


        check = false;
        RedMove.RedEndPortalLook = false;
        BlueMove.BlueEndPortalLook = false;

        RedMove.RedReversePortalLook = false;
        BlueMove.BlueReversePortalLook = false;

        BlueReverse = false;
        a = new bool[Thorn.Length];
        moveY = new float[Thorn.Length];

        for (int i = 0; i < Wall.Length; i++)
            Wall[i] = GameObject.Find("BWall").transform.Find("blue_wall (" + i + ")").gameObject;

        for (int i = 0; i < Thorn.Length; i++)
        {
            Thorn[i] = GameObject.Find("BThorns").transform.Find("blue_thorn (" + i + ")").gameObject;
            a[i] = true;
            moveY[i] = Thorn[i].transform.localPosition.y;
        }
        for (int i = 0; i < coinn.Length; i++)
            coinn[i] = GameObject.Find("BCoins").transform.Find("bcoin (" + i + ")").gameObject;

        if (PlayerPrefs.GetInt("CurStage", 0) > 30)
        {
            for (int i = 0; i < ReversePotalArr.Length; i++)
            {
                ReversePotalArr[i] = GameObject.Find("BlueReversePortal").transform.Find("BlueReverse (" + i + ")").gameObject;

            }
            for (int i = 0; i < ReversePotalArr.Length; i++)
            {
                ReversePotal.Insert(i, ReversePotalArr[i]);
            }
            ReversePotal2 = ReversePotal;
        }

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


    void ReverseMove()
    {

        if (BlueMove.BlueEndPortalLook == true || BlueMove.BlueReversePortalLook == true)
        {

            return;
        }

        if (BlueMove.BlueReversePortalLook == false)
        {

            Move();
            //Debug.Log("redreverse");
            //return;

            //여러번 실행되지 않게 하기위한 변수
            //Debug.Log(PlayerPrefs.GetInt("CurStage", 0) + "stage");

            switch (PlayerPrefs.GetInt("CurStage", 0))
            {
                case 6:
                    {
                        ThornMoveY(1f, 0);
                        ThornMoveY(1.5f, 1);
                        break;
                    }
                case 7:
                    {
                        ThornMoveY(1f, 0);
                        ThornMoveY(1.5f, 1);
                        ThornMoveX(0.5f, 2);
                        ThornMoveX(0.5f, 3);
                        ThornMoveY(1f, 2);
                        ThornMoveY(1f, 3);

                        break;
                    }
                case 8:
                    {
                        ThornMoveX(0.5f, 4);
                        break;
                    }
                
                case 36:
                    {

                        if (ReversePotal.Count == 0 && check == false)
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 16);
                            TThornNum.Insert(1, 17);
                            TThornNum.Insert(2, 18);
                            TThornNum.Insert(3, 19);

                            FThornNum.Insert(0, 0);
                            FThornNum.Insert(1, 1);
                            FThornNum.Insert(2, 13);
                            FThornNum.Insert(3, 14);
                            FThornNum.Insert(4, 15);

                            FWallNum.Insert(0, 6);
                            FWallNum.Insert(1, 15);
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
                        ThornMoveX(0.5f, 5);
                        ThornMoveY(1f, 5);
                        ThornMoveX(0.5f, 8);
                        ThornMoveY(1f, 8);

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
                            FThornNum.Insert(2, 9);
                            FThornNum.Insert(3, 10);

                            FWallNum.Insert(0, 6);
                            FWallNum.Insert(1, 15);
                            FWallNum.Insert(2, 16);

                            TWallNum.Insert(0, 19);
                            TWallNum.Insert(1, 20);
                            TWallNum.Insert(2, 21);
                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,9,10
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

                            List<int> TPortalNum = new List<int>();
                            List<int> FPortalNum = new List<int>();
                            TPortalNum.Insert(0, 1);


                            FPortalNum.Insert(0, 0);




                            for (int i = 0; i < FPortalNum.Count; i++)
                                Potal[FPortalNum[i]].SetActive(false);//6,15,16



                            for (int i = 0; i < TPortalNum.Count; i++)
                                Potal[TPortalNum[i]].SetActive(true);//19,20,21
                            check = false;
                            //Debug.Log("레드포탈 On");
                        }

                        if (ReversePotal.Count % 2 == 0 && check == false)
                        {

                            List<int> TPortalNum = new List<int>();
                            List<int> FPortalNum = new List<int>();
                            TPortalNum.Insert(0, 0);


                            FPortalNum.Insert(0, 1);



                            for (int i = 0; i < FPortalNum.Count; i++)
                                Potal[FPortalNum[i]].SetActive(false);//6,15,16


                            for (int i = 0; i < TPortalNum.Count; i++)
                                Potal[TPortalNum[i]].SetActive(true);//19,20,21
                            check = true;
                            //Debug.Log("블루포탈 On");
                        }
                        break;
                    }
                case 39:
                    {

                        if (ReversePotal.Count == 0 && check == false)
                        {

                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 15);
                            TThornNum.Insert(1, 16);
                            TThornNum.Insert(2, 17);
                            TThornNum.Insert(3, 18);

                            FThornNum.Insert(0, 2);
                            FThornNum.Insert(1, 3);
                            FThornNum.Insert(2, 11);
                            FThornNum.Insert(3, 10);

                            FWallNum.Insert(0, 6);
                            FWallNum.Insert(1, 15);
                            FWallNum.Insert(2, 16);

                            TWallNum.Insert(0, 19);
                            TWallNum.Insert(1, 20);
                            TWallNum.Insert(2, 21);




                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,9,10
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
                        ThornMoveY(1f, 9);
                        ThornMoveX(1f, 0);
                        ThornMoveX(1f, 20);
                        break;
                    }

                case 41:
                    {
                        ThornMoveY(1f, 9);
                        ThornMoveX(1f, 0);
                        ThornMoveX(1f, 21);

                        if (ReversePotal.Count == 2 && check == false)
                        {

                            List<int> TThornNum = new List<int>();

                            List<int> TWallNum = new List<int>();

                            TThornNum.Insert(0, 15);
                            TThornNum.Insert(1, 16);
                            TThornNum.Insert(2, 17);
                            TThornNum.Insert(3, 18);



                            TWallNum.Insert(0, 19);
                            TWallNum.Insert(1, 20);
                            TWallNum.Insert(2, 21);








                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            for (int i = 0; i < TWallNum.Count; i++)
                                Wall[TWallNum[i]].SetActive(true);//19,20,21
                            check = true;
                        }

                        break;
                    }
                case 42:
                    if (Wall[11].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        TThornNum.Insert(0, 19);
                        TThornNum.Insert(1, 20);

                        FThornNum.Insert(0, 18);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);

                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[19].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        TThornNum.Insert(0, 21);

                        FThornNum.Insert(0, 8);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);

                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    if (Wall[22].transform.localPosition.y >= 0)
                    {
                        List<int> TThornNum = new List<int>();
                        List<int> FThornNum = new List<int>();
                        TThornNum.Insert(0, 8);

                        FThornNum.Insert(0, 21);

                        for (int i = 0; i < FThornNum.Count; i++)
                            Thorn[FThornNum[i]].SetActive(false);

                        for (int i = 0; i < TThornNum.Count; i++)
                            Thorn[TThornNum[i]].SetActive(true);
                    }
                    break;
                case 45:
                    {
                        if (Thorn[0].transform.localPosition.y >= 1)
                            Thorn[0].SetActive(true);
                        if (Wall[8].transform.localPosition.y >= 0 && ReversePotal.Count == 1)
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();
                            List<int> TWallNum = new List<int>();
                            List<int> FWallNum = new List<int>();
                            TThornNum.Insert(0, 11);
                            TThornNum.Insert(1, 12);
                            TThornNum.Insert(2, 13);
                            TThornNum.Insert(3, 14);

                            FThornNum.Insert(0, 7);
                            FThornNum.Insert(1, 8);
                            FThornNum.Insert(2, 9);
                            FThornNum.Insert(3, 10);

                            FWallNum.Insert(0, 13);
                            FWallNum.Insert(1, 14);
                            FWallNum.Insert(2, 15);

                            TWallNum.Insert(0, 16);
                            TWallNum.Insert(1, 17);
                            TWallNum.Insert(2, 18);
                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                            for (int i = 0; i < FWallNum.Count; i++)
                                Wall[FWallNum[i]].SetActive(false);//6,15,16


                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            for (int i = 0; i < TWallNum.Count; i++)
                                Wall[TWallNum[i]].SetActive(true);//19,20,21

                        }
                        if (Wall[19].transform.localPosition.y >= 0 && TextManager.gamecoin >= 3 && ReversePotal.Count == 1)
                        {

                            List<int> FThornNum = new List<int>();

                            List<int> FWallNum = new List<int>();


                            FThornNum.Insert(0, 16);
                            FThornNum.Insert(1, 17);
                            FThornNum.Insert(2, 18);
                            FThornNum.Insert(3, 19);

                            FWallNum.Insert(0, 25);
                            FWallNum.Insert(1, 26);
                            FWallNum.Insert(2, 24);

                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
                            for (int i = 0; i < FWallNum.Count; i++)
                                Wall[FWallNum[i]].SetActive(false);//6,15,16



                            
                        }
                        if (Potal[0].transform.localPosition.y >= 2.5 && ReversePotal.Count == 1)
                        {
                            Potal[0].SetActive(true);
                        }
                        if (Thorn[24].transform.localPosition.y >= 0 && ReversePotal.Count == 1)
                        {
                            Thorn[24].transform.localPosition = new Vector3(1.9f, moveY[24], 0);
                        }
                        if (ReversePotal.Count == 0&&check==false)
                        {
                            List<int> TThornNum = new List<int>();
                            List<int> FThornNum = new List<int>();

                            TThornNum.Insert(0, 29);
                            TThornNum.Insert(1, 30);
                            TThornNum.Insert(2, 31);
                            // TThornNum.Insert(3, 14);

                            FThornNum.Insert(0, 26);
                            FThornNum.Insert(1, 27);
                            FThornNum.Insert(2, 28);
                            // FThornNum.Insert(3, 10);


                            for (int i = 0; i < FThornNum.Count; i++)
                                Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15



                            for (int i = 0; i < TThornNum.Count; i++)
                                Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
                            Potal[0].SetActive(false);

                            ReversePotal.Insert(0, GameObject.Find("BlueReversePortal").transform.Find("BlueReverse (" + 1 + ")").gameObject);

                            ReversePotal2 = ReversePotal;
                            ReversePotal[0].SetActive(true);
                            check = true;
                        }
                        if (Thorn[35].transform.localPosition.y >= -1 && ReversePotal.Count == 0&&check==true)
                        {
                            Vector3 posRed = Thorn[35].transform.position;
                            Vector3 posBlue = Potal[4].transform.position;
                            float tempx = posRed.x;
                            float tempy = posRed.y;
                            Thorn[35].transform.position = new Vector3(posBlue.x, posBlue.y, 0);
                            Potal[4].transform.position = new Vector3(tempx, tempy, 0);
                            Potal[4].transform.Rotate(0, 180, 0);
                            Thorn[35].transform.Rotate(180, 0, 0);
                            check = false;
                        }
                        break;
                    }
            }

        }

    }

    void WallChange(List<int> FThornNum, List<int> FWallNum, List<int> TThornNum, List<int> TWallNum)
    {
        for (int i = 0; i < FThornNum.Count; i++)
            Thorn[FThornNum[i]].SetActive(false);//0,1,13,14,15
        for (int i = 0; i < FWallNum.Count; i++)
            Wall[FWallNum[i]].SetActive(false);//6,15,16


        for (int i = 0; i < TThornNum.Count; i++)
            Thorn[TThornNum[i]].SetActive(true);//16,17,18,19
        for (int i = 0; i < TWallNum.Count; i++)
            Wall[TWallNum[i]].SetActive(true);//19,20,21

    }

    void ThornMoveX(float speed, int ThornNum)//0.5f가 적당한 속도
    {


        if (a[ThornNum] == true)
        {
            Thorn[ThornNum].transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
            if (Thorn[ThornNum].transform.localPosition.x < 0.75f)
            {
                a[ThornNum] = false;
            }

        }
        else
        {
            Thorn[ThornNum].transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            if (Thorn[ThornNum].transform.localPosition.x > 2.1f)
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


        if (BlueReverse == false)
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
                //Debug.Log("카운트 = " + ReversePotal.Count);
                if (PlayerPrefs.GetInt("CurStage", 0) == 45)
                {
                    GameObject.Find("BlueReversePortal").transform.Find("BlueReverse (" + 1 + ")").gameObject.transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
                }
            }


            for (int i = 0; i < coinn.Length; i++)
                coinn[i].transform.Translate(0, 3f * Time.deltaTime, 0, Space.World);
        }
        else if (BlueReverse == true)//RedReverse모드인 경우
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
                //Debug.Log("카운트 = " + ReversePotal.Count);

            }
            for (int i = 0; i < coinn.Length; i++)
                coinn[i].transform.Translate(0, -3f * Time.deltaTime, 0, Space.World);
        }

    }

    void BluePotalisLooked()//화면은 움직이지 않고 슬라임이 움직일 EndPortal의 y좌표값 입력
    {
        if (EndPotal.Length > 0)
        {
            if (EndPotal[0].localPosition.y >= -4f && EndPotal[0].localPosition.y <= -3.5f)
            {
                //BlueMove.BlueEndPortalLook = true;
                BlueMove.BlueEndPortalLook = true;
                //Debug.Log("potal");
            }
            else if (EndPotal[0].localPosition.y <= 2f && EndPotal[0].localPosition.y >= 1.5f)
            {
                BlueMove.BlueEndPortalLook = true;
            }
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

}