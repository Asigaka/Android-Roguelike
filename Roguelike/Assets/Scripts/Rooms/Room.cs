using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Room : MonoBehaviour
{
    public RoomEntity Entity;

    [System.Serializable]
    public class RoomEntity
    {
        public GameObject RoomPrefab;
        public GameObject LadderPrefab;
        public Transform PlayerSpawnPoint;
        public List<Transform> LadderSpawnPoint;
        public RoomEnemiesSpawn SpawnZone;

        public Transform GetLadderSpawnPoint() => LadderSpawnPoint[Random.Range(0, LadderSpawnPoint.Count)];
    }
}
