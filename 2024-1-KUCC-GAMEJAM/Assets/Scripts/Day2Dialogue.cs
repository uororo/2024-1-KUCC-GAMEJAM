using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day2Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "오늘도 쌈@뽕하게 하루종일 놀아제낀 나는 슬슬 자취방에 돌아갈 준비중이었다.",
        "갑자기 누군가 나의 어깨를 붙잡기에 뒤를 돌아보았다.",
        "통학하는 동기인 이광칠이었다.",
        "\"이광칠: 얘, 민서야. 무어가 그리 급하길래 집으로 가는 발걸음을 서두르니. 그러지 말고 나랑 막차시간까지만 놀자 응?\"",
        "아.. 솔직히 귀찮은데, 빨리 집가서 씻고 자고싶은데. 어떡하지?" };
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "이광칠: \"얘, 역시 너밖에 없다! 너 정말 좋은 친구구나!\"\n교우들이 우정을 저버리지 않는 내모습을 보고 좋은 인상을 가지게 되었다. 나를 향한 표심이 40 올라갔다. 야호",
            "소외되는 친구 없이 오늘도 신나게 놀아제낀 나는 자취방에 와서 쿨쿨 잠들었다." } },
        { 1, new string[] { "김봉팔: \"그래~ 민서는 많이 피곤한가봐~ 나는 첫차까지도 된다고? 어디 한번 광란의 밤을 보내볼까?\"\n교우들이 나는 안중에도 없이 봉팔이와 끝내주게 놀았다. 라이벌의 표심이 60만큼 올라갔다.",
            "친구들이 봉팔이만 좋아하는 모습에 열등감을 느낀 민서는 질투심에 빠져 씩씩대다가 잠이 들었다." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 40) },
        { 1, (false, 60) }
    };

    public void StartDialogue()
    {
        // 대화 시작 로직은 DialogueManager가 처리
    }

    public string[] GetSentences()
    {
        return sentences;
    }

    public int GetChoicePoint()
    {
        return choicePoint;
    }

    public int GetNumberOfChoices()
    {
        return choiceSentences.Count;
    }

    public Dictionary<int, string[]> GetChoices()
    {
        return choiceSentences;
    }

    // 선택지에 따른 점수 조정 메소드
    public void ApplyChoiceEffect(int choiceIndex)
    {
        if (choiceEffects.ContainsKey(choiceIndex))
        {
            var effect = choiceEffects[choiceIndex];
            GameManager.Instance.AdjustScore(effect.isPlayer, effect.points);
        }
    }
}
