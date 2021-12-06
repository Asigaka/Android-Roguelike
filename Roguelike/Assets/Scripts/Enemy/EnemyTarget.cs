using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    private PlayerCombat _playerCombat;

    private void Start()
    {
        _playerCombat = PlayerCombat.Instance;
    }

    private void OnBecameVisible()
    {
        PlayerCombat.Instance.VisibleTargets.Add(transform);
    }

    private void OnBecameInvisible()
    {
        PlayerCombat.Instance.VisibleTargets.Remove(transform);
    }
}
