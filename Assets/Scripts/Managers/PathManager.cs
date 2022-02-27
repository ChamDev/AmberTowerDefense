using UnityEngine;

namespace Managers
{
    public class PathManager : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPointsTransform;


        public Transform[] WayPointsTransform => wayPointsTransform;
    }
}
