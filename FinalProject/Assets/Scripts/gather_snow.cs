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
    private  int snowFromThisPile;
    public AudioSource gather_sound;
    private snowPileScript snowPile;
    // Start is called before the first frame update
    void Start()
    {
        current_snow = 0;
        snowFromThisPile = 0;
        gather_sound = GameObject.Find("gatherSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(can_gather)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                incSnow();
                gather_sound.Play();
                --snowFromThisPile;
                //Debug.Log("current snow: " + current_snow);
                if(current_snow > 0)
                    Total_snow_can_store[current_snow - 1].SetActive(true);
                if (snowFromThisPile < 0)
                    done();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Snowpile"))
        {
            snowPile = collider.GetComponent<snowPileScript>();
            snowFromThisPile = snowPile.getSnowAmount();
            UI_hint.SetActive(true);
            can_gather = true;
            hitsnowile = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Snowpile"))
        {
           // Debug.Log("amount of Snow: " + snowFromThisPile);
            snowPile = collider.GetComponent<snowPileScript>();
            snowPile.setSnowAmount(snowFromThisPile);
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
            snowPile.setSnowAmount(snowFromThisPile);
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
    public void done()
    {
        //Debug.Log("makeGone");
        snowPile.setSnowAmount(snowFromThisPile);
        snowPile.makeGone();
        UI_hint.SetActive(false);
        can_gather = false;
    }
}
