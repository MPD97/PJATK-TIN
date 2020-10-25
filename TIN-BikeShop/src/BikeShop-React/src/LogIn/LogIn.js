import React, { useState, useEffect } from 'react';
import Language from "../Utils/Cookie"

import './LogIn.css';

function LogIn() {
    const [language, setLanguage] = useState(Language.getLanguage());

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
                        <input type="text" name="UserName" required />
                    </div>
                    <div className="LogIn-Form__Element-Container">
                        <label htmlFor="Password">                            
                            {language == 'PL' ? 'Hasło: ' : 'Password:'}
                        </label>
                        <input type="password" name="Password" required />
                    </div>
                    <div className="LogIn-Form__Element-Container-Submit">
                        <button type="submit">
                            {language == 'PL' ? 'Zaloguj ' : 'Login'}
                        </button>
                    </div>
                </div>

            </div>
        </div>
    );
}

export default LogIn;
