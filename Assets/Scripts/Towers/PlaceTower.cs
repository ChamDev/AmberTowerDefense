using UnityEngine;
using Zenject;
namespace Towers
{
    public class PlaceTower : MonoBehaviour
    {
        private float _mousePosInX;
        private float _mousePosInY;
        private const float LocalPosInZ = 7.0f;
        
        private Tower _towerScript;
        private SpriteRenderer _spriteRenderer;
        
        [Inject] private IGameManager _gameManager;
     
        void Awake () 
        {
            _towerScript = GetComponent<Tower>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    
        void Update ()
        {
            GetMousePos();
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_mousePosInX,_mousePosInY,LocalPosInZ));
            
            if (_gameManager.isPointerOnAllowedArea())
            {
                //To show the player if the placement is allowed
                _spriteRenderer.color = Color.green;
                
                if (Input.GetMouseButtonDown(0))
                {
                    PlacingTower();
                }
            }
            else
            {
                _spriteRenderer.color = Color.red;
            }
        }

        void PlacingTower()
        {
            //Enabling the tower so it can shoot
            _towerScript.enabled = true;
            //Restoring color
            _spriteRenderer.color = Color.white;
            //Adding a collider to prevent other torrets can be placed here
            gameObject.AddComponent<BoxCollider2D>();
            //Disabling this script
            this.enabled = false;
        }
        
        void GetMousePos()
        {
            _mousePosInX = Input.mousePosition.x;
            _mousePosInY = Input.mousePosition.y;
        }
    }
}
