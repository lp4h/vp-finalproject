using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [HideInInspector]private Vector3 currentPosition = new Vector3(0,0,0);

    //serializeField so object can be set in inspector but object still private
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    private List<GameObject> currentTerrains = new List<GameObject>(); 
    private void Start()    //spawn a certain amount of blocks on startup
    {
        for(int i = 0; i < maxTerrainCount; i++)
        {
            spawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount += currentTerrains.Count;
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spawnTerrain(false);
        }
    }*/

    public void spawnTerrain(bool isStart, Vector3 playerPos )
    {
        if(currentPosition.x - playerPos.x < minDistanceFromPlayer || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count); //decide which terrain to spawn
            int terrainInSuccession = Random.Range(1, terrainDatas.Count);  //how many will be spawned in a row

            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                terrain.transform.SetParent(terrainHolder);
                currentTerrains.Add(terrain);

                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)    //deletes terrain
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }
        }
    }
}
