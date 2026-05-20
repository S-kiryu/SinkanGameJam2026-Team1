using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu]
public class PlayerStatus : ScriptableObject
{
    public int PlayerHP = 10;
    public int PlayerMaxHP = 10;

    public void TakeDamage(int damage)
    {
        PlayerHP += damage;

        if (PlayerHP <= 0)
        {
            //しぼうしょり

        }
    }
}
