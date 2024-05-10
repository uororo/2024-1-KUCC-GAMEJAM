using System.Collections.Generic;
using UnityEngine;

public class Day5Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "다섯째 날 대화문 테스트",
        "이어서 나오는 대화 테스트", "선택지 등장:" };
    private int choicePoint = 2;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "1번 선택지를 골랐습니다.", "Resulting dialogue" } },
        { 1, new string[] { "2번 선택지를 골랐습니다.", "Resulting dialogue" } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 10) },  // 1번 선택지가 플레이어에게 +10 점수
        { 1, (false, -5) }  // 2번 선택지가 상대방에게 -5 점수
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
