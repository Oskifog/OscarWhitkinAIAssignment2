using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  public Vector3 waypointLocation;
  [SerializeField] public Collider collider;
  public void Start(){
    waypointLocation = transform.position;
  }
}
