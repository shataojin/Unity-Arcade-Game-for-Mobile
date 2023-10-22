using UnityEngine;
using UnityEngine.UI;

public class ImageMover : MonoBehaviour
{
    public Transform imageToMove;
    public Button ButtonNmae;
    public float moveSpeed ;
    private bool isMoving = false;
    public float stopPositionX;
    private void Start()
    {
        // Add a listener to the Play button to start moving the image
        ButtonNmae.onClick.AddListener(StartMoving);
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the image in the desired direction
            imageToMove.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (imageToMove.position.x <= stopPositionX)
            {
                isMoving = false;
            }
        }
    }

    private void StartMoving()
    {
        // This method is called when the Play button is clicked
        isMoving = true;
    }
}
