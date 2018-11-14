using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour {
    public TextMeshProUGUI gamecoinText;
    public TextMeshProUGUI stageText;
    
    public static int gamecoin;
    


    private void Awake()
    {
       
        
        gamecoin = 0;
        stageText.text = "Stage " + MenuButton.CurStage.ToString();
        gamecoinText.text = gamecoin.ToString();
    }
    
    public void getCoin()
    {
        gamecoin++;

        gamecoinText.text = gamecoin.ToString();

    }
}
