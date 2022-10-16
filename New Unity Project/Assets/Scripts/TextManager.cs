using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static string playerName;
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
        if(GameManager.isIntro)
        {
            LoadTextMap();
            textNum = 10000;
            nextTextNum = -1;
        }
        else
        {
            LoadTextMap();

            if (BattleManager.isWin)
            {
                textNum = 50000;
            }
            else
            {
                textNum = 51000;
            }
            nextTextNum = -1;
            gameManager.BattleResult();
        }
        StartText();
    }

    public void StartText()
    {
        gameManager.ChangeEncounterImage();
        isReading = true;
        originText = textMap.GetValueOrDefault(textNum);
        skipButton.SetActive(true);
        dialog.text = "";
        nextButtonImage.gameObject.SetActive(false);
        StartCoroutine("TextWork");
    }

    public void StartText(bool isNotFirst)
    {
        gameManager.ChangeEncounterImage();
        isReading = true;
        originText = textMap.GetValueOrDefault(0);
        textNum--;
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
        else if(GameManager.money < 3 && textNum == 32000)
        {
            textNum = 67991;
            nextTextNum = -1;
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

        //인카운터 중간과정
        textMap.Add(0, "한참이 지난 후...");

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
        textMap.Add(24002, "평범한 보물상자가 반쯤 묻혀 있었다!!");
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
        textMap.Add(31004, "이 사람 이교도였다.");
        textMap.Add(31005, playerName + "은(는) 이 사람의 정신을 고쳐주기로 마음먹었다.");  //전투

        //주점 인카운터
        textMap.Add(32000, "주점이었다.");
        //주점 입장
        textMap.Add(32001, "마침 쉬고 싶었던 " + playerName + "은(는) 곧장 주점에 들어갔다.");
        textMap.Add(32002, "주점 내부는 꽤나 넓었다.");
        textMap.Add(32003, "음료를 하나 주문하고 나서, " + playerName + "은(는) 주변 대화를 엿들었다.");
        //돈이없네... 주점 지나침
        textMap.Add(67991, "마침 쉬고 싶었던 " + playerName + "은(는) 곧장 주점에 들어가려했으나...");
        textMap.Add(67992, "음료를 살 돈이 충분하지 않았다.");
        textMap.Add(67993, "아쉽지만 이번엔 그냥 지나가기로 했다.");
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
        textMap.Add(33002, "\"이야~! 반갑습니다 용사님. 포션 좀 구매하시겠어요?\"");
        textMap.Add(33003, playerName + "은(는) 포션을 보기로 했다.");

        //동전게임 인카운터
        textMap.Add(34000, "마을의 주민이었다.");
        textMap.Add(34001, playerName + "을(를) 발견한 주민은 다가와 말을 걸었다.");
        textMap.Add(34002, "\"용사님이신 것 같은데... 저랑 재밌는 게임 하나 하시겠습니까?\"");
        textMap.Add(34003, "\"제가 동전을 던지면, 용사님이 앞면인지 뒷면인지 맞히시는 겁니다.\"");
        textMap.Add(34004, "\"만약 맞히시면 3골드를 드리고, 못 맞히시면 3골드를 받아가겠습니다.\"");
        textMap.Add(34005, "'마침 심심했는데 잘됐네'");
        textMap.Add(34006, "'한번 해볼까?'");


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
        textMap.Add(41003, "설상가상으로 이리저리 돌아다니다 돈도 조금 잃어버린 듯 하다.");
        textMap.Add(41004, playerName + "은(는) 아쉬운대로 다시 가던 길을 가기로 했다.");
        //악천후 인카운터 - 2/비를 피했다(마을)
        textMap.Add(42000, "다행히 근처에 비를 피할 건물을 발견할 수 있었다.");
        textMap.Add(42001, playerName + "은(는) 비가 그칠 때까지 그 곳에서 쉬었다.");
        textMap.Add(42002, "한참 뒤에야 비가 그쳤고, " + playerName + "은(는) 다시 갈 길을 떠났다.");


        //전투 승리시
        textMap.Add(50000, playerName + "은(는) 전투에서 승리했다.");
        textMap.Add(50001, playerName + "은(는) 전리품을 챙겨 다시 갈 길을 떠났다.");
        //전투 패배시
        textMap.Add(51000, playerName + "은(는) 전투에서 패배했다.");
        textMap.Add(51001, playerName + "은(는) 만신창이가 된 몸으로 겨우 도망쳤다.");


        //보스 인카운터
        textMap.Add(60000, playerName + "은(는) 마침내 마왕성에 도착했다.");
        textMap.Add(60001, playerName + "이(가) 알현실까지 가는 길에는 아무 생명체도 없었다.");
        textMap.Add(60002, playerName + "은(는) 모험의 끝을 직감한다.");
        textMap.Add(60003, playerName + "이(가) 알현실에 도달했고, 그곳엔...");
        //보스 인카운터 - 1/아무도 없었다.(랜덤 엔딩 1)
        textMap.Add(61000, "아무도...없었다.....");
        textMap.Add(61001, "무슨 일이 일어났는지는 모르겠으나 알현실엔 개미 한 마리 조차 보이지 않았다.");
        textMap.Add(61002, playerName + "은(는) 차라리 잘 된 일이라며 성을 나섰다.");
        textMap.Add(61003, playerName + "이(가) 고향에 돌아왔을 때엔 용사가 마왕을 물리쳤다는 소문이 돌고 있었다.");
        textMap.Add(61004, "정작 용사인 " + playerName + "은(는) 마왕을 만나지도 못했다.");
        textMap.Add(61005, "정말 마왕은 그냥 소멸한 것일까?");
        textMap.Add(61006, ".....아니면 다른 꿍꿍이가 있는 것일까?");
        textMap.Add(61007, "그건 마왕만 알 터였다.");
        textMap.Add(61008, "'그렇지만 지금 당장은 평화가 찾아왔으니 괜찮을 것이다'");
        textMap.Add(61009, playerName + "은(는) 집에 돌아가 쉬기로 한다.");
        textMap.Add(61010, "아무 일도 없을것이다.");
        textMap.Add(61011, ".....");
        textMap.Add(61012, "아마도.");
        textMap.Add(61013, "-랜덤 엔딩 1[이게 뭐야 찝찝하게.....]-");
        textMap.Add(61014, "-운이 좋다면 다른 엔딩을 볼 수 있을지도 모릅니다.-");
        //보스 인카운터 - 2/보스전!(승리시 랜덤 엔딩 2, 패배시 게임 오버)
        textMap.Add(62000, playerName + "의 쌍둥이 동생이 있었다.");
        textMap.Add(62001, playerName + "은(는) 그가 소문의 마왕이라는 것을 알아챘다.");
        textMap.Add(62002, "어릴 적 " + playerName + "을(를) 꼬드겨 도박을 같이 하다 둘의 전재산을 들고 잠적한 그가,");
        textMap.Add(62003, "지금, 여기에 마왕으로 있었다.");
        textMap.Add(62004, "어릴적 기억이 떠오른 " + playerName + "은(는) 분노를 이기지 못하고 곧장 마왕에게 싸움을 걸었다.");

        //랜덤 엔딩 2
        textMap.Add(70000, playerName + "은(는).....");
        textMap.Add(70001, "결국 마왕을 처치했다.");
        textMap.Add(70002, "마왕의 숨이 끊어졌고");
        textMap.Add(70003, "마왕이 죽었다는 사실은 순식간에 퍼져나갔다.");
        textMap.Add(70004, "이 세계는 평화가 찾아왔다.");
        textMap.Add(70005, "용사 " + playerName + "은(는) 마왕이 자신의 쌍둥이 동생이었다는 사실을 누구에게도 말하지 않았다.");
        textMap.Add(70006, "훗날 " + playerName + "은(는) 마왕을 물리친 용사로 기억되고,");
        textMap.Add(70007, "그 누구도 마왕과 용사가 가족이었다는 것을 모를 것이다.");
        textMap.Add(70008, "-랜덤 엔딩 2[진엔딩인데 뭔가 찝찝하네]-");
        textMap.Add(70009, "-축하드립니다. 이 게임의 진엔딩을 보셨네요.-");
        textMap.Add(70010, "-끝이 찝찝해도 어쩔 수 없습니다.-");
        textMap.Add(70011, "-원래 도박의 끝은 구린 법이니까요.-");

        //게임 오버
        textMap.Add(80000, playerName + "은(는).....");
        textMap.Add(80001, "험난한 모험을 견디지 못했다.");
        textMap.Add(80002, playerName + "의 숨이 끊어졌고");
        textMap.Add(80003, "용사" + playerName + "이(가) 죽었다는 사실은 순식간에 퍼져나갔다.");
        textMap.Add(80004, "이 세계 어딘가에서 마왕은 웃고 있을 것이다.");
        textMap.Add(80005, "그렇게 용사 " + playerName + "의 모험은 끝을 맞이했다.");
        textMap.Add(80006, "-[게임 오버]-");
        textMap.Add(80007, "-이번엔 운이 안좋으셨나 봅니다.-");


        //오류 메세지
        textMap.Add(90000, "인카운터 계산 과정에 오류가 생겼습니다.");
    }
}
