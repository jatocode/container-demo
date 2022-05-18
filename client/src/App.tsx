import React, { useEffect, useState } from 'react';
import './App.css';

function App() {

  const [fryken, setFryken] = useState('')
  const [gapern, setGapern] = useState('')

  useEffect(() => {
    console.log('hey 1')
    async function getFryken() {
        let result = await fetch('http://localhost:5111/fryken')
        let data = await result.json()
        setFryken(data)
    }
    getFryken()
  },[])

  useEffect(() => {
    console.log('hey 2')

    async function getGapern() {
        let result = await fetch('http://localhost:5111/gapern')
        setGapern(await result.text())
    }  
    getGapern()
  },[])

  return (
    <div className="App">
      <h1>Testklient</h1>
      <p>Sjön heter {fryken}</p>
      <p>Nej, sjön heter {gapern}</p>
    </div>
  );
}

export default App;
