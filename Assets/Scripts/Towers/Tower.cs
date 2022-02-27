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
				
                //Instantiating projectile
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = transform.position;
                projectile.GetComponent<Projectiles.Projectile>().Direction = direction;
                    
                _timeSinceLastShot = 0;
            }
        }
    }
}

