import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, Switch, Route, NavLink, HashRouter, Link, useRouteMatch, useParams } from "react-router-dom";
import Language, { Currency } from "../Utils/Cookie"
import "./ProductDetails.css"

function ProductDetails() {
    let { shopId } = useParams();
    let { productId } = useParams();

    const [currency, setCurrency] = useState(Currency.getCurrency());
    const [language, setLanguage] = useState(Language.getLanguage());
    const [loading, setLoading] = useState(false);
    const [product, setProduct] = useState(false);
    let loadingText = language === 'PL' ? 'Wczytywanie...' : 'Loading...';
    useEffect(() => {
        axios.defaults.headers.common['language'] = language
        axios.defaults.headers.common['currency'] = currency;
        console.log(productId);
        axios.get(`http://localhost:5000/api/Shop/${shopId}/Product/${productId}`).then(response => {
            console.debug(response.data);
            setProduct(response.data);
            setLoading(true);
        }).catch(error => {
            console.error(error);
            setLoading(false);
        });
    }, []);
    function renderProductDetails(product) {
        return (
            <div className="Product-Element-Details" key={`product-${product.productId}`}>
                <div className="Product-Element-Details__Inline">
                    <div className="Product-Element__Image-Container">
                        <img src={require('../../public/' + product.photoPath)} alt="Product Image" />
                    </div>
                    <div className="Product-Element-Details__Inline-Center"> 
                        <div className="Product-Element-Details__Name">
                            {product.name}
                        </div>
                        <div className="Product-Element-Details__Details-Description">
                            <small><i>{product.description}</i></small>
                        </div>
                    </div>
                </div>
                <div className="Product-Element-Details__Details-Amount">
                    {language == 'PL' ? <> Dostępne: <div className="green" >{product.amount}</div> sztuk</> : <> Available: <div className="green" >{product.amount}</div>  pieces</>}
                </div>
                <div className="Product-Element-Details__Details-Price">
                    {language == 'PL' ? <> Cena: <div className="red" >{product.price}</div>  {currency}</> : <> Price: <div className="red" >{product.price}</div>  {currency}</>}
                </div>
               
            </div>);
    }

    return (
        <div className="Shop">
            <div className="Shop-Container">
                {loading == true ? renderProductDetails(product) : loadingText}
            </div>
        </div>
    );
}
export default ProductDetails;
