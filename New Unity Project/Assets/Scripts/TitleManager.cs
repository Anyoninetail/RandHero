using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public InputField inputField;

    public void GameStart()
    {
        GameManager.mobType = 0;
        GameManager.isIntro = true;
        
        if(inputField.text != "")
        {
            TextManager.playerName = inputField.text;
        }
        else
        {
            LoadNameMap();
            TextManager.playerName = playerNames.GetValueOrDefault(Random.Range(0, 36));
        }

        SceneLoader.Instance.LoadScene("TextScene");
    }

    Dictionary<int, string> playerNames = new Dictionary<int, string>();

    void LoadNameMap()
    {
        playerNames.Add(0, "김치볶음밥");
        playerNames.Add(1, "간장계란밥");
        playerNames.Add(2, "크림파스타");
        playerNames.Add(3, "스파게티");
        playerNames.Add(4, "마라샹궈");
        playerNames.Add(5, "타코야끼");
        playerNames.Add(6, "간장게장");
        playerNames.Add(7, "양념게장");
        playerNames.Add(8, "해물파전");
        playerNames.Add(9, "샌드위치");
        playerNames.Add(10, "양념치킨");
        playerNames.Add(11, "닭볶음탕");
        playerNames.Add(12, "쟁반짜장");
        playerNames.Add(13, "해물라면");
        playerNames.Add(14, "된장찌게");
        playerNames.Add(15, "전주비빔밥");
        playerNames.Add(16, "고기만두");
        playerNames.Add(17, "야채스프");
        playerNames.Add(18, "티라미수");
        playerNames.Add(19, "카페라떼");
        playerNames.Add(20, "스테이크");
        playerNames.Add(21, "아메리카노");
        playerNames.Add(22, "제육볶음");
        playerNames.Add(23, "잔치국수");
        playerNames.Add(24, "치즈돈가스");
        playerNames.Add(25, "연어초밥");
        playerNames.Add(26, "장어초밥");
        playerNames.Add(27, "배추김치");
        playerNames.Add(28, "딸기케이크");
        playerNames.Add(29, "프리티우먼");
        playerNames.Add(30, "핸섬가이");
        playerNames.Add(31, "학생회장");
        playerNames.Add(32, "랜덤용사");
        playerNames.Add(33, "새우튀김");
        playerNames.Add(34, "초코파이");
        playerNames.Add(35, "옛날떡볶이");
    }
}
