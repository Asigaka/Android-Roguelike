using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private List<Room> rooms;

    private void Start()
    {
        SpawnNewRoom();
    }

    private void SpawnNewRoom()
    {
        Room room = rooms[Random.Range(0, rooms.Count)];
        Instantiate(room.Entity.RoomPrefab);
        Instantiate(room.Entity.LadderPrefab, room.Entity.GetLadderSpawnPoint().position, Quaternion.identity);
        playerObj.transform.position = room.Entity.PlayerSpawnPoint.position;
    }
}
