using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections.Generic;

public class StartDrawManager : MonoBehaviour
{
    [SerializeField] private Button startDrawButton;
    [SerializeField] private GameObject videoPanel;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject characterDisplayPanel;
    [SerializeField] private Image selectedCharacterImage;
    [SerializeField] private IntroductionManager introductionManager;
    [SerializeField] private List<Character> characters;
    [SerializeField] private Animator characterAnimator;

    private Character drawnCharacter;

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

        if (videoPanel != null) videoPanel.SetActive(false);
        if (characterDisplayPanel != null) characterDisplayPanel.SetActive(false);
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
        SelectRandomCharacter();
        DisplaySelectedCharacter();
    }

    private void SelectRandomCharacter()
    {
        if (characters == null || characters.Count == 0)
        {
            Debug.LogError("Character list is empty or not assigned.");
            return;
        }

        int randomIndex = Random.Range(0, characters.Count);
        drawnCharacter = characters[randomIndex];
        Debug.Log($"Selected Character: {drawnCharacter.characterName}");
    }

    private void DisplaySelectedCharacter()
    {
        if (characterDisplayPanel != null && selectedCharacterImage != null && drawnCharacter != null)
        {
            selectedCharacterImage.sprite = drawnCharacter.cardImage;
            characterDisplayPanel.SetActive(true);

            Button characterButton = selectedCharacterImage.GetComponent<Button>();
            if (characterButton != null)
            {
                characterButton.onClick.RemoveAllListeners();
                characterButton.onClick.AddListener(OnCharacterClicked);
            }
            else
            {
                Debug.LogError("SelectedCharacterImage does not have a Button component.");
            }

            if (characterAnimator != null)
            {
                characterAnimator.SetTrigger("Appear");
            }
            else
            {
                Debug.LogWarning("Character Animator is not assigned.");
            }
        }
        else
        {
            Debug.LogError("Character Display Panel, SelectedCharacterImage, or drawnCharacter is not assigned.");
        }
    }

    private void OnCharacterClicked()
    {
        if (introductionManager != null && drawnCharacter != null)
        {
            introductionManager.ShowIntroduction(drawnCharacter.introductionImage);
        }
        else
        {
            Debug.LogError("IntroductionManager or drawnCharacter is not assigned.");
        }
    }

    public void ResetUI()
    {
        if (characterDisplayPanel != null)
        {
            characterDisplayPanel.SetActive(false);
            selectedCharacterImage.sprite = null;
        }
    }
}
