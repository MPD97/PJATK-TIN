import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { getToken, removeUserSession, tokenExist } from '../Utils/Auth';
import { BrowserRouter as Router, Redirect } from "react-router-dom";
import Language from "../Utils/Cookie"
import './LogOut.css';

function LogOut() {
  const [loading, setLoading] = useState(true);
  const [authorized, setAuthorized] = useState(tokenExist());
  const [error, setError] = useState(null);
  const [language, setLanguage] = useState(Language.getLanguage());

  let loadingText = language === 'PL' ? 'Trwa wylogowywanie...' : 'LogOut in progress...';

  useEffect(() => {
    const token = getToken();
    axios.get('http://localhost:5000/api/Account/LogOut', { headers: { "Authorization": `Bearer ${token}` } })
      .then(response => {
        removeUserSession();
        setAuthorized(false);
        setLoading(false);
        window.location.reload();
        console.debug('Logged Out.');
      }).catch(err => {
        removeUserSession();
        setAuthorized(false);
        setLoading(false);
        window.location.reload();
      });
  }, []);
  return (
    <>
      {loading === true ? <>{loadingText}</> : <Redirect to="/" />}
    </>
  );
}

export default LogOut;
