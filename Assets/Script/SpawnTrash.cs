using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    public GameObject[] paperTrashPrefabs1;
    public GameObject[] paperTrashPrefabs2;
    public GameObject[] paperTrash;

    public GameObject spawnLocation;
    void Start()
    {
        
    }
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            paperTrash = new GameObject[paperTrashPrefabs.Length];

            for (int i = 0; i < paperTrashPrefabs.Length; i++)
            {
                paperTrash[i] = Instantiate(paperTrashPrefabs[i], spawnLocation.transform) as GameObject;
            }
        }
        */
    }
    public void spawnTrash1()
    {
        paperTrash = new GameObject[paperTrashPrefabs1.Length];

        for (int i = 0; i < paperTrashPrefabs1.Length; i++)
        {
            paperTrash[i] = Instantiate(paperTrashPrefabs1[i], spawnLocation.transform) as GameObject;
        }
    }
    public void spawnTrash2()
    {
        paperTrash = new GameObject[paperTrashPrefabs2.Length];

        for (int i = 0; i < paperTrashPrefabs2.Length; i++)
        {
            paperTrash[i] = Instantiate(paperTrashPrefabs2[i], spawnLocation.transform) as GameObject;
        }
    }
}
