using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Terrain Data")]

public class TerrainData : ScriptableObject
{
    public List<GameObject> possibleTerrain;  //store a terrain object
    public int maxInSuccession; //the terrain object can spawn this many times in a row
}
