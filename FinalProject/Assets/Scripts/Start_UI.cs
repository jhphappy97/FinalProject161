﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_UI : MonoBehaviour
{
    public GameObject i1;
    public GameObject i2;
    float time;
    public static bool begin;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(begin==true){
        time+= Time.deltaTime;
        i2.transform.Translate(Vector2.down*700*Time.deltaTime);
            if(time>0.2f){
                SceneManager.LoadScene("Level_2");
            }
        }
     
    }
    public void onClick(){
    begin = true;
     
     // LoadSceneMode.Additive
    }
}
