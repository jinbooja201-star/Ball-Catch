using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public float moveSpeed; // toc do di chuyen cua line
    float xDirection; // huong di chuyen cua line
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // khi bam nut sang trai tra -1, khi bam sang phai tra ve 1
        xDirection = Input.GetAxisRaw("Horizontal");
        // di chuyen gia do
        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        if ((transform.position.x <= -8f && xDirection < 0) || (transform.position.x >= 8f && xDirection > 0))
            return;
        transform.position = transform.position + new Vector3(moveStep, 0, 0);
    }
}