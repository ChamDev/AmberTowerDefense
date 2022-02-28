using System;
using Managers;
using UnityEngine;

namespace Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        private float rangeRadius;
        [SerializeField]
        private float reloadTime;
        [SerializeField]
        private GameObject projectilePrefab;
        [SerializeField]
        private int initialCost;
        private float _timeSinceLastShot;
        public int InitialCost => initialCost;
        
        private const int _poolingAmount = 5;
        private ObjectPool _objectPool;
      
        
        private void Awake()
        {
            _objectPool = gameObject.AddComponent<ObjectPool>();
            _objectPool.PoolingObjects(projectilePrefab, _poolingAmount);
        }


        private void Update()
        {
            if (_timeSinceLastShot >= reloadTime)
            {
                Shoot();
            }
		
            _timeSinceLastShot += Time.deltaTime;
        }

        void Shoot()
        {
            //Find hit colliders inside the range
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
			
            if (hitColliders.Length != 0)
            {
                float minDistance = int.MaxValue;
                int index = -1;
				
                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].tag == "Enemy")
                    {
                        float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                        if (distance < minDistance)
                        {
                            index = i;
                            minDistance = distance;
                        }
                    }
                }
				
                if (index < 0)
                {
                    return;
                }
                    
                //If we are here is because we have a target
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;		
				
                //Using the pool of projectiles
                GameObject projectile =  _objectPool.GetPooledObject();
                if (projectile != null)
                {
                    projectile.transform.position = transform.position;
                    projectile.transform.rotation = transform.rotation;
                    projectile.GetComponent<Projectiles.Projectile>().Direction = direction;
                    projectile.SetActive(true);
                }
                
                _timeSinceLastShot = 0;
            }
        }
    }
}

