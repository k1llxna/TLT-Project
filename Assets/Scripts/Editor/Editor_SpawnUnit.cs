using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitLibrary))]
public class Editor_SpawnUnit : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UnitLibrary unitLibrary = (UnitLibrary)target;

        if (GUILayout.Button("Unit1"))
            unitLibrary.SpawnUnit(0);

        if (GUILayout.Button("Unit2"))
            unitLibrary.SpawnUnit(1);

        if (GUILayout.Button("Unit3"))
            unitLibrary.SpawnUnit(2);

        if (GUILayout.Button("Unit4"))
            unitLibrary.SpawnUnit(3);

        if (GUILayout.Button("Unit5"))
            unitLibrary.SpawnUnit(4);
    }
}
