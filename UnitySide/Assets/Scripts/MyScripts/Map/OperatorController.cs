using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour
{
    [SerializeField]
    MapUpdateResponse MapUpdateResponse;

    [SerializeField]
    UserRegister userRegister;

    [SerializeField]
    public const int MAX_BULLET_COUNT = 1;
    [SerializeField]
    public const float MAX_STAMINA = 5f;

    // Current moving operator
    private int bulletCount;
    private float stamina;

    private GameObject[] attackers = null;
    private GameObject[] defenders = null;

    public GameObject[] GetAttackers() { return attackers; }
    public GameObject[] GetDefenders() {  return defenders; }

    public void SetAttackers(GameObject[] attackers) { this.attackers = attackers; }
    public void SetDefenders(GameObject[] defenders) { this.defenders = defenders; }

    public void SetOperatorActive(int index)
    {
        switch (userRegister.GetPlayerIdentity())
        {
            case "attacker":
                attackers[index].GetComponent<OperatorData>().GetIndicator().SetActive(true);
                break;

            case "defender":
                defenders[index].GetComponent<OperatorData>().GetIndicator().SetActive(true);
                break;
        }
    }

    public void SetBulletCount(int bulletCount) { this.bulletCount = bulletCount;}
    public void SetStamina(float stamina) { this.stamina = stamina;}
}
