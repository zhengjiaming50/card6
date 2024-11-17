using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartDrawManager : MonoBehaviour
{
    public Button startDrawButton;
    public GameObject animationPanel; // Panel to display the animation
    public VideoPlayer videoPlayer; // VideoPlayer component for the animation

    void Start()
    {
        startDrawButton.onClick.AddListener(OnStartDrawClicked);
        animationPanel.SetActive(false);
    }

    void OnStartDrawClicked()
    {
        // Disable the start button to prevent multiple clicks
        startDrawButton.interactable = false;

        // Activate the animation panel
        animationPanel.SetActive(true);

        // Play the animation
        videoPlayer.Play();
    }
}
