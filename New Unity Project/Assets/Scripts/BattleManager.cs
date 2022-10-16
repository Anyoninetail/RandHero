using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static string mobName;
    public static bool isWin;
    public int playerHP;
    public int enemyHP;
    public int diceCount; // 플레이어
    public int enemyDiceCount;
    public int diceImageIndex = 0;
    public bool isRolling;
    public GameObject rollPanel;
    public Button rollBtn;
    public GameObject diceCountPanel;
    public GameObject skipButton;
    public Text diceNumText;
    public Text enemyDiceText;
    public Text playerDiceText;
    public Text playerNameText;
    public Text enemyNameText;
    public Image dice;
    public Image enemyHpBar;
    public Image playerHpBar;
    public BattleTextManager battleTextManager;
    public Sprite[] diceArr;
    public Sprite diceIdleImage;

    void Start()
    {
        playerHP = 25;
        enemyHP = 25;
        enemyHpBar.fillAmount = 1f;
        playerHpBar.fillAmount = 1f;

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
            case 5:
                mobName = "마왕";
                break;
            default:
                mobName = "???";
                break;
        }

        enemyNameText.text = mobName;
    }

    void Update()
    {
        if (isRolling)
        {
            dice.sprite = diceArr[diceImageIndex];
            if(diceImageIndex + 1 == 72)
            {
                diceImageIndex = 0;
            }
            else
            {
                diceImageIndex++;
            }
        }
    }

    public void HealthReduse()
    {
        if(diceCount - enemyDiceCount > 0)
        {
            enemyHP -= diceCount - enemyDiceCount;
        }
        else
        {
            playerHP -= enemyDiceCount - diceCount;
        }
    }

    public void Next()
    {
        enemyHpBar.fillAmount = (float)enemyHP / 25;
        playerHpBar.fillAmount = (float)playerHP / 25;
        if (playerHP > 0 && enemyHP > 0)
        {
            skipButton.SetActive(false);
            WaitRoll();
        }
        else if(playerHP > 0)
        {
            isWin = true;
            battleTextManager.textNum = 20000;
        }
        else
        {
            isWin = false;
            battleTextManager.textNum = 30000;
        }
    }

    public void WaitRoll()
    {
        rollBtn.gameObject.SetActive(true);
        rollBtn.interactable = true;
        rollPanel.SetActive(true);
        isRolling = true;
    }

    public void Roll()
    {
        rollBtn.interactable = false;
        diceCount = Mathf.Max(Random.Range(1, 21), Random.Range(1, 21), Random.Range(1, 21));
        isRolling = false;
        dice.sprite = diceIdleImage;
        diceNumText.text = diceCount.ToString();
        diceCountPanel.SetActive(true);
        StartCoroutine(HideRollPanel(true));
    }
    
    public void EnemyRoll()
    {
        rollBtn.gameObject.SetActive(false);
        rollPanel.SetActive(true);
        isRolling = true;
        StartCoroutine(WaitTimer(2.0f));
    }

    IEnumerator WaitTimer(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        EnemyCountResult();
    }

    IEnumerator HideRollPanel(bool isPlayer)
    {
        yield return new WaitForSecondsRealtime(1.0f);
        if(isPlayer)
        {
            playerDiceText.text = diceCount.ToString();
            rollPanel.SetActive(false);
            diceCountPanel.SetActive(false);
            yield return new WaitForSecondsRealtime(1.0f);
            EnemyRoll();
        }
        else
        {
            enemyDiceText.text = enemyDiceCount.ToString();
            rollPanel.SetActive(false);
            diceCountPanel.SetActive(false);
            skipButton.SetActive(true);
            battleTextManager.HitResult();
        }
    }

    void EnemyCountResult()
    {
        StopCoroutine("WaitTimer");
        StopCoroutine("EnemyRolling");
        isRolling = false;
        dice.sprite = diceIdleImage;
        if (GameManager.mobType == 5)
        {
            enemyDiceCount = Mathf.Max(Random.Range(1, 21), Random.Range(1, 21), Random.Range(1, 21));
        }
        else
        {
            enemyDiceCount = Random.Range(1, 21);
        }
        diceNumText.text = enemyDiceCount.ToString();
        diceCountPanel.SetActive(true);
        StartCoroutine(HideRollPanel(false));
    }
}
