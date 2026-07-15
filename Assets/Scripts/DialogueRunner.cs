using System;
using UnityEngine;
using Cysharp;
using Cysharp.Threading.Tasks;

public class DialogueRunner : MonoBehaviour, IDialogueRunner
{
    private DialogesSO _currentDialogue;
    private int _currentNode; // храним инфу о текущем узле диалога
    [SerializeField] private GameObject _NPC;
    [SerializeField] private GameObject _nextNPC;


    [SerializeField] private DialogueUI dialogueUI;

    public event Action<DialogueNode> dialogueChanged;
    public event Action DialogueEnded;////
    public void StartDialogue(DialogesSO dialogue)
    {
        _currentDialogue = dialogue;
        _currentNode = 0; 
         
        ShowCurrentNode();
    }
    private void ShowCurrentNode()
    {
        DialogueNode node = _currentDialogue.Nodes[_currentNode];
        dialogueChanged?.Invoke(node);

    }

    public void FirstChoice()
    {
        DialogueNode node = _currentDialogue.Nodes[_currentNode];

        if (node.FirstNextNode == -1)
        {
            EndDialogue();
            return;
        }

        _currentNode = node.FirstNextNode;

        ShowCurrentNode();
    }
    public void SecondChoice()
    {
        DialogueNode node = _currentDialogue.Nodes[_currentNode];

        if (node.SecondNextNode == -1)
        {
            EndDialogue();
            return;
        }

         else if (node.SecondNextNode == -2)
        {
            TheEnd();
            return;
        }

        _currentNode = node.SecondNextNode;

        ShowCurrentNode();
    }


    private async UniTask TheEnd()
    {
        await UniTask.Delay(2000);
        Application.Quit();

    }

    private async UniTask EndDialogue()
    {
        dialogueUI.HideDialogue();

        _currentDialogue = null;
        await UniTask.Delay(4000);
        _NPC.SetActive(false);
        await UniTask.Delay(2000);
        _nextNPC.SetActive(true);

    }

}
public interface IDialogueRunner
{
    event Action<DialogueNode> dialogueChanged;
}