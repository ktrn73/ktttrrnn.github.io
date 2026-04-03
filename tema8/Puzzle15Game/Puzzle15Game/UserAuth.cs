using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Puzzle15Game
{
    [Serializable]
    public class GameResult
    {
        public string PlayerName { get; set; }
        public int Moves { get; set; }
        public int TimeSeconds { get; set; }
        public DateTime Date { get; set; }
        public string Difficulty { get; set; }
    }

    public static class UserAuth
    {
        private static string ResultsFile = "results.bin";
        public static string CurrentUser { get; set; }

        public static void SaveResult(GameResult result)
        {
            List<GameResult> results = LoadAllResults();
            results.Add(result);
            using (FileStream fs = new FileStream(ResultsFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, results);
            }
        }

        public static List<GameResult> LoadAllResults()
        {
            if (!File.Exists(ResultsFile))
                return new List<GameResult>();
            using (FileStream fs = new FileStream(ResultsFile, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (List<GameResult>)formatter.Deserialize(fs);
            }
        }

        public static List<GameResult> GetResultsForCurrentUser()
        {
            return LoadAllResults().Where(r => r.PlayerName == CurrentUser).ToList();
        }
    }
}