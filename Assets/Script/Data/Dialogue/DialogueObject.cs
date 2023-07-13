using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] string[] characterName;
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Character => characterName;
    public string[] Dialogue => dialogue;
    
    //put the dialogue list into ^this dialogue
    //character: foreach dialogue, if current is left, insert left, else insert right
    
    //within the dialogue, if current is left, left image
}
