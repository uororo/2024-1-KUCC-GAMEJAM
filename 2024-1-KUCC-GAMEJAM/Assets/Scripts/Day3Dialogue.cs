using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day3Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "더럽게 재미없고 힘든 전공 5연강이 끝나고 방에 돌아왔다.",
        "아. 힘들어 죽겠네. 오늘은 이제 방에서 안나가야지.",
        "흠.. 할것도 없는데 과 잡담방에 글이나 올려볼까? 뭐라고 올리지?" };
    private int choicePoint = 2;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "어? 잠깐만, 봉팔이는 랜덤 선물하기로 투썸 홀케이크를 뿌리기 시작했다.\n벼룩의 간만한 내 씀씀이에 비해 봉팔이의 인심에 감동한 교우들이 생겨났다. 라이벌의 표심이 30만큼 상승했다.",
            "미친거 아니야? 참내. 있는집 자식이라 돈이 남아도나봐? 그래도 나도 받았으니까 조용히 있어야지.",
        "험담을 하면서도 취할건 취한 민서는 떨떠름하지만 나름 만족하면서 하루를 보내다 잠을 청했다."} },
        { 1, new string[] { "아무도 맞장구를 안친다. 나혼자 갑자기 험담을 하는 이상한 사람이 됐다.\n나를 향한 표심이 30만큼 떨어졌다.",
            "졸지에 성격 더러운 음침한 외톨이가 된 민서는 쓸쓸히 잠을 청했다." } },
        { 2, new string[] { "김봉팔: \"민서야, 지금 이게 말이 된다고 생각하니? 교수님께 죄송하지도 않아?\"라이벌인 봉팔이가 공개적으로 나를 나무랐다.\n정당하지 못한 나의 모습에 교우들이 실망했다. 나를 향한 표심이 20만큼 떨어졌다.",
        "참내, 지는 얼마나 잘났다고. 씩씩대면서 민서는 폰을 내려놓고 하루종일 롤체만 하다가 잠에 들었다."} }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (false, 30) },
        { 1, (true, -30) },
        { 2, (true, -20) }
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
