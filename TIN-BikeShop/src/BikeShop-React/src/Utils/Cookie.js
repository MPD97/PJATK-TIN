import { bake_cookie, read_cookie } from 'sfcookies';

const cookie_key_language = 'site-language';
const cookie_key_currency = 'site-currency';
const cookie_key_roles = 'site-roles';


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
const Roles = {
    setCurrency: function (roles) {
        console.debug('Setting Roles cookie: ' + roles);
        bake_cookie(cookie_key_roles, roles);
    },
    getCurrency: function () {
        return read_cookie(cookie_key_roles);
    }
}
export default Language;
export { Currency, Roles };
