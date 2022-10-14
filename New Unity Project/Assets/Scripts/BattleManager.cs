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
                mobName = "������";
                break;
            case 1:
                mobName = "��ũ";
                break;
            case 2:
                mobName = "���";
                break;
            case 3:
                mobName = "�̹�";
                break;
            case 4:
                mobName = "�̱���";
                break;
        }

        enemyNameText.text = mobName;
    }

    public void Next()
    {
        if(playerHP > 0 && enemyHP > 0)
        {
            //���� ����
            Roll();
            enemyDiceCount = RollDice(true);
        }
        else if(playerHP > 0)
        {
            //�¸�
        }
        else
        {
            //�й�
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
