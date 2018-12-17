const userModel = (function () {
    var userUrl = `user/${storage.appKey}`;

    const login = function(username, password){
        var authString = btoa(`${username}:${password}`);
        var headers = { 
            Authorization: 'Basic ' + authString 
        };

        var data = { username, password };
        var url = userUrl + '/login';
        
        return requester.post(url, data, headers);
    };

    const logout = function(){
        var url = userUrl +  '/_logout';

        return requester.post(url);
    }

    const register = function(params){
        var data = {
            username: params.username,
            password: params.pass,
        }

        var authString = btoa(`${storage.appKey}:${storage.appSecret}`);
        var headers = { Authorization: 'Basic ' + authString};
        
        return requester.post(userUrl, data, headers);
    };

    const isAuthorized = function(){
        return !!storage.getData('authToken');
    };

    return {
        login,
        logout,
        register,
        isAuthorized
    }
}());