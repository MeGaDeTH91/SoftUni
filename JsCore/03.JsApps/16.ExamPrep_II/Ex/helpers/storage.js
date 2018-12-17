const storage = function () {
    const appKey = 'kid_S1GMWTfeN';
    const appSecret = '73888b95bbef473c8321596e6ade92a5';
    const masterSecret = '6b78edd90bba4cfebd71f321edc140f0';

    const saveData = function (key, value) {
        sessionStorage.setItem(appKey + key, JSON.stringify(value));
    };

    const getData = function (key) {
        return JSON.parse(sessionStorage.getItem(appKey + key));
    };

    const deleteData = function(key) {
        sessionStorage.removeItem(appKey + key);
    };

    const saveUser = function(data){
        saveData('userInfo', {
            id: data._id,
            username: data.username,
        });

        saveData('authToken', data._kmd.authtoken);
    };

    const deleteUser = function(){
        deleteData('authToken');
        deleteData('userInfo');
    };

    return {
        saveData,
        getData,
        deleteData,
        appKey,
        appSecret,
        masterSecret,
        saveUser,
        deleteUser
    };
}();