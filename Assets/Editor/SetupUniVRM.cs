using UnityEditor;
using UnityEngine;

public class SetupUniVRM : MonoBehaviour
{
    // Unityメニューに新しい項目を追加する
    [MenuItem("Tools/Setup UniVRM")]
    public static void ImportPackage()
    {
        // パッケージのパスを指定
        string packagePath = "/Users/RH/Documents/git/UniVRM/UniVRM-0.125.0_f812.unitypackage";
        
        // パスが有効かどうか確認
        if (System.IO.File.Exists(packagePath))
        {
            // パッケージをインポート
            AssetDatabase.ImportPackage(packagePath, true);
        }
        else
        {
            Debug.LogError("指定されたパスにパッケージが見つかりません: " + packagePath);
        }
    }
}
