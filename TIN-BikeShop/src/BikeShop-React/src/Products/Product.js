import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Switch, Route, NavLink, HashRouter, Link, useRouteMatch, useParams } from "react-router-dom";
import Language, { Currency } from "../Utils/Cookie"
import "./Product.css"

function Product() {
    let { shopId } = useParams();

    const [currency, setCurrency] = useState(Currency.getCurrency());
    const [language, setLanguage] = useState(Language.getLanguage());
    const [loading, setLoading] = useState(false);
    const [products, setProducts] = useState(false);

    useEffect(() => {
        console.log('Currency: ' + currency);
        console.log('Language: ' + language);
        axios.defaults.headers.common['language'] = language
        axios.defaults.headers.common['currency'] = currency;
        axios.get(`http://localhost:5000/api/Shop/${shopId}/Product`).then(response => {
            console.debug(response.data);
            setProducts(response.data);
            setLoading(true);
        }).catch(error => {
            console.error(error);
            setLoading(false);
        });
    }, []);

    function renderProduct(product) {
        return (
            <div className="Product-Element" key={`product-${product.productId}`}>
                <div className="Product-Element__Image-Container">
                    <img src={require('../../public/' + product.photoPath)} alt="Product Image" />
                </div>
                <div className="Product-Element__Name">
                    {product.name}
                </div>
                <div className="Product-Element__Details-Description">
                    <small><i>{product.description}</i></small>
                </div>
                <div className="Product-Element__Details-Price">
                    {language == 'PL' ? <> Cena: <div className="red" >{product.price}</div>  {currency}</> : <> Price: <div className="red" >{product.price}</div>  {currency}</>}
                   
                </div>
                <div className="Product-Element__Enter">
                    <HashRouter>
                        <NavLink to={`/Shop/${shopId}/Product/${product.productId}`} className="button">
                            {language == 'PL' ? 'Szczegóły' : 'Details'}
                        </NavLink>
                    </HashRouter>
                </div>
            </div>
        );
    }

    return (
        <div className="Shop">
            <div className="Shop-Container">
                {loading && <> {products.map((product, i) => renderProduct(product))}  </>}
            </div>
        </div>
    );
}
export default Product;
