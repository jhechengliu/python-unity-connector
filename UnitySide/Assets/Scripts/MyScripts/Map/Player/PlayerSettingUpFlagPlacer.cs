using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingUpFlagPlacer : MonoBehaviour
{
    [SerializeField]
    private UserRegister userRegister;

    [SerializeField]
    private GameObject flagPrefab;

    private BasePlaneClickEvent basePlaneClickEvent = null;

    [SerializeField]
    private int maxFlagsCount;

    [SerializeField]
    private GameObject map;

    [SerializeField]
    private SetOperatorCommandPublisher setOperatorCommandPublisher;


    private List<GameObject> playerFlags = new List<GameObject>();

    private class Identity
    {
        public static string ATTACKER = "attacker";
        public static string DEFENDER = "defender";
    }
    private string playerIdentity;

    private void Start()
    {
        if (userRegister.GetPlayerIdentity() == "attacker") { playerIdentity = Identity.ATTACKER; }
        else if (userRegister.GetPlayerIdentity() == "defender") { playerIdentity = Identity.DEFENDER; }

        Debug.Log("Delete Stuff From Here");
    }

    private void GetBasePlaneClickEvent()
    {

        if (map.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>() != null)
        {
            basePlaneClickEvent = map.GetComponent<JsonMapBuilder>().GetBasePlaneObject()
                .GetComponent<BaseSizeModifier>().GetBasePlane().GetComponent<BasePlaneClickEvent>();
        }
        else
        {
            Debug.LogWarning("Cannot get map Object");
        }
    }

    public void basePlaneClickEventListener(float MapX, float MapY)
    {
        if (playerFlags.Count < maxFlagsCount)
        {
            bool attackerGood = (playerIdentity == Identity.ATTACKER) &&
                ((map.GetComponent<JsonMapBuilder>().GetMapObjectFromMap((int)MapX, (int)MapY)) == "entrance");

            bool defenderGood = (playerIdentity == Identity.DEFENDER) &&
                ((map.GetComponent<JsonMapBuilder>().GetMapObjectFromMap((int)MapX, (int)MapY)) == "floor");

            if (attackerGood || defenderGood)
            {
                GameObject playerFlag = Instantiate(flagPrefab, new Vector3((int)MapY, 0, (int)MapX), Quaternion.identity);
                playerFlags.Add(playerFlag);
                setOperatorCommandPublisher.PublishOperatorLocation((int)MapX, (int)MapY);
            }
            
        }
        else
        {
            Debug.Log("YOU REACH MAX FLAGS COUNT");
        }
        
    }

    private void Update()
    {
        if (basePlaneClickEvent == null)
        {
            GetBasePlaneClickEvent();
        }
        else
        {
            if (basePlaneClickEvent.GetPlayerSettingUpFlagPlacer() == null)
            {
                basePlaneClickEvent.SetPlayerSettingUpFlagPlacer(this);
            }
        }
    }
}
