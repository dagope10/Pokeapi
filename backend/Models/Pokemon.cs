using System.Runtime.InteropServices;

public class Pokemon {

    public int id { get; set;}
    public string name { get; set;}

    public List<PokemonType> types {get; set;}


}

public class PokemonType {
    public int Slot { get; set; }
    public TypeDetail type { get; set; }
}

public class TypeDetail {
    public string Name { get; set; }
    public string Url { get; set; }
}