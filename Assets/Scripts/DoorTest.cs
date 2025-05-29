using UnityEngine;

public class DoorTest : MonoBehaviour
{
    private Animation animationComponent; // Declare the variable
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        animationComponent = GetComponent<Animation>();
    }
    
    void Update() {
        if (Input.GetKeyDown("f"))
        {
            animationComponent.Play();
        }
    }
}