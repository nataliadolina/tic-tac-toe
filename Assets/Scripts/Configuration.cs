using MonoBehaviours;
using UnityEngine;

[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    public int LevelWidth = 3;
    public int LevelHeight = 3;
    public int ChainLength = 3;

    public SignView RingView;
    public SignView CrossView;

    public CellView CellView;
    public Vector2 Offset;

    public LineView WinLine;
}