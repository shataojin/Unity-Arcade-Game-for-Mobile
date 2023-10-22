using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [Range(1, 4)]
    public int HealthNumber = 3;
    public float PositionX, PositionY,Gap;
    private List<GameObject> HealthList;
    private GameObject HealthPrefab;

    // Start is called before the first frame update
    void Start()
    {
        HealthPrefab = Resources.Load<GameObject>("Prefabs/Health");
        BuildHealthList();
    }

    public void BuildHealthList()
    {
        HealthList = new List<GameObject>();

        for (var i = 0; i < HealthNumber; i++)
        {
            var healthObject = Instantiate(HealthPrefab);
            healthObject.transform.position = new Vector3(PositionX, PositionY, 0); // Set the position
            HealthList.Add(healthObject);


            PositionX = Gap + PositionX; // Adjust the X position
        }
    }

    public void RemoveLastHealthObject()
    {
        if (HealthList.Count > 0)
        {
            GameObject lastHealthObject = HealthList[HealthList.Count - 1];
            HealthList.RemoveAt(HealthList.Count - 1);
            Destroy(lastHealthObject);
        }
    }
   //test the function works or not
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RemoveLastHealthObject();
        }
        if(HealthList.Count<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
