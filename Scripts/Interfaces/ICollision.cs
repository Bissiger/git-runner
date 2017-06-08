using UnityEngine;



namespace CVRunner.Interface
{   
    //If player car collision with other obj they call this void (if have)
    public interface ICollision
    {
        void CollisionEffect();
    }
}
