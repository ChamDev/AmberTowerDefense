using UnityEngine;

namespace Towers
{
    public class PlaceTower : MonoBehaviour
    {
        private Managers.GameManager _gameManager;
        private float _mousePosInX;
        private float _mousePosInY;
        private const float LocalPosInZ = 7.0f;

        private Towers.Tower _towerScript;
    
        void Awake () 
        {
            _gameManager = FindObjectOfType<Managers.GameManager>();
            _towerScript = GetComponent<Towers.Tower>();
        }
    
        void Update ()
        {
            GetMousePos();
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_mousePosInX,_mousePosInY,LocalPosInZ));
        
            if (Input.GetMouseButtonDown(0) && _gameManager.isPointerOnAllowedArea())
            {
                //Enabling the tower so it can shoot
                _towerScript.enabled = true;
                //Adding a collider to prevent other torrets can be placed here
                gameObject.AddComponent<BoxCollider2D>();
                //Disabling this script
                this.enabled = false;
            }
        }

        void GetMousePos()
        {
            _mousePosInX = Input.mousePosition.x;
            _mousePosInY = Input.mousePosition.y;
        }
    }
}
