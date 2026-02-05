using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float playerHealth;

    public float playerMaxHealth;

    public float playerSpeed;

    public float playerJump;

    public float playerDamage;

    public float playerLifeRegen;

    public bool isTakingDamage;

    public Color playerColorStandart;

    public Color playerColorTakingDamage;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().color = playerColorStandart;
    }
    private void Update()
    {
        PlayerColor();
    }

    public void OnTakingDamage(float enemyDamage)
    {
        playerHealth = playerHealth - enemyDamage * Time.deltaTime;
    }

    void PlayerColor()
    {
        if (isTakingDamage)
        {
            this.GetComponent<SpriteRenderer>().color = playerColorTakingDamage;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = playerColorStandart;
        }
    }
        
}

