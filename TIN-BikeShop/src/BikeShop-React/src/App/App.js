import React, { useState, useEffect } from 'react';
import './App.css';
import LogIn from "../LogIn/LogIn";
import LogOut from "../LogOut/LogOut";
import Shop from "../Shop/Shop";
import Product from "../Products/Product";
import { BrowserRouter as Router, Switch, Route, NavLink, HashRouter, Link, useRouteMatch, useParams } from "react-router-dom";
import Language from "../Utils/Language"

function App() {
  const [language, setLanguage] = useState(Language.getLanguage());
  
  return (
    <HashRouter>
      <div className="App">
        <header className="App-header">
          <div className="Header-Nav">
            <NavLink to="/" className="Header-Nav__Link">
              {language == 'EN' ? 'Nasze Sklepy' : 'Our Shops'}
            </NavLink >
          </div>
          <div className="Header-Nav">
            <div className="Header-Nav__Link-Language" onClick={() => { Language.setLanguage('PL'); setLanguage(Language.getLanguage()) }}>
              Polski
            </div >
            <div className="Header-Nav__Link-Language" onClick={() => { Language.setLanguage('EN'); setLanguage(Language.getLanguage()) }}>
              English
            </div >
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
          <Route path="/Shop/:shopId/Product" component={Product} />
        </div>
      </div>
    </HashRouter>
  );
}

export default App;
