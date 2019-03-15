using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gather_UI : MonoBehaviour
{
    public GameObject trailRender;
    public GameObject particleprefab;
    public GameObject barposition1;
    //public Canvas barposition2;
    public Vector3 targetpos;
    public Player player;
    private GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = Camera.main.ScreenToWorldPoint(barposition1.transform.position);
        if (player.shootstatus)
        {
            a = Instantiate(trailRender, player.transform.position, Quaternion.identity);
            Invoke("particle", 0.5f);
        }
        if(a != null)
            a.transform.position = Vector3.MoveTowards(a.transform.position, targetpos, 50f * Time.deltaTime);
    }
    void particle(){
        Instantiate(particleprefab,targetpos,Quaternion.identity);
    }
}
