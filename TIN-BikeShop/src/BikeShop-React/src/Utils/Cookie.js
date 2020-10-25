import React, { useState, useEffect } from 'react';
import { bake_cookie, read_cookie, delete_cookie } from 'sfcookies';

const cookie_key_language = 'site-language';
const cookie_key_currency = 'site-currency';


const Language = {
    setLanguage: function (language) {
        console.debug('Setting Language cookie: ' + language);
        bake_cookie(cookie_key_language, language);
    },
    getLanguage: function () {
        return read_cookie(cookie_key_language);
    }
}
const Currency = {
    setCurrency: function (currency) {
        console.debug('Setting Currency cookie: ' + currency);
        bake_cookie(cookie_key_currency, currency);
    },
    getCurrency: function () {
        return read_cookie(cookie_key_currency);
    }
}
export default Language;
export { Currency };
