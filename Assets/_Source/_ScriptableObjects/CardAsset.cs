using UnityEngine;
using UnityEngine.UI;

namespace _ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName="SO/CardAsset")]
    public class CardAsset : ScriptableObject
    {
        public string cardName;
        public Color cardColor;
        public Sprite cardImage;
    }
}
