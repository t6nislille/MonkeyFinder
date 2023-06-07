using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    HttpClient httpClient;
    List<Monkey> monkeyList = new();

    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
        {
            return monkeyList;
        }

        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        return monkeyList;
    }
}
