using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, Defense}
    public PowerUpType powerUpType;
    [SerializeField] private float duration = 5f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData player = collision.GetComponent<PlayerData>();
            ApplyPowerUp(player);
            gameObject.SetActive(false);
        }
    }

    void ApplyPowerUp(PlayerData player)
    {
        switch (powerUpType)
        {
            case PowerUpType.SpeedBoost:
                StartCoroutine(ApplySpeedBoost(player));
                break;
            case PowerUpType.Defense:
                break;
        }
    }

    IEnumerator ApplySpeedBoost(PlayerData player)
    {
        float originalSpeed = player.moveSpeed * Time.deltaTime * 1000;
        player.moveSpeed *= 1.5f * Time.deltaTime * 1000;
        yield return new WaitForSeconds(duration);
        player.moveSpeed = originalSpeed;
    }
}
