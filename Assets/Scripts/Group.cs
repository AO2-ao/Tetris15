using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool isValidGridPos() {        
    foreach (Transform child in transform) {
        Vector2 v = PlayField.roundVec2(child.position);

        // Not inside Border?
        if (!PlayField.insideBorder(v))
            return false;

        // Block in grid cell (and not part of same group)?
        if (PlayField.grid[(int)v.x, (int)v.y] != null &&
            PlayField.grid[(int)v.x, (int)v.y].parent != transform)
            return false;
        }
    return true;
    }
    void updateGrid() {
    // Remove old children from grid
    for (int y = 0; y < PlayField.h; ++y)
        for (int x = 0; x < PlayField.w; ++x)
            if (PlayField.grid[x, y] != null)
                if (PlayField.grid[x, y].parent == transform)
                    PlayField.grid[x, y] = null;

    // Add new children to grid
    foreach (Transform child in transform) {
        Vector2 v = PlayField.roundVec2(child.position);
        PlayField.grid[(int)v.x, (int)v.y] = child;
        }        
    }
}
