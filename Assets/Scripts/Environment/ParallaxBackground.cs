using UnityEngine;
using System.Collections.Generic;
using Game.Data;

namespace Game.Environment
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private ParallaxDataSo _data;

        [SerializeField] private List<Transform> _backgrounds = new();
                
        private float _backgroundWidth;

        private void Awake()
        {
            SpriteRenderer spriteRenderer =
                _backgrounds[0].GetComponent<SpriteRenderer>();

            _backgroundWidth = spriteRenderer.bounds.size.x;

            for (int i = 1; i < _backgrounds.Count; i++)
            {
                Vector3 position = _backgrounds[0].position;
                position.x += _backgroundWidth * i;

                _backgrounds[i].position = position;
            }
        }

        private void Update()
        {
            MoveBackgrounds();
            RepositionBackgrounds();
        }

        private void MoveBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                background.position += Vector3.left * (_data.MovementSpeed * Time.deltaTime);
            }
        }

        private void RepositionBackgrounds()
        {
            foreach (Transform background in _backgrounds)
            {
                if (background.position.x <= _data.MinXPos)
                {
                    Vector3 position = background.position;

                    position.x += _backgroundWidth * _backgrounds.Count;

                    background.position = position;
                }
            }
        }
    }
}