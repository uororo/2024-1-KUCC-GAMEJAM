using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day5Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "전공 수업이 끝났다. 오늘은 동기들과 중광에서 치맥을 때리기로 한 날이다.",
        "오늘따라 맥주 맛이 참 좋다. 키야~ 시원해~ 아주 콸콸 들어간다.",
        "정신 못차리고 배에 거지가 든 것 마냥 맥주를 목구멍에 들이붓다가 아뿔싸! 옆자리 어색한 친구의 무릎에 쏟아버렸다.",
        "\"워메! 깜짝이여! 이게 도대체 무슨짓이야 어이!!!\"",
        "어떡하지? 안그래도 어색한데 신사답지 못하게 결례까지 범하다니, 정말 나 자신에게 실망이다. 이럴때가 아니라 얼른 닦아줘야지!"};
    private int choicePoint = 4;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "자신의 손을 희생해서까지 책임지는 모습에 친구와 다른 동기들이 감동한다.\n나를 향한 표심이 80 상승했다.",
            "손에 남은 맥주를 쪽쪽 빨아먹고나서 마저 놀다가 집에 온 민서는 신사다운 본인의 모습에 스스로 감탄하며 잠을 청한다." } },
        { 1, new string[] { "\"민서는 준비성이 정말 철저한 친구로구나? 네 녀석은 과대를 해도 참말로 잘하겠어.\"\n모든 변수에 철저히 대비하는 나의 모습에 교우들이 감동했다. 나를 향한 표심이 50 상승했다.",
            "닦고 더러워진 손수건은 친구들이 안보는 사이에 대충 구석 땅바닥에 버리고 민서는 마저 자리를 즐기다가 방에 돌아가 잠에 청했다." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 80) },
        { 1, (true, 50) }
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
