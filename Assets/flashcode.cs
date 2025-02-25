using UnityEngine;

public class lightScript : MonoBehaviour
{
    public GameObject flashlight_ground, inticon, flashlight_player;
    private bool isPlayerNearby = false;

    void Start()
    {
        if (inticon == null)
        {
            Debug.LogError("?? inticon is NOT assigned! Assign a UI element in the Inspector.");
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            flashlight_ground.SetActive(false);
            inticon.SetActive(false);
            flashlight_player.SetActive(true);
            Debug.Log("?? Flashlight picked up!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { // ? Change from "MainCamera" to "Player"
            inticon.SetActive(true);
            isPlayerNearby = true;
            Debug.Log("?? Player is near the flashlight.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inticon.SetActive(false);
            isPlayerNearby = false;
            Debug.Log("????? Player left the flashlight area.");
        }
    }
}