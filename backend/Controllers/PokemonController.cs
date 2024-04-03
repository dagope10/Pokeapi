using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PokemonController : Controller {
    private readonly PokeAPIService _pokeAPIService;

    public PokemonController(PokeAPIService pokeAPIService) {
        _pokeAPIService = pokeAPIService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetPokemon(string name) {
        var pokemon = await _pokeAPIService.GetPokemonAsync(name);
        if(pokemon != null) {
            return Json(pokemon);
        }
        else {
            return NotFound();
        }

    }   
    
}