using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float maxDistanceToTarget = 4;

    [SerializeField] private float smoothFactor = 0.5f;

    private PlayerCombat _combat;
    private Vector3 velocity;

    public static PlayerCamera Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    private void Start()
    {
        _combat = PlayerCombat.Instance;
    }

    private void LateUpdate()
    {
        if (_combat.MainTarget == null || GetGreatestDistance() > maxDistanceToTarget)
        {
            Vector3 targetPos = player.position + offset;
            Vector3 smoothPos = Vector3.Lerp(cam.transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
            cam.transform.position = smoothPos;
        }
        else
        {
            Vector3 centerPoint = GetCenterPoint();
            Vector3 newPosition = centerPoint + offset;
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, newPosition, ref velocity, smoothFactor);
        }
    }

    private Vector3 GetCenterPoint()
    {
        if (_combat.MainTarget == null)
            return player.position;

        var bounds = new Bounds(player.position, Vector3.zero);
        bounds.Encapsulate(_combat.MainTarget.position);

        return bounds.center;
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds(player.position, Vector3.zero);
        bounds.Encapsulate(_combat.MainTarget.position);

        return bounds.size.x;
    }
}
