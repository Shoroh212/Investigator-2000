using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.Unicode;

public  class DialogueUI : MonoBehaviour
{

    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private TMP_Text firstButtonText;
    [SerializeField] private TMP_Text secondButtonText;

    [SerializeField] private Image characterImage;

    [SerializeField] private GameObject dialoguePanel;

    private IDialogueRunner runner;

    private void Awake()
    {
        runner = GetComponent<IDialogueRunner>();
    }

    void OnEnable()
    {
        runner.dialogueChanged += ShowDialogue;
       // runner.dialogueEnded += HideDialogue;
    }

    void OnDisable()
    {
        runner.dialogueChanged -= ShowDialogue;
       // runner.dialogueEnded -= HideDialogue;
    }

    public void ShowDialogue(DialogueNode node)
    {
        dialoguePanel.SetActive(true);

        dialogueText.text = node.DialogueText;
        firstButtonText.text = node.FirstButtonText;
        secondButtonText.text = node.SecondButtonText;

       // characterImage.sprite = node.CharacterSprite;
    }
    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
