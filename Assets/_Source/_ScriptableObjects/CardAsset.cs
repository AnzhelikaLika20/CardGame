using UnityEngine;

namespace _ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "SO/CardAsset", order = 1)]
    public class CardAsset : ScriptableObject
    {
        public string cardName;
        public Color cardColor;
        public Sprite cardImage;
    }
}