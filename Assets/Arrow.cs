using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Arrow : MonoBehaviour
    {
    public GameObject arrow;
        [SerializeField] private float damage = 2f;
        void Start()
        {
            Destroy(gameObject, 3f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
