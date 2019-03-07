using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLevel : MonoBehaviour
{
    public GameObject floor;
    public SpriteRenderer background;
    public Transform player;
    public Camera camera;
    float leftLimit;
    float rightLimit;
    float offsetx;
    float offsety;
    private float horizontalMin;
    private float horizontalMax;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 pos = player.GetComponent<Transform>().position;
        pos.y -= 5;
        pos.x -= 250;
        leftLimit = -250f;
        for (int i = 0; i < 500; ++i, ++pos.x)
        {
            Instantiate(floor, pos, Quaternion.identity);
        }
        rightLimit = pos.x;
        pos = player.GetComponent<Transform>().position;
        pos.y = -2.0f;
        pos.x -= 250;
        for (int i = 0; i < 200; ++i, pos.x+= 12f)
        {
            Instantiate(background, pos, Quaternion.identity);
        }
    }
    void Start()
    {
        offsetx = camera.transform.position.x - player.transform.position.x;
        offsety = camera.transform.position.y;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (camera.transform.position.x + horizontalMin > leftLimit && camera.transform.position.x + horizontalMax < rightLimit)
            camera.transform.position = new Vector3(player.transform.position.x + offsetx, offsety, -10);

    }
}
