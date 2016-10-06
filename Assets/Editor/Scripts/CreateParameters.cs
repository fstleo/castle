using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateParameters 
{
    [MenuItem("Assets/Create/Parameters/Attack Parameter Object")]
    public static void CreateAttackParametersObject()
    {
        AttackerParameters asset = ScriptableObject.CreateInstance<AttackerParameters>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Parameters/AttackParameters/Stickman_AttackParameters.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Parameters/Run Parameter Object")]
    public static void CreateRunParametersObject()
    {
        RunnerParameters asset = ScriptableObject.CreateInstance<RunnerParameters>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Parameters/RunParameters/Stickman_RunParameters.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Parameters/Fly Parameter Object")]
    public static void CreateFlyParametersObject()
    {
        FlyingParameters asset = ScriptableObject.CreateInstance<FlyingParameters>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Parameters/FlyParameters/Stickman_FlyParameters.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }


    [MenuItem("Assets/Create/Parameters/Destroyable Parameter Object")]
    public static void CreateDestroyableParametersObject()
    {
        DestroyableParameters asset = ScriptableObject.CreateInstance<DestroyableParameters>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Parameters/DestroyableParameters/Castle_DestroyableParameters.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}