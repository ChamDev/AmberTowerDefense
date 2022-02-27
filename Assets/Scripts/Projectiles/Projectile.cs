using UnityEngine;

namespace Projectiles
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField]
		private float damage;
		[SerializeField]
		private float speed = 1f;
		[SerializeField]
		private Vector3 direction;
		[SerializeField]
		private float lifeDuration = 10f;
    
		private Rigidbody2D rb2D;

		public Vector3 Direction
		{
			get => direction;
			set => direction = value;
		}

		void Start () {
		
			rb2D = GetComponent<Rigidbody2D>();
        
			direction = direction.normalized;
		
			//Rotating the projectile
			float angleRad = Mathf.Atan2(-direction.y, direction.x);
			float angleDeg = angleRad * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);
        
			Destroy(gameObject, lifeDuration);
		}
    
		void FixedUpdate () {
		
			// s = v * t
			//transform.position += ( speed * direction ) * Time.deltaTime;
			rb2D.MovePosition(transform.position + ( speed * direction ) * Time.fixedDeltaTime);
		} 
	}
}
