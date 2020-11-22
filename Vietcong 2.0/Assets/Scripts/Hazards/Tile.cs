using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color COrange = new Color32(254, 161, 0, 1);
    public bool IsHit = true;
    public float SlowSpeed;
    public GameObject Killzone;   
    public GameObject Target;
    public GameObject AirProjectile;
    public Transform tile;
    public Projector Shadow;

    public IEnumerator DroppingThisTile()
    {
        if (IsHit == false)
        {
            //Creates the target effect on the tile and stores it in the variable TempTarget.
            var TempTarget = Instantiate(Target, tile.position + (Vector3.up * 1.5f), tile.rotation);
            //Creates the shadow effect on the tile and stores it in the variable TempShadow.
            var TempShadow = Instantiate(Shadow, tile.position + (-Vector3.up * 20f), tile.rotation);
            //Waits 2 seconds before executing the rest of the code.
            yield return new WaitForSeconds(2);
            //Creates the air projectile on the tile and stores it in the variable TempAirProjectile.
            var TempAirProjectile = Instantiate(AirProjectile, tile.position + (Vector3.up * 20f), tile.rotation);
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Creates the killzone area on the tile and stores it in the variable TempKillZone.
            var TempKillZone = Instantiate(Killzone, tile.position + (Vector3.up * 1f), tile.rotation);
            //Resizes the killzone area to the same size as the tile itself.
            TempKillZone.transform.localScale = tile.transform.localScale;
            //Waits 1/10 of a second before executing the rest of the code.
            yield return new WaitForSeconds(0.1f);
            //Destroys the temporarely killzone, the target and shadow.
            Destroy(TempKillZone);
            Destroy(TempTarget);
            Destroy(TempShadow);
            //Disables the tile that is stored in the variable DTile.
            gameObject.SetActive(false);
        }
        if(IsHit == true)
        {
            //Creates the target effect on the tile and stores it in the variable TempTarget.
            var TempTarget = Instantiate(Target, tile.position + (Vector3.up * 1.5f), tile.rotation);
            //Gets all the transform components inside the tile object and stores them in the transform array TempTileInfo.
            Transform[] TempTileInfo = GetComponentsInChildren<Transform>();
            //Creates the shadow effect on the tile and stores it in the variable TempShadow.
            var TempShadow = Instantiate(Shadow, tile.position + (-Vector3.up * 20f), tile.rotation);
            //Waits 2 seconds before executing the rest of the code.
            yield return new WaitForSeconds(2);
            //Creates the air projectile on the tile and stores it in the variable TempAirProjectile.
            var TempAirProjectile = Instantiate(AirProjectile, tile.position + (Vector3.up * 20f), tile.rotation);
            yield return new WaitForSeconds(1);
            //Creates the killzone area on the tile and stores it in the variable TempKillZone.
            var TempKillZone = Instantiate(Killzone, tile.position + (Vector3.up * 1f), tile.rotation);
            //Resizes the killzone area to the same size as the tile itself.
            TempKillZone.transform.localScale = tile.transform.localScale;
            //Sets the AllowHit boolean to true.
            TempKillZone.GetComponent<Killzone>().AllowHit = true;
            //Waits 15/10 of a second before executing the rest of the code.
            yield return new WaitForSeconds(0.15f);
            //Sets the AllowHit boolean to false.
            TempKillZone.GetComponent<Killzone>().AllowHit = false;
            //Destroys the temporarely killzone, the target and shadow.
            Destroy(TempKillZone);
            Destroy(TempTarget);
            Destroy(TempShadow);
            //Goes over each item in the TempTileInfo array.
            foreach (Transform Info in TempTileInfo)
            {
                //Checks if the item has the ground script attached to itself. If so, it moves the object down.
                //If the Riceplant script is attached to itself it disables itself.
                if(Info.GetComponent<Ground>())
                {
                    Info.transform.position = new Vector3(tile.transform.position.x, transform.position.y - 0.5f, tile.transform.position.z);
                }
                if(Info.GetComponent<Riceplant>())
                {
                    var Remove = Info.gameObject;
                    Destroy(Remove);
                }
            }
            //Sets the bool IsHit to false.
            IsHit = false;
        }   
    }

    private void OnCollisionStay(Collision other)
    { 
        //Check if the player collides with a tile that has been hit once. If so it adjusts the movementspeed of the player to a slower speed.
        //Sets the animator boolean IsRunning to fals and sets the boolean IsMud to true. Once the player gets of the tile it sets the boolean IsMud back to false.
        //Also checks if the amount of players is equal to one and if that last person is standing on the damaged tile. If so it sets the boolean IsMud to false.
        if (PlayerTotal.PlayerList.Contains(other.gameObject) && IsHit == false)
        {
            other.gameObject.GetComponent<Movement>().ChangeMovementSpeed(SlowSpeed);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsRunning", false);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", true);
        }
        if (PlayerTotal.PlayerList.Contains(other.gameObject) && IsHit == true)
        {
            other.gameObject.GetComponent<Movement>().ChangeMovementSpeed();
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", false);
        }
        if(PlayerTotal.PlayerList.Count == 1 && PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", false);
        }
    }
    //Checks if the player leaves the tile. If so it sets the bool IsMud to false.
    private void OnCollissionExit(Collision other)
    {
        if (PlayerTotal.PlayerList.Contains(other.gameObject))
        {
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", false);
        }     
    }
}
