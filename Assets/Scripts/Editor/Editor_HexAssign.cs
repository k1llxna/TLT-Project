using UnityEngine;
using UnityEditor;

public class Editor_HexAssign : EditorWindow
{
    private GUISkin skin;
    Vector2 scrollPos = new Vector2(0, 0);

    UnitLibrary unitLibrary = UnitLibrary.instance;

    [MenuItem("Edit Unit/Assign Unit to Hex")]
    public static void ShowWindow()
    {
        GetWindow<Editor_HexAssign>("Assign Unit to Hex");
    }

    void OnGUI()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(400));
        skin = GUI.skin;
        GUILayout.Label("Select a Unit and a Hex to Assign to Location", EditorStyles.boldLabel);

        GUILayout.Space(10);

        #region row1
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("1", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(1);
        if (GUILayout.Button("2", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(2);
        if (GUILayout.Button("3", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(3);
        if (GUILayout.Button("4", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(4);
        if (GUILayout.Button("5", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(5);
        if (GUILayout.Button("6", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(6);
        if (GUILayout.Button("7", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(7);
        if (GUILayout.Button("8", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(8);
        if (GUILayout.Button("9", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(9);
        if (GUILayout.Button("10", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(10);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

        #region row2
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("11", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(11);
        if (GUILayout.Button("12", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(12);
        if (GUILayout.Button("13", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(13);
        if (GUILayout.Button("14", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(14);
        if (GUILayout.Button("15", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(15);
        if (GUILayout.Button("16", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(16);
        if (GUILayout.Button("17", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(17);
        if (GUILayout.Button("18", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(18);
        if (GUILayout.Button("19", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(19);
        if (GUILayout.Button("20", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(20);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

        #region row3
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("21", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(21);
        if (GUILayout.Button("22", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(22);
        if (GUILayout.Button("23", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(23);
        if (GUILayout.Button("24", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(24);
        if (GUILayout.Button("25", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(25);
        if (GUILayout.Button("26", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(26);
        if (GUILayout.Button("27", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(27);
        if (GUILayout.Button("28", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(28);
        if (GUILayout.Button("29", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(29);
        if (GUILayout.Button("30", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(30);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

        #region row4
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("31", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(31);
        if (GUILayout.Button("32", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(32);
        if (GUILayout.Button("33", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(33);
        if (GUILayout.Button("34", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(34);
        if (GUILayout.Button("35", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(35);
        if (GUILayout.Button("36", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(36);
        if (GUILayout.Button("37", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(37);
        if (GUILayout.Button("38", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(38);
        if (GUILayout.Button("39", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(39);
        if (GUILayout.Button("40", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(40);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

        #region row5
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("41", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(41);
        if (GUILayout.Button("42", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(42);
        if (GUILayout.Button("43", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(43);
        if (GUILayout.Button("44", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(44);
        if (GUILayout.Button("45", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(45);
        if (GUILayout.Button("46", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(46);
        if (GUILayout.Button("47", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(47);
        if (GUILayout.Button("48", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(48);
        if (GUILayout.Button("49", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(49);
        if (GUILayout.Button("50", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(50);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

        #region row6
        GUILayout.BeginHorizontal();
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        if (GUILayout.Button("51", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(51);
        if (GUILayout.Button("52", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(52);
        if (GUILayout.Button("53", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(53);
        if (GUILayout.Button("54", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(54);
        if (GUILayout.Button("55", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(55);
        if (GUILayout.Button("56", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(56);
        if (GUILayout.Button("57", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(57);
        if (GUILayout.Button("58", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(58);
        if (GUILayout.Button("59", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(59);
        if (GUILayout.Button("60", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
            SetPosition(60);
        GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        GUILayout.EndHorizontal();
        #endregion

      
        GUILayout.Space(10);

        GUILayout.Label("Clear the Board Here", EditorStyles.boldLabel);
        if (GUILayout.Button("Clear Board"))
            ClearBoard();

        if (GUILayout.Button("Delete Unit"))
            DeleteUnit();

        if (GUILayout.Button("Return Unit to its Hex"))
            ReturnToHex();

        if (GUILayout.Button("CalibrateBoard"))
            CalibrateBoard();

        EditorGUILayout.EndScrollView();
    }

    private void CalibrateBoard()
    {
        GameObject.Find("_Board1Blocks").GetComponent<Board>().GenerateGrid();

        ////GameObject obj = Instantiate(gridPrefab, new Vector3(origin.x + scale * i, origin.y, origin.z + scale * j), Quaternion.identity);
    }

    private void SetPosition(int i)
    {
        if (Selection.count != 1)
        {
            Debug.LogWarning("Incorrect Amount of Units Selected! You Must Only Select 1!");
            return;
        }

        foreach (GameObject go in Selection.gameObjects) {
            if (!go.gameObject.GetComponent<UnitMovement>())
            {
                Debug.LogWarning("Object Selected isn't a Unit!");
                return;
            }
            go.gameObject.GetComponent<UnitMovement>().MoveToNewHex(i);
        }
    }
    private void ClearBoard()
    {
        // clear hex components & remove any units on board
        foreach (Transform t in GameObject.Find("_Board1Blocks").transform)
        {
            Hex hex = t.gameObject.GetComponent<Hex>();

            GameObject.Find("Enemy").gameObject.GetComponent<EnemyPlayer>().enemyUnits.Remove(hex.gameObject.GetComponent<Hex>().GetHeldUnit());

            hex.SetIsOccupied(false);

            if (hex.GetHeldUnit() != null)
                hex.DestroyHeldUnit();

            hex.gameObject.GetComponent<Hex>().SetHeldUnit(null);
        }
        Debug.Log("Board Cleared!");
    }

    private void DeleteUnit()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            if (!go.gameObject.GetComponent<UnitMovement>())
            {
                Debug.LogWarning("Object Selected isn't a Unit!");
                return;
            }
            go.gameObject.GetComponent<UnitMovement>().DestroyUnit();
        }
    }

    private void ReturnToHex()
    {
        foreach (GameObject go in Selection.gameObjects)
        {
            if (!go.gameObject.GetComponent<UnitMovement>())
            {
                Debug.LogWarning("Object Selected isn't a Unit!");
                return;
            }
            go.gameObject.GetComponent<UnitMovement>().SetOriginHex(go.gameObject.GetComponent<UnitMovement>().originHex);
        }
    }
}
/*
   //#region row7
        //GUILayout.BeginHorizontal();
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //if (GUILayout.Button("61", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(61);
        //if (GUILayout.Button("62", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(62);
        //if (GUILayout.Button("63", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(63);
        //if (GUILayout.Button("64", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(64);
        //if (GUILayout.Button("65", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(65);
        //if (GUILayout.Button("66", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(66);
        //if (GUILayout.Button("67", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(67);
        //if (GUILayout.Button("68", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(68);
        //if (GUILayout.Button("69", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(69);
        //if (GUILayout.Button("70", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(70);
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //GUILayout.EndHorizontal();
        //#endregion
        //#region row8
        //GUILayout.BeginHorizontal();
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //if (GUILayout.Button("71", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(71);
        //if (GUILayout.Button("72", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(72);
        //if (GUILayout.Button("73", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(73);
        //if (GUILayout.Button("74", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(74);
        //if (GUILayout.Button("75", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(75);
        //if (GUILayout.Button("76", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(76);
        //if (GUILayout.Button("77", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(77);
        //if (GUILayout.Button("78", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(78);
        //if (GUILayout.Button("79", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(79);
        //if (GUILayout.Button("80", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(80);
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //GUILayout.EndHorizontal();
        //#endregion
        //#region row9
        //GUILayout.BeginHorizontal();
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //if (GUILayout.Button("81", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(81);
        //if (GUILayout.Button("82", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(82);
        //if (GUILayout.Button("83", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(83);
        //if (GUILayout.Button("84", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(84);
        //if (GUILayout.Button("85", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(85);
        //if (GUILayout.Button("86", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(86);
        //if (GUILayout.Button("87", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(87);
        //if (GUILayout.Button("88", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(88);
        //if (GUILayout.Button("89", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(89);
        //if (GUILayout.Button("90", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(90);
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //GUILayout.EndHorizontal();
        //#endregion
        //#region row10
        //GUILayout.BeginHorizontal();
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //if (GUILayout.Button("91", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(91);
        //if (GUILayout.Button("92", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(92);
        //if (GUILayout.Button("93", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(93);
        //if (GUILayout.Button("94", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(94);
        //if (GUILayout.Button("95", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(95);
        //if (GUILayout.Button("96", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(96);
        //if (GUILayout.Button("97", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(97);
        //if (GUILayout.Button("98", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(98);
        //if (GUILayout.Button("99", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(99);
        //if (GUILayout.Button("100", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(100);
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //GUILayout.EndHorizontal();
        //#endregion

        //#region row11
        //GUILayout.BeginHorizontal();
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //if (GUILayout.Button("101", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(101);
        //if (GUILayout.Button("102", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(102);
        //if (GUILayout.Button("103", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(103);
        //if (GUILayout.Button("104", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(104);
        //if (GUILayout.Button("105", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(105);
        //if (GUILayout.Button("106", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(106);
        //if (GUILayout.Button("107", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(107);
        //if (GUILayout.Button("108", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(108);
        //if (GUILayout.Button("109", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(109);
        //if (GUILayout.Button("110", GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f)))
        //    SetPosition(110);
        //GUILayout.Button("", skin.label, GUILayout.ExpandWidth(false), GUILayout.MaxHeight(30f), GUILayout.MaxWidth(30f));
        //GUILayout.EndHorizontal();
        //#endregion
     */