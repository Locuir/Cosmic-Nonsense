using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class PlayerData : MonoBehaviour
{

    public List<OwnedCard> OwnedCards = new List<OwnedCard>();
    public int Stars;

}
