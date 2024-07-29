using System.IO;
using UnityEditor;
using UnityEngine;

public class AddScopedRegistry
{
    // この後に Window > Package Manager > My Registries > でCDKをInstallする
    [MenuItem("Tools/Add Scoped Registry")]
    public static void AddRegistry()
    {
        string manifestFilePath = Path.Combine(Application.dataPath, "../Packages/manifest.json");
        
        if (!File.Exists(manifestFilePath))
        {
            Debug.LogError("manifest.json file not found at: " + manifestFilePath);
            return;
        }

        string manifestJson = File.ReadAllText(manifestFilePath);

        // Check if the Scoped Registries already contains the Cluster registry
        if (manifestJson.Contains("\"name\": \"Cluster\""))
        {
            Debug.Log("Scoped Registry 'Cluster' is already added.");
            return;
        }

        // JSON for the new scoped registry
        string scopedRegistry = @"
        {
            ""name"": ""Cluster"",
            ""url"": ""https://registry.npmjs.com"",
            ""scopes"": [
                ""mu.cluster""
            ]
        }";

        // Inserting the new scoped registry into the existing manifest JSON
        int insertIndex = manifestJson.LastIndexOf("\"scopedRegistries\": [");
        if (insertIndex == -1)
        {
            // If no scopedRegistries exists, add one
            manifestJson = manifestJson.Replace("\"dependencies\": {", "\"scopedRegistries\": [ " + scopedRegistry + " ],\n\"dependencies\": {");
        }
        else
        {
            // Insert the new registry before the closing bracket of scopedRegistries array
            insertIndex = manifestJson.IndexOf("]", insertIndex);
            manifestJson = manifestJson.Insert(insertIndex, "," + scopedRegistry);
        }

        // Save the modified manifest.json file
        File.WriteAllText(manifestFilePath, manifestJson);
        AssetDatabase.Refresh();

        Debug.Log("Scoped Registry 'Cluster' has been added.");
    }
}
