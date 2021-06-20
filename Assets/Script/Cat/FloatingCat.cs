using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCat : MonoBehaviour
{
    float hriMoveSpeed = 4f;
    float amplitude = 5f;
    float fraquency = 1.5f;

    float timeStamp = 0f;

    Vector2 oriPos;
    Vector2 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        oriPos = transform.position;
        hriMoveSpeed = Random.Range(0.4f, 1f) * hriMoveSpeed;
        if (Random.Range(-1f, 1f) > 0)
        {
            hriMoveSpeed = -hriMoveSpeed;
        }
        amplitude = Random.Range(0.4f, 1f) * amplitude;
        fraquency = Random.Range(0.4f, 1f) * fraquency;
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp += Time.deltaTime;
        ChangePos();
    }

    void ChangePos()
    {
        nextPos = transform.position;
        nextPos.x += Time.deltaTime * hriMoveSpeed;
        nextPos.y = oriPos.y + Mathf.Sin(timeStamp * fraquency) * amplitude;

        transform.position = nextPos;
    }
}