import React, { useState } from 'react';
import './App.css';

function App() {
  const [pokemon, setPokemon] = useState(null);

  const fetchPokemon = async (name) => {
    const response = await fetch(`http://localhost:5252/Pokemon/${name}`);
    const data = await response.json();
    setPokemon(data);

  }

  return(
    <div className="App">
  <input type="text" placeholder="Ingrese nombre del Pokémon" onBlur={(e) => fetchPokemon(e.target.value)} />
  {pokemon && (
    <div className="pokemon-info">
      <h1>{pokemon.name}</h1>
      <div className="pokemon-types">
        {pokemon.types.map((type, index) => (
          <span key={index} className="type">{type.type.name}</span>
        ))}
      </div>
    </div>
  )}
</div>
  );
}


export default App;