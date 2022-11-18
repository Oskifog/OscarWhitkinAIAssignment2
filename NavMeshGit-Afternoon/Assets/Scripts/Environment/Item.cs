using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public int scoreAmount;
  public bool isKey;
  public PlayerScript player;
  public Collider collider;

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.name == "Player")
    {
      player.AddScore(scoreAmount);
      if (isKey)
      {
        player.AddKey();
      }
      Destroy(gameObject);
    }
  }
}