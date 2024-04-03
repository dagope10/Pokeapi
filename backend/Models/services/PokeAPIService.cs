using System.Net.Http.Json;
using Newtonsoft.Json;

public class PokeAPIService {
// Add missing import statement

    private readonly HttpClient _httpClient;

    public PokeAPIService(HttpClient httpClient){
        _httpClient = httpClient;
    }

    public async Task<Pokemon> GetPokemonAsync(string name) {
        var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");

        if(response.IsSuccessStatusCode) {
            var content = await response.Content.ReadAsStringAsync();
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(content);
            return pokemon;
        }
        else {
            return null;
        }
        
    }

}
