using UnityEngine;
using TMPro; // If using TextMeshPro

public class CollisionTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign in Inspector
    private float timer = 30f;
    private bool timerActive = false;

    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Get Back to Starting Position " + Mathf.Ceil(timer).ToString()+"s"; // Display time rounded up

            if (timer <= 0)
            {
                timer = 0;
                timerActive = false;
                timerText.text = "You're Dead ";
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Debug message
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        timer = 30f; // Reset timer
        timerActive = true;
        timerText.gameObject.SetActive(true); // Show the timer UI
    }
}
