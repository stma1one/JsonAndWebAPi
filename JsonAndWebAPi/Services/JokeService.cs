using JsonAndWebAPi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonAndWebAPi.Services
{
    public class JokeService
    {
        //httpClient handles Request and responses
        private HttpClient client;
        public JokeService()
        {
            client = new HttpClient();
        }

        public async Task<Joke> GetJoke()
        {
            //error handling - חייבים לתפוס מקרים שבהם הקוד נכשל מסיבה לא צפויה - הפסקת חשמל בצד השרת, אין אינטרנט
            try
            {
                //פעולת GET - מאחזרת מידע מהשרת.
                //הפעולה מקבלת את כתובת השרת והפרמטרים שנדרשים לקבלת המידע הדרוש
                var response = await client.GetAsync(@"https://v2.jokeapi.dev/joke/Programming,Pun?blacklistFlags=nsfw,racist,sexist&type=single");
                //חובה לבדוק אם התקבלה תשובה תקינה
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //נקרא את הJSON מהתוכן שהתקבל
                    var content = await response.Content.ReadAsStringAsync();
                    //נמיר אותו לאובייקט
                    return JsonSerializer.Deserialize<Joke>(content);
                }
                else
                    return null;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return null;
        }
    }
}
