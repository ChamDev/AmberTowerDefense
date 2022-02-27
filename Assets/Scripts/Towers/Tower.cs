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
        [SerializeField]
        private int upgradeCost;
        [SerializeField]
        private int sellCost;
        [SerializeField]
        private int upgradeIncrementCost;
        [SerializeField]
        private int sellIncrementCost;
        
        private float _timeSinceLastShot;
        private int _upgradeLevel;

        public int InitialCost => initialCost;

        private void Update()
        {
            if (_timeSinceLastShot >= reloadTime)
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
                    Vector2 direction = (target.position - this.transform.position).normalized;		
				
                    //Instantiating projectile
                    GameObject projectile = Instantiate(projectilePrefab);
                    projectile.GetComponent<Projectiles.Projectile>().Direction = direction;
                    
                    _timeSinceLastShot = 0;
                }
            }
		
            _timeSinceLastShot += Time.deltaTime;
        }
    }
}

