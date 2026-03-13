using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    GameControler m_gc;

    private void Start()
    {
        // Tim object GameControler tren scene
        m_gc = FindObjectOfType<GameControler>();
    }

    // Su dung OnCollisionEnter2D cho va cham vat ly (neu Line khong la Trigger)
    private void OnCollisionEnter2D(Collision2D col)
    {
        // Va cham voi thanh Player (Tag: Line)
        if (col.gameObject.CompareTag("line"))
        {
            // Tang diem
            m_gc.IncrementScore();

            // Huy bong
            Destroy(gameObject);

            Debug.Log("Bong cham Player (Collision)");
        }
    }

    // Su dung OnTriggerEnter2D cho va cham Trigger (neu Line hoac DeathZone la Trigger)
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Va cham voi thanh Player (Tag: Line)
        if (col.CompareTag("line"))
        {
            // Tang diem
            m_gc.IncrementScore();

            // Huy bong
            Destroy(gameObject);

            Debug.Log("Bong cham Player (Trigger)");
        }

    
    }
}