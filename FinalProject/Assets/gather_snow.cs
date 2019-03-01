using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gather_snow : MonoBehaviour
{   
    public GameObject UI_hint;
    public GameObject[] Total_snow_can_store;
    public int current_snow;
    private bool can_gather;
    // Start is called before the first frame update
    void Start()
    {
        current_snow=-1;
    }

    // Update is called once per frame
    void Update()
    {
        if(can_gather){
        if (Input.GetKeyDown(KeyCode.F)){
                current_snow+=1;
                Debug.Log(current_snow);
                current_snow = Mathf.Min(current_snow,4);
                Total_snow_can_store[current_snow].SetActive(true);
                }
            }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {   
            
            UI_hint.SetActive(true);
            can_gather=true;
        }
    }
     private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {   
            UI_hint.SetActive(false);
            }
    }
}
