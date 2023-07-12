using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public avatarMessage[] avatarMessages;
    public avatar[] avatars;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(avatarMessages, avatars);
    }
}

[System.Serializable]
public class avatarMessage
{
    public string avatarName;
    public string Message;
}

[System.Serializable]
public class avatar
{
    public string name;
    public Sprite sprite;
}
