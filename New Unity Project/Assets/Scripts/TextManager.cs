using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public string originText;
    public Text dialog;
    public float textSpeed;
    public bool isReading;
    public int textNum;
    public GameObject skipButton;

    void Start()
    {
        loadTextMap();
        textNum = 10000;
        originText = textMap.GetValueOrDefault(textNum);
        StartText();
    }

    public void StartText()
    {
        skipButton.SetActive(true);
        dialog.text = "";
        isReading = true;
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            isReading = false;
            
        }
        else if(textMap.GetValueOrDefault(textNum + 1) != null)
        {
            originText = textMap.GetValueOrDefault(++textNum);
            isReading = true;
            StartText();
        }
        else
        {
            skipButton.SetActive(false);
            dialog.text = "";
        }
    }

    IEnumerator TextWork()
    {
        for(int i = 0; i <= originText.Length; i++)
        {
            yield return new WaitForSecondsRealtime(textSpeed);
            dialog.text = originText.Substring(0, i);
        }
        isReading = false;
        yield break;
    }












































































































    Dictionary<int, string> textMap;

    void loadTextMap()
    {
        textMap = new Dictionary<int, string>();

        textMap.Add(10000, "(플레이어).");
        textMap.Add(10001, "그는 럭키 왕국의 한 운좋은 도박꾼일 뿐이었다.");
        textMap.Add(10002, "그의 전매특허 '주사위 놀이'는 왕국 내에서 무적이라 소문이 날 정도였다.");
        textMap.Add(10003, "하지만 그런 그에게도 이길 수 없는게 있었으니...");
        textMap.Add(10004, "그건 바로 사기였다.......");
        textMap.Add(10005, "사기로 모든 재산을 잃은 그는 몰락하는 듯 했으나..");
        textMap.Add(10006, "그의 꿈에 부모님이 나와 이렇게 말했다 :");
        textMap.Add(10007, "\"(플레이어), 넌 여기서 쓰러질 사람이 아니다!\"");
        textMap.Add(10008, "\"넌 몰랐겠지만 사실 너는 용사의 피를 타고났단다.\"");
        textMap.Add(10009, "\"이런데서 도박이나 할게 아니란다!\"");
        textMap.Add(10010, "그 말을 들은 (플레이어)는 믿지 않았다.");
        textMap.Add(10011, "마왕같은 위협도 없는 이 나라에 뭔 용사인가..");
        textMap.Add(10012, "하지만 그는 곧 알게 되었다.");
        textMap.Add(10013, "꿈에서 부모님을 만난 후 (플레이어)는 최고의 도박꾼의 자리에 오르게 되는데,");
        textMap.Add(10014, "어이없게도 최고의 도박꾼이 되고 얼마 지나지 않아 마왕이 나타났다는 소식이 들려온 것이다.");
        textMap.Add(10015, "게다가 그 마왕은 싸움이 아닌 도박으로 모두를 굴복시키고 있다고 한다...");
        textMap.Add(10016, "그 마왕을 도박으로 막을 사람이 자신밖에 없다는 것을 깨달은 (플레이어)는 세계를 구하기 위해 모험에 떠나게 되는데...");
    }
}
