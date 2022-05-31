using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : SpeedSynchronization
{
    private Transform backTransform;
    private float backSize;
    [SerializeField] private float backPos;
    public float timeStart;



    void Start()
    {
        backTransform = GetComponent<Transform>();
        backSize = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        timeStart = Time.deltaTime;
        backPos -= speed * Time.deltaTime;
        backPos = Mathf.Repeat(backPos, backSize);
        backTransform.position = new Vector3(0, backPos, 1);
    }
}
