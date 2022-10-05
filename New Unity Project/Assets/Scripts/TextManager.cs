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

    void Start()
    {
        loadTextMap();
        textNum = 10000;
        originText = textMap.GetValueOrDefault(textNum);
        Invoke("StartText", 1.5f);
    }

    public void StartText()
    {
        dialog.text = "";
        isReading = true;
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(!isReading && textMap.GetValueOrDefault(textNum + 1) != null)
        {
            originText = textMap.GetValueOrDefault(++textNum);
            isReading = true;
            StartText();
        }
        else if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            isReading = false;
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

        textMap.Add(10000, "만을욜이 나라에는 어린애조차 다 아는 전설의 도박사 상현.N이 있었다...");
        textMap.Add(10001, "상현.N은 신의 잃어버린 주사위를 가지고 모든 도박장을 재패하고 있었다...");
        textMap.Add(10002, "그러던 어느 날!");
        textMap.Add(10003, "상현.N의 만행에 분노한 신은 상현.N의 꿈에 나와 말했다.");
        textMap.Add(10004, "\"나의 주사위로 그런 일을 벌이다니...\"");
        textMap.Add(10005, "\"네가 그 주사위를 가지고 마왕을 물리친다면 그 주사위의 소유권을 너에게 주겠다.\"");
        textMap.Add(10006, "\"만약 그러지 못하면....\"");
        textMap.Add(10007, "\"너의 목숨과 함께 주사위를 회수해 가겠다!!\"");
        textMap.Add(10008, "그렇게 상현.N은 신의 주사위와 함께 모험을 떠나게 되는데.....");
    }
}
