using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("Targets")]
    [SerializeField] private List<Transform> visibleTargets = new List<Transform>();
    [SerializeField] private List<Transform> enemyTargets = new List<Transform>();
    [SerializeField] private LayerMask targetLayer;

    /*[Header("Weapon")]
    [SerializeField] private Transform currentWeapon;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    */
    public Transform _mainTarget;
    private bool _canShoot = false;
    private bool _isReloaded = false;
    private float _localRateOfFireTimer = 0;

    public List<Transform> EnemyTargets { get => enemyTargets; set => enemyTargets = value; }
    public Transform MainTarget { get => _mainTarget; set => _mainTarget = value; }
    public List<Transform> VisibleTargets { get => visibleTargets; set => visibleTargets = value; }

    public static PlayerCombat Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    private void Update()
    {
        CheckTarget();
        //RotateWeaponToTarget();

        //if (_canShoot)
           // Shoot();

        //if (!_isReloaded)
          //  Reload();
    }

    private void CheckTarget()
    {
        if (visibleTargets.Count > 0)
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
                    return Vector3.Distance(t1.position, player.position).CompareTo(Vector3.Distance(t2.position, player.position));
                });

                //if (player.position.x - _mainTarget.position.x > 5 && player.position.y - _mainTarget.position.y > 5)
                    _mainTarget = visibleTargets[0];
                //Debug.Log(player.position.x - _mainTarget.position.x);
                //Debug.Log(player.position.y - _mainTarget.position.y);

                Debug.DrawLine(player.position, _mainTarget.position);
            }
            else
                _mainTarget = null;
        }
        else
            _mainTarget = null;
    }

   /* private void RotateWeaponToTarget()
    {
        if (_mainTarget != null)
        {
            Vector2 direction = _mainTarget.position - currentWeapon.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            currentWeapon.transform.rotation = Quaternion.Slerp(currentWeapon.rotation, rotation, 20 * Time.deltaTime);
        }
        else
            currentWeapon.transform.rotation = Quaternion.Slerp(currentWeapon.rotation, Quaternion.Euler(0, 0, 0), 20 * Time.deltaTime);
    }

    public void WeaponFlip()
    {
        Vector3 scaler = currentWeapon.localScale;
        scaler.x *= -1;
        currentWeapon.localScale = scaler;
    }

    private void Shoot()
    {
        if (_isReloaded)
        {
            Vector2 directionWithoutSpread = _mainTarget.position - firePoint.transform.position;
            Vector2 directionWithSpread = directionWithoutSpread + new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f));

            GameObject currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            //currentBullet.transform.right = directionWithSpread.normalized;
            currentBullet.GetComponent<Rigidbody2D>().AddForce(directionWithSpread.normalized * 10, ForceMode2D.Impulse);

            _isReloaded = false;
        }
    }

    public void ShootDown() => _canShoot = true;

    public void ShootUp() => _canShoot = false;

    private void Reload()
    {
        if (_localRateOfFireTimer <= 0 && !_isReloaded)
        {
            _isReloaded = true;
            _localRateOfFireTimer = 0.2f;
        }
        else
        {
            _isReloaded = false;
            _localRateOfFireTimer -= Time.deltaTime;
        }
    }*/
}
