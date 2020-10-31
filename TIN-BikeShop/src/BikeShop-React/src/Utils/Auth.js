import Language, { Currency, Roles } from "./Cookie";

// return the token from the session storage
export const getToken = () => {
    return sessionStorage.getItem('token') || null;
}
export const tokenExist = () => {
    if (sessionStorage.getItem('token'))
        return true;
    return false;
}
// remove the token and user from the session storage
export const removeUserSession = () => {
    sessionStorage.removeItem('token');
    Roles.setRoles(null);
}

// set the token and user from the session storage
export const setUserSession = (token, roles) => {
    sessionStorage.setItem('token', token);
    Roles.setRoles(roles);
}