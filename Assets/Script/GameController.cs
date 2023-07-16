using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DataManager datamanager = GetComponent<DataManager>();
        datamanager.LoadRefData();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
