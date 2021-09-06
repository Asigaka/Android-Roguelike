using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Цели")]
    [SerializeField] private List<Transform> visibleTargets = new List<Transform>();
    [SerializeField] private List<Transform> enemyTargets = new List<Transform>();
    [SerializeField] private LayerMask targetLayer;

    [Header("Компоненты")]
    //[SerializeField] private Weapon currentWeapon;

    private Transform _mainTarget;

    public List<Transform> EnemyTargets { get => enemyTargets; set => enemyTargets = value; }
    public Transform MainTarget { get => _mainTarget; set => _mainTarget = value; }

    private void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (enemyTargets.Count > 0)
        {
            foreach (Transform target in enemyTargets)
            {
                RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, targetLayer);

                if (hit.collider == null)
                {
                    if (!visibleTargets.Contains(target))
                        visibleTargets.Add(target);
                }
                else
                    visibleTargets.Remove(target);
            }

            if (visibleTargets.Count > 0)
            {
                visibleTargets.Sort(delegate (Transform t1, Transform t2)
                {
                    return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
                });

                _mainTarget = visibleTargets[0];
            }
            else
                _mainTarget = null;
        }
        else
            _mainTarget = null;
    }
}
