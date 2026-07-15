
using UnityEngine;

public class NPCStarted : MonoBehaviour
{
   private DialogueRunner _dialogueRunner;
    [SerializeField] DialogesSO scriptableObject;

    private void Start()
    {
        _dialogueRunner = GetComponent<DialogueRunner>();
        _dialogueRunner.StartDialogue(scriptableObject);


    }

   
}
