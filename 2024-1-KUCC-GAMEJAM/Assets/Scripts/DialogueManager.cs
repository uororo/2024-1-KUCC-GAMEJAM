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
