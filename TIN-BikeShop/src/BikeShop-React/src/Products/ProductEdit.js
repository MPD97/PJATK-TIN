import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { BrowserRouter as Router, NavLink, HashRouter, useParams } from "react-router-dom";
import Language, { Currency, Roles } from "../Utils/Cookie"
import "./ProductEdit.css"

function ProductEdit() {
    let { shopId } = useParams();
    let { productId } = useParams();

    const [language, setLanguage] = useState(Language.getLanguage());
    const [roles, setRoles] = useState(Roles.getRoles());
    const [loaded, setLoading] = useState(false);
    const [product, setProduct] = useState(false);
    let loadingText = language === 'PL' ? 'Wczytywanie...' : 'Loading...';

    const name = useFormInput('');
    const description = useFormInput('');
    const pricePLN = useFormInput('');
    const priceUSD = useFormInput('');
    const priceEUR = useFormInput('');

    useEffect(() => {
        axios.defaults.headers.common['language'] = language
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
        return (<>
            { loaded === true ? <div className="Product-Element-Details" key={`product-${product.productId}`}>
                <div className="Product-Element-Details__Inline">
                    <div className="Product-Element__Image-Container">
                        <img src={require('../../public/' + product.photoPath)} alt="Product Image" />
                    </div>
                    <div className="Product-Element-Details__Inline-Center">
                        <div className="Product-Element-Details__Name">
                            <label htmlFor="Name">
                                {language === 'PL' ? 'Nazwa:' : 'Name:'}
                            </label>
                        </div>

                        <input type="text" name="Name" {...name} required />
                        <div className="Product-Element-Details__Details-Description">
                            <div className="Product-Element-Details__Name">
                                <label htmlFor="Description">
                                    {language === 'PL' ? 'Opis:' : 'Details:'}
                                </label>
                            </div>
                            <textarea type="text" name="Description"  {...description} required />
                        </div>
                    </div>
                </div>
                <div className="Product-Element-Details__Details-Amount">
                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena PLN:' : 'Price PLN:'}
                        </label>
                    </div>
                    <input type="number" name="Description" min="0" step="any" {...pricePLN} required />

                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena USD:' : 'Price USD:'}
                        </label>
                    </div>
                    <input type="number" name="Description" min="0" step="any" {...priceUSD} required />

                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena EUR:' : 'Price EUR:'}
                        </label>
                    </div>
                    <input type="number" name="Description" min="0" step="any"{...priceEUR} required />

                </div>
                <div className="Product-Element-Details__Details-Price">
                </div>
            </div > : <></>}
        </>);
    }

    return (
        <div className="Shop">
            <div className="Shop-Container">
                {loaded === true ? renderProductDetails(product) : loadingText}
            </div>
        </div>
    );
}
const useFormInput = initialValue => {
    const [value, setValue] = useState(initialValue);

    const handleChange = e => {
        setValue(e.target.value);
    }
    return {
        value,
        onChange: handleChange
    }
}
export default ProductEdit;
