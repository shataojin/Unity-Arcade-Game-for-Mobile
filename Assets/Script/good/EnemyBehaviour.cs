using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    
    public Boundary screenBounds;
    public float horizontalSpeed;
    public float verticalSpeed;
    public Color randomColor;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public float rotationAngle;


    private BulletManager bulletManager;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletManager = FindObjectOfType<BulletManager>();
        ResetEnemy();
        InvokeRepeating("FireBullets", 0.3f, fireRate);
        transform.Rotate(0, 0, rotationAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    //public void Move()
    //{
    //    var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
    //    transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max,
    //        transform.position.x - verticalSpeed * Time.deltaTime, transform.position.z);
    //}

    public void Move()
    {
        //k:1,change the enemy movement from random left-right to top-bottom
        var verticalLength = screenBounds.max - screenBounds.min;
        transform.position = new Vector3(
            transform.position.x - horizontalSpeed * Time.deltaTime,
            transform.position.y,
            transform.position.z);


    }

    public void CheckBounds()
    {
        if (transform.position.x < screenBounds.left)
        {
            ResetEnemy();
        }
    }

    public void ResetEnemy()
    {
        
        var RandomXPosition = Random.Range(0, screenBounds.right);
        var RandomYPosition = Random.Range(screenBounds.min, screenBounds.max);
        horizontalSpeed = Random.Range(1.0f, 3.0f);
        verticalSpeed = Random.Range(0.0f, 4.0f);
        transform.position = new Vector3(screenBounds.right + RandomXPosition, RandomYPosition, 0.0f);

        List<Color> colorList = new List<Color>() {Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.white};

        randomColor = colorList[Random.Range(0, 6)];
        spriteRenderer.material.SetColor("_Color", randomColor);
        Debug.Log("enemy new location set ");
    }

    void FireBullets()
    {
        var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
    }
}
