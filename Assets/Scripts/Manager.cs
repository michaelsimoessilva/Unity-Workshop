using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] CirclesPrefabs;
    public GameObject ColorChanger;
    private int index = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateObstacles()
    {
        Instantiate(CirclesPrefabs[0], new Vector3(0f, 2f + 7*index , 0f), Quaternion.identity);

        Instantiate(ColorChanger, new Vector3(0f, 5.5f + 7 * index, 0f), Quaternion.identity);
        index++;


    }
    
}
