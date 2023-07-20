using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Gameplay.Units
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        GameObject prefabExplosion;
        private void OnTriggerExit2D(Collider2D other)
        {
            // Instantiate<GameObject>(prefabExplosion,
            //    transform.position, Quaternion.identity);
            if (other.gameObject.CompareTag("defenders"))
            {
                Unit unit = other.gameObject.GetComponent<Unit>();
                unit.TakeDamage(5);
                Destroy(gameObject);
            }  
        }

        /// <summary>
        /// Destroy when leave game
        /// </summary>
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
