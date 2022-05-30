import { useEffect, useState } from 'react';
import './App.css';

function App() {

  const [address, setAddress] = useState('')
  const [data, setData] = useState('')

  const API_URL = 'http://localhost:5111/api/'

  async function getAddress() {
    let result = await fetch(API_URL + 'ipaddress')
    setAddress(await result.text())
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
        <p>Backend har ipaddress: {address}</p>
        <p>Statisk data från backend: {data}</p>
      <button onClick={() => refresh()}>Hämta data!</button>
    </div>
  );
}

export default App;
