using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // 대화를 표시할 TextMeshProUGUI
    public GameObject[] choiceButtons; // 선택지 버튼 배열
    private List<string> sentences; // 대화 내용을 저장할 리스트
    private int index; // 현재 표시할 문장의 인덱스
    public float typingSpeed = 0.02f; // 글자가 표시되는 속도

    private void Start()
    {
        sentences = new List<string>();
        index = 0;
        SetupChoices(false); // 처음에는 선택지를 숨깁니다.
    }

    public void StartDialogue(string[] dialogueLines)
    {
        sentences.Clear();
        sentences.AddRange(dialogueLines);
        index = 0;
        StartCoroutine(TypeSentence(sentences[index]));
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
        if (Input.GetMouseButtonDown(0) && dialogueText.text == sentences[index] && !AnyChoiceActive())
        {
            NextSentence();
        }
    }

    void NextSentence()
    {
        if (index < sentences.Count - 1)
        {
            index++;
            if (ShouldShowChoices(index))
            {
                SetupChoices(true); // 선택지 표시
            }
            else
            {
                StartCoroutine(TypeSentence(sentences[index]));
            }
        }
        else
        {
            dialogueText.text = "";
            // 대화 종료
        }
    }

    bool ShouldShowChoices(int sentenceIndex)
    {
        if (sentenceIndex == 4) return true;
        return false; // 기본적으로 false 반환
    }

    void SetupChoices(bool show)
    {
        foreach (GameObject button in choiceButtons)
        {
            button.SetActive(show);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        SetupChoices(false);
        
        if (choiceIndex == 0)
        {
            StartDialogue(new string[] { "감히 날 골라?", "여기까지 0번 선택지" });
        }
        else if (choiceIndex == 1)
        {
            StartDialogue(new string[] { "안녕 나는 1번 선택지야", "테스트 끝" });
        }
        // 선택에 따른 다음 대화 줄을 설정합니다.
        // 예: if (choiceIndex == 0) { StartDialogue(new string[] { "Yes, you chose A.", "More text..." }); }
        // 이외 다른 선택지에 대한 처리
    }

    bool AnyChoiceActive()
    {
        foreach (GameObject button in choiceButtons)
        {
            if (button.activeSelf) return true;
        }
        return false;
    }
}
