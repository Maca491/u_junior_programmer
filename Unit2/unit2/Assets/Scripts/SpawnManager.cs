using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public int animalIndex;

    private int spawnRangeX = 20;

    private int spawnPosZ = 20;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            animalIndex = Random.Range(0, animalPrefabs.Length);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
