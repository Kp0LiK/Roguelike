using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<LevelManager>();
        if (player != null)
        {
            player.SetRespawnPoint(transform.position);
        }
    }
}
