using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBackGroundMove : MonoBehaviour
{
    public Transform[] Grounds;
    Vector3 Pos;

    void Update()
    {
        if (RedMove.RedDieOrClear == false||RedMove.AllAlive==false)
            return;
        if (RedMove.RedStart == true)
            return;
        if (RedMove.RedReversePortalLook == true)//reverseportal 이 보이면 멈춤 근데이게 update에 있어도되나
        {
            return;
        }
        if (RedMove.RedAlive == false || RedMove.AllAlive == false)
        {
            return;
        }

        RedBackMove();

    }

    void RedBackMove()
    {
        if (RedThornMove.RedReverse == true)
        {
            for (int i = 0; i < Grounds.Length; i++)
                Grounds[i].Translate(0, -3f * Time.deltaTime, 0, Space.World);


            for (int i = 0; i < Grounds.Length; i++)
            {
                Pos = Grounds[i].localPosition;

                if (Pos.y < -11.5f)
                {
                    Pos.y = Grounds[i].localPosition.y + 23f;
                    Grounds[i].localPosition = Pos;

                }
            }
        }
        else
        {
            for (int i = 0; i < Grounds.Length; i++)
                Grounds[i].Translate(0, 3f * Time.deltaTime, 0, Space.World);


            for (int i = 0; i < Grounds.Length; i++)
            {
                Pos = Grounds[i].localPosition;

                if (Pos.y >11.5f)
                {
                    Pos.y = Grounds[i].localPosition.y - 23f;
                    Grounds[i].localPosition = Pos;

                }
            }
        }
    }
}
       

    








