using UnityEngine;
using UnityEngine.UI;

public class PortfolioSwitcher : MonoBehaviour
{
    public Image portfolioImage;       // UI Image to display the portfolio
    public Sprite[] portfolioSprites; // Array of portfolio images
    public Button leftButton;         // Button to navigate left
    public Button rightButton;        // Button to navigate right

    private int currentIndex = 0;     // Index of the currently displayed image

    private void Start()
    {
        // Initialize the portfolio with the first image
        if (portfolioSprites.Length > 0)
        {
            portfolioImage.sprite = portfolioSprites[currentIndex];
        }

        // Add listeners to the buttons
        leftButton.onClick.AddListener(ShowPreviousImage);
        rightButton.onClick.AddListener(ShowNextImage);

        // Update button states initially
        UpdateButtonStates();
    }

    private void ShowPreviousImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            portfolioImage.sprite = portfolioSprites[currentIndex];
        }
        UpdateButtonStates();
    }

    private void ShowNextImage()
    {
        if (currentIndex < portfolioSprites.Length - 1)
        {
            currentIndex++;
            portfolioImage.sprite = portfolioSprites[currentIndex];
        }
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        // Disable left button if at the first image
        leftButton.interactable = currentIndex > 0;

        // Disable right button if at the last image
        rightButton.interactable = currentIndex < portfolioSprites.Length - 1;
    }
}
