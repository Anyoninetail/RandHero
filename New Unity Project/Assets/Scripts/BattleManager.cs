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
        
    }
}
