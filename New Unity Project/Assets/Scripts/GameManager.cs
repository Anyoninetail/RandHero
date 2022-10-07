using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text daysRemain;
    public int dayLeft;

    void Start()
    {
        dayLeft = 15;
        daysRemain.text = "마왕성 도착까지\n" + dayLeft + "일";
    }











































































    Dictionary<int, string> encounterMap;

    void LoadEncounterMap()
    {
        encounterMap = new Dictionary<int, string>();

        encounterMap.Add(0, "Slime");  //슬라임
        encounterMap.Add(1, "Ork");  //오크
        encounterMap.Add(2, "Goblin");  //고블린
        encounterMap.Add(3, "Skeleton");  //스켈레톤
        encounterMap.Add(4, "Cultist");  //이교도(세뇌된 마을사람)
        //여기까진 전투 인카운터

        encounterMap.Add(5, "Tavern");  //선술집(체력 회복)
        encounterMap.Add(6, "Store");  //상점(돈 사용)
        encounterMap.Add(7, "Treasure");  //보물(돈 획득)
        encounterMap.Add(8, "BadWeather");  //악천후(일정 확률로 체력 감소/돈 분실)
        encounterMap.Add(9, "Casino");  //도박장(일정 확률로 돈 대량 획득/체력 감소)
    }
}
