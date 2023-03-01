using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        player.GetComponent<Transform>().position = gameObject.transform.position;
    }
}

