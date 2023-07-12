using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public Image avatarImage;
    public TMP_Text avatarName;
    public TMP_Text avatarText;
    public RectTransform backgroundBox;

    avatarMessage[] currentMessages;
    avatar[] currentAvatars;
    int activeMessage = 0;

    public void OpenDialogue(avatarMessage[] avatarMessages, avatar[] avatars)
    {
        currentMessages = avatarMessages;
        currentAvatars = avatars;
        activeMessage = 0;

        Debug.Log("loaded");
    }

}



