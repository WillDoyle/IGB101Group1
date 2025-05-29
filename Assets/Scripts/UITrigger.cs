using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject uiPanel;
    
    [Header("Settings")]
    public bool showOnEnter = true;
    
    private void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(!showOnEnter);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (showOnEnter && uiPanel != null)
            {
                uiPanel.SetActive(true);
            }
            else if (!showOnEnter && uiPanel != null)
            {
                uiPanel.SetActive(false);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (showOnEnter && uiPanel != null)
            {
                uiPanel.SetActive(false);
            }
            else if (!showOnEnter && uiPanel != null)
            {
                uiPanel.SetActive(true);
            }
        }
    }
}