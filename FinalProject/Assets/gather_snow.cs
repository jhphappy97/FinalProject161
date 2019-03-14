using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gather_snow : MonoBehaviour
{   
    public GameObject UI_hint;
    public GameObject[] Total_snow_can_store;
    public int current_snow;
    private bool can_gather;
    public bool hitsnowile = false;

    private snowPileScript snowPile;
    // Start is called before the first frame update
    void Start()
    {
        current_snow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(can_gather)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                incSnow();
                
                Debug.Log("current snow: " + current_snow);
                if(current_snow > 0)
                    Total_snow_can_store[current_snow - 1].SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Snowpile"))
        {
            snowPile = collider.GetComponent<snowPileScript>();
            UI_hint.SetActive(true);
            can_gather=true;
            hitsnowile = true;
        }
    }
     private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Snowpile"))
        {   
            UI_hint.SetActive(false);
            can_gather = false;
            hitsnowile = false;
            collider.GetComponent<snowPileScript>().makeGone();
            
        }
    }

    public void decSnow()
    {
        if (--current_snow <= 0)
            current_snow = 0;
    }

    public void incSnow()
    {
        if (++current_snow >= 4)
            current_snow = 4;
        else
        {
            snowPile.decSnow();
        }
    }
}
