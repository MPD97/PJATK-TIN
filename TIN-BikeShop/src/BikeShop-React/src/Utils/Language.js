import React, { useState, useEffect } from 'react';
let LANGUAGE = 'PL';

const Language = {
    setLanguage: function (language) {
        console.debug('Set Language: '+ Language.getLanguage());
        LANGUAGE = language;
    },
    getLanguage: function () {
        return LANGUAGE;
    }
}
export default Language;
