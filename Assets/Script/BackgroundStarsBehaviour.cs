using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStarsBehaviour : MonoBehaviour
{
    [Header("BackgroundStarsBehaviour,Student Name: Sha taojin , StudentID:101334639," +
        "Date last Modified:2023/10/22,Program description:background moving," +
        "Revision History :After correction, the background moves LOOP to the left.")]

    public Boundary boundary;
    [Header("Transforms")]
    public float Lateralspeed;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        
        transform.position -= new Vector3(Lateralspeed * Time.deltaTime, 0.0f);
    }

    public void CheckBounds()
    {
        
        if (transform.position.x < boundary.min)
        {
            ResetStars();
        }
    }

    public void ResetStars()
    {
       
        transform.position = new Vector2(boundary.max, 0.0f);
    }
}
