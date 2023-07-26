using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Cammy
public class playerTutorial : MonoBehaviour
{
    private Animator ani;
    bool[] tutorials = { true, false };
    int currentTutorial = 0;
    bool left = false;
    bool right = false;
    bool jump = false;
    [SerializeField] private TMP_Text defaultText;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorials[0])
        {
            tutorial1();
            if (left && right)
            {
                ani.SetBool("tutorial1", false);
                tutorials[0] = false;
            }
        }
        if (tutorials[1])
        {
            tutorial2();
            if (jump)
            {
                ani.SetBool("tutorial2", false);
                tutorials[1] = false;
            }
        }
    }

    private void tutorial1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
    }

    public void InitializeNextTutorial()
    {
        currentTutorial += 1;
        if(currentTutorial == 1)
        {
            ani.SetBool("tutorial1", false);
            ani.SetBool("tutorial2", true);
        }
        tutorials[currentTutorial] = true;
    }

    private void tutorial2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    public IEnumerator defText(string message, float waitTime)
    {
        defaultText.text = message;
        defaultText.enabled = true;
        yield return new WaitForSeconds(waitTime);
        defaultText.enabled = false;
    }
}
