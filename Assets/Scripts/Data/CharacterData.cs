using UnityEditor.Experimental.Rendering;
using UnityEngine;


public enum CharacterRarity
{

    Common,
    UltraCommon,
    Rare,
    Epic,
    Legendary,
    Ultimate,

}


[CreateAssetMenu(
    fileName = "NewCharacter",
    menuName = "Gacha/Character")]

public class CharacterData : ScriptableObject
{
    public int Id;
    public string Name;
    public CharacterRarity Rarity;
    public Sprite Image;
    public double CoinsPerSecond;





}





