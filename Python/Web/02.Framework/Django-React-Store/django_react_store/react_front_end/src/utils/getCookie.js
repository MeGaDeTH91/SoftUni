const getCookie = (name) => {
    var cookieValue  = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return cookieValue ? cookieValue[2] : null;
}

export default getCookie;