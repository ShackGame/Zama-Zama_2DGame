using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Respawner respawn;

    private void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("PS").GetComponent<Respawner>();
        transform.position = respawn.lastCheckpointPos;
    }
}
