import React from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import DUsers from './components/DUsers';

function App() {
  return (
    <Provider store={store}> 
<DUsers></DUsers>
    </Provider>
  );
}

export default App;
