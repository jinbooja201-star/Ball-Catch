using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DeathZone va cham voi: " + other.name);

        if (other.CompareTag("ball"))
        {
            Debug.Log("DeathZone nhan BALL");

            GameControler gameControler = FindObjectOfType<GameControler>();
            if (gameControler != null)
            {
                Debug.Log("GameOver() dang duoc goi");
                gameControler.GameOver();
            }

            Destroy(other.gameObject);
        }
    }

}