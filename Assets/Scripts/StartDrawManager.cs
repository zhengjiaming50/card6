using UnityEngine;
using UnityEngine.UI;

public class StartDrawManager : MonoBehaviour
{
    [SerializeField] private Button startDrawButton;

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
    }

    private void OnStartDrawClicked()
    {
        Debug.Log("Start Draw button clicked!");
        // TODO: Implement draw logic here
    }
}
