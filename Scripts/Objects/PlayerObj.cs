using UnityEngine;
using CVRunner.Interface;

namespace CVRunner
{
    public class PlayerObj : BaseObjectScene, ICollision
    {

        private void OnTriggerEnter(Collider other)
        {
            CollisionEffect();
        }

        public void CollisionEffect()
        {
            //TODO: change this code
            Debug.Log("BANG!");
        }
    }
}
