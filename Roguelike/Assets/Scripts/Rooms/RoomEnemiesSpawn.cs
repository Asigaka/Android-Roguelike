using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class RoomEnemiesSpawn : MonoBehaviour
{
    [Header("Enemies")]
    public int MinEnemiesCount;
    public int MaxEnemiesCount;
    public List<GameObject> EnemiesPrefabs = new List<GameObject>();

    private PolygonCollider2D _polygonCollider;

    private void Start()
    {
        SpawnInZone();
    }

    public void SpawnInZone()
    {
        _polygonCollider = GetComponent<PolygonCollider2D>();

        int enemiesCount = Random.Range(MinEnemiesCount, MaxEnemiesCount);

        for (int i = 0; i < enemiesCount;)
        {
            GameObject enemy = Instantiate(EnemiesPrefabs[Random.Range(0, EnemiesPrefabs.Count)]);
            Vector3 rndPoint3D = RandomPointInBounds(_polygonCollider.bounds, 1f);
            Vector2 rndPoint2D = new Vector2(rndPoint3D.x, rndPoint3D.y);
            Vector2 rndPointInside = _polygonCollider.ClosestPoint(new Vector2(rndPoint2D.x, rndPoint2D.y));
            if (rndPointInside.x == rndPoint2D.x && rndPointInside.y == rndPoint2D.y)
            {
                //rndCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                enemy.transform.position = rndPoint2D;
                i++;
            }
        }
    }

    private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
}
