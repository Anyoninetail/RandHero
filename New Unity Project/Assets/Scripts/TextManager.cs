using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static string playerName = "[플레이어]";
    public string originText;
    public float textSpeed;
    public bool isReading;
    public int textNum;
    public int nextTextNum;
    public GameManager gameManager;
    public GameObject skipButton;
    public Image nextButtonImage;
    public Text dialog;

    void Start()
    {
        LoadTextMap();
        textNum = 10000;
        nextTextNum = -1;
        StartText();
    }

    public void StartText()
    {
        isReading = true;
        originText = textMap.GetValueOrDefault(textNum);
        skipButton.SetActive(true);
        dialog.text = "";
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
            StartText();
        }
        else if(nextTextNum != -1)
        {
            textNum += nextTextNum;
            switch(textNum)
            { 
                case 24003:
                    nextTextNum = Random.Range(1, 3) * 100;
                    break;
                case 32002:
                    nextTextNum = Random.Range(1, 4) * 100;
                    break;
                default:
                    nextTextNum = -1;
                    break;
            }
            textNum -= textNum % 100;
            originText = textMap.GetValueOrDefault(textNum);

            StartText();
        }
        else
        {
            skipButton.SetActive(false);
            nextButtonImage.gameObject.SetActive(false);
            dialog.text = "";
            gameManager.EncounterResult();
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

    private void LoadTextMap()
    {
        textMap = new Dictionary<int, string>();

        //인트로
        textMap.Add(10000, "'" + playerName + "'.");
        textMap.Add(10001, "그는 럭키 왕국의 한 운좋은 도박꾼일 뿐이었다.");
        textMap.Add(10002, "그가 굴리는 주사위는 행운의 신의 축복을 받았다는 소문이 돌 정도였다.");
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
        textMap.Add(10015, "게다가 그 마왕이 세상에 내린 저주가 더 어이없었다.");
        textMap.Add(10016, "무려 생사를 오가는 전투도 도박으로 결정짓게 되는 저주였다.......");
        textMap.Add(10017, "'그럼 난 도박꾼이 아니라 용사가 된 거네..?'");
        textMap.Add(10018, "그렇게 마왕을 무찌르기 위한 용사 '" + playerName + "'의 모험이 시작되었다.");


        //숲(지역) 인카운터
        textMap.Add(20000, playerName + "은(는) 평화롭게 숲속을 거닐고 있었다.");
        textMap.Add(20001, "새가 지저귀는 소리를 들으며 산책하던 " + playerName + "은(는) 수상한 느낌을 받는다.");
        textMap.Add(20002, "저 앞 풀숲 너머에 무언가 있다.");
        textMap.Add(20003, playerName + "은(는) 무엇인지 확인해보기로 했다.");

        //슬라임 인카운터
        textMap.Add(21000, playerName + "은(는) 풀숲을 옆으로 밀고 너머를 들여다 보았다.");
        textMap.Add(21001, "그곳엔.....");
        textMap.Add(21002, "조금씩 기어가던 슬라임이 있었다.");
        textMap.Add(21003, playerName + "은(는) 슬라임을 퇴치하기로 마음먹었다.");  //전투

        //오크 인카운터
        textMap.Add(22000, playerName + "은(는) 풀숲을 헤치고 앞으로 나아갔다.");
        textMap.Add(22001, "그곳엔.....");
        textMap.Add(22002, "오크가 거대한 돌덩이로 운동하고 있었다.");
        textMap.Add(22003, "운동하던걸 들킨 오크는 부끄러웠는지 싸움을 걸어왔다!");  //전투

        //고블린 인카운터
        textMap.Add(23000, playerName + "은(는) 조용히 풀숲을 헤치고 나왔다.");
        textMap.Add(23001, "그곳엔.....");
        textMap.Add(23002, "고블린이 땅을 열심히 파고 있었다.");
        textMap.Add(23003, playerName + "은(는) 고블린이 찾는게 무엇인지 궁금해 기다렸다.");
        textMap.Add(23004, "얼마나 기다렸을까...");
        textMap.Add(23005, "고블린은 허탕을 쳤는지 땅을 파는 것을 그만두었다.");
        textMap.Add(23006, playerName + "은(는) 머리를 긁적이며 주변을 둘러보던 고블린과 눈이 마주쳤다.");
        textMap.Add(23007, "고블린이 싸움을 걸어왔다!");  //전투

        //상자 인카운터
        textMap.Add(24000, playerName + "은(는) 풀숲 옆으로 돌아나왔다.");
        textMap.Add(24001, "그곳엔.....");
        textMap.Add(24002, "황금빛 보물상자가 반쯤 묻혀 있었다!!");
        textMap.Add(24003, "신난 " + playerName + "은(는) 묻힌 보물상자를 파내 열어보았다.");
        textMap.Add(24004, "보물상자 안에는.....");
        //상자 인카운터 - 1/상자가 사실 미믹
        textMap.Add(24100, "이빨이... 있었다..?");
        textMap.Add(24101, "보물상자는 사실 미믹이었다!");
        textMap.Add(24102, "정체를 들킨게 분한 미믹이 싸움을 걸어왔다!");  //전투
        //상자 인카운터 - 2/상자에 보물이 가득
        textMap.Add(24200, "금화가 가득했다!!!");
        textMap.Add(24201, playerName + "은(는) 신나게 보물을 쓸어모았다.");


        //마을(지역) 인카운터
        textMap.Add(30000, playerName + "은(는) 어느 작은 마을에 도착했다.");
        textMap.Add(30001, "거리를 활보하던 " + playerName + "은(는) 무언가 발견한다.");
        textMap.Add(30002, "그것은 바로.....");

        //이교도 인카운터
        textMap.Add(31000, "마을의 주민으로 보였다.");
        textMap.Add(31001, "그냥 지나가려고 하니 그 사람이 다가와 말을 꺼냈다.");
        textMap.Add(31002, "\"혹시 마왕교를 아십니까?\"");
        textMap.Add(31003, "..........");
        textMap.Add(31004, "알고보니 이교도였다.");
        textMap.Add(31005, playerName + "은(는) 이 사람의 정신을 고쳐주기로 마음먹었다.");  //전투

        //주점 인카운터
        textMap.Add(32000, "주점이었다.");
        textMap.Add(32001, "마침 쉬고 싶었던 " + playerName + "은(는) 곧장 주점에 들어갔다.");
        textMap.Add(32002, "주점 내부는 꽤나 넓었다.");
        textMap.Add(32003, "음료를 하나 주문하고 나서, " + playerName + "은(는) 주변 대화를 엿들었다.");
        //주점 인카운터 - 1/용사 미담
        textMap.Add(32100, "구석에서 주민 두명이 서로 대화하고 있었다.");
        textMap.Add(32101, "\"요즘 용사님이 나타났다지?\"");
        textMap.Add(32102, "\"맞아, 원래는 도박꾼이었다던데?\"");
        textMap.Add(32103, "\"그럼 저주가 걸린 지금은 굉장히 강자겠네.\"");
        textMap.Add(32104, "\"그럴지도 모르지.\"");
        textMap.Add(32105, "계속 듣고있다간 부끄러움을 감당할 수 없다고 생각한 " + playerName + "은(는) 남은 음료를 원샷하고 황급히 주점을 나섰다.");
        //주점 인카운터 - 2/사라진 보물
        textMap.Add(32200, "구석에서 주민 한명이 신세한탄하고 있었다.");
        textMap.Add(32201, "\"어휴 인생....\"");
        textMap.Add(32202, "\"도대체 누가 알고 내 보물상자를 파간거지..?\"");
        textMap.Add(32203, "\"그걸 찾지 못하면 내 빚을 다 갚을 수 없을텐데...\"");
        textMap.Add(32204, "\"집이라도 팔아야 하나...\"");
        textMap.Add(32205, "불쌍한 주민을 뒤로하고 " + playerName + "은(는) 다시 갈 길을 떠났다.");
        //주점 인카운터 - 3/여기도 이교도가?
        textMap.Add(32300, "바로 그때,");
        textMap.Add(32301, "누군가 들어와 " + playerName + "의 옆에 앉았다.");
        textMap.Add(32302, "\"인상이 굉장히 선하시네요 ㅎㅎ\"");
        textMap.Add(32303, "'하...'");
        textMap.Add(32304, "별로 상대하기 싫은 유형의 사람이라 " + playerName + "은(는) 얼른 자리를 떴다.");
        textMap.Add(32305, "뒤에서 누군가 욕을 하는 소리가 들려왔지만 " + playerName + "은(는) 아랑곳하지 않고 주점을 나섰다.");

        //떠돌이 상인 인카운터
        textMap.Add(33000, "떠돌이 상인이었다.");
        textMap.Add(33001, "눈이 마주치자 상인이 반가운 얼굴로 다가온다.");
        textMap.Add(33002, "\"이야! 안녕하세요, 용사이신 것 같은데 물건 좀 보시겠습니까?\"");
        textMap.Add(33003, playerName + "은(는) 물건을 둘러보았다.");

        //야바위 인카운터
        textMap.Add(34000, "거리 한복판에 누가 컵 3개를 앞에 두고 앉아 있었다.");
        textMap.Add(34001, playerName + "은(는) 호기심을 참지 못하고 뭐하고 있는지 물어보았다.");
        textMap.Add(34002, "\"용사님이신 것 같은데... 저랑 놀이 하나 하시겠습니까?\"");
        textMap.Add(34003, "\"3개에 컵 중에 공을 하나 넣고 어디있는지 맞추는 겁니다.\"");
        textMap.Add(34004, "\"성공하면 3배에 3분의 1 확률, 공평하지 않습니까?\"");
        textMap.Add(34005, "'어차피 사기 쳐봤자 나도 한 때 도박꾼이었으니 알아챌 수 있겠지...'");
        textMap.Add(34006, "'한번 재미 좀 볼까?'");


        //악천후(지역) 인카운터
        textMap.Add(40000, playerName + "은(는) 평소와 같이 걷고 있었다.");
        textMap.Add(40001, "그런데 하늘에서 불안한 기운이 느껴진다.");
        textMap.Add(40002, "아니나 다를까...");
        textMap.Add(40003, "하늘에서 천둥번개가 치기 시작했다!");
        textMap.Add(40004, "뒤이어 비가 아주 세차게 내린다!");
        textMap.Add(40005, "어딘가 비를 피할 곳을 찾아야 한다.");

        //악천후 인카운터 - 1/비를 피하지 못했다(숲)
        textMap.Add(41000, "얼마나 지났을까...");
        textMap.Add(41001, playerName + "은(는) 계속 돌아다녔지만 비를 피할 만한 곳은 찾지 못했다.");
        textMap.Add(41002, "한참 뒤에야 비가 그쳤고, " + playerName + "은(는) 감기에 걸린 듯 하다.");
        textMap.Add(41003, "설상가상으로 주머니 속 지폐도 젖어 형체를 알아볼 수 없게 되었다.");
        textMap.Add(41004, playerName + "은(는) 사용할 수 없는 지폐를 몇 장 버렸다.");
        //악천후 인카운터 - 2/비를 피했다(마을)
        textMap.Add(42000, "다행히 근처에 비를 피할 건물을 발견할 수 있었다.");
        textMap.Add(42001, playerName + "은(는) 비가 그칠 때까지 그 곳에서 쉬었다.");
        textMap.Add(42002, "한참 뒤에야 비가 그쳤고, " + playerName + "은(는) 다시 갈 길을 떠났다.");

        //오류 메세지
        textMap.Add(90000, "인카운터 계산 과정에 오류가 생겼습니다.");
    }
}
