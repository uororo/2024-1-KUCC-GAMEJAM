using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject[] choiceButtons; // 선택지 버튼 배열
    private int index; // 현재 표시할 문장의 인덱스
    public float typingSpeed = 0.02f; // 글자가 표시되는 속도

    public TextMeshProUGUI choiceOneText;
    public TextMeshProUGUI choiceTwoText;
    public TextMeshProUGUI choiceThreeText;

    private IDayDialogue currentDayDialogue; // 현재 일자에 대한 대화 스크립트 인터페이스
    private string[] sentences; // 현재 대화 내용
    private int choicePoint; // 선택지를 표시할 대화의 인덱스
    private Dictionary<int, string[]> choiceSentences; // 선택지에 따른 대화문
    private int currentDay = 1; // 현재 일자

    public FadeManager fadeManager;

    void Start()
    {
        LoadDayDialogue(currentDay); // 게임 시작 시 첫째 날 대화 로드
    }

    void LoadDayDialogue(int day)
    {
        string className = "Day" + day + "Dialogue";
        Component comp = gameObject.AddComponent(System.Type.GetType(className)) as Component;
        currentDayDialogue = comp as IDayDialogue;

        UpdateChoiceButtons(day);

        sentences = currentDayDialogue.GetSentences();
        choicePoint = currentDayDialogue.GetChoicePoint();
        choiceSentences = currentDayDialogue.GetChoices();
        

        index = 0;

        StartCoroutine(TypeSentence(sentences[index])); // 첫째 날에는 바로 대화 시작
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueText.text == sentences[index])
        {
            if (index == choicePoint)
            {
                SetupChoiceButtons(true); // 선택지 표시
            }
            else
            {
                NextSentence();
            }
        }
    }

    void UpdateChoiceButtons(int day)
    {
        switch (day)
        {
            case 1:
                if (choiceOneText != null)
                    choiceOneText.text = "귀요미를 맡고있는 민서입니다~~~";
                if (choiceTwoText != null)
                    choiceTwoText.text = "예비! 과대!를 맡고있는 민서입니다~~~";
                if (choiceThreeText != null)
                    choiceThreeText.text = "비주얼을 담당하고있는 민서입니다~~~";
                break;
            case 2:
                if (choiceOneText != null)
                    choiceOneText.text = "그래? 그럼 막차까지만 같이 놀아볼까?";
                if (choiceTwoText != null)
                    choiceTwoText.text = "아 싫어싫어 귀찮다 나 먼저 갈래 수고해";
                if (choiceThreeText != null)
                    choiceThreeText.text = "";
                break;
            case 3:
                if (choiceOneText != null)
                    choiceOneText.text = "역사적으로 돈은 많은 상황에 도움이 되어왔다. 과 친구들에게 랜덤 선물하기로 스벅 아아를 뿌려볼까?";
                if (choiceTwoText != null)
                    choiceTwoText.text = "갑자기 내 몸속의 음침한 기운이 올라오기 시작한다. 라이벌인 봉팔이에 대한 안좋은 얘기를 꺼내본다.";
                if (choiceThreeText != null)
                    choiceThreeText.text = "과제에 치이는 대학생에겐 이것만한게 없지! 먼저 완벽하게 끝낸 과제의 답을 교우들에게 공유해준다.";
                break;
            case 4:
                if (choiceOneText != null)
                    choiceOneText.text = "뭐라고 하시는거야? 모르겠으니 대충 가만히 있어야겠다.";
                if (choiceTwoText != null)
                    choiceTwoText.text = "내가 나서지 않으면 안돼! 조원이 쩔쩔매는 꼴을 보고만 있을 수는 없어! 손을 들고 대신 대답하자!";
                if (choiceThreeText != null)
                    choiceThreeText.text = "";
                break;
            case 5:
                if (choiceOneText != null)
                    choiceOneText.text = "대충 머리긁고 있던 손으로 닦아준다.";
                if (choiceTwoText != null)
                    choiceTwoText.text = "으하하. 이럴때를 대비하고 가방에 손수건을 들고 다녔지. 슥하고 손수건을 꺼내 닦아준다.";
                if (choiceThreeText != null)
                    choiceThreeText.text = "";
                break;
            case 6:
                if (choiceOneText != null)
                    choiceOneText.text = "이때가 기회다! 과대가 되고 싶다는 포부를 선배에게 열정적으로 어필한다.";
                if (choiceTwoText != null)
                    choiceTwoText.text = "할 말이 없는데 뭘 어째. 그냥 가만히 있어야겠다.";
                if (choiceThreeText != null)
                    choiceThreeText.text = "선배에게 인생조언을 시작한다.";
                break;
        }   
    }

    void SetupChoiceButtons(bool isActive)
    {
        int numberOfChoices = currentDayDialogue.GetNumberOfChoices();
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(i < numberOfChoices && isActive);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        SetupChoiceButtons(false);
        if (choiceSentences.ContainsKey(choiceIndex))
        {
            string[] chosenDialogue = choiceSentences[choiceIndex];
            sentences = new string[] { chosenDialogue[0], chosenDialogue[1] }; // 실제 대화문 업데이트
            index = 0;
            StartCoroutine(TypeSentence(sentences[index]));
            currentDayDialogue.ApplyChoiceEffect(choiceIndex);  // 점수 조정
        }
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialogueText.text = ""; // 모든 대화를 표시했다면 비움
            index = 0;
            EndOfDay(++currentDay);
        }
    }

    public void EndOfDay(int nextDay)
    {
        StartCoroutine(EndDayRoutine(nextDay));
    }

    IEnumerator EndDayRoutine(int nextDay)
    {
        yield return StartCoroutine(fadeManager.FadeIn());
        fadeManager.dayText.text = "Day " + nextDay;
        fadeManager.dayText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        fadeManager.dayText.gameObject.SetActive(false);
        yield return StartCoroutine(fadeManager.FadeOut());

        currentDay = nextDay;
        LoadDayDialogue(currentDay);
    }
}
