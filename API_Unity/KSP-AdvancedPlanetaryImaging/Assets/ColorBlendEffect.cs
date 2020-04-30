using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorBlendEffect : APIEffectBase
{
    private Matrix4x4 color;
    public Vector3 preset = new Vector3(1,2,3);

    void Update()
    {
        UpdateColors();
        material.SetMatrix("transform", color);
    }

    void UpdateColors()
    {
        // 1 is red, 2 is blue, 3 is green
        switch (preset.x)
        {
            case 0: // red input missing
                color.SetRow(0, new Vector4(0, 0.5f, 0.5f, 0));
                break;
            default:
            case 1: // red output is red input
                color.SetRow(0, new Vector4(1, 0, 0, 0));
                break;
            case 2: // red output is green input
                color.SetRow(0, new Vector4(0, 1, 0, 0));
                break;
            case 3: // red output is blue input
                color.SetRow(0, new Vector4(0, 0, 1, 0));
                break;
        }
        switch (preset.y)
        {
            case 0: // green input missing
                color.SetRow(1, new Vector4(0.5f, 0, 0.5f, 0));
                break;
            case 1: // green output is red input
                color.SetRow(1, new Vector4(1, 0, 0, 0));
                break;
            default:
            case 2: // green output is green input
                color.SetRow(1, new Vector4(0, 1, 0, 0));
                break;
            case 3: // green output is blue input
                color.SetRow(1, new Vector4(0, 0, 1, 0));
                break;
        }
        switch (preset.z)
        {
            case 0: // blue input missing
                color.SetRow(2, new Vector4(0.5f, 0.5f, 0, 0));
                break;
            case 1: // blue output is red input
                color.SetRow(2, new Vector4(1, 0, 0, 0));
                break;
            case 2: // blue output is green input
                color.SetRow(2, new Vector4(0, 1, 0, 0));
                break;
            default:
            case 3: // blue output is blue input
                color.SetRow(2, new Vector4(0, 0, 1, 0));
                break;
        }
        color.SetRow(3, new Vector4(0, 0, 0, 1));
        color.SetColumn(3, new Vector4(0, 0, 0, 1));
    }

    public Stack<int> NumbersIn(int value)
    {
        if (value == 0) return new Stack<int>();

        var numbers = NumbersIn(value / 10);

        numbers.Push(value % 10);

        return numbers;
    }
}
