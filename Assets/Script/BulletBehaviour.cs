using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public struct ScreenBounds
{
    public Boundary boundary;

}


public class BulletBehaviour : MonoBehaviour
{
    [Header("BackgroundStarsBehaviour,Student Name: Sha taojin , StudentID:101334639," +
       "Date last Modified:2023/10/22,Program description:bullet moves" +
       "Revision History :added function that will reset other items.")]
    [Header("Bullet Properties")]
    public BulletDirection bulletDirection;
    public float speed;
    public ScreenBounds bounds;
    public BulletType bulletType;

    private Vector3 velocity;
    private BulletManager bulletManager;
    //added totation for bullet 
    public float rotationAngle = 0.0f;

    public ScoreManager scoreManager;
    public HealthManager healthManager;
    public EnemyBehaviour enemyBehaviour;
    
  // bool LoseHeathTrigger = false, AddScoreTrigger = false;

  void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        //added totation for bullet 
        transform.Rotate(0, 0, rotationAngle);
        scoreManager= FindObjectOfType<ScoreManager>();
        healthManager= FindObjectOfType<HealthManager>();
        enemyBehaviour= FindObjectOfType<EnemyBehaviour>();
    
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void CheckBounds()
    {
        if ((transform.position.x > bounds.boundary.right) ||
            (transform.position.x < bounds.boundary.left) ||
            (transform.position.y > bounds.boundary.max) ||
            (transform.position.y < bounds.boundary.min))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
    }

    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right * speed;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null)
        {
            return; // Return early if 'other' is null to avoid potential errors.
        }

        if (bulletType == BulletType.PLAYER && other.gameObject.CompareTag("Enemy"))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
            scoreManager.AddPoints(10);
            enemyBehaviour.ResetEnemy();
            //LoseHeathTrigger=true;
            Debug.Log("added score resetEnemy triggered");
        }

        if (bulletType == BulletType.ENEMY && other.gameObject.CompareTag("Player"))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
            healthManager.RemoveLastHealthObject();
            //AddScoreTrigger=true;
            Debug.Log("loseHealth triggered");
    
        }
        

    }


}
