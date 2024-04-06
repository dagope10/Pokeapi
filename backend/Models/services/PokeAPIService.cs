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
                pokemon.imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{pokemon.id}.png";
                return pokemon;
            }
            else {
                return null;
            }
            
    }

    public async Task GuardarImagenPokemon(int pokemonId){
        var imageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{pokemonId}.png";
        using(var httpClient = new HttpClient()){
            var response = await httpClient.GetAsync(imageUrl);
            if(response.IsSuccessStatusCode){
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                await File.WriteAllBytesAsync($"pokemon_{pokemonId}.png", imageBytes);
            }
        }
    }

}
