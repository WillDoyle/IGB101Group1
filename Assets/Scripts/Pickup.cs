using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audio;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            audio.Play();
            gameManager.currentPickups += 1;
            
            // Remove this audio source from the GameManager's array
            gameManager.RemoveAudioSource(audio);
            
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }
}