using UnityEngine;

public class SpawnTestscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject objectToSpawn;
    public Vector3 spawnPosition;
    void Start()
    {
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
