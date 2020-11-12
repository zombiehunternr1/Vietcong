using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color COrange = new Color32(254, 161, 0, 1);
    public bool IsHit = true;
    public GameObject Killzone;
    public Transform tile;
    public GameObject AirProjectile;
    public float SlowSpeed;

    public IEnumerator DroppingThisTile()
    {
        if (IsHit == false)
        {
            //Gets the material from the selected tile that is stored in the variable DTile.
            var DTileColor = GetComponent<Renderer>().material;
            //Changes the color to orange.
            DTileColor.color = COrange;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Changes the color to red.
            DTileColor.color = Color.red;
            //Creates the air projectile on the tile and stores it in the variable TempAirProjectile.
            var TempAirProjectile = Instantiate(AirProjectile, tile.position + (Vector3.up * 20f), tile.rotation);
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Creates the killzone area on the tile and stores it in the variable TempKillZone.
            var TempKillZone = Instantiate(Killzone, tile.transform.position, tile.rotation);
            //Resizes the killzone area to the same size as the tile itself.
            TempKillZone.transform.localScale = tile.transform.localScale;
            //Waits 1/10 of a second before executing the rest of the code.
            yield return new WaitForSeconds(0.1f);
            //Destroys the temporarely killzone.
            Destroy(TempKillZone);
            //Disables the tile that is stored in the variable DTile.
            gameObject.SetActive(false);
        }
        if(IsHit == true)
        {
            //Gets the material from the selected tile that is stored in the variable DTile.
            var DTileColor = GetComponent<Renderer>().material;
            //Changes the color to orange.
            DTileColor.color = COrange;
            //Waits 1 seconds before executing the rest of the code.
            yield return new WaitForSeconds(1);
            //Changes the color to red.
            DTileColor.color = Color.red;
            //Waits 1 seconds before executing the rest of the code.
            //Creates the air projectile on the tile and stores it in the variable TempAirProjectile.
            var TempAirProjectile = Instantiate(AirProjectile, tile.position + (Vector3.up * 20f), tile.rotation);
            yield return new WaitForSeconds(1);           
            //Changes the color to black.
            DTileColor.color = Color.black;
            //Creates the killzone area on the tile and stores it in the variable TempKillZone.
            var TempKillZone = Instantiate(Killzone, tile.transform.position, tile.rotation);
            //Resizes the killzone area to the same size as the tile itself.
            TempKillZone.transform.localScale = tile.transform.localScale;
            //Waits 1/10 of a second before executing the rest of the code.
            yield return new WaitForSeconds(0.1f);
            //Destroys the temporarely killzone.
            Destroy(TempKillZone);
            //Sets the bool IsHit to false.
            IsHit = false;
        }   
    }

    private void OnCollisionStay(Collision other)
    { 
        //Check if the player collides with a tile that has been hit once. If so it adjusts the movementspeed of the player to a slower speed.
        //Sets the animator boolean IsRunning to fals and sets the boolean IsMud to true. Once the player gets of the tile it sets the boolean IsMud back to false.
        if (PlayerTotal.PlayerList.Contains(other.gameObject) && IsHit == false)
        {
            other.gameObject.GetComponent<Movement>().ChangeMovementSpeed(SlowSpeed);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsRunning", false);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", true);
        }
        else
        {
            other.gameObject.GetComponent<Movement>().ChangeMovementSpeed();
            other.gameObject.GetComponentInChildren<Animator>().SetBool("IsMud", false);
        }
    }
}
