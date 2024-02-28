using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
   public Action<int> OnCoinsCountChanged;
   public Action OnAllCoinsCollected;

   private readonly List<Coin> _coins = new();

   //public int TotalCoins => _coins.Count;

   private void Start()
   {
      _coins.AddRange(FindObjectsOfType<Coin>());

      foreach (Coin coin in _coins)
      {
         coin.OnCoinCollected += CollectCoin;
      }
      
      OnCoinsCountChanged.Invoke(_coins.Count);
   }
   
   private void CollectCoin(Coin coin)
   {
      coin.OnCoinCollected -= CollectCoin;

      _coins.Remove(coin);
        
      OnCoinsCountChanged?.Invoke(_coins.Count);

      if (_coins.Count == 0)
      {
         OnAllCoinsCollected?.Invoke();
      }
   }

   public Vector3 GetTarget(Vector3 pointer)
   {
      float minDistance = Mathf.Infinity;

      Vector3 target = Vector3.zero;

      for (int i = 0; i < _coins.Count; i++)
      {
         float distance = Vector3.Distance(pointer, _coins[i].transform.position);

         if (distance < minDistance)
         {
            minDistance = distance;

            target = _coins[i].transform.position;
         }
      }

      return target;
   }
}
