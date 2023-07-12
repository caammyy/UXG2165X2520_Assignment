using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] string[] characterName;
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Character => characterName;
    public string[] Dialogue => dialogue;
}
