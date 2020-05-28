using UnityEngine;

namespace TurretSystem
{
    public class TempTurret : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer renderer;
        [SerializeField] private Color canPlaceColor;
        [SerializeField] private Color canNotPlaceColor;

        public bool CanPlace
        {
            set { renderer.color = value ? canPlaceColor : canNotPlaceColor; }
        }
    }
}