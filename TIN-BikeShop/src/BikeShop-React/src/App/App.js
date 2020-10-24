import React from 'react';
import './App.css';
import LogIn from "../LogIn/LogIn";
import LogOut from "../LogOut/LogOut";
import Shop from "../Shop/Shop";
import { Route, NavLink, HashRouter } from "react-router-dom";

function App() {
  return (
    <HashRouter>
      <div className="App">
        <header className="App-header">
          <div className="Header-Nav">
            <NavLink to="/" className="Header-Nav__Link">
              Sklep Rowerowy
            </NavLink >
          </div>
          <div className="Header-Nav">
            <NavLink to="/LogIn" className="Header-Nav__Link">
              Logowanie
            </NavLink >
            <NavLink to="/LogOut" className="Header-Nav__Link">
              Wyloguj
            </NavLink >
          </div>
        </header>
        <div className="App-Content">
          <Route exact path="/" component={Shop} />
          <Route path="/LogIn" component={LogIn} />
          <Route path="/LogOut" component={LogOut} />
        </div>
      </div>
    </HashRouter>
  );
}

export default App;
