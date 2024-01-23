using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
//using System.Security.Policy;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePlaneClickEvent : MonoBehaviour, IPointerClickHandler
{
    private PlayerSettingUpFlagPlacer playerSettingUpFlagPlacer;


    public void SetPlayerSettingUpFlagPlacer(PlayerSettingUpFlagPlacer playerSettingUpFlagPlacer)
    {
        this.playerSettingUpFlagPlacer = playerSettingUpFlagPlacer;
    }

    public PlayerSettingUpFlagPlacer GetPlayerSettingUpFlagPlacer()
    {
        return playerSettingUpFlagPlacer;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log($"{eventData.pointerCurrentRaycast.worldPosition}");
        float MapX = eventData.pointerCurrentRaycast.worldPosition.z;
        float MapY = eventData.pointerCurrentRaycast.worldPosition.x;

        
        if (playerSettingUpFlagPlacer != null)
        {
            playerSettingUpFlagPlacer.basePlaneClickEventListener(MapX, MapY);
        }

    }
}



