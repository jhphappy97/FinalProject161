using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cont()
    { 
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
