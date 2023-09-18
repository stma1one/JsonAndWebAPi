using JsonAndWebAPi.Models;
using System;

using System.Threading.Tasks;
using System.Text.Json;
using JsonAndWebAPi.Services;

namespace JsonAndWebAPi;

class Program
{
    static async Task Main(string[] args)
    {

        #region Example on Serialization and DeSerializtion
        //Create Exercise
        Exercise ex = new Exercise
        {
            FirstVal = 3,
            SecondVal = 8,
            Op = '*'
        };
        #region Serializtion
        //JsonSerializerOptions - הגדרת אופציה של הצגת הנתונים/שליחת הנתונים
        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true };
        string content = JsonSerializer.Serialize(ex, options);
        Console.WriteLine(content);
        #endregion

        #region DeSerializtion
        var reverse = JsonSerializer.Deserialize<Exercise>(content, options);
        Console.WriteLine($"First Val ={reverse?.FirstVal}");
        #endregion
        #endregion

        #region Example of Deserializtion a Json taken from JokeApi docs
        //you can copy the json and then edit->paste Spacial -> paste json as classes
        //dont forget to change the name of the class.
        string jokeContent = @"{
    ""error"": false,
    ""category"": ""Pun"",
    ""type"": ""single"",
    ""joke"": ""A horse walks into a bar.\n\""Hey\"", the Bartender says.\n\""Sure\"", the horse replies."",
    ""flags"": {
        ""nsfw"": false,
        ""religious"": false,
        ""political"": false,
        ""racist"": false,
        ""sexist"": false,
        ""explicit"": false
    },
    ""id"": 74,
    ""safe"": true,
    ""lang"": ""en""
}";
       


        var joke = JsonSerializer.Deserialize<Joke>(jokeContent, options);
        Console.WriteLine(joke?.joke);
        #endregion
        Console.WriteLine("_______________________");

        #region Usage of HttpClient
        JokeService jokeService = new JokeService();
        joke=await jokeService.GetJoke();
        Console.WriteLine(joke.joke);
        #endregion
    }
}
