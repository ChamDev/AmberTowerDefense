using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class ObjectPool : MonoBehaviour
    {
        private int _amountToPool;
        private List<GameObject> _pooledObjects;

        public void PoolingObjects(GameObject objectToPool, int amountToPool)
        {
            _pooledObjects = new List<GameObject>();
            _amountToPool = amountToPool;
            GameObject tmp;
            
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                _pooledObjects.Add(tmp);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                if (!_pooledObjects[i].activeInHierarchy)
                {
                    return _pooledObjects[i];
                }
            }

            return null;
        }
    }
}
