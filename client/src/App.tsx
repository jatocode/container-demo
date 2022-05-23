import React, { useEffect, useState } from 'react';
import './App.css';

function App() {

  const [address, setAddress] = useState('')
  const [data, setData] = useState('')

  async function getAddress() {
    let result = await fetch('http://localhost:5111/ipaddress')
    let data = await result.json()
    setAddress(data)
  }

  async function getData() {
    let result = await fetch('http://localhost:5111/data')
    setData(await result.text())
  }  

  useEffect(() => {
    getAddress()
    getData()
  },[])

  function refresh() {
      getAddress();
      getData();
  }

  return (
    <div className="App">
      <h1>Testklient</h1>
      <p>Backend har ipaddress: {address}</p>
      <p>Statisk data från backend: {data}</p>
      <button onClick={() => refresh()}>Hämta data!</button>
    </div>
  );
}

export default App;
