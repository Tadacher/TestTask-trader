using Enums;
using UnityEngine;

public class Item
{
    public Side Owner => _owner;
    public int Price => _worth;


    private Side _owner;
    private int _worth;

    public Item() => 
        Init();
    public void SetOwner(Side side) => 
        _owner = side;
    public void ReInit(Side side) => 
        Init(side);
    private void Init(Side side)
    {
        _owner = side;
        _worth = Random.Range(10, 45);
    }
    private void Init()
    {
        _owner = Side.Right;
        _worth = Random.Range(10, 45);
    }
}