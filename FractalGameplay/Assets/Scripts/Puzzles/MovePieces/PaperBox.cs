using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBox : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox[,] boxes = new NumberBox[3, 3];
    public Sprite[] sprites;

    void Start()
    {
     
    }

    private void Init()
    {
        int n = 0;
        for (int y = 2; y >= 0; y--)
        {
            for (int x = 0; x <= 3; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
        }
    }

    void ClickToSwap(int x, int y)
    {
        int diffX = getDiffX(x, y);
        int diffY = getDiffY(x, y);

        var from = boxes[x, y];
        var target = boxes[x + diffX, y + diffY];

        boxes[x, y] = target;
        boxes[x + diffX, y + diffY] = from;

        from.UpdatePosition(x + diffX, y + diffY);
        target.UpdatePosition(x, y);
    }

    int getDiffX(int x, int y)
    {
        if (x < 2 && boxes[x + 1, y].isEmpty())
        {
            return 1;
        }

        if (x > 0 && boxes[x - 1, y].isEmpty())
        {
            return -1;
        }

        return 0;
    }

    int getDiffY(int x, int y)
    {
        if (y < 2 && boxes[x, y + 1].isEmpty())
        {
            return 1;
        }

        if (y > 0 && boxes[x, y - 1].isEmpty())
        {
            return -1;
        }

        return 0;
    }
}
