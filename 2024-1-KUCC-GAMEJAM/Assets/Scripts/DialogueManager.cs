using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI 버튼을 사용하기 위해 추가

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    public GameObject[] choiceButtons; // 선택지 버튼 배열
    private int index;
    public float typingSpeed = 0.02f;

    private int choicePoint = 3; // 선택지를 표시할 대화의 인덱스, 예를 들어 4번째 대화 후 선택지 표시
    private Dictionary<int, string[]> choiceSentences; // 선택지에 따른 대화문

    private void Start()
    {
        index = 0;
        InitializeChoices();
        StartDialogue();
        SetupChoiceButtons(false); // 시작 시 모든 선택지 버튼을 비활성화
    }

    void InitializeChoices()
    {
        choiceSentences = new Dictionary<int, string[]>();
        choiceSentences.Add(0, new string[] { "1번째 선택지 테스트", "1번 선택지 다음 대화문 테스트" });
        choiceSentences.Add(1, new string[] { "2번째 선택지 테스트", "2번 선택지 다음 대화문 테스트" });
        choiceSentences.Add(2, new string[] { "3번째 선택지 테스트", "3번 선택지 다음 대화문 테스트" });
    }

    void StartDialogue()
    {
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
        foreach (GameObject button in choiceButtons)
        {
            button.SetActive(isActive);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        SetupChoiceButtons(false);
        if (choiceSentences.ContainsKey(choiceIndex))
        {
            sentences = choiceSentences[choiceIndex]; // 선택에 따라 새로운 대화문 배열을 로드
            index = 0; // 새로운 대화문의 시작
            StartDialogue();
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
        }
    }
}
