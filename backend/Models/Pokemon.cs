using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Routing;

public class Pokemon {

    public int id { get; set;}
    public string name { get; set;}

    public List<PokemonType> types {get; set;}

    public string imageUrl {get; set;}

    public List<Abilities> abilities {get; set;}


}

public class PokemonType {
    public int Slot { get; set; }
    public TypeDetail type { get; set; }
}

public class TypeDetail {
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Abilities {
    public Ability ability { get; set; }

}

public class Ability {
    public string name {get; set;}
    public string url {get; set;}
    public Boolean is_hidden {get; set;}
    public int slot {get; set;}
}