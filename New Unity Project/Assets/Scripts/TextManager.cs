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
    public Image nextButtonImage;
    public string playerName;

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
        nextButtonImage.gameObject.SetActive(false);
        StartCoroutine("TextWork");
    }

    public void SkipText()
    {
        if(isReading)
        {
            StopCoroutine("TextWork");
            dialog.text = originText;
            nextButtonImage.gameObject.SetActive(true);
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
            nextButtonImage.gameObject.SetActive(false);
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
        nextButtonImage.gameObject.SetActive(true);
        yield break;
    }












































































































    Dictionary<int, string> textMap;

    void loadTextMap()
    {
        textMap = new Dictionary<int, string>();

        //인트로
        textMap.Add(10000, playerName + ".");
        textMap.Add(10001, "그는 럭키 왕국의 한 운좋은 도박꾼일 뿐이었다.");
        textMap.Add(10002, "그의 전매특허 '주사위 놀이'는 왕국 내에서 무적이라 소문이 날 정도였다.");
        textMap.Add(10003, "하지만 그런 그에게도 이길 수 없는게 있었으니...");
        textMap.Add(10004, "그건 바로 사기였다.......");
        textMap.Add(10005, "사기로 모든 재산을 잃은 그는 몰락하는 듯 했으나..");
        textMap.Add(10006, "그의 꿈에 부모님이 나와 이렇게 말했다 :");
        textMap.Add(10007, "\"" + playerName + ", 넌 여기서 쓰러질 사람이 아니다!\"");
        textMap.Add(10008, "\"넌 몰랐겠지만 사실 너는 용사의 피를 타고났단다.\"");
        textMap.Add(10009, "\"이런데서 도박이나 할게 아니란다!\"");
        textMap.Add(10010, "그 말을 들은 " + playerName + "은(는) 믿지 않았다.");
        textMap.Add(10011, "마왕같은 위협도 없는 이 나라에 뭔 용사인가..");
        textMap.Add(10012, "하지만 그는 곧 알게 되었다.");
        textMap.Add(10013, "꿈에서 부모님을 만난 후 " + playerName + "은(는) 최고의 도박꾼의 자리에 오르게 되는데,");
        textMap.Add(10014, "어이없게도 최고의 도박꾼이 되고 얼마 지나지 않아 마왕이 나타났다는 소식이 들려온 것이다.");
        textMap.Add(10015, "게다가 그 마왕은 싸움이 아닌 도박으로 모두를 굴복시키고 있다고 한다...");
        textMap.Add(10016, "그 마왕을 도박으로 막을 사람이 자신밖에 없다는 것을 깨달은 " + playerName + "은(는) 세계를 구하기 위해 모험에 떠나게 되는데...");

        
        //숲(지역) 인카운터
        textMap.Add(11000, playerName + "은(는) 평화롭게 숲속을 거닐고 있었다.");
        textMap.Add(11001, "새가 지저귀는 소리를 들으며 산책하던 " + playerName + "은(는) 수상한 느낌을 받는다.");
        textMap.Add(11002, "저 앞 풀숲 너머에 무언가 있다.");
        textMap.Add(11003, playerName + "은(는) 무엇인지 확인해보기로 했다.");

        //슬라임 인카운터
        textMap.Add(11100, playerName + "은(는) 풀숲을 옆으로 밀고 너머를 들여다 보았다.");
        textMap.Add(11101, "그곳엔.....");
        textMap.Add(11102, "조금씩 기어가던 슬라임이 있었다.");
        textMap.Add(11103, playerName + "은(는) 슬라임을 퇴치하기 위해 싸움을 걸었다!");

        //오크 인카운터
        textMap.Add(11200, playerName + "은(는) 풀숲을 헤치고 앞으로 나아갔다.");
        textMap.Add(11201, "그곳엔.....");
        textMap.Add(11202, "오크가 돌덩이로 운동하고 있었다.");
        textMap.Add(11203, playerName + "은(는) 오크 혼자 운동하는게 못마땅해 싸움을 걸었다!");

        //고블린 인카운터
        textMap.Add(11300, playerName + "은(는) 조용히 풀숲을 헤치고 나왔다.");
        textMap.Add(11301, "그곳엔.....");
        textMap.Add(11302, "고블린이 땅을 열심히 파고 있었다.");
        textMap.Add(11303, playerName + "은(는) 고블린이 찾는게 무엇인지 궁금해 기다렸다.");
        textMap.Add(11304, "얼마나 기다렸을까...");
        textMap.Add(11305, "고블린은 허탕을 쳤는지 땅을 파는 것을 그만두었다.");
        textMap.Add(11306, playerName + "은(는) 머리를 긁적이며 주변을 둘러보던 고블린과 눈이 마주쳤다.");
        textMap.Add(11304, "고블린이 싸움을 걸어왔다!");

        //상자 인카운터
        textMap.Add(11400, playerName + "은(는) 풀숲 옆으로 돌아나왔다.");
        textMap.Add(11401, "그곳엔.....");
        textMap.Add(11402, "황금빛 보물상자가 있었다!!");
        textMap.Add(11403, "신난 " + playerName + "은(는) 보물상자를 열어보았다.");
        textMap.Add(11404, "보물상자 안에는.....");
        //상자가 사실 미믹
        textMap.Add(11410, "이빨이.. 있었다.");
        textMap.Add(11411, "보물상자는 사실 미믹이었다!");
        textMap.Add(11412, "입이 열린게 분한 미믹이 싸움을 걸어왔다!");
        //상자에 보물이 가득
        textMap.Add(11420, "금화가 가득했다!!");
        textMap.Add(11421, playerName + "은(는) 신나게 보물을 쓸어모았다.");

        
        //마을(지역) 인카운터

    }
}
