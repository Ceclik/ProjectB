using UnityEngine;

namespace Services.MovingScripts
{
    public interface IPlayerMover
    {
        public void MakeTug(Transform characterTransform, KeyCode key, float tugSpeed, float tugDelay);
        public void MakeTug(Transform characterTransform, KeyCode key1, KeyCode key2, float tugSpeed, float tugDelay);
        public void Move(KeyCode key, float movingSpeed, Transform characterTransform);
        public void Move(KeyCode key1, KeyCode key2 , float movingSpeed, Transform characterTransform);
    
    }
}