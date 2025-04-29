using UnityEngine;
using UnityEditor;

public class AudioAssetPostprocessor : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        AudioImporter audioImporter = (AudioImporter)assetImporter;
        audioImporter.forceToMono = true;
    }
}
