using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Color COrange = new Color32(254, 161, 0, 1);

    public IEnumerator DroppingThisTile()
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
        yield return new WaitForSeconds(1);
        //Destroys the tile that is stored in the variable DTile.
        Destroy(this.gameObject);
    }
}
