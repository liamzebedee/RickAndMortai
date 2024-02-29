using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class CharacterVotesData
{
    public static string characterVotesFilePath = $"{WholeThingManager.Singleton.GetDataDir()}/character-votes.json";
    

    public CharacterVoteResults[] voteResults = new CharacterVoteResults[] { };

    public static CharacterVotesData ReadFromDisk()
    {
        Debug.Log(characterVotesFilePath);
        if(!File.Exists(characterVotesFilePath))
        {
            throw new Exception("character-votes.json not found");
        }
        string data = File.ReadAllText(characterVotesFilePath);
        var x = JsonConvert.DeserializeObject<CharacterVotesData>(data);
        return x;
    }

    public void WriteToDisk()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(characterVotesFilePath, json);
    }
}
