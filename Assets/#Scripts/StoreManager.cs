using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class StoreManager : MonoBehaviour {
    private MenuTextManager menutextmanager;
    public GameObject payPopup;
    public GameObject SantaButton;
    public GameObject CrownButton;
    public GameObject StrawButton;
    public GameObject BeretButton;
    public GameObject CookButton;
    public GameObject CatButton;
    public GameObject ChickButton;
    public GameObject RabbitButton;
    public GameObject FrogButton;
    public GameObject redItem;
    public GameObject blueItem;
    public Toggle defaultred;
    public Toggle defaultblue;
    public Toggle[] RedWearButton;
    public Toggle[] BlueWearButton;
    static string str;
    List<int> itemstate;
    static int i ;
    int a;
    int paycoin;
    Vector3 vibrate;
    // Use this for initialization
    void Start () {
       // PlayerPrefs.DeleteAll();
        a = 0;
        PlayerPrefs.SetInt("TotalCoin", 100000);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("RedWear", "DefaultRedToggle") + "      " + RedWearButton[2].ToString());
        for (int a = 0; a < 10; a++)
        {
            if (RedWearButton[a].ToString() == PlayerPrefs.GetString("RedWear", "DefaultRedToggle"))
            {
                switch (a)
                {
                    case 0:
                        redItem.GetComponent<SpriteRenderer>().sprite = null; 
                        break;
                    case 1:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
                        break;
                    case 2:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;
                        break;
                    case 3:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;
                        break;
                    case 4:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
                        break;
                    case 5:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;
                        break;
                    case 6:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;
                        break;
                    case 7:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;
                        break;
                    case 8:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;
                        break;
                    case 9:
                        redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;
                        break;

                }
                RedWearButton[a].isOn = true;

            }
            if (BlueWearButton[a].ToString() == PlayerPrefs.GetString("BlueWear", "DefaultRedToggle"))
            {
                switch (a)
                {
                    case 0:
                        blueItem.GetComponent<SpriteRenderer>().sprite = null;
                        break;
                    case 1:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
                        break;
                    case 2:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;
                        break;
                    case 3:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;
                        break;
                    case 4:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
                        break;
                    case 5:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;
                        break;
                    case 6:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;
                        break;
                    case 7:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;
                        break;
                    case 8:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;
                        break;
                    case 9:
                        blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;
                        break;

                }
                BlueWearButton[a].isOn = true;

            }
        }

        //str => Santa == 0  Crown == 1 Straw == 2 Beret == 3 Cook == 4 Cat == 5 Chick == 6 Rabbit == 7 Frog == 8
        itemstate = new List<int>();//itemstate[itemnumber] : 0 -> Not buy  1 -> Buy   2 -> Wear


        for (int k =  i ; k < 9; k++)// i is itemnumber and Itemstate is state of itemnumber
        {
            
            itemstate.Add(PlayerPrefs.GetInt(k.ToString(), 0));

            if (itemstate[k] != 0)//if itemstate is "bought", buy button is "false"
            {
                if (k == 0)
                    SantaButton.SetActive(true);
                else if (k == 1)
                    CrownButton.SetActive(true);
                else if (k == 2)
                    StrawButton.SetActive(true);
                else if (k == 3)
                    BeretButton.SetActive(true);
                else if (k == 4)
                    CookButton.SetActive(true);
                else if (k == 5)
                    CatButton.SetActive(true);
                else if (k == 6)
                    ChickButton.SetActive(true);
                else if (k == 7)
                    RabbitButton.SetActive(true);
                else if (k == 8)
                    FrogButton.SetActive(true);


            }
            else
            {
                Debug.Log("a++");
                a++;
            }
        }//i = 2;
        if (a == 9)
        {
            Debug.Log("아무것도 안삼");
            defaultred.isOn = true;
            defaultblue.isOn = true;
        }


        PlayerPrefs.Save();
        vibrate = new Vector3(0.5f, 0, 0);
        menutextmanager = GameObject.Find("TotalCoinText").GetComponent<MenuTextManager>();
       
	}
   

    // Update is called once per frame
    void Update () {
        
	}
    public void PaybuttonClick() {
        str = EventSystem.current.currentSelectedGameObject.name;
        str = str.Replace("PayBtn", "");
       
        payPopup.SetActive(true);
    }
    public void YesbuttonClick()
    {

        if (str == "Santa")
        {
           
            str = "0";
            paycoin = 8000;
        }
        else if (str == "Crown")
        {
         
            str = "1";
            paycoin = 15000;
        }
        else if (str == "Straw")
        {
           
            str = "2";
            paycoin = 18000;
        }
        else if (str == "Beret")
        {
          
            str = "3";
            paycoin = 20000;
        }
        else if (str == "Cook")
        {
           
            str = "4";
            paycoin = 35000;
        }
        else if (str == "Cat")
        {
           
            str = "5";
            paycoin = 80000;
        }
        else if (str == "Chick")
        {
           
            str = "6";
            paycoin = 70000;
        }
        else if (str == "Rabbit")
        {
           
            str = "7";
            paycoin = 20000;
        }
        else if (str == "Frog")
        {
           
            str = "8";
            paycoin = 50000;
        }



        if (MenuTextManager.totalcoin < paycoin)
        {
            Handheld.Vibrate();
           
            iTween.ShakePosition(payPopup,vibrate,0.5f);
        }
        else {
            MenuTextManager.totalcoin -= paycoin;
            PlayerPrefs.SetInt("TotalCoin", MenuTextManager.totalcoin);
            if (str == "0")
            {
              

                SantaButton.SetActive(true);

            }

            else if (str == "1")
            {
               
                CrownButton.SetActive(true);
            }
            else if (str == "2")
            {
                StrawButton.SetActive(true);
            }
            else if (str == "3")
            {
                BeretButton.SetActive(true);
            }
            else if (str == "4")
            {
                CookButton.SetActive(true);
            }
            else if (str == "5")
            {
              
                CatButton.SetActive(true);
            }
            else if (str == "6")
            {
               
                ChickButton.SetActive(true);
            }
            else if (str == "7")
            {
                
                RabbitButton.SetActive(true);
            }
            else if (str == "8")
            {
               
                FrogButton.SetActive(true);
            }

            payPopup.SetActive(false);
            menutextmanager.totalcoinText.text = MenuTextManager.totalcoin.ToString();
            PlayerPrefs.SetInt(str, 1);// if buy it, str state is "Buy"(1)
            
            



        }
        
      

    }
    public void NobuttonClick()
    {
        payPopup.SetActive(false);
    }
    public void RedToggleControl(Toggle toggle)
    {
        if (toggle.isOn)
        {
            redItem.transform.localScale = new Vector3(110f, 100f, 0);
            redItem.transform.localPosition = new Vector3(-85f, -347f, -17280f);
            PlayerPrefs.SetString("RedWear", toggle.ToString());
            if (toggle.ToString() == "DefaultRedToggle (UnityEngine.UI.Toggle)")
                redItem.GetComponent<SpriteRenderer>().sprite = null;
            else if (toggle.ToString() == "SantaRedToggle (UnityEngine.UI.Toggle)")
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "CrownRedToggle (UnityEngine.UI.Toggle)")
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "StrawRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "BeretRedToggle (UnityEngine.UI.Toggle)")
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "CookRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "CatRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "ChickRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "RabbitRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-75f, -367f, -17280f);
            }
            else if (toggle.ToString() == "FrogRedToggle (UnityEngine.UI.Toggle)")
            {
                redItem.transform.localScale = new Vector3(55f, 50f, 0);
                redItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;
                redItem.transform.localPosition = new Vector3(-75f, -347f, -17280f);
            }
        }
       
    }
    public void BlueToggleControl(Toggle toggle)
    {
        if (toggle.isOn)
        {
            blueItem.transform.localScale = new Vector3(110f, 100f, 0);
            blueItem.transform.localPosition = new Vector3(85f, -347f, -17280f);
            PlayerPrefs.SetString("BlueWear", toggle.ToString());
            if (toggle.ToString() == "DefaultBlueToggle (UnityEngine.UI.Toggle)")
                blueItem.GetComponent<SpriteRenderer>().sprite = null;
            else if (toggle.ToString() == "SantaBlueToggle (UnityEngine.UI.Toggle)")
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/santa_hat", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "CrownBlueToggle (UnityEngine.UI.Toggle)")
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/crown", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "StrawBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Straw_hat", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "BeretBlueToggle (UnityEngine.UI.Toggle)")
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/beret", typeof(Sprite)) as Sprite;
            else if (toggle.ToString() == "CookBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cook", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "CatBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Cat", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "ChickBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Chick", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "RabbitBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Rabbit", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -367f, -17280f);
            }
            else if (toggle.ToString() == "FrogBlueToggle (UnityEngine.UI.Toggle)")
            {
                blueItem.GetComponent<SpriteRenderer>().sprite = Resources.Load("#Images/Frog", typeof(Sprite)) as Sprite;
                blueItem.transform.localScale = new Vector3(55f, 50f, 0);
                blueItem.transform.localPosition = new Vector3(85f, -347f, -17280f);
            }
        }
    }
           
    

}
