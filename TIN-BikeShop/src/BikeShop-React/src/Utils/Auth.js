
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
}

// set the token and user from the session storage
export const setUserSession = (token) => {
    sessionStorage.setItem('token', token);
}