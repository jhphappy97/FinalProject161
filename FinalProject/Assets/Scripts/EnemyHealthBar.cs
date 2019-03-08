using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private SpriteRenderer healthbar;
    public Transform enemy;
    private Vector3 original_size;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = this.GetComponent<SpriteRenderer>();
        original_size = healthbar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1.5f, healthbar.transform.position.z);
    }

    public void decHealth(int health)
    {
        float per = (float)health / 30f;
        Vector3 temp = original_size;
        temp.x *= per;
        healthbar.transform.localScale = temp;
    }
}
