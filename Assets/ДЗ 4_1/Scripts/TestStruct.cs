using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStruct : MonoBehaviour
{
    private void Awake()
    {
        TestClass testClass = new TestClass();
        Vector3 position = testClass.Position;
        position.Scale(new Vector3(100, 10, 10));

        Vector3Class vectorClass = testClass.Vector3Class;
        vectorClass.X = 1000;

        Debug.Log($"Struct - {testClass.Position}");
        Debug.Log($"Class - {testClass.Vector3Class.X}");
        
    }
}

public class TestClass
{
    public Vector3 Position { get;  }
    public Vector3Class Vector3Class { get; } = new Vector3Class();


}

public class Vector3Class
{
    public int X;
    public int Y;
    public int Z;
}
