using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [Header("World Size")]
    public float levelLength;
    public float levelWidth;
    public List<GameObject> tileTypes; //level tile prefabs
    public List<GameObject> activeTiles; //the tiles in the level
    public GameObject startTile;

    [Header("Navigation")]
    private NavMeshSurface surface;

    private void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
        BuildWorld();
    }

    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildWorld()
    {
        for (int width = 0; width < levelWidth; width++)
        {
            for (int length = 0; length < levelLength; length++)
            {
                if (activeTiles.Count < 1)
                {
                    activeTiles.Add(startTile);
                    continue;
                }
                var randomTileIndex = Random.Range(0, tileTypes.Count); //max exlusive
                var randomTilePosition = new Vector3(width * 16, 0f, length * 16);
                var randomTileRotation = Random.Range(0, 4) * 90f; //4 types of 90 degree rotations
                var randomTile = Instantiate(tileTypes[randomTileIndex], randomTilePosition, Quaternion.Euler(0f, randomTileRotation, 0f));
                randomTile.transform.parent = this.transform; //this.transform = LevelTiles object transform
                activeTiles.Add(randomTile);
            }
        }
    }
}
