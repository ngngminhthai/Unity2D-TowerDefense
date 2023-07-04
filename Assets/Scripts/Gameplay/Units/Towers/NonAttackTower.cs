using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Towers
{
    public abstract class NonAttackTower : MonoBehaviour
    {
        public abstract void Create(Vector2 buildPosition, GameObject gameObject);
    }
}
