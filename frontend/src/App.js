import React, { useState } from 'react';
import './App.css';

function App() {
  const [pokemon, setPokemon] = useState(null);

  const getTypeColor = (type) => {
    switch(type) {
      case 'normal': return 'bg-normal';
      case 'fire': return 'bg-fire';
      case 'water': return 'bg-water';
      case 'electric': return 'bg-electric';
      case 'grass': return 'bg-grass';
      case 'ice': return 'bg-ice';
      case 'fighting': return 'bg-fighting';
      case 'poison': return 'bg-poison';
      case 'ground': return 'bg-ground';
      case 'flying': return 'bg-flying';
      case 'psychic': return 'bg-psychic';
      case 'bug': return 'bg-bug';
      case 'rock': return 'bg-rock';
      case 'ghost': return 'bg-ghost';
      case 'dragon': return 'bg-dragon';
      case 'dark': return 'bg-dark';
      case 'steel': return 'bg-steel';
      case 'fairy': return 'bg-fairy';
      default: return 'bg-gray-400';
    }
  };

  const fetchPokemon = async (name) => {
    const response = await fetch(`http://localhost:5252/Pokemon/${name}`);
    const data = await response.json();
    setPokemon(data);

  }

  const primeraMayuscula = (string) => {
    return string.charAt(0).toUpperCase() + string.slice(1);
  }

  return(
    <div className="App">
  <input
    type="text"
    placeholder="Ingrese nombre del Pokémon"
    onBlur={(e) => fetchPokemon(e.target.value)}
    className="mt-5 mb-5 p-2 text-center shadow-lg rounded-lg"
  />
  {pokemon && (
    <div className="pokemon-info max-w-sm mx-auto bg-white rounded-xl shadow-md overflow-hidden md:max-w-2xl">
      <div className="md:flex">
        <div className="md:flex-shrink-0">
          <img className="h-48 w-full object-cover md:w-48" src={pokemon.imageUrl} alt={pokemon.name} />
        </div>
        <div className="p-8">
          <h1 className="block mt-1 text-lg leading-tight font-medium text-black">{primeraMayuscula(pokemon.name)}</h1>
          <div className="pokemon-types mt-2">
          {pokemon.types.map((type, index) => (
  <span key={index} className={`inline-block rounded-full px-3 py-1 text-sm font-semibold text-white mr-2 ${getTypeColor(type.type.name)}`}>
    {type.type.name.toUpperCase()}
  </span>
))}
          </div>
        </div>
      </div>
    </div>
  )}
</div>

  );
}


export default App;