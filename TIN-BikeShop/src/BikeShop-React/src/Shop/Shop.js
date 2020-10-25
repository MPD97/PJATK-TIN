import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Switch, Route, NavLink, HashRouter, Link, useRouteMatch, useParams } from "react-router-dom";

import './Shop.css';

function Shop() {
  const [loading, setLoading] = useState(false);
  const [shops, setShops] = useState(false);

  useEffect(() => {
    axios.get('http://localhost:5000/api/Shop').then(response => {
      console.debug(response.data);
      setShops(response.data);
      setLoading(true);
    }).catch(error => {
      console.error(error);
      setLoading(false);
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
              Pokaż Produkty
            </NavLink>
          </HashRouter>
        </div>
      </div>
    );
  }


  return (
    <div className="Shop">
      <div className="Shop-Container">
        {loading && <> {shops.map((shop, i) => renderShop(shop))}  </>}
      </div>
    </div>
  );
}

export default Shop;
