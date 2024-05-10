using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Day1Dialogue : MonoBehaviour, IDayDialogue
{
    private string[] sentences = { "두근거리는 마음으로 고려대에 입학한 나 자신.",
        "그런 나에겐 한가지 고민거리가 있었다.",
        "그건 바로 과대가 되지 못하면 단단히 각오하라는 엄마의 경고였다.",
        "결국 나는 과대로 선출되기 위해 후보자 등록을 했다",
        "그런데 정신없이 놀면서 까먹고 있다가 과대 투표일까지 일주일 남았다는 사실을 방금 알게됐다.",
        "어떡하지? 엄마한테 혼나기는 싫은데.",
        "결국 나는 남은 일주일동안 전력을 다하기로 결심했다.",
        "상대는 우리 과의 도내 1급 엄친아로 유명한 김봉팔이다.",
        "힘들긴 하겠지만, 일주일동안 열심히 살아볼까?",
        "라고 생각하는 찰나에, 친한 동기인 곽두팔이 말을 걸어왔다.",
        "곽두팔: \"야 이녀석아. 오늘 애들이랑 춘자 가기로 했는데 너도 올래?\"",
        "\"어 그래.\" 나는 고민할 겨를도 없이 예스를 외쳤다.",
        "춘자에 도착하고 몇시간이 지났을까, 갑자기 옆자리 어색한 친구가 나한테 말을 걸어온다.",
        "\"너 과대 후보로 나간다며? 그럼 에프엠정도는 해야하는거 아냐?\"",
        "어? 그런가? 부끄럽지만 그래도 이정돈 해야겠지..?",
        "나는 난데없이 일어나서 FM을 시작했다.",
        "\"안녕, 안녕, 안녕하십니까!!! 민족고대! 첨단정보! 백야컴과! 저는 컴과에서...\""
        };
    private int choicePoint = 16;
    private Dictionary<int, string[]> choiceSentences = new Dictionary<int, string[]>
    {
        { 0, new string[] { "동기들: \"흠.. 그래 뭐 민서정도면 귀여운 편이지\"\n나를 향한 표심이 20만큼 올랐다! 오예",
            "쌈뽕한 에프엠을 때린 나는 술자리를 마무리하고 자취방에와서 쿨쿨 잤다." } },
        { 1, new string[] { "동기들: \"아직 투표도 안했는데 왜저러지? 개싫어\"\n나를 향한 표심이 10만큼 떨어졌다.",
            "많은 이들에게 미움을 받은 나는 먼저 자취방에 돌아와 베개를 눈물로 적시며 잠에 들었다." } },
        { 2, new string[] { "동기들: \"우리과 비주얼은 김봉팔인데? 쟤 너무 나대는거 아니야?\"\n라이벌의 표심이 30만큼 올랐다.",
            "차가운 현실에 직면하게 된 나는 먼저 방에 돌아와 눈물을 훔치며 잠을 청했다." }}
    };
    private Dictionary<int, (bool isPlayer, int points)> choiceEffects = new Dictionary<int, (bool, int)>
    {
        { 0, (true, 20) },
        { 1, (true, -10) },
        { 2, (false, 30) }
    };

    public void StartDialogue()
    {

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
