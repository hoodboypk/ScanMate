using UnityEngine;

public class SwipeablePortfolio : MonoBehaviour
{
    public RectTransform portfolioContainer; // The container holding all images
    public float swipeThreshold = 50f;       // Minimum swipe distance to register a swipe
    public float lerpSpeed = 10f;            // Speed of smooth transition

    private Vector2 touchStartPos;          // Start position of the touch
    private Vector2 touchEndPos;            // End position of the touch
    private int currentImageIndex = 0;      // Current image index
    private int totalImages;                // Total number of images
    private float imageWidth;               // Width of each image

    private void Start()
    {
        // Calculate the total number of images and their width
        totalImages = portfolioContainer.childCount;
        imageWidth = portfolioContainer.rect.width / totalImages;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    touchEndPos = touch.position;
                    HandleSwipe();
                    break;
            }
        }

        // Smoothly move the container to the target position
        Vector2 targetPos = new Vector2(-currentImageIndex * imageWidth, portfolioContainer.anchoredPosition.y);
        portfolioContainer.anchoredPosition = Vector2.Lerp(portfolioContainer.anchoredPosition, targetPos, Time.deltaTime * lerpSpeed);
    }

    private void HandleSwipe()
    {
        float swipeDistance = touchEndPos.x - touchStartPos.x;

        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance > 0 && currentImageIndex > 0)
            {
                // Swipe left for previous image
                currentImageIndex--;
            }
            else if (swipeDistance < 0 && currentImageIndex < totalImages - 1)
            {
                // Swipe right for next image
                currentImageIndex++;
            }
        }
    }
}
