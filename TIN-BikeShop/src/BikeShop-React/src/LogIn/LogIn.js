import React from 'react';
import './LogIn.css';

function LogIn() {
    return (
        <div className="LogIn">
            <div className="LogIn-Container">
                <div className="LogIn-Header">
                    <h1>Logowanie</h1>
                    <hr />
                </div>
                <div className="LogIn-Form">
                    <div className="LogIn-Form__Element-Container">
                        <label htmlFor="UserName">Nazwa Użytkownika: </label>
                        <input type="text" name="UserName" required />
                    </div>
                    <div className="LogIn-Form__Element-Container">
                        <label htmlFor="Password">Hasło:</label>
                        <input type="password" name="Password" required />
                    </div>
                    <div className="LogIn-Form__Element-Container-Submit">
                        <button type="submit">Zaloguj</button>
                    </div>
                </div>

            </div>
        </div>
    );
}

export default LogIn;
