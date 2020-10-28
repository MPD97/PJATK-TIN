import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, HashRouter, NavLink } from "react-router-dom";
import Language, { Currency } from "../Utils/Cookie"
import './Shop.css';

function Shop() {
  const [currency, setCurrency] = useState(Currency.getCurrency());
  const [language, setLanguage] = useState(Language.getLanguage());
  const [loaded, setLoading] = useState(false);
  const [shops, setShops] = useState(false);
  const [error, setError] = useState(false);


  useEffect(() => {
    axios.defaults.headers.common['language'] = language;
    axios.defaults.headers.common['currency'] = currency;
    axios.get('http://localhost:5000/api/Shop').then(response => {
      console.debug(response.data);
      setShops(response.data);
      setLoading(true);
    }).catch(error => {
      console.error(error);
      setError(true);
      setLoading(true);
    });
  }, []);

  function renderShop(shop) {
    return (
      <div className="Shop-Element" key={shop.shopId}>
        <div className="Shop-Element__Image-Container">
          <img src={require('../../public/' + shop.photoPath)} alt="Shop Image" />
        </div>
        <div className="Shop-Element__Name">
          {shop.name}
        </div>
        <div className="Shop-Element__Details">
          <small><i>{shop.city} ul.{shop.street} {shop.streetNumber}</i></small>
        </div>
        <div className="Shop-Element__Enter">
          <HashRouter>
            <NavLink to={`/Shop/${shop.shopId}/Product`} className="button">
              {language === 'PL' ? 'Pokaż produkty' : 'Show Products'}
            </NavLink>
          </HashRouter>
        </div>
      </div>
    );
  }


  return (
    <>
      {loaded && error ? <p>{language === 'PL' ? 'Wystąpił błąd połączenia z serwerem.' : 'Server is not responding.'}</p> :
        <div className="Shop">
          <div className="Shop-Container">
            {loaded && <> {shops.map((shop, i) => renderShop(shop))}  </>}
          </div>
        </div>}
    </>);
}

export default Shop;
