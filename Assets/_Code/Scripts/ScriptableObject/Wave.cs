using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Tower Defense/Wave Data", order = 1)]
public class Wave : ScriptableObject
{
    public List<Enemy> wave;
}
