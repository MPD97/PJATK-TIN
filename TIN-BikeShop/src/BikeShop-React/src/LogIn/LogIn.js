import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { getToken, removeUserSession, setUserSession } from '../Utils/Auth';
import Language from "../Utils/Cookie"
import './LogIn.css';

function LogIn() {
    const [language, setLanguage] = useState(Language.getLanguage());

    const [loading, setLoading] = useState(false);
    const username = useFormInput('');
    const password = useFormInput('');
    const [error, setError] = useState(null);
    let loadingText = language === 'PL' ? 'Wczytywanie...' : 'Loading...';
    let submitText = language === 'PL' ? 'Zaloguj' : 'Login';

    const handleLogin = () => {
        setError(null);
        setLoading(true);

        var FD = new FormData();
        FD.append('UserName', username.value);
        FD.append('Password', password.value);


        console.debug(FD);
        console.debug("UserName: " + username.value);
        console.debug("Password: " + password.value);

        axios.post('http://localhost:5000/api/Account/LogIn', FD)
            .then(response => {
                setLoading(false);
                setUserSession(response.data.token, response.data.user);
                console.debug('Logged In.');
            }).catch(error => {
                setLoading(false);
                console.error(error);
                if (error.status >= 500) {
                    if (language === 'PL')
                        setError("Wystąpił błąd serwera.");
                    else
                        setError("Internal server error.");
                    console.error(error.response.data.message);
                }
                else {
                    if (language === 'PL')
                        setError("Nieprawidłowe login, lub hasło.")
                    else
                        setError("Invalid login attempt.")
                };
            });
    }


    return (
        <div className="LogIn">
            <div className="LogIn-Container">
                <div className="LogIn-Header">
                    <h1>
                        {language == 'PL' ? 'Logowanie' : 'Login'}
                    </h1>
                    <hr />
                </div>
                <div className="LogIn-Form">
                    <div className="LogIn-Form__Element-Container">
                        <label htmlFor="UserName">
                            {language == 'PL' ? 'Nazwa Użytkownika:' : 'User Name:'}
                        </label>
                        <input type="text" name="UserName" {...username} required />
                    </div>
                    <div className="LogIn-Form__Element-Container">
                        <label htmlFor="Password">
                            {language == 'PL' ? 'Hasło: ' : 'Password:'}
                        </label>
                        <input type="password" name="Password" {...password} required />
                    </div>
                    <div>
                        <div className="LogIn-Red">{error && <> {error} </>}</div>
                    </div>
                    <div className="LogIn-Form__Element-Container-Submit">
                        <input type="button" value={loading ?  loadingText  :  submitText } onClick={handleLogin} disabled={loading} />
                    </div>
                </div>

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
export default LogIn;
