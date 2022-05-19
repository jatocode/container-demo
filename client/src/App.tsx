import React, { useEffect, useState } from 'react';
import './App.css';

function App() {

  const [fryken, setFryken] = useState('')
  const [gapern, setGapern] = useState('')

  async function getFryken() {
    let result = await fetch('http://localhost:5111/fryken')
    let data = await result.json()
    setFryken(data)
  }

  async function getGapern() {
    let result = await fetch('http://localhost:5111/gapern')
    setGapern(await result.text())
  }  

  useEffect(() => {
    getFryken()
    getGapern()
  },[])

  return (
    <div className="App">
      <h1>Testklient</h1>
      <p>Sjön heter {fryken}</p>
      <p>Nej, sjön heter {gapern}</p>
      <button onClick={() => getFryken()}>Fryken!</button>
    </div>
  );
}

export default App;
