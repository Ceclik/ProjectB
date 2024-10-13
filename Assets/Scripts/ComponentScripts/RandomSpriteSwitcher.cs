using System.Collections.Generic;
using UnityEngine;

namespace ComponentScripts
{
    public class RandomSpriteSwitcher : MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;
        
        private void Start() => GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
    }
}