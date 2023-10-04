using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int xp, hp;
    
    public float speed, runSpeed, jumpHeight, gravityValue, rotation;
    
    public float[] position;
    public float[] rotationPlayer;

    public float[] positionCamera;
    public float[] rotationCamera;

    public int playerId;

    public PlayerData(Player player)
    {
        xp = player.XP;
        hp = player.HP;
        speed = player.speed;
        runSpeed = player.runSpeed;
        jumpHeight = player.jumpHeight;
        gravityValue = player.gravityValue;
        rotation = player.rotation;

        position = new float[3];
        position[0] = player.playerTransform.position.x;
        position[1] = player.playerTransform.position.y;
        position[2] = player.playerTransform.position.z;

        rotationPlayer = new float[3];
        rotationPlayer[0] = player.playerTransform.rotation.eulerAngles.x;
        rotationPlayer[1] = player.playerTransform.rotation.eulerAngles.y;
        rotationPlayer[2] = player.playerTransform.rotation.eulerAngles.z;

        positionCamera = new float[3];
        positionCamera[0] = player.cameraTransform.position.x;
        positionCamera[1] = player.cameraTransform.position.y;
        positionCamera[2] = player.cameraTransform.position.z;

        rotationCamera = new float[3];
        rotationCamera[0] = player.cameraTransform.rotation.eulerAngles.x;
        rotationCamera[1] = player.cameraTransform.rotation.eulerAngles.y;
        rotationCamera[2] = player.cameraTransform.rotation.eulerAngles.z;
        
        try
        {
            playerId = (int)player.playerSelected.playerType;
        }
        catch
        {
            playerId = 0;
        }

    }

    // public static void SetPlayerData(this Player player, PlayerData playerData)
    // {
    //     player.XP = playerData.xp;
    //     player.HP = playerData.hp;
    //     player.speed = playerData.speed;
    //     player.runSpeed = playerData.runSpeed;
    //     player.jumpHeight = playerData.jumpHeight;
    //     player.gravityValue = playerData.gravityValue;
    //     player.rotation = playerData.rotation;

    //     player.playerTransform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
    //     player.playerTransform.rotation = new Quaternion(playerData.rotationPlayer[0], playerData.rotationPlayer[1], playerData.rotationPlayer[2], 0);

    //     player.cameraTransform.position = new Vector3(playerData.positionCamera[0], playerData.positionCamera[1], playerData.positionCamera[2]);
    //     player.cameraTransform.rotation = new Quaternion(playerData.rotationCamera[0], playerData.rotationCamera[1], playerData.rotationCamera[2], 0);

    //     switch (playerData.playerId)
    //     {
    //         case 0:
    //             player.ChangePlayer(player.cavaleiroDoSaber);
    //             break;
    //         case 1:
    //             player.ChangePlayer(player.cientistaAlquimico);
    //             break;
    //         case 2:
    //             player.ChangePlayer(player.guerreiroMatematico);
    //             break;
    //         case 3:
    //             player.ChangePlayer(player.ladinoDasSombas);
    //             break;
    //         default:
    //             player.ChangePlayer(player.cavaleiroDoSaber);
    //             break;
    //     }


    // }



}
