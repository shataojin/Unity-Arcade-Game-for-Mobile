using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    [Header("Player Properties")]
    public float speed = 2.0f;
    public Boundary boundary;


    private float lateralPosition;
    public float Lateralspeed = 10.0f;

    public bool usingMobileInput = false;


    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;


    private Camera camera;
    public ScoreManager scoreManager;
    private BulletManager bulletManager;

    //player jump
    public float jumpForce = 10.0f;
    //private bool isGrounded = true; // Initially set to true to indicate the player is on the ground.


    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        camera = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                           Application.platform == RuntimePlatform.IPhonePlayer;

        scoreManager = FindObjectOfType<ScoreManager>();

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInput();
        }

        ClampPosition();

        if (Input.GetKeyDown(KeyCode.L))
        {
                scoreManager.AddPoints(10); // Increase the score by 10 when 'L' key is pressed.
        }

    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * Lateralspeed);
        }
    }

    public void ConventionalInput()
    {

        // Check for "A" key to move left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        // Check for "D" key to move right
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        



    }
    public void MoveLeft()
    {
        lateralPosition -= speed * Time.deltaTime;
        ClampPosition();
    }

    public void MoveRight()
    {
        lateralPosition += speed * Time.deltaTime;
        ClampPosition();
    }

    public void ClampPosition()
    {
        float clampedY = Mathf.Clamp(transform.position.y, boundary.min, boundary.max);
        float clampedX = Mathf.Clamp(lateralPosition, boundary.left, boundary.right);

        // Set the player's position while keeping the Y position above the ground.
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void FireBullets()
    {
        if (bulletManager != null)
        {
            var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.PLAYER);
            // Perform other actions related to firing bullets.
        }
        else
        {
            Debug.LogError("BulletManager is not assigned.");
        }
    }
}
