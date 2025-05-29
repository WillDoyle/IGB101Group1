using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResetTrigger : MonoBehaviour
{
    [Header("Reset Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float resetDelay = 0f;
    
    [Header("Optional Effects")]
    [SerializeField] private AudioClip resetSound;
    [SerializeField] private ParticleSystem resetEffect;
    
    private AudioSource audioSource;
    private bool hasTriggered = false;
    
    private void Start()
    {
        // Get or add AudioSource component if reset sound is assigned
        if (resetSound != null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player and we haven't triggered yet
        if (other.CompareTag(playerTag) && !hasTriggered)
        {
            hasTriggered = true;
            TriggerLevelReset();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // For 2D games - check if the colliding object is the player
        if (other.CompareTag(playerTag) && !hasTriggered)
        {
            hasTriggered = true;
            TriggerLevelReset();
        }
    }
    
    private void TriggerLevelReset()
    {
        // Play sound effect if assigned
        if (resetSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(resetSound);
        }
        
        // Play particle effect if assigned
        if (resetEffect != null)
        {
            resetEffect.Play();
        }
        
        // Reset the level after delay
        if (resetDelay > 0)
        {
            Invoke(nameof(ResetLevel), resetDelay);
        }
        else
        {
            ResetLevel();
        }
    }
    
    private void ResetLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Alternative method to reset to a specific scene
    public void ResetToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    // Method to reset to scene by build index
    public void ResetToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}