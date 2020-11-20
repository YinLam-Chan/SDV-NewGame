using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SQLite4Unity3d;

[Serializable]
public class Person
{
    [PrimaryKey]
    public string Name { get; set; }
    public string Password { get; set; }
    public int Score { get; set; }
    public int LocationId { get; set; }
}
