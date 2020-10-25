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

  function setLng(lang) {
    Language.setLanguage(lang);
    setLanguage(Language.getLanguage());
    window.location.reload();
  }

  return (
    <HashRouter>
      <div className="App">
        <header className="App-header">
          <div className="Header-Nav">
            <NavLink to="/" className="Header-Nav__Link">
              {language == 'PL' ? 'Nasze Sklepy' : 'Our Shops'}
            </NavLink >
          </div>
          <div className="Header-Nav">
            <div  className="Header-Nav__Link-Language" onClick={() => setLng('PL')}>
              Polski
            </div >
            <div  className="Header-Nav__Link-Language" onClick={() => setLng('EN')}>
              English
            </div >
          </div>
          <div className="Header-Nav">
            <NavLink to="/LogIn" className="Header-Nav__Link">
              {language == 'PL' ? 'Logowanie' : 'Login'}
            </NavLink >
            <NavLink to="/LogOut" className="Header-Nav__Link">
              {language == 'PL' ? 'Wyloguj' : 'LogOut'}
            </NavLink >
          </div>
        </header>
        <div className="App-Content">
          <Route exact path="/" component={Shop} lang={language}/>
          <Route path="/LogIn" component={LogIn} />
          <Route path="/LogOut" component={LogOut} />
          <Route path="/Shop/:shopId/Product" component={Product} lang={language}/>
        </div>
      </div>
    </HashRouter>
  );
}

export default App;
