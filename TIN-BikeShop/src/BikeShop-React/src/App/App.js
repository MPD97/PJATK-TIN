import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { getToken, removeUserSession, tokenExist } from '../Utils/Auth';
import LogIn from "../LogIn/LogIn";
import LogOut from "../LogOut/LogOut";
import Shop from "../Shop/Shop";
import Product from "../Products/Product";
import ProductDetails from "../Products/ProductDetails";
import { BrowserRouter as Router, Route, NavLink, HashRouter } from "react-router-dom";
import Language, { Currency, Roles } from "../Utils/Cookie";
import './App.css';


function App() {
  const [authLoading, setAuthLoading] = useState(true);
  const [authorized, setAuthorized] = useState(tokenExist());
  const [language, setLanguage] = useState(Language.getLanguage());
  const [currency, setCurrency] = useState(Currency.getCurrency());
  const [roles, setRoles] = useState(Roles.getRoles());
  const [error, setError] = useState(null);

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


  useEffect(() => {
    const token = getToken();
    axios.get('http://localhost:5000/api/Account/VerifyToken', { headers: { "Authorization": `Bearer ${token}` } })
      .then(response => {
        console.log(response);
        if (response.status === 200) {
          Roles.setRoles(response.data);
          setRoles(response.data.roles);
          setAuthLoading(false);
          setAuthorized(true);
        }
        else {
          removeUserSession();
          setAuthLoading(false);
        }
      }).catch(err => {
        if (err.response) {
          if (err.response.status >= 500) {
            console.debug("Server internal error.");
            setError("")
          }
          else if (err.response.status === 401) {
            console.debug("Token is not valid.");
            removeUserSession();
            setAuthLoading(false);
            setAuthorized(false);
          }
        }
        else {
          console.debug("Token is not valid.");
          removeUserSession();
          setAuthLoading(false);
          setAuthorized(false);
        }
      });
  }, []);

  if (authLoading) {
    return <div className="content" > Trwa logowanie... </div>
  }

  return (
    <HashRouter>
      <div className="App">
        <header className="App-header">
          <div className="Header-Nav">
            <NavLink to="/" className="Header-Nav__Link">
              {language === 'PL' ? 'Sklep' : 'Shops'}
            </NavLink >
          </div>
          <div className="Header-Nav">
            <div>
              {language === 'PL' ? 'Język:' : 'Language:'}
            </div>
            <div className="Header-Currency__Container">
              <div className={`Header-Nav__Link-Language ${language === "PL" ? 'active' : ''}`} onClick={() => setLng('PL')}>
                Polski
            </div >
              <div className={`Header-Nav__Link-Language ${language === "EN" ? 'active' : ''}`} onClick={() => setLng('EN')}>
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
                <div className={`Header-Nav__Link-Language ${currency === "PLN" ? 'active' : ''}`} onClick={() => setCurr('PLN')}>
                  PLN
                </div >
                <div className={`Header-Nav__Link-Language ${currency === "USD" ? 'active' : ''}`} onClick={() => setCurr('USD')}>
                  USD
                </div >
                <div className={`Header-Nav__Link-Language ${currency === "EUR" ? 'active' : ''}`} onClick={() => setCurr('EUR')}>
                  EUR
                </div >
              </div>
            </div>
          </div>
          <div className="Header-Nav">
            {authorized == false ?
              <NavLink to="/LogIn" className="Header-Nav__Link">
                {language == 'PL' ? 'Logowanie' : 'Login'}
              </NavLink > :
              <NavLink to="/LogOut" className="Header-Nav__Link">
                {language == 'PL' ? 'Wyloguj' : 'LogOut'}
              </NavLink >}
          </div>
        </header>
        <div className="App-Content">
          <Route exact path="/" component={Shop} />
          <Route exact path="/LogIn" component={LogIn} />
          <Route exact path="/LogOut" component={LogOut} />
          <Route exact path="/Shop/:shopId/Product" component={Product} />
          <Route exact path="/Shop/:shopId/Product/:productId" component={ProductDetails} />
        </div>
      </div>
    </HashRouter>
  );
}

export default App;
