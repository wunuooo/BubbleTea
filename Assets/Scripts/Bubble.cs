using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Rigidbody2D rb;
    float vLimit = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float vx = Random.Range(-vLimit, vLimit);
        float vy = Random.Range(-vLimit, vLimit);
        Vector3 v = new Vector3 (vx, vy, 0f);
        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
