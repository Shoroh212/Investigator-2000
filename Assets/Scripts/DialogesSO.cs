using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Node")]
public class DialogesSO : ScriptableObject
{
    public Sprite CharacterSprite; // спрайт персонажа 

    public List<DialogueNode> Nodes = new(); // список узлов диалога
}

/// <summary>
/// 
/// </summary>
