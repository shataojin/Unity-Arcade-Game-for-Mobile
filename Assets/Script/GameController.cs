using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("BackgroundStarsBehaviour,Student Name: Sha taojin , StudentID:101334639," +
      "Date last Modified:2023/10/22,Program description:GameController " +
      "Revision History :added setting for enemy limits")]

    [Range(1, 4)]
    public int enemyNumber = 3;
    
    private List<GameObject> enemyList;
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        BuildEnemyList();
    }


    public void BuildEnemyList()
    {
        enemyList = new List<GameObject>();

        for (var i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
    }
}
