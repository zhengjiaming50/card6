using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "GachaGame/Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite cardImage;
    public Sprite introductionImage;
}
