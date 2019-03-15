using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackUI_control : MonoBehaviour
{
    public float rotationspeed=5f;
    public float raisespeed;
    public Player playerScript;
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject aim;
    public Color c1;
    public Color c2;
    public Color c3;
    public SpriteRenderer r1;
    public SpriteRenderer r2;
    public SpriteRenderer r3;
    float inc;
    float inc2;
    float inc3;
    float deltaRotation;
    float initial;
    Color initialcolor;
    
    // Start is called before the first frame update
    void Start()
    {
       initial = aim.transform.localRotation.z;
       initialcolor = r1.color;
    }

    // Update is called once per frame
    void Update()
    {  
//        Debug.Log(playerScript.angle_var);
        if(playerScript.angle_var == 1){
            bar1.transform.localScale = new Vector3(1.183288f, 0f,1.183288f);
            bar2.transform.localScale = new Vector3(1.183288f, 0f,1.183288f);
            bar3.transform.localScale = new Vector3(1.183288f, 0f,1.183288f);
            aim.transform.localRotation = Quaternion.Euler(0f,0f,initial  );
            inc = 0;inc2 = 0;inc3 = 0;deltaRotation=0;
            r1.color=r2.color=r3.color = initialcolor;
              
            
//            aim.SetActive(false);
//            bar1.SetActive(false);
//            bar2.SetActive(false);
//            bar3.SetActive(false);
        }
        
        if(playerScript.angle_var>1){
            aim.SetActive(true);
            bar1.SetActive(true);
            bar2.SetActive(true);
            bar3.SetActive(true);
            if(aim.transform.localRotation.z<0.43f){
                deltaRotation += aim.transform.localRotation.z+rotationspeed*Time.deltaTime;
                aim.transform.localRotation = Quaternion.Euler(0f,0f,deltaRotation  );

            }
        
        
            if(bar1.transform.localScale.y <1){
                inc =inc+ raisespeed*Time.deltaTime;
                bar1.transform.localScale = new Vector3(1.183288f, inc,1.183288f);
                r2.color=r3.color=r1.color = Color.Lerp(c1,c2,0.5f*Time.time);
                
            }
            if(bar1.transform.localScale.y>=1 && bar2.transform.localScale.y <1){
                inc2 =inc2+ raisespeed*Time.deltaTime;
                bar2.transform.localScale = new Vector3(1.183288f, inc2,1.183288f);
                r2.color=r3.color=r1.color = Color.Lerp(c2,c3,0.1f*Time.time);
               
            }

            if(bar1.transform.localScale.y>=1 && bar2.transform.localScale.y>=1&& bar3.transform.localScale.y <1){
                inc3 =inc3+ raisespeed*Time.deltaTime;
                bar3.transform.localScale = new Vector3(1.183288f, inc3,1.183288f);

            }
        }
    }
}
