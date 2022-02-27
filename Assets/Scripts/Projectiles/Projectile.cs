﻿using UnityEngine;

namespace Projectiles
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField]
		private float damage = 10;
		[SerializeField]
		private float speed = 1f;
		[SerializeField]
		private float lifeDuration = 10f;
    
		private Rigidbody2D _rigidbody2D;
		private Vector3 _direction;
		public Vector3 Direction
		{
			set => _direction = value;
		}

		public float Damage => damage;

		void Start () {
		
			_rigidbody2D = GetComponent<Rigidbody2D>();
        
			_direction = _direction.normalized;
		
			//Rotating the projectile
			float angleRad = Mathf.Atan2(-_direction.y, _direction.x);
			float angleDeg = angleRad * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);
        
			Destroy(gameObject, lifeDuration);
		}
    
		void FixedUpdate () {
		
			// s = v * t
			_rigidbody2D.MovePosition(transform.position + ( speed * _direction ) * Time.fixedDeltaTime);
		} 
	}
}
