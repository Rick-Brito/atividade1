using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    public Vector3 startPos;
    public Vector3 distance;

    void Start()
    {
        startPos = new Vector3(0f, 11.2f, -11.2f);
    }

    // Update is called once per frame
    void Update()
    {
        distance= startPos + playerPos.transform.position;
        this.transform.position = distance;
    }
}
