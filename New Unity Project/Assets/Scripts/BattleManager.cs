using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public string mobName;
    public int playerHP;
    public int enemyHP;
    public int diceCount;
    public int enemyDiceCount;
    public GameObject rollPanel;
    public Text playerNameText;
    public Text enemyNameText;
    public Image dice;

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
        if(playerHP > 0 && enemyHP > 0)
        {
            //다음 전투
            Roll();
            enemyDiceCount = RollDice(true);
        }
        else if(playerHP > 0)
        {
            //승리
        }
        else
        {
            //패배
        }
    }

    public void Roll()
    {
        
    }

    public int RollDice(bool isAuto)
    {
        int num = 0;
        dice.gameObject.SetActive(true);
        if (!isAuto)
        {

        }
        return num;
    }
}
