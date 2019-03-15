using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowPileScript : MonoBehaviour
{
    private float timer;
    private int wait_time;
    private bool reset;
    private int amount_of_snow;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        reset = false;
        wait_time = 0;
        amount_of_snow = 4;
        timer = 0;
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        if (reset)
        {    
            //Debug.Log("still alive");
            timer += Time.deltaTime;
            if (timer > wait_time)
            {
                //Debug.Log("im back");
                boxCollider2D.enabled = true;
                sprite.enabled = true;
                reset = false;
                wait_time = 0;
                amount_of_snow = 4;
                timer = 0;
            }
        }
    }

    public void decSnow()
    {
        if (--amount_of_snow <= 0)
            amount_of_snow = 0;
    }

    public void makeGone()
    {
        if (amount_of_snow == 0)
        {
            boxCollider2D.enabled = false;
            sprite.enabled = false;
            reset = true;
            wait_time = UnityEngine.Random.Range(10, 20);
            //Debug.Log("At the end");
            //if (reset)
            //{
            //    Debug.Log("ITs True");
            //}

        }
    }

    public void setSnowAmount(int snowFromThisPile)
    {
        amount_of_snow = snowFromThisPile;
        if (amount_of_snow < 0)
            amount_of_snow = 0;
    }

    public int getSnowAmount()
    {
        return amount_of_snow;
    }

}
