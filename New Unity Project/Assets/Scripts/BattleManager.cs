using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public string mobName;
    public Text playerNameText;
    public Text enemyNameText;
    void Start()
    {
        playerNameText.text = TextManager.playerName;
        switch(GameManager.mobType)
        {
            case 0:
                mobName = "슬라임";
                break;
            case 1:
                mobName = "오크";
                break;
            case 2:
                mobName = "고블린";
                break;
            case 3:
                mobName = "미믹";
                break;
            case 4:
                mobName = "이교도";
                break;
        }

        enemyNameText.text = mobName;
    }

    public void Next()
    {
        
    }
}
