using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h];

    //Vec2がfloatなのでintにまるめる
    public static Vector2 roundVec2(Vector2 v) {
    return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));
    }

    //ボーダー内にあるか判定
    public static bool insideBorder(Vector2 pos){
        return((int)pos.x>=0 &&
        (int)pos.x<w &&
        (int)pos.y>=0);
    }

    //行を消す
    public static void deleteRow(int y) {
    for (int x = 0; x < w; ++x) {
        Destroy(grid[x, y].gameObject);
        grid[x, y] = null;
        }
    }
    //行を1段下げる
    public static void decreaseRow(int y) {
    for (int x = 0; x < w; ++x) {
        if (grid[x, y] != null) {
            // Move one towards bottom
            grid[x, y-1] = grid[x, y];
            grid[x, y] = null;

            // Update Block position
            grid[x, y-1].position += new Vector3(0, -1, 0);
            }
        }
    }
    //全ての行に一段下げる
    public static void decreaseRowsAbove(int y) {
    for (int i = y; i < h; ++i)
        decreaseRow(i);
    }

    //列がいっぱいか
    public static bool isRowFull(int y) {
    for (int x = 0; x < w; ++x)
        if (grid[x, y] == null)
            return false;
    return true;
    }

    public static void deleteFullRows() {
    for (int y = 0; y < h; ++y) {
        if (isRowFull(y)) {
            deleteRow(y);
            decreaseRowsAbove(y+1);
            --y;
            }
        }
    }
}
