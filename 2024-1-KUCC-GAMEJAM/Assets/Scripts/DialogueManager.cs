using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // ��ȭ�� ǥ���� TextMeshProUGUI
    public GameObject[] choiceButtons; // ������ ��ư �迭
    private List<string> sentences; // ��ȭ ������ ������ ����Ʈ
    private int index; // ���� ǥ���� ������ �ε���
    public float typingSpeed = 0.02f; // ���ڰ� ǥ�õǴ� �ӵ�

    private void Start()
    {
        sentences = new List<string>();
        index = 0;
        SetupChoices(false); // ó������ �������� ����ϴ�.
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
                SetupChoices(true); // ������ ǥ��
            }
            else
            {
                StartCoroutine(TypeSentence(sentences[index]));
            }
        }
        else
        {
            dialogueText.text = "";
            // ��ȭ ����
        }
    }

    bool ShouldShowChoices(int sentenceIndex)
    {
        if (sentenceIndex == 4) return true;
        return false; // �⺻������ false ��ȯ
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
            StartDialogue(new string[] { "���� �� ���?", "������� 0�� ������" });
        }
        else if (choiceIndex == 1)
        {
            StartDialogue(new string[] { "�ȳ� ���� 1�� ��������", "�׽�Ʈ ��" });
        }
        // ���ÿ� ���� ���� ��ȭ ���� �����մϴ�.
        // ��: if (choiceIndex == 0) { StartDialogue(new string[] { "Yes, you chose A.", "More text..." }); }
        // �̿� �ٸ� �������� ���� ó��
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
