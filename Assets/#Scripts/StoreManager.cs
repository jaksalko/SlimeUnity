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
    public GameObject redItem;
    public GameObject blueItem;
    public Toggle[] RedWearButton;
    public Toggle[] BlueWearButton;
    static string str;
    List<int> itemstate;
    static int i ;
    int paycoin;
    Vector3 vibrate;
    // Use this for initialization
    void Start () {

        
        //Debug.Log(PlayerPrefs.GetString("RedWear", "DefaultRedToggle") + "      " + RedWearButton[2].ToString());
        for (int a = 0; a < 3; a++)
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

                }
                BlueWearButton[a].isOn = true;

            }
        }

        //str => Santa == 0  Crown == 1 Straw == 2 Beret == 3 Cook == 4 Cat == 5 Chick == 6
        itemstate = new List<int>();//itemstate[itemnumber] : 0 -> Not buy  1 -> Buy   2 -> Wear


        for (int k =  i ; k < 7; k++)// i is itemnumber and Itemstate is state of itemnumber
        {
            
            itemstate.Add(PlayerPrefs.GetInt(k.ToString(), 0));
            //Debug.Log(k + " itemstate =" +itemstate[k]);
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

                Debug.Log("산게 있음");
            }
        }//i = 2;


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
        Debug.Log("PayBtn" + str + " is clicked");
        payPopup.SetActive(true);
    }
    public void YesbuttonClick()
    {

        if (str == "Santa")
        {
            Debug.Log("Santa Yesbutton" + str + " is clicked");
            str = "0";
            paycoin = 1;
        }
        else if (str == "Crown")
        {
            Debug.Log("Crown Yesbutton" + str + " is clicked");
            str = "1";
            paycoin = 1;
        }
        else if (str == "Straw")
        {
            Debug.Log("Crown Yesbutton" + str + " is clicked");
            str = "2";
            paycoin = 1;
        }
        else if (str == "Beret")
        {
            Debug.Log("Beret Yesbutton" + str + " is clicked");
            str = "3";
            paycoin = 1;
        }
        else if (str == "Cook")
        {
            Debug.Log("Cook Yesbutton" + str + " is clicked");
            str = "4";
            paycoin = 1;
        }
        else if (str == "Cat")
        {
            Debug.Log("Cat Yesbutton" + str + " is clicked");
            str = "5";
            paycoin = 1;
        }
        else if (str == "Chick")
        {
            Debug.Log("Chick Yesbutton" + str + " is clicked");
            str = "6";
            paycoin = 1;
        }



        if (MenuTextManager.totalcoin < paycoin)
        {
            Handheld.Vibrate();
            Debug.Log("can't buy this" + paycoin);
            iTween.ShakePosition(payPopup,vibrate,0.5f);
        }
        else {
            MenuTextManager.totalcoin -= paycoin;
            PlayerPrefs.SetInt("TotalCoin", MenuTextManager.totalcoin);
            if (str == "0")
            {
                Debug.Log("Santa is Sold out");

                SantaButton.SetActive(true);

            }

            else if (str == "1")
            {
                Debug.Log("Crown is Sold out");

                CrownButton.SetActive(true);
            }
            else if (str == "2")
            {
                Debug.Log("Crown is Sold out");

                StrawButton.SetActive(true);
            }
            else if (str == "3")
            {
                Debug.Log("Beret is Sold out");

                BeretButton.SetActive(true);
            }
            else if (str == "4")
            {
                Debug.Log("Cook is Sold out");

                CookButton.SetActive(true);
            }
            else if (str == "5")
            {
                Debug.Log("Cat is Sold out");

                CatButton.SetActive(true);
            }
            else if (str == "6")
            {
                Debug.Log("Chick is Sold out");

                ChickButton.SetActive(true);
            }

            payPopup.SetActive(false);
            menutextmanager.totalcoinText.text = MenuTextManager.totalcoin.ToString();
            PlayerPrefs.SetInt(str, 1);// if buy it, str state is "Buy"(1)
            
            



        }
        
        Debug.Log(MenuTextManager.totalcoin);
        
        

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
        }
    }
           
    

}
