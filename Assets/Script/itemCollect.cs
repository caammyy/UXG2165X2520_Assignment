using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollect : MonoBehaviour
{
    private int item = 0;

    [SerializeField] private Text gemText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collect1"))
        {
            Destroy(collision.gameObject);
            item++;
            Debug.Log("Item Collected: " + item);
            gemText.text = "Item Collected: " + item;
        }
    }
}
