using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public Transform spawnPoint;

    void Start()
    {
        SpawnCharacter();
    }

    void SpawnCharacter()
    {
        Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
