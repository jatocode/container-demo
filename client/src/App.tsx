import React, { Suspense, useEffect, useState } from 'react';
import './App.css';

function App() {

  const [address, setAddress] = useState('')
  const [data, setData] = useState('')

  const API_URL = 'http://localhost:5111/api/'

  async function getAddress() {
    let result = await fetch(API_URL + 'ipaddress')
    let data = await result.json()
    setAddress(data)
  }

  async function getData() {
    let result = await fetch(API_URL + 'data')
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
      <Suspense fallback={<div>Loading ...</div>}>
        <p>Backend har ipaddress: {address}</p>
      </Suspense>
      <Suspense fallback={<p>Waiting...</p>}>
        <p>Statisk data från backend: {data}</p>
      </Suspense>
      <button onClick={() => refresh()}>Hämta data!</button>
    </div>
  );
}

export default App;
