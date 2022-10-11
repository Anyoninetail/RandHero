using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text daysRemain;
    public Text currentDay;
    public int dayLeft;
    public GameObject nextDay;

    void Start()
    {
        LoadEncounterMap();
        dayLeft = 15;
        daysRemain.text = "마왕성\n도착까지\n" + dayLeft + "일";
    }

    public void ShowNextDay()
    {
        currentDay.text = (16 - dayLeft) + "일차";
        nextDay.SetActive(true);
    }

    public void Encounter()
    {
        
    }






































































    Dictionary<int, string> locationMap;
    Dictionary<int, string> encounterMap;

    void LoadLocationMap()
    {
        locationMap = new Dictionary<int, string>();

        locationMap.Add(0, "Slime");  //슬라임
        locationMap.Add(1, "Ork");  //오크
        locationMap.Add(2, "Goblin");  //고블린
        locationMap.Add(3, "Skeleton");  //스켈레톤
        locationMap.Add(4, "Cultist");  //이교도(세뇌된 마을사람)
        //여기까진 전투 인카운터

        locationMap.Add(5, "Tavern");  //선술집(체력 회복)
        locationMap.Add(6, "Store");  //상점(돈 사용)
        locationMap.Add(7, "Treasure");  //보물(돈 획득)
        locationMap.Add(8, "BadWeather");  //악천후(일정 확률로 체력 감소/돈 분실)
        locationMap.Add(9, "Casino");  //도박장(일정 확률로 돈 대량 획득/체력 감소)
    } 

    void LoadEncounterMap()
    {
        encounterMap = new Dictionary<int, string>();

        encounterMap.Add(0, "당신은 기어가던 슬라임을 발견했다");
        encounterMap.Add(1, "오크가 나타나 앞길을 가로막았다");
        encounterMap.Add(2, "당신은 땅을 파던 고블린과 눈이 마주쳤다");
        encounterMap.Add(3, "상자처럼 둔갑해 있던 미믹을 발견했다");
        encounterMap.Add(4, "마을에서 이교도를 만났다");
        //여기까진 전투 인카운터

        encounterMap.Add(5, "마을에서 선술집을 발견했다");
        encounterMap.Add(6, "지나가던 보부상을 만났다");
        encounterMap.Add(7, "수풀 속에서 황금빛 보물상자를 찾았다");
        encounterMap.Add(8, "천둥 번개가 치기 시작했다");
        encounterMap.Add(9, "은밀한 골목에서 도박장으로 안내받았다");
    }
}
