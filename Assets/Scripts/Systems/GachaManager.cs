using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class RarityRate
{

    public CharacterRarity Rarity;
    [Min(0f)] public float Rate;
}

public class GachaManager : MonoBehaviour
{
    [SerializeField] private List<RarityRate> rarityRates = new List<RarityRate>();
    [SerializeField] private List<CharacterData> Cards = new List<CharacterData>();
    [SerializeField] private CardManager cardManager;



    public CharacterData Pull()
    {
        CharacterRarity? rarity = GetRondomRarity();

        if (!rarity.HasValue)
            return null;

        List<CharacterData> AvailableCards = Cards.FindAll(card => card != null && card.Rarity == rarity.Value);

        if (AvailableCards.Count == 0)
        { 
            Debug.LogWarning($"No cards available for rarity: {rarity.Value}");
            return null;
        }

        CharacterData SelectedCard = AvailableCards[UnityEngine.Random.Range(0, AvailableCards.Count)];
        
        cardManager.AddCard(SelectedCard);

        return SelectedCard;
    }


    private CharacterRarity? GetRondomRarity()
    {
        float TotalChance = 0f;


       foreach (RarityRate Rate in rarityRates)
        {
            if (Rate.Rate > 0f)
                TotalChance += Rate.Rate;

        }

       if (TotalChance <= 0f)
            return null;

        float roll = UnityEngine.Random.Range(0f, TotalChance);


        foreach (RarityRate Rate in rarityRates)
        {
            if (Rate.Rate <= 0f)
                continue;

            roll -= Rate.Rate;

            if (roll < 0f)
                return Rate.Rarity;

        }


        return null;

    }



}