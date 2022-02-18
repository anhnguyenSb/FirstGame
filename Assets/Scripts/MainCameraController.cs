using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        transform.position = new Vector3(Player.position.x + 5f, Player.position.y + 1f, transform.position.z);
    }
}
