import React, { useState, useEffect } from 'react';
import { bake_cookie, read_cookie, delete_cookie } from 'sfcookies';

const cookie_key = 'site-language';

const Language = {
    setLanguage: function (language) {
        console.debug('Setting Language cookie: '+ Language.getLanguage());
        bake_cookie(cookie_key, language);
    },
    getLanguage: function () {
        return read_cookie(cookie_key);
    }
}
export default Language;
