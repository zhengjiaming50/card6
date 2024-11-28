using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private GameObject introductionPanel; // Reference to IntroductionPanel
    [SerializeField] private Image introductionImage; // Reference to IntroductionImage
    [SerializeField] private Button closeButton; // Reference to CloseButton

    void Start()
    {
        // Assign the Close Button Listener
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseIntroduction);
        }
        else
        {
            Debug.LogError("Close Button is not assigned in the inspector.");
        }

        // Ensure the Introduction Panel is Hidden at Start
        if (introductionPanel != null)
        {
            introductionPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Introduction Panel is not assigned in the inspector.");
        }

        // Adjust the Introduction Image size to 80% of the screen
        AdjustIntroductionImageSize();
    }

    public void ShowIntroduction(Sprite introSprite)
    {
        if (introductionImage != null && introductionPanel != null)
        {
            introductionImage.sprite = introSprite;
            introductionPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Introduction Image or Introduction Panel is not assigned.");
        }
    }

    private void CloseIntroduction()
    {
        if (introductionPanel != null)
        {
            introductionPanel.SetActive(false);
            
            // Optionally, notify StartDrawManager to reset UI
            StartDrawManager resetManager = FindObjectOfType<StartDrawManager>();
            if (resetManager != null)
            {
                resetManager.ResetUI();
            }
        }
        else
        {
            Debug.LogError("Introduction Panel is not assigned.");
        }
    }

    // Adjust the introduction image to occupy 80% of the screen
    private void AdjustIntroductionImageSize()
    {
        if (introductionImage != null)
        {
            RectTransform panelRect = introductionPanel.GetComponent<RectTransform>();
            RectTransform imageRect = introductionImage.GetComponent<RectTransform>();

            if (panelRect != null && imageRect != null)
            {
                float width = panelRect.rect.width * 0.8f;
                float height = panelRect.rect.height * 0.8f;

                imageRect.sizeDelta = new Vector2(width, height);
                imageRect.anchoredPosition = Vector2.zero; // Center the image
            }
            else
            {
                Debug.LogError("RectTransform components are missing.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
