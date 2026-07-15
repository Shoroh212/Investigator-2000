using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string DialogueText; // текст диалога

    public string FirstButtonText;           // текст 
    public string SecondButtonText;

    public int FirstNextNode = -1;
    public int SecondNextNode = -1;
}