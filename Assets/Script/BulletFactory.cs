using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("BackgroundStarsBehaviour,Student Name: Sha taojin , StudentID:101334639," +
       "Date last Modified:2023/10/22,Program description:BulletFactory " +
       "Revision History :nothing changed.")]

    // Bullet Prefab
    private GameObject bulletPrefab;

    // Sprite Textures
    private Sprite playerBulletSprite;
    private Sprite enemyBulletSprite;

    // Bullet Parent
    private Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        enemyBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject CreateBullet(BulletType type)
    {
        GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
        bullet.GetComponent<BulletBehaviour>().bulletType = type;

        switch (type)
        {
            //i:1,change player Bullet towards the Right-side and enemy Bullet towards the Left-side
            case BulletType.PLAYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.RIGHT);
                bullet.name = "PlayerBullet";
                break;
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.LEFT);
                bullet.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                bullet.name = "EnemyBullet";
                break;
        }

        bullet.SetActive(false);
        return bullet;
    }

}
