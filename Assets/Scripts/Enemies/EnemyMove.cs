using System;
using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private float wayPointThreshold = 0.001f;
        [SerializeField] private float speed = 5;

        private EnemyDamage _enemyDamage;
        private PathManager _pathManager;
        private int _wayPointIndex = 0;
        private Transform _currentWayPoint;
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _pathManager = GameObject.FindObjectOfType<PathManager>();
            _enemyDamage = GetComponent<EnemyDamage>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _currentWayPoint = _pathManager.WayPointsTransform[_wayPointIndex];
        }

        private void FixedUpdate()
        {
            if (_currentWayPoint == null)
            {
                _enemyDamage.MakeDamage();
                gameObject.SetActive(false);
                return;
            }

            var distance = Vector2.Distance(transform.position,
                _currentWayPoint.position);

            if (distance <= wayPointThreshold)
            {
                _wayPointIndex++;
                if (_wayPointIndex >= _pathManager.WayPointsTransform.Length)
                {
                    _currentWayPoint = null;
                }
                else
                {
                    _currentWayPoint = _pathManager.WayPointsTransform[_wayPointIndex];
                }
            }
            else
            {
                MoveTowards(_currentWayPoint.position);
            }
        }

        private void MoveTowards(Vector3 destination){
            
            float step = speed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
        }
        
        private void OnDisable()
        {
            _wayPointIndex = 0;
        }
    }
}
