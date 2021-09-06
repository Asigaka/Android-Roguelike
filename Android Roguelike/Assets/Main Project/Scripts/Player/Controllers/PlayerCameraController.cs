using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float smoothFactor = 0.5f;

    private PlayerCombatController _combatController;
    private Vector3 velocity;

    private void Start()
    {
        _combatController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatController>();
    }

    private void LateUpdate()
    {
        if (_combatController.MainTarget == null)
        {
            Vector3 targetPos = player.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPos;
        }
        else
        {
            Vector3 centerPoint = GetCenterPoint();
            Vector3 newPosition = centerPoint + offset;
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothFactor);
        }
    }

    private Vector3 GetCenterPoint()
    {
        if (_combatController.MainTarget == null)
            return player.position;

        var bounds = new Bounds(player.position, Vector3.zero);
        bounds.Encapsulate(_combatController.MainTarget.position);

        return bounds.center;
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(player.position, Vector3.zero);
        bounds.Encapsulate(_combatController.MainTarget.position);

        return bounds.size.x;
    }
}
