using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLevel : MonoBehaviour
{
    public Transform player;
    public Camera camera;
    float leftLimit;
    float rightLimit;
    Vector3 offset;
    private float horizontalMin;
    private float horizontalMax;

    void Start()
    {
        offset = camera.transform.position - player.transform.position;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camera.transform.position = player.transform.position + offset;
    }
}
