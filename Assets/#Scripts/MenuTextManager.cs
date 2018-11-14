using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuTextManager : MonoBehaviour {
    public TextMeshProUGUI totalcoinText;
    public static int totalcoin;
    // Use this for initialization
    private void Awake () {
        
        totalcoinText = GetComponent<TextMeshProUGUI>();
        totalcoin = PlayerPrefs.GetInt("TotalCoin", totalcoin);
        PopupCoinTextManager.temp = totalcoin;
        totalcoinText.text = totalcoin.ToString();
       
    }
   
    // Update is called once per frame
   
}
