using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using B83.Win32;
using System.Linq;

public class SpriteGenerator : MonoBehaviour
{
    void OnEnable()
    {
        FileDragAndDrop.Instance.AddOnFiles(OnFiles);
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        foreach (var file in aFiles)
        {
            GenerateFromPath(file);
        }
    }

    [SerializeField] SpriteRenderer prefab;
    byte[] ReadPngFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }


    //https://qiita.com/r-ngtm/items/6cff25643a1a6ba82a6c
    public void GenerateFromPath(string path)
    {
        string extention = Path.GetExtension(path);
        if (!CanGenerate(extention))
        {
            Debug.LogError("SpriteGenerator : file not supported");
            return;
        }
        Debug.Log($"SpriteGenerator : load {path}");


        byte[] readBinary = ReadPngFile(path);
        int pos = 16; // 16バイトから開始

        int width = 0;
        for (int i = 0; i < 4; i++)
        {
            width = width * 256 + readBinary[pos++];
        }

        int height = 0;
        for (int i = 0; i < 4; i++)
        {
            height = height * 256 + readBinary[pos++];
        }

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        prefab.sprite = Sprite.Create(texture, new Rect(0f, 0f, width, height), new Vector2(0.5f, 0.5f), 100f);
    }

    public static bool CanGenerate(string extension)
    {
        var ex = extension.ToLower();
        if (ex == ".png") return true;
        return false;
    }



}
