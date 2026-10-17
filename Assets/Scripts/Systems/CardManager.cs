using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class CardManager : MonoBehaviour
{

    [SerializeField] private List<CharacterData> CardDatabase = new List<CharacterData>();

    public PlayerData PlayerData { get; private set; }


    public event Action<CharacterData> OnCardAdded;
    public event Action<CharacterData,int> OnDuplicateConverted;
    public event Action<int> OnStarsChanged;

    private string SavePath => Path.Combine(Application.persistentDataPath, "PlayerData");



    public bool AddCard(CharacterData Card)
    {
        if (Card == null) 
            return false;


        if (PlayerData == null)
        {
            PlayerData = new PlayerData();
        }
        if (OwnesCard(Card.Id))
        {
            int stars = GetCardValueInStars(Card);

            PlayerData.Stars += stars;

            OnDuplicateConverted?.Invoke(Card, stars);
            OnStarsChanged?.Invoke(stars);

            SaveData();
            return false;
        }


        PlayerData.OwnedCards.Add(new OwnedCard(Card.Id));
        OnCardAdded?.Invoke(Card);
        return true;

        
    }


    public CharacterData GetCardData(int CardId)
    {

        return CardDatabase.Find(card => card != null && card.Id == CardId);
    
    }
    public bool OwnesCard(int CardId)
    {

        if (PlayerData == null)
        {
            return false;
        }
        
        foreach(OwnedCard OwnedCard in PlayerData.OwnedCards)
        {
            if (OwnedCard._CardID == CardId)
            {
                return true;
            }
        }

        return false;
    }
    public int GetCardValueInStars(CharacterData Card)
    {

        switch (Card.Rarity) 
        
        { 
          case CharacterRarity.Common:
                return 1;

          case CharacterRarity.UltraCommon:
                return 3;

          case CharacterRarity.Rare:
                return 10;

          case CharacterRarity.Epic:
                return 30;

          case CharacterRarity.Legendary:
                return 50;

          case CharacterRarity.Ultimate:
                return 100;

          default:
                return 0;

        }

    }


    public void SaveData()
    {

        string json = JsonUtility.ToJson(PlayerData,true);
        File.WriteAllText(SavePath, json); ;
    }
    public void LoadData() 
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            PlayerData = JsonUtility.FromJson<PlayerData>(json);
        }

        if (PlayerData == null)
        {
            PlayerData = new PlayerData();

        }
        if (PlayerData.OwnedCards == null)
        {
            PlayerData.OwnedCards = new List<OwnedCard>();
        }


    }
}
