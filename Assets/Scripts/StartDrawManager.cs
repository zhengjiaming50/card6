using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartDrawManager : MonoBehaviour
{
    [SerializeField] private Button startDrawButton;
    [SerializeField] private GameObject videoPanel;
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        if (startDrawButton != null)
        {
            startDrawButton.onClick.AddListener(OnStartDrawClicked);
        }
        else
        {
            Debug.LogError("Start Draw Button is not assigned in the inspector.");
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogError("Video Player is not assigned in the inspector.");
        }
    }

    private void OnStartDrawClicked()
    {
        Debug.Log("Start Draw button clicked!");
        PlayDrawAnimation();
    }

    private void PlayDrawAnimation()
    {
        if (videoPanel != null && videoPlayer != null)
        {
            videoPanel.SetActive(true);
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Video Panel or Video Player is not assigned.");
        }
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPanel.SetActive(false);
        Debug.Log("Draw animation completed!");
    }
}
