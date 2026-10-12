using UnityEditor.Experimental.Rendering;
using UnityEngine;


public enum CharacterRarity
{

    Common,
    UltraCommon,
    Rare,
    Epic,
    Legendary,
}


[CreateAssetMenu(
    fileName = "NewCharacter",
    menuName = "Gacha/Character")]

public class CharacterData : ScriptableObject
{
    public string Id;
    public string Name;
    public CharacterRarity Rarity;
    public Sprite Image;
    public double CoinsPerSecond;





}





