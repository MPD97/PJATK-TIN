import React, { useState, useEffect } from 'react';
import './App.css';
import LogIn from "../LogIn/LogIn";
import LogOut from "../LogOut/LogOut";
import Shop from "../Shop/Shop";
import Product from "../Products/Product";
import { BrowserRouter as Router, Switch, Route, NavLink, HashRouter, Link, useRouteMatch, useParams } from "react-router-dom";
import Language, { Currency } from "../Utils/Cookie";


function App() {
  const [language, setLanguage] = useState(Language.getLanguage());
  const [currency, setCurrency] = useState(Currency.getCurrency());

  function setLng(lang) {
    Language.setLanguage(lang);
    setLanguage(Language.getLanguage());
    window.location.reload();
  }
  function setCurr(curr) {
    Currency.setCurrency(curr);
    setCurrency(Currency.getCurrency());
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
            <div>
              {language == 'PL' ? 'Język:' : 'Language:'}
            </div>
            <div className="Header-Currency__Container">
              <div className={`Header-Nav__Link-Language ${language == "PL" ? 'active' : ''}`} onClick={() => setLng('PL')}>
                Polski
            </div >
              <div className={`Header-Nav__Link-Language ${language == "EN" ? 'active' : ''}`} onClick={() => setLng('EN')}>
                English
            </div >
            </div>
          </div>
          <div className="Header-Nav">
            <div className="Header-Currency__Container-Label">
              <div>
                {language == 'PL' ? 'Waluta:' : 'Currency:'}
              </div>
              <div className="Header-Currency__Container">
                <div className={`Header-Nav__Link-Language ${currency == "PLN" ? 'active' : ''}`} onClick={() => setCurr('PLN')}>
                  PLN
                </div >
                <div className={`Header-Nav__Link-Language ${currency == "USD" ? 'active' : ''}`} onClick={() => setCurr('USD')}>
                  USD
                </div >
                <div className={`Header-Nav__Link-Language ${currency == "EUR" ? 'active' : ''}`} onClick={() => setCurr('EUR')}>
                  EUR
                </div >
              </div>
            </div>
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
