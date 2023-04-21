using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagement : MonoBehaviour
{
    //Components
    [Header("Components")]

    public Transform Camera;
    //Components
    
    //Chunks
    [Header("Chunks")]

    public List<GameObject> ChunksPrefabsList = new List<GameObject>();

    [Space]

    public List<GameObject> CurrentChunksList = new List<GameObject>();
    //Chunks

    //Coordinates
    private Vector2 Height;

    private Vector2 LastCoordinates;
    //Coordinates

    //Coins
    [Header("Coins")]

    public GameObject CoinPrefab;

    [Space]

    public Vector2 XCoinSpawnCoordinates;
    public Vector2 YCoinSpawnCoordinates;

    [Space]
    
    public float CoinRateSpawn;
    private float CoinSpawnChance;
    //Coins

    void Start()
    {
        RectTransform RectHeight = ChunksPrefabsList[0].transform.GetChild(0).GetComponent<RectTransform>();

        Height = new Vector2(0, RectHeight.rect.height * RectHeight.localScale.y);
    }

    void FixedUpdate()
    {
        if (Camera.position.y > LastCoordinates.y - Height.y)
        {
            CreateChunk();
        }
        else
        {
            if (Camera.position.y > CurrentChunksList[0].transform.position.y + Height.y)
            {
                DeleteChunk();
            }
        }
    }

    public void CreateChunk()
    {
        LastCoordinates += Height;

        GameObject NewChunk = Instantiate(ChunksPrefabsList[Random.Range(0, ChunksPrefabsList.Count)]);

        NewChunk.transform.position = LastCoordinates;

        CurrentChunksList.Add(NewChunk);

        //Other
        SpawnCoin(NewChunk);
        //Other
    }

    public void DeleteChunk()
    {
        Destroy(CurrentChunksList[0].gameObject);

        CurrentChunksList.RemoveAt(0);
    }

    public void SpawnCoin(GameObject Chunk)
    {
        if (CoinSpawnChance >= Random.Range(0.0f, 1.0f))
        {
            GameObject NewCoin = Instantiate(CoinPrefab, Chunk.transform);

            NewCoin.transform.localPosition = new Vector2(Random.Range(XCoinSpawnCoordinates.x, XCoinSpawnCoordinates.y), Random.Range(YCoinSpawnCoordinates.x, YCoinSpawnCoordinates.y));

            //Spawn Chance
            CoinSpawnChance = 0;
            //Spawn Chance
        }
        else
        {
            //Spawn Chance
            CoinSpawnChance += CoinRateSpawn;
            //Spawn Chance
        }
    }
}
