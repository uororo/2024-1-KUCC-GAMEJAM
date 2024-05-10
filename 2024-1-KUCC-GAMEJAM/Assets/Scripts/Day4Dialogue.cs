using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day4Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "한동안 나의 스트레스의 주범이 된 조별과제 발표날이 다가왔다.",
        "쌈뽕하게 발표를 마친 뒤 뿌듯한 표정으로 있는 조원에게 질의응답 시간이 찾아왔다.",
        "그런데, 질문을 교수님께서 하신다. 도대체 뭐라고 하시는거지? 교수님의 질문에 대한 답변을 뭐라 해야할 지 감도 안온다.",
        "교수: \"자네는 이정도 질문도 스스로 안 던져보고 발표를 하러 온겐가?\"",
        "교수님의 얼굴에서 실망이 묻어나온다.",
        "여기서 멋진 모습을 보이면 나, 교우들이 다르게 봐줄지도?" };
    private int choicePoint = 5;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "갑자기 손을 번쩍 든 김봉팔이 젊은 학자에 빙의하여 논리정연하게 답을 쏟아내기 시작한다. 스마트한 모습에 사람들이 웅성대기 시작한다.\n라이벌의 표심이 80 올라갔다.",
            "이런 젠장, 들었는데도 뭐라는지 모르겠네. 에라이 퉤",
        "멋진 기회를 라이벌에게 빼앗긴 나는 방에 돌아와 누워서 또 잡지식에 관한 나무위키만 읽어보다가 잠을 청했다."} },
        { 1, new string[] { "교수님: \"자네는 도대체 무슨 소릴 하는겐가?\"\n비록 헛소리를 뱉었지만, 용기있는 모습에 감동하고 눈물을 글썽이는 사람들이 생겨났다. 나에 대한 표심이 50만큼 올라갔다.",
            "역시 나야. 너무 똑똑한 나머지 내 수준높은 답변을 교수님도 이해 못하시는군. 민서는 뿌듯하게 생각하며 방에 돌아와 잠에 들었다." } }
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (false, 80) },
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
