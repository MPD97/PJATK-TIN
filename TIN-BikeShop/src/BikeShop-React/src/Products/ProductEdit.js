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


    const [nameValidation, setNameValidation] = useState(null);
    const [descriptionValidation, setDescriptionValidation] = useState(null);
    const [pricePLNValidation, setPricePLNValidation] = useState(null);
    const [priceUSDValidation, setPriceUSDValidation] = useState(null);
    const [priceEURValidation, setPriceEURValidation] = useState(null);

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
            alert("Acces denied.")
            console.error(error);
            setLoading(false);
        });
    }, []);

    function editProduct() {
        var FD = new FormData();
        FD.append('name', name.value);
        FD.append('description', description.value);
        FD.append('pricePLN', pricePLN.value);
        FD.append('priceUSD', priceUSD.value);
        FD.append('priceEUR', priceEUR.value);
        console.debug(FD);

        const validate = (key, value) => {
            let valid = true;
            switch (key) {
                case 'name': {
                    if (value.length < 10) {
                        setNameValidation(language === 'PL' ? 'Nazwa produktu musi mieć co najmniej 10 znaków' : 'Product Name must have at least 10 characters')
                        return false;

                    } else if (value.length > 1000) {
                        setNameValidation(language === 'PL' ? 'Nazwa produktu musi mieć maksymalnie 1000 znaków' : 'Product Name must have not more than 1000 characters')
                        return false;
                    } else {
                        setNameValidation(null);
                    }
                }
                case 'description': {
                    if (value.length < 10) {
                        setDescriptionValidation(language === 'PL' ? 'Opis produktu musi mieć co najmniej 10 znaków' : 'Product details must have at least 10 characters')
                        return false;

                    } else if (value.length > 1000) {
                        setDescriptionValidation(language === 'PL' ? 'Opis produktu musi mieć maksymalnie 1000 znaków' : 'Product details must have not more than 1000 characters')
                        return false;
                    } else {
                        setDescriptionValidation(null);
                    }
                }
                case 'pricePLN': {
                    if (value <= 0.01) {
                        setPricePLNValidation(language === 'PL' ? 'minimalna wartość to 0.01' : 'Minimum value is 0.01')
                        return false;

                    } else if (value >= 9999) {
                        setPricePLNValidation(language === 'PL' ? 'maksymalna watość to 9999' : 'Maximum value is 9999')
                        return false;
                    } else {
                        setPricePLNValidation(null);
                    }
                }
                case 'priceEUR': {
                    if (value <= 0.01) {
                        setPriceEURValidation(language === 'PL' ? 'minimalna wartość to 0.01' : 'Minimum value is 0.01')
                        return false;

                    } else if (value >= 9999) {
                        setPriceEURValidation(language === 'PL' ? 'maksymalna watość to 9999' : 'Maximum value is 9999')
                        return false;
                    } else {
                        setPriceEURValidation(null);
                    }
                }
                case 'priceUSD': {
                    if (value <= 0.01) {
                        setPriceUSDValidation(language === 'PL' ? 'minimalna wartość to 0.01' : 'Minimum value is 0.01')
                        return false;

                    } else if (value >= 9999) {
                        setPriceUSDValidation(language === 'PL' ? 'maksymalna watość to 9999' : 'Maximum value is 9999')
                        return false;
                    } else {
                        setPriceUSDValidation(null);
                    }
                }
            }
            return valid;
        }

        let success = true;
        for (var pair of FD.entries()) {
            let validationResult = validate(pair[0], pair[1]);
            console.log(pair[0] + ': ' + pair[1] + ', Result: ' + validationResult);
            if(validationResult){
                success = false;
            }
        }
        if(success){
            //send requ
        }

    }


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
                        <input type="text" name="Name" {...name} placeholder={product.name} required />
                        <span className="red">{nameValidation !== null ? nameValidation : ''}</span>

                        <div className="Product-Element-Details__Details-Description">
                            <div className="Product-Element-Details__Name">
                                <label htmlFor="Description">
                                    {language === 'PL' ? 'Opis:' : 'Details:'}
                                </label>
                            </div>
                            <textarea type="text" name="Description"  {...description} placeholder={product.description} required />
                            <span className="red">{descriptionValidation !== null ? descriptionValidation : ''}</span>
                        </div>
                    </div>
                </div>
                <div className="Product-Element-Details__Details-Amount">
                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena PLN:' : 'Price PLN:'}
                        </label>
                    </div>
                    <input type="number" name="PricePLN" min="0" step="any" {...pricePLN} placeholder={product.pricePLN} required /><br/>
                    <span className="red">{pricePLNValidation !== null ? pricePLNValidation : ''}</span>

                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena USD:' : 'Price USD:'}
                        </label>
                    </div>
                    <input type="number" name="PriceUSD" min="0" step="any" {...priceUSD} placeholder={product.priceUSD} required /><br/>
                    <span className="red">{priceUSDValidation !== null ? priceUSDValidation : ''}</span>

                    <div className="Product-Element-Details__Name">
                        <label htmlFor="Description">
                            {language === 'PL' ? 'Cena EUR:' : 'Price EUR:'}
                        </label>
                    </div>
                    <input type="number" name="PriceEUR" min="0" step="any"{...priceEUR} placeholder={product.priceEUR} required /><br/>
                    <span className="red">{priceEURValidation !== null ? priceEURValidation : ''}</span>
                    <br />
                    <input type="button" className="Product-Edit button" value={language === 'PL' ? 'Zatwierdź' : 'Accept changes'} onClick={editProduct} />
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

export default ProductEdit;
