using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day6Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "오늘은 과 MT에서 만난 회장, 이덕기 선배와 밥약이 있는 날이다.",
        "선배, 이왕 사줄꺼면 무르무르로 가시죠?",
        "새내기 후배의 당돌함에 감탄한 선배는 흔쾌히 나를 무르무르로 끌고 갔다.",
        "자리에 앉아 메뉴판을 순식간에 스캔한 뒤, 가장 비싼 메뉴로 주문을 마쳤다.",
        "흠, 이제 무슨 얘기를 하지?"};
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "아직 세상 물정을 모르는듯한 나의 모습에 선배가 혀를 차기 시작한다. 속으로 나는 글렀다고 생각하고 있다.\n나를 향한 표심이 40 하락했다.",
            "참내, 지는 뭐 얼마나 잘났다고. 밥 사면 다야? 민서는 또 다시 음침하게 밤새 남을 욕하다가 잠을 청했다." } },
        { 1, new string[] { "극 내향인I를 만나면 신나는 선배의 성격 때문에 밥약 내내 분위기가 좋았다. 과에 좋은 소문이 퍼진다.\n나를 향한 평판이 50 상승했다.",
            "하루종일 말만 듣느라 귀에서 피가 날 지경인 민서는 좋아하는 제이팝으로 귀를 정화하다가 스르르 잠에 들었다." } },
        { 2, new string[] { "늘 연장자로만 취급 받던 선배가 감격하여 눈물을 흘리기 시작한다. 선배가 과 사람들에게 좋은 소문을 퍼뜨린다.\n나를 향한 표심이 70 상승했다.",
        "뿌듯하게 인생조언과 격언을 전해준 나는 선배에게 커피까지 얻어먹고 인생의 쓴소리를 하다가 방에 돌아와서 바둑을 두다가 잠에 들었다."} }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, -40) },
        { 1, (true, 50) },
        { 2, (true, 70) }
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
