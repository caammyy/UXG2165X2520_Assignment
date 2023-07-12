using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typeWriterSpeed = 50f;

    //for running coroutine
    public Coroutine Run(string textToType, TMP_Text dialogueMessage)
    {
        return StartCoroutine(TypeText(textToType, dialogueMessage));
    }

    //for typing text out
    private IEnumerator TypeText(string textToType, TMP_Text dialogueMessage)
    {
        dialogueMessage.text = string.Empty;
        //yield return new WaitForSeconds(1);
        
        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            dialogueMessage.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        dialogueMessage.text = textToType;

    }
}
