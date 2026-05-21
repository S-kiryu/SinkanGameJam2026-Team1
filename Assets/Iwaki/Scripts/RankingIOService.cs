using System.IO;
using UnityEngine;

public static class RankingIOService
{
    private static readonly string LocalFilePath = "SaveData/Ranking.json";

    private static string GetFilePath()
    {
        // ビルドのフォルダ内に保存する
        return $"{Application.dataPath}/{LocalFilePath}";
    }

    //jsonとしてデータを保存
    private static void Save(RankingData data)
    {
        var path = GetFilePath();

        // ディレクトリが存在しなかったら作成
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            if (directory != null) Directory.CreateDirectory(directory);
        }

        // ランキングデータを保存
        string json = JsonUtility.ToJson(data);
        StreamWriter wr = new(path, false);
        wr.WriteLine(json);
        wr.Close();
    }

    //jsonファイルを読み込み
    public static RankingData Load()
    {
        var path = GetFilePath();
        if (File.Exists(path))
        {
            //jsonファイルを型に戻して返す
            return JsonUtility.FromJson<RankingData>(File.ReadAllText(path));
        }

        //ファイルが存在しなければ新しくセーブして返す
        var newData = new RankingData();
        Save(newData);
        return newData;
    }

    /// <summary>
    /// ランキングにスコアを登録
    /// </summary>
    public static void RegisterRank(RankingRegisterInfo info)
    {
        var data = Load();

        data.AddItem(new RankingItem(data, info));

        Save(data);
    }

    public static void ResetRank()
    {
        Save(new RankingData()); //新しいデータで上書き保存
    }
}
