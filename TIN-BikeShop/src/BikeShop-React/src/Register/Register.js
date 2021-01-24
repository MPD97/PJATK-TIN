import React, { useState } from 'react';
import axios from 'axios';
import { setUserSession } from '../Utils/Auth';
import { BrowserRouter as Router, Redirect } from "react-router-dom";
import Language from "../Utils/Cookie"
import './Register.css';

function Register() {
    const [language, setLanguage] = useState(Language.getLanguage());
    const [loading, setLoading] = useState(false);
    const username = useFormInput('');
    const password = useFormInput('');
    const repeatPassword = useFormInput('');
    const [error, setError] = useState(null);
    const [Registered, setRegistered] = useState(false);

    let loadingText = language === 'PL' ? 'Wczytywanie...' : 'Loading...';
    let submitText = language === 'PL' ? 'Rejestracja' : 'Register';

    const handleRegister = () => {
        setError(null);
        setLoading(true);

        var FD = new FormData();
        FD.append('UserName', username.value);
        FD.append('Password', password.value);
        FD.append('RepeatPassword', repeatPassword.value);


        console.debug(FD);
        console.debug("UserName: " + username.value);
        console.debug("Password: " + password.value);
        console.debug("Repeat Password: " + repeatPassword.value);

        axios.post('http://localhost:5000/api/Account/Register', FD)
            .then(response => {
                setLoading(false);
                setUserSession(response.data.token, response.data.roles);
                setRegistered(true);
                window.location.reload();
                console.debug('Registered and logged in!');
            }).catch(err => {
                setLoading(false);
                console.error(err);
                if (err.response) {
                    if (err.status >= 500) {
                        if (language === 'PL')
                            setError("Wystąpił błąd serwera.");
                        else
                            setError("Internal server error.");
                        console.error(err.response.data.message);
                    }
                    else {
                        if (language === 'PL')
                            setError("Nieprawidłowe dane rejestracji.")
                        else
                            setError("Invalid register attempt.")
                    };
                }
                else {
                    if (language === 'PL')
                        setError("Nieprawidłowe dane rejestracji.")
                    else
                        setError("Invalid register attempt.")
                }
            });
    }


    return (
        <>
            { Registered === false ?
                <div className="LogIn">
                    <div className="LogIn-Container-Register">
                        <div className="LogIn-Header">
                            <h1>
                                {language === 'PL' ? 'Rejestracja' : 'Register'}
                            </h1>
                            <hr />
                        </div>
                        <div className="LogIn-Form">
                            <div className="LogIn-Form__Element-Container">
                                <label htmlFor="UserName">
                                    {language === 'PL' ? 'Nazwa Użytkownika:' : 'User Name:'}
                                </label>
                                <input type="text" name="UserName" {...username} required />
                            </div>
                            <div className="LogIn-Form__Element-Container">
                                <label htmlFor="Password">
                                    {language === 'PL' ? 'Hasło: ' : 'Password:'}
                                </label>
                                <input type="password" name="Password" {...password} required />
                            </div>
                            <div className="LogIn-Form__Element-Container">
                                <label htmlFor="RepeatPassword">
                                    {language === 'PL' ? 'Powtórz Hasło: ' : 'Repeat Password:'}
                                </label>
                                <input type="password" name="RepeatPassword" {...repeatPassword} required />
                            </div>
                            <div>
                                <div className="LogIn-Red">{error && <> {error} </>}</div>
                            </div>
                            <div className="LogIn-Form__Element-Container-Submit">
                                <input type="button" value={loading ? loadingText : submitText} onClick={handleRegister} disabled={loading} />
                            </div>
                        </div>

                    </div>
                </div>
                : <Redirect to="/" />
            }
        </>
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
export default Register;
