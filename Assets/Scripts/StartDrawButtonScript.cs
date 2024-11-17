using UnityEngine;
using UnityEngine.UI;

public class StartDrawManager : MonoBehaviour
{
    // Reference to the Start Draw button
    public Button startDrawButton;

    void Start()
    {
        // Add a listener to the button
        startDrawButton.onClick.AddListener(OnStartDrawButtonClick);
    }

    // Method called when the Start Draw button is clicked
    void OnStartDrawButtonClick()
    {
        Debug.Log("Start Draw button clicked!");
        // TODO: Implement the animation playback here
    }
}
