using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpdateResponse : AbstractResponse
{
    [SerializeField]
    private GameObject attackerOperatorPrefab;
    [SerializeField]
    private GameObject defenderOperatorPrefab;

    [SerializeField]
    private UserRegister userRegister;
    private GameObject[] attackers;
    private GameObject[] defenders;

    [SerializeField]
    private OperatorController operatorController;

    private void Start()
    {
        attackers = new GameObject[userRegister.GetMaxOperatorCount()];
        defenders = new GameObject[userRegister.GetMaxOperatorCount()];
    }

    public GameObject[] GetAttackers() { return attackers; }
    public GameObject[] GetDefenders() { return defenders; }

    public override void ResponseToMessage(string responseMessage)
    {
        splittedResponse = responseMessage.Split('_');
        string heading = splittedResponse[0];
        string json_str = "";
        for (int i = 1; i < splittedResponse.Length; i++)
        {
            json_str += splittedResponse[i];
            if (i != splittedResponse.Length - 1)
            {
                json_str += "_";
            }
        }

        if (heading == "success")
        {
            FileList playersData = JsonConvert.DeserializeObject<FileList>(json_str);
            foreach (PlayerData data in playersData.player)
            {
                if (data.identity == "attacker")
                {
                    attackers[data.index] = Instantiate(attackerOperatorPrefab,
                        new Vector3(data.location[1]+0.5f, 0, data.location[0]+0.5f), Quaternion.identity);
                }
                else if (data.identity == "defender")
                {
                    defenders[data.index] = Instantiate(defenderOperatorPrefab,
                        new Vector3(data.location[1]+0.5f, 0, data.location[0]+0.5f), Quaternion.identity);
                }
                else
                {
                    Debug.Log("Identity Data has typo in it");
                }

                

            }
            operatorController.SetAttackers(attackers);
            operatorController.SetDefenders(attackers);
        }

        
    }

    public class FileList
    {
        public List<PlayerData> player;
    }

    public class PlayerData
    {
        public int index;
        public List<float> location;
        public string identity;
    }
}
